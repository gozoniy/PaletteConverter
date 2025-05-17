using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using PalettePluginContracts;

namespace PaletteConverter
{
    public partial class PluginManagerForm : Form
    {
        private List<IColorPalettePlugin> allPlugins = new();
        private string pluginDir = "Plugins";
        private string enabledPluginsFile = "enabled_plugins.txt";


        private Dictionary<string, IColorPalettePlugin> pluginByName = new();

        private HashSet<Guid> loadedPluginGuids = new();



        private Button buttonApply = new();
        private Button buttonCancel = new();
        
        public HashSet<string> EnabledPluginNames { get; private set; } = new();
        public event Action<List<IColorPalettePlugin>> PluginsLoaded;

        public PluginManagerForm()
        {
            InitializeComponent();
            LoadPlugins();
            LoadEnabledPlugins();
            InitUI();
            checkedListBoxPlugins.SelectedIndex = 0; // Устанавливаем первый элемент как выбранный по умолчанию
        }

        private void LoadPlugins()
        {
            if (!Directory.Exists(pluginDir))
                Directory.CreateDirectory(pluginDir);

            foreach (var file in Directory.GetFiles(pluginDir, "*.dll"))
            {
                try
                {
                    var asm = Assembly.LoadFrom(file);

                    foreach (var type in asm.GetTypes())
                    {
                        try
                        {
                            var guidProp = type.GetProperty("PluginGuid", BindingFlags.Public | BindingFlags.Instance);
                            if (guidProp == null) continue;

                            object? tempInstance = Activator.CreateInstance(type);
                            if (tempInstance == null) continue;

                            Guid pluginGuid = (Guid)(guidProp.GetValue(tempInstance) ?? Guid.Empty);
                            if (pluginGuid == Guid.Empty) continue;

                            if (loadedPluginGuids.Contains(pluginGuid))
                            {
                                MessageBox.Show($"Пропущен дубликат плагина с GUID {pluginGuid}");
                                continue;
                            }

                            // Теперь проверим — реализует ли плагин нужный интерфейс
                            if (tempInstance is IColorPalettePlugin instance)
                            {
                                loadedPluginGuids.Add(pluginGuid);
                                allPlugins.Add(instance);

                                
                                pluginByName[instance.Name] = instance;

                                Console.WriteLine($"Загружен плагин: {instance.Name} (GUID: {pluginGuid})");
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

            // Вызываем событие загрузки плагинов
            PluginsLoaded?.Invoke(allPlugins);
        }


        private void LoadEnabledPlugins()
        {
            if (File.Exists(enabledPluginsFile))
            {
                var lines = File.ReadAllLines(enabledPluginsFile);
                EnabledPluginNames = new HashSet<string>(lines);
            }
        }
        public List<IColorPalettePlugin> GetEnabledPlugins()
        {
            return allPlugins
                .Where(p => EnabledPluginNames.Contains(p.Name))
                .ToList();
        }

        private void InitUI()
        {
            if (allPlugins.Count == 0)
            {
                MessageBox.Show("Нет загруженных плагинов.");
                return;
            }

            foreach (var plugin in allPlugins)
            {
                var nameProp = plugin.GetType().GetProperty("Name");
                var pluginName = nameProp?.GetValue(plugin)?.ToString();
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
            File.WriteAllLines(enabledPluginsFile, enabledPlugins);
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

            if (pluginByName.TryGetValue(selectedPluginName, out var plugin))
            {
                var type = plugin.GetType();

                string author = type.GetProperty("Author")?.GetValue(plugin)?.ToString() ?? "Неизвестен";
                string description = type.GetProperty("Description")?.GetValue(plugin)?.ToString() ?? "Нет описания";
                string version = type.GetProperty("Version")?.GetValue(plugin)?.ToString() ?? "n/a";
                string createdAt = type.GetProperty("CreatedAt")?.GetValue(plugin)?.ToString() ?? "-";
                string updatedAt = type.GetProperty("LastUpdated")?.GetValue(plugin)?.ToString() ?? "-";
                string guid = type.GetProperty("PluginGuid")?.GetValue(plugin)?.ToString() ?? "-";

                AuthorLabel.Text = $"{author}";
                DescBox.Text = $"{description}";
                VersionLabel.Text = $"{version}";
                GuidLabel.Text = $"{guid}";
                CreatedLabel.Text = $"{createdAt}";
                UpdatedLabel.Text = $"{updatedAt}";
            }
        }

    }
}
