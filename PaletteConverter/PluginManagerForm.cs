using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using PalettePluginContracts;
using static PaletteConverter.Form1;
using ParserContracts;
using FormPluginsContracts;

namespace PaletteConverter
{
    public partial class PluginManagerForm : Form
    {
        public static List<IColorPalettePlugin> allPalettes = new();
        public static List<IProductParserPlugin> allParsers = new();
        public static List<IFormPlugin> FormPlugins = new();

        private static string pluginDir = "Plugins";
        private static string enabledPluginsFile = "config.ini";


        private static Dictionary<string, IColorPalettePlugin> pluginByName = new();

        private static Dictionary<string, IProductParserPlugin> parserByName = new();

        private static Dictionary<string, IFormPlugin> formPluginByName = new();

        private static HashSet<Guid> loadedPluginGuids = new();



        private Button buttonApply = new();
        private Button buttonCancel = new();

        public static HashSet<string> EnabledPluginNames { get; private set; } = new();
        public static event Action<List<IColorPalettePlugin>> PluginsLoaded;



        public static event Action<List<IProductParserPlugin>> ProductParsersLoaded;
        public List<IProductParserPlugin> GetProductParsers() => allParsers;
        private static Guid GetPluginGuid(object plugin)
        {
            try
            {
                var prop = plugin.GetType().GetProperty("PluginGuid");
                if (prop == null)
                {
                    Debug.WriteLine($"Свойство PluginGuid не найдено у типа {plugin.GetType().FullName}");
                    return Guid.Empty;
                }
                return (Guid)(prop.GetValue(plugin) ?? Guid.Empty);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка получения GUID из плагина: {ex.Message}");
                return Guid.Empty;
            }
        }

        public PluginManagerForm()
        {
            InitializeComponent();
            LoadPlugins();
            LoadEnabledPlugins();
            InitUI();
            checkedListBoxPlugins.SelectedIndex = 0; // Устанавливаем первый элемент как выбранный по умолчанию
        }

