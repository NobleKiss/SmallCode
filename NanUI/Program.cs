using NetDimension.NanUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Bootstrap.Load(setting => {
                setting.LogSeverity = Chromium.CfxLogSeverity.Disable;
                setting.AcceptLanguageList = "zh-CN";
                setting.Locale = "zh-CN";
            }, commandLine => {
                commandLine.AppendSwitch("disable-web-security");
            }))
            {
                Application.Run(new Form1());
            }            
        }
    }
}
