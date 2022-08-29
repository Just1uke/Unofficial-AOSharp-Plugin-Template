using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AOSharp.Core.UI;
using AOSharp.Common.GameData;
using AOSharp.Common.GameData.UI;

namespace $safeprojectname$.ViewControllers
{
    public class MainController : Controller
{
    public MainController(String PluginDirectory, AOSharp.Core.Settings PluginSettings) : base(PluginDirectory, PluginSettings) { }

    public override void RegisterCommands()
    {
        base.RegisterCommands();

        Chat.RegisterCommand("$safeprojectname$", (string command, string[] param, ChatWindow chatWindow) =>
        {
            try
            {
                InitializeWindow();
                if (PluginUI.IsVisible)
                {
                    PluginUI.Close();
                }
                else
                {
                    PluginUI.Show(true);
                }
            }
            catch (Exception e)
            {
                Chat.WriteLine(e);
            }
        });
    }

    public override void RegisterControllerCallbacks()
    {
        base.RegisterControllerCallbacks();
        MainController.AllControllersLoaded += delegate (Object o, EventArgs e)
        {
            Chat.WriteLine("$projectname$ loaded!");
            Chat.WriteLine("Run command /$safeprojectname$ to open the main window.");
        };
    }


    public override bool InitializeWindow(bool AutoOpen)
    {
        if (base.InitializeWindow(PluginDirectory + "\\Views\\Main.xml", new Rect(0, 0, 455, 345),
            windowName: "$projectname$ - Main Window",
            windowStyle: WindowStyle.Default,
            windowFlags: WindowFlags.AutoScale | WindowFlags.NoFade,
            autoOpen: AutoOpen))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void CheckForClickedButtons()
    {
        try
        {
            if (PluginUI != null && PluginUI.IsValid)
            {

                PluginUI.Views.ForEach(delegate (View UIView)
                {
                    if (UIView != null)
                    {
                        if (UIView.FindChild("Open_Sample_Window", out Button btnOpenSampleWindow))
                        {
                            btnOpenSampleWindow.Tag = UIView;
                            btnOpenSampleWindow.Clicked = (object s, ButtonBase button) => {
                                ControllerManager.Open("SampleWindowController"); // Open the Sample window.

                            };
                        }

                        // Custom run actions, mostly used for the quick testing of things
                        if (UIView.FindChild("Run_Action1", out Button btnAction1))
                        {
                            btnAction1.Tag = UIView;
                            btnAction1.Clicked = (object s, ButtonBase button) => {
                                Chat.WriteLine("You clicked Action 1!", ChatColor.DarkPink);

                            };
                        }
                        if (UIView.FindChild("Run_Action2", out Button btnAction2))
                        {
                            btnAction2.Tag = UIView;
                            btnAction2.Clicked = (object s, ButtonBase button) => {
                                Chat.WriteLine("You clicked Action 2!", ChatColor.Yellow);

                            };
                        }
                        if (UIView.FindChild("Run_Action3", out Button btnAction3))
                        {
                            btnAction3.Tag = UIView;
                            btnAction3.Clicked = (object s, ButtonBase button) => {
                                Chat.WriteLine("You clicked Action 3!", ChatColor.LightBlue);
                            };
                        }
                        if (UIView.FindChild("Run_Action4", out Button btnAction4))
                        {
                            btnAction4.Tag = UIView;
                            btnAction4.Clicked = (object s, ButtonBase button) => {
                                Chat.WriteLine("You clicked Action 4!", ChatColor.Orange);
                            };
                        }
                    }
                });
            }
        }
        catch (Exception e)
        {
            Chat.WriteLine(e);
        }
    }
}
}
