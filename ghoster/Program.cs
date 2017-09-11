using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ghoster
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            foreach (string arg in args)
            {
                if (arg == "-help" || arg == "-?" || arg == "/?") {
                    MessageBox.Show(helpText, "Ghost Vision Help");
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        static string helpText =
            "Launch Options\n\n" +
            "-oX             \tset opacity to X (0-100)" +
            "-wX             \tset width to X (in pixels)" +
            "-hX             \tset height to X (in pixels)" +
            "-top  -t  -aot  \talways on top\n" +
            "-ghost  -gm     \tghost mode (can't be clicked)\n" +
            "-novid  -blank  \tempty on startup\n" +
            "-colors  -panels\tshow debug panels\n" +
            "-errors -js     \tallow js errors to appear\n" +
            "-debug          \tshow panels and allow errors\n" +
            "-help           \tdisplay this text\n\n" +
            "pass url as any argument to start on that video"+
            "may need to wrap url in double quotes";

        
    }
}
