using System.Diagnostics;
using System.Reflection;
using System.Media;

namespace YouAreAnIdiot
{
    internal static class Program
    {
        private const string Path = "C:\\Users\\Public\\youareanidiot.txt";
        public static int i;
        public static bool FocusWindow = false;
        public const bool SafeMode = false;

        [STAThread]
        static void Main()
        {
            ExecutionsLogic();
            if (ExecutionWarning() == -1)
            {
                File.Delete(Path);
                return;
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static void OpenItself()
        {
            if (!SafeMode)
            {
                int openTimes = ReturnExecutions();
                for (int j = 0; j < openTimes; j++)
                {
                    Process.Start(Application.ExecutablePath);
                }
            }

        }

        private static void ExecutionsLogic()
        {
            i = ReturnExecutions();
            i++;
            ShowFile();
            File.WriteAllText(Path, i.ToString()); // write i value for the next execution
            HideFile();
        }

        private static int ReturnExecutions()
        {
            int times = 0;
            ShowFile();
            if (File.Exists(Path))
            {
                string text = File.ReadAllText(Path);
                int.TryParse(text, out times);
                HideFile();
            }
            return times;
        }
        public static void PlaySound()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "YouAreAnIdiot.youareanidiot.wav";

            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream != null)
                {
                    SoundPlayer player = new SoundPlayer(resourceStream);
                    player.Load();
                    player.PlayLooping();
                }
            }
        }

        private static int ExecutionWarning()
        {
            if (i < 0)
            {
                return -1;
            }
            if (i > 1)
            {
                return 0; // warning only for the first execution
            }
            DialogResult dialog = MessageBox.Show("Warning: this program is a \"virus\". It will probably led your computer to crash. Please save your work before continuing. Do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog != DialogResult.Yes)
            {
                return -1;
            }
            dialog = MessageBox.Show("Last warning. Do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog != DialogResult.Yes)
            {
                return -1;
            }
            return 0;
        }

        private static void HideFile()
        {
            if (File.Exists(Path))
                File.SetAttributes(Path, File.GetAttributes(Path) | FileAttributes.Hidden);
        }

        private static void ShowFile()
        {
            if (File.Exists(Path))
                File.SetAttributes(Path, File.GetAttributes(Path) & ~FileAttributes.Hidden);
        }
    }
}