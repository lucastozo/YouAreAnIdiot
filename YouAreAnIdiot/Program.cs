using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Media;

namespace YouAreAnIdiot
{
    internal static class Program
    {
        private const string Path = "control.txt";
        static int i;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            ExecutionsLogic();
            Application.ApplicationExit += OnApplicationExit;
            Application.Run(new Form1());
        }
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            if (i < 3)
            {
                OpenItself();
                return;
            }
            File.Delete(Path);
        }
        public static void OpenItself()
        {
            bool safeMode = false;
            if (i < 3 || !safeMode) //safe safe yey yey
            {
                for (int j = 0; j < i; j++)
                {
                    Process.Start(Application.ExecutablePath);
                }
            }
            
        }
        private static void ExecutionsLogic()
        {
            if (File.Exists(Path))
            {
                string text = File.ReadAllText(Path);
                int.TryParse(text, out i);
                File.Delete(Path); // remove file after get i value
            }
            i++;
            File.WriteAllText(Path, i.ToString()); // write i value for the next execution
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
    }
}