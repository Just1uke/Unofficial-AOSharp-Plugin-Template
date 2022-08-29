using System;

using AOSharp.Core;
using AOSharp.Core.UI;
using AOSharp.Common.GameData;

using $safeprojectname$.ViewControllers;

namespace $safeprojectname$
{
    public class Main : AOPluginEntry
    {

        private static AOSharp.Core.Settings PluginTemplateSettings = new AOSharp.Core.Settings("$safeprojectname$");
        public static string PluginDirectory;

        public override void Run(string PluginDirectory)
        {

            try
            {
                PluginTemplateSettings.Load();
                Main.PluginDirectory = PluginDirectory;
                RegisterControllers();
            }
            catch (Exception e)
            {
                Chat.WriteLine($"Exception encountered: {e.Message}", ChatColor.Red);
            }
        }

        private void RegisterControllers()
        {
            ControllerManager.controllers.Add(new MainController(Main.PluginDirectory, Main.PluginTemplateSettings));
            ControllerManager.controllers.Add(new SampleWindowController(Main.PluginDirectory, Main.PluginTemplateSettings));

            Controller.AllControllersLoaded?.Invoke(null, null);
        }

        public override void Teardown()
        {
            Controller.Teardown?.Invoke(null, null);
            PluginTemplateSettings.Save();
        }
    }

}
