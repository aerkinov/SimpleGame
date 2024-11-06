using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Game
{
    public partial class GameUI : Form
    {
        public Button ButtonStart => button1;
        public Label ResultLabel => label7;
        public SplitContainer SplitContainer => splitContainer1;
        public PictureBox PictureBox => pictureBox1;
        public Label timerLabel=>label5;
        public Label ScoreLabel => label6;

        private Game game { get; set; }
        public Label Label1 => label1;
        public GameUI()
        {
            InitializeComponent();
                       
            splitContainer1.BringToFront();
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            button1.Text = "Start";
            splitContainer1.Panel1.BackColor = Color.DarkSeaGreen;
            checkedListBox1.BackColor = splitContainer1.Panel1.BackColor;
            label2.Text = "Difficulty";
            label3.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            label4.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            label3.Text = "Time";
            label4.Text = "Score";
            label7.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            label7.Text = "";
            label7.ForeColor= Color.Red;
            label7.AutoSize = false;
            label7.TextAlign = ContentAlignment.MiddleCenter;
            label7.Dock= DockStyle.Fill;
            label7.Visible= false;
            button2.Text = "Exit";
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DifficultyLevel difficulty = 0;
            label7.Visible = false;
            if(checkedListBox1.CheckedItems.Count == 1)
            difficulty = (DifficultyLevel) Enum.Parse(typeof(DifficultyLevel), checkedListBox1.CheckedItems[0].ToString());
            game = new Game(difficulty,this, @"R.png", @"smile2.jpg", @"smile 3.png", @"smile4.png", @"smile5.jpg");
            game.Play();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix) 
                if (ix != checkedListBox1.SelectedIndex) checkedListBox1.SetItemChecked(ix, false);
        }
    }
}
