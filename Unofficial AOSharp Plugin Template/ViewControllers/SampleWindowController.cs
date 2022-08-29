using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AOSharp.Common.GameData;
using AOSharp.Common.GameData.UI;

namespace $safeprojectname$.ViewControllers
{
    public class SampleWindowController : Controller
    {
        public SampleWindowController(String PluginDirectory, AOSharp.Core.Settings PluginSettings) : base(PluginDirectory, PluginSettings) { }

        public override bool InitializeWindow(bool AutoOpen)
        {
            if (base.InitializeWindow(PluginDirectory + "\\Views\\SampleWindow.xml", new Rect(0, 0, 455, 345),
                windowName: "$projectname$ - Sample Window",
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
    }
}