        public static void LoadPlugins()
        {
            if (!Directory.Exists(pluginDir))
                Directory.CreateDirectory(pluginDir);

            foreach (var file in Directory.GetFiles(pluginDir, "*.dll"))
            {
                try
                {
                    Debug.WriteLine($"Пробуем загрузить сборку: {file}");
                    var asm = Assembly.LoadFrom(file);

                    foreach (var type in asm.GetTypes())
                    {
                        try
                        {
                            Debug.WriteLine($"Найден тип: {type.FullName}");

                            if (!type.IsClass || type.IsAbstract)
                            {
                                Debug.WriteLine($"Пропущен абстрактный или не-класс тип: {type.FullName}");
                                continue;
                            }

                            // Вывод всех интерфейсов типа
                            var interfaces = type.GetInterfaces();
                            if (interfaces.Length == 0)
                            {
                                Debug.WriteLine($"  Интерфейсы: нет");
                            }
                            else
                            {
                                Debug.WriteLine("  Интерфейсы:");
                                foreach (var iface in interfaces)
                                {
                                    Debug.WriteLine($"    {iface.FullName}");
                                }
                            }

                            object? tempInstance = null;

                            // Проверка на IColorPalettePlugin
                            if (typeof(IColorPalettePlugin).IsAssignableFrom(type))
                            {
                                tempInstance = Activator.CreateInstance(type);
                                if (tempInstance is IColorPalettePlugin palettePlugin)
                                {
                                    var guid = GetPluginGuid(palettePlugin);
                                    if (loadedPluginGuids.Contains(guid))
                                        continue;

                                    allPalettes.Add(palettePlugin);
                                    pluginByName[palettePlugin.Name] = palettePlugin;
                                    loadedPluginGuids.Add(guid);

                                    //MessageBox.Show($"Загружен плагин палитры: {palettePlugin.Name} (GUID: {guid})");
                                }
                            }
                            // Проверка на IProductParserPlugin
                            else if (typeof(IProductParserPlugin).IsAssignableFrom(type))
                            {
                                tempInstance = Activator.CreateInstance(type);
                                if (tempInstance is IProductParserPlugin parserPlugin)
                                {
                                    var guid = GetPluginGuid(parserPlugin);
                                    if (loadedPluginGuids.Contains(guid))
                                        continue;

                                    allParsers.Add(parserPlugin);
                                    // Теперь строка будет работать корректно:
                                    parserByName[parserPlugin.Name] = parserPlugin;
                                    //comboBox4.Items.Add(parserPlugin.PluginName);
                                    loadedPluginGuids.Add(guid);
                                    //MessageBox.Show(allParsers.Count().ToString());
                                    //MessageBox.Show($"Загружен плагин парсера: {parserPlugin.Name} (GUID: {guid})");
                                }
                            }
                            else if (typeof(IFormPlugin).IsAssignableFrom(type))
                            {
                                tempInstance = Activator.CreateInstance(type);
                                if (tempInstance is IFormPlugin formPlugin)
                                {
                                    var guid = GetPluginGuid(formPlugin);
                                    if (loadedPluginGuids.Contains(guid))
                                        continue;

                                    FormPlugins.Add(formPlugin);
                                    formPluginByName[formPlugin.Name] = formPlugin; // <-- добавляем в словарь
                                    loadedPluginGuids.Add(guid);

                                    //pluginByName[formPlugin.Name] = null; // для отображения в списке
                                }

                            }
                            else
                            {
                                Debug.WriteLine($"Тип {type.FullName} не реализует нужные интерфейсы.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при загрузке плагина {type.Name}:\n{ex.Message}");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки плагина из {file}:\n{ex.Message}");
                }
            }

            PluginsLoaded?.Invoke(allPalettes);
            ProductParsersLoaded?.Invoke(allParsers);
        }





        public void LoadEnabledPlugins()
        {
            EnabledPluginNames.Clear();

            if (File.Exists(enabledPluginsFile))
            {
                var lines = File.ReadAllLines(enabledPluginsFile);
                foreach (var line in lines)
                {
                    var trimmedLine = line.Trim();
                    if (trimmedLine.StartsWith("EnabledPlugins=", StringComparison.OrdinalIgnoreCase))
                    {
                        var pluginList = trimmedLine.Substring("EnabledPlugins=".Length);
                        var names = pluginList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        EnabledPluginNames = new HashSet<string>(names.Select(s => s.Trim()));
                    }

                }
            }
        }
        public static List<IColorPalettePlugin> GetEnabledPalettes()
        {
            return allPalettes
                .Where(p => EnabledPluginNames.Contains(p.Name))
                .ToList();
        }
        public static List<IProductParserPlugin> GetEnabledParsers()
        {
            return allParsers
                .Where(p => EnabledPluginNames.Contains(p.Name))
                .ToList();
        }
        public static List<IFormPlugin> GetEnabledFormPlugins()
        {
            return FormPlugins
                .Where(p => EnabledPluginNames.Contains(p.Name))
                .ToList();
        }


        private void InitUI()
        {
            if (allPalettes.Count == 0)
            {
                MessageBox.Show("Нет загруженных плагинов.");
                return;
            }

            foreach (var plugin in allPalettes)
            {
                var nameProp = plugin.GetType().GetProperty("Name");
                var pluginName = nameProp?.GetValue(plugin)?.ToString();
                if (!string.IsNullOrEmpty(pluginName))
                {
                    bool isChecked = EnabledPluginNames.Contains(pluginName);
                    checkedListBoxPlugins.Items.Add(pluginName, isChecked);
                }
            }
            foreach (var parser in allParsers)
            {
                var pluginName = parser.Name;
                if (!string.IsNullOrEmpty(pluginName))
                {
                    bool isChecked = EnabledPluginNames.Contains(pluginName);
                    checkedListBoxPlugins.Items.Add(pluginName, isChecked);
                }
            }
            foreach (var formPlugin in FormPlugins)
            {
                string pluginName = formPlugin.Name;
                if (!string.IsNullOrEmpty(pluginName))
                {
                    bool isChecked = EnabledPluginNames.Contains(pluginName);
                    checkedListBoxPlugins.Items.Add(pluginName, isChecked);
                }
            }

        }

        private void SaveEnabledPlugins()
        {
            var enabledPlugins = checkedListBoxPlugins.CheckedItems.Cast<string>().ToList();
            var lines = new List<string>
            {
                $"EnabledPlugins={string.Join(",", enabledPlugins)}"
            };

            // В будущем сюда можно добавить другие параметры, например:
            // lines.Add("RecentColors=#FF0000,#00FF00");

            File.WriteAllLines(enabledPluginsFile, lines);
        }


        private void checkedListBoxPlugins_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var pluginName = checkedListBoxPlugins.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                EnabledPluginNames.Add(pluginName);
            }
            else
            {
                EnabledPluginNames.Remove(pluginName);
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SaveEnabledPlugins(); // Сохраняем состояние при применении изменений
            MessageBox.Show("Состояние плагинов сохранено!");
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            LoadEnabledPlugins(); // Загружаем состояние плагинов при отмене
            InitUI();
            MessageBox.Show("Изменения отменены.");
        }

        private void checkedListBoxPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = checkedListBoxPlugins.SelectedIndex;
            if (selectedIndex < 0) return;

            string selectedPluginName = checkedListBoxPlugins.Items[selectedIndex].ToString();

            object plugin = null;



            // Сначала ищем в FormPlugins
            if (formPluginByName.TryGetValue(selectedPluginName, out var formPlugin))
            {
                plugin = formPlugin;
                Settings_button.Enabled = true;
                LastOperations.Enabled = false;
            }
            // Потом ищем в палитрах
            else if (pluginByName.TryGetValue(selectedPluginName, out var palettePlugin))
            {
                plugin = palettePlugin;
                Settings_button.Enabled = false;
                LastOperations.Enabled = true;
            }
            // Потом в парсерах
            else if (parserByName.TryGetValue(selectedPluginName, out var parserPlugin))
            {
                plugin = parserPlugin;
                Settings_button.Enabled = false;
                LastOperations.Enabled = true;
            }



            if (plugin != null)
            {
                var type = plugin.GetType();

                string author = type.GetProperty("Author")?.GetValue(plugin)?.ToString() ?? "Неизвестен";
                string description = type.GetProperty("Description")?.GetValue(plugin)?.ToString() ?? "Нет описания";
                string version = type.GetProperty("Version")?.GetValue(plugin)?.ToString() ?? "n/a";
                string createdAt = type.GetProperty("CreatedAt")?.GetValue(plugin)?.ToString() ?? "-";
                string updatedAt = type.GetProperty("LastUpdated")?.GetValue(plugin)?.ToString() ?? "-";
                string guid = type.GetProperty("PluginGuid")?.GetValue(plugin)?.ToString() ?? "-";

                string typeName = plugin is IColorPalettePlugin ? "Палитра" :
                                  plugin is IProductParserPlugin ? "Парсер" :
                                  plugin is IFormPlugin ? "Интерфейс" : type.Name.ToString();

                AuthorLabel.Text = author;
                DescBox.Text = description;
                VersionLabel.Text = version;
                GuidLabel.Text = guid;
                CreatedLabel.Text = createdAt;
                UpdatedLabel.Text = updatedAt;
                TypeLabel.Text = typeName;

                string PluginCurrent = type.GetProperty("Name")?.GetValue(plugin)?.ToString();

                if (Form1.pluginExecutionTimes.TryGetValue(selectedPluginName, out var execTimes))
                {
                    // Преобразуем очередь в список и форматируем
                    var timesText = string.Join(", ", execTimes.Select(t => $"{t}"));

                    LastOperations.Text = $"Время последних операций (мс):\r\n{timesText}";

                    if (Form1.pluginAverageTimes.TryGetValue(selectedPluginName, out var avg))
                    {
                        LastOperations.AppendText($"\r\nСреднее: {avg:F2} мс");
                    }
                }
                else
                {
                    LastOperations.Text = "Нет данных по времени выполнения.";
                }


            }
            else
            {
                MessageBox.Show("Плагин не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Settings_button_Click(object sender, EventArgs e)
        {
            int selectedIndex = checkedListBoxPlugins.SelectedIndex;
            if (selectedIndex < 0) return;

            string selectedPluginName = checkedListBoxPlugins.Items[selectedIndex].ToString();

            if (formPluginByName.TryGetValue(selectedPluginName, out var formPlugin))
            {
                // Вызов формы настроек плагина
                var settingsForm = formPlugin.GetSettingsForm();
                if (settingsForm != null)
                {
                    settingsForm.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("У этого плагина нет формы настроек.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Настройки доступны только для плагинов интерфейса.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
