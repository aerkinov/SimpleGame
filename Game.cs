using Timer = System.Windows.Forms.Timer;

namespace Game
{


    public sealed class Game
    {
        private GameUI form;
        Label tick, score;
        int height, width;
        private readonly SplitContainer splitContainer;
        private string[] images;
        private LevelBase level;
        private double timerCounter;
        private readonly Timer timer;
        private readonly DifficultyLevel difficulty;
        public Game(DifficultyLevel difficulty, GameUI form, params string[] images)
        {
            timerCounter = ((double)difficulty)+.0;
            this.difficulty = difficulty;
            timer = new Timer();
            timer.Tick += Timer_Tick;
            level = new Level.ConcretreLevel(form.PictureBox);
            this.images = images;
            this.splitContainer = form.SplitContainer;
            tick = form.timerLabel;
            score = form.ScoreLabel;
            this.form = form;
            height = form.Height; width = form.Width;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Random rnd = new();

            var level_info = level.GetInfo();
            if (level_info.score == 60)
            {
                timer.Stop();
                timer.Enabled = false;
                form.ResultLabel.Text = $"Completed\nScore:{level_info.score}";
                form.ResultLabel.Visible = true;
                form.ButtonStart.Visible = true;

            }
            if (timerCounter < 0.1)
            {
                timer.Stop();
                timer.Enabled = false;
                form.ResultLabel.Text = $"GAME OVER\nScore:{level_info.score}";
                form.ResultLabel.Visible= true;
                form.ButtonStart.Visible = true;

            }
            if (level_info.prev_level < level_info.level)
            {
                level.skip_iter();
                form.Size = new Size(form.Size.Width + rnd.Next(-200,350), form.Size.Height + rnd.Next(-200, 350));
                timerCounter = (float)difficulty;
            }
            
            var panel1 = splitContainer.Panel1;
            var panel2 = splitContainer.Panel2;
            rnd.Next(10, width / 2); rnd.Next(10, height - 50);
            if (!level.SpriteGenerated)
                level.Render(new Bitmap(images[level_info.level]), rnd.Next(10, panel2.Width - (panel1.Width - 100)), rnd.Next(10, panel2.Height > 100 ?panel2.Height - 100:100));

            tick.Text = timerCounter.ToString("0.0");

            score.Text = level_info.score.ToString();

            timerCounter -= .1;

        }
       
        public void Play()
        {
            form.ButtonStart.Visible = false;
            timer.Start();
        }
    }
}
