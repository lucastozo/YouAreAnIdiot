using System.Windows.Forms;

namespace YouAreAnIdiot
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            ExecutionsLogic();
            Application.ApplicationExit += OnApplicationExit;

            Application.Run(new Form1());
        }
        

        private static void PlaySound()
        {
            var player = new System.Media.SoundPlayer
            {
                SoundLocation = "C:\\Windows\\Media\\tada.wav"
            };
            player.Load();
            player.PlayLooping();
        }
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            OpenItself();
        }

        private static void OpenItself()
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
        }

        private static void ExecutionsLogic()
        {
            int i = 0;
            string path = "control.txt";
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                int.TryParse(text, out i);
            }
            MessageBox.Show(i.ToString());
            i++;
            File.WriteAllText(path, i.ToString());
        }
    }
}