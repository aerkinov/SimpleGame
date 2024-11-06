namespace Game
{
    public abstract class LevelBase
    {
        public abstract void Render(Image image, int x, int y);
        public abstract (int score, int level, int prev_level) GetInfo();
        public abstract bool SpriteGenerated { get; }
        internal abstract void skip_iter();
    }


    namespace Level
    {
        internal sealed class ConcretreLevel : LevelBase
        {
            private const int second_level_score = 10, third_level_score = 20, fourth_level_score = 30, fifth_level_score = 41;
            PictureBox imageBox;

            private int score, level, prev_level;
            private bool is_sprite_generated;
            public override bool SpriteGenerated => is_sprite_generated;

            public ConcretreLevel(PictureBox imageBox)
            {
                this.imageBox = imageBox;
                level = 0;
                imageBox.MouseClick += ImageBox_MouseClick;
            }

            private void ImageBox_MouseClick(object? sender, MouseEventArgs e)
            {
                is_sprite_generated = false;
                imageBox.Image?.Dispose();
                imageBox.Image = null;
                score++;

                if (score == second_level_score || score == third_level_score || score == fourth_level_score || score == fifth_level_score)
                {
                    prev_level = level;
                    level++;
                    return;
                }
                else
                {
                    prev_level = level;
                }
            }

            public override void Render(Image image, int x, int y)
            {
                imageBox.Image = image;
                imageBox.SizeMode = PictureBoxSizeMode.StretchImage;
                imageBox.Location = new Point(x, y);
                is_sprite_generated = true;

                imageBox.Update();
            }
            internal override void skip_iter()
            {
                prev_level = level;
            }

            public override (int score, int level, int prev_level) GetInfo()
            {

                return new(score, level, prev_level);
            }
        }
    }
}
