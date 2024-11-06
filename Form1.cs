using System.Media;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text= "";
            label1.Text= "Hunting Game";
            label1.Font = new Font("Segoe UI",12,FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 7, FontStyle.Bold);
            label2.Text = "Enter your name below\nand click Play";
            textBox1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            button1.Text= "Play";
            button2.Text= "Exit";

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int interval = 0;
            label3.Text = "";

            System.Windows.Forms.Timer timer = new();
            timer.Tick += (object? sender, EventArgs e) =>
            {
                interval++;
                if (interval == 3)
                {
                    label3.Text = "";
                    label3.ForeColor = Color.Red;
                    label3.Text = "Name cannot be whitespace";
                    SystemSounds.Hand.Play();
                    timer.Stop();
                }
            };


            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                timer.Start();
                return;
            }
            Name = textBox1.Text;
            GameUI gameUI = new GameUI();
            gameUI.FormClosed += On_GameUI_Closed;
            gameUI.Show();
            Visible = false;
            gameUI.Label1.Text = $"Welcome\n{Name}";
        }

        private void On_GameUI_Closed(object? sender, FormClosedEventArgs e)
        {
            this.Visible= true;
        }
    }
}