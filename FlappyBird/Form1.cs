using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class form1 : Form
    {
        int gravity = 10;
        int pipespeed = 6;
        int score = 0;
        public form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bird.Top += gravity;
            PipeTop.Left -= pipespeed;
            PipeBottom.Left -= pipespeed;
            scorelabel.Text = $"score: {score}";

            if (PipeTop.Left < -130)
            {
                PipeTop.Left = 1000;
                score++;
            }

            if (PipeBottom.Left < -135)
            {
                PipeBottom.Left = 1000;
                score++;
            }
            if(bird.Top < -25)
            {
                GameOver();
            }

            if (bird.Bounds.IntersectsWith(PipeTop.Bounds) || bird.Bounds.IntersectsWith(PipeBottom.Bounds) || bird.Bounds.IntersectsWith(ground.Bounds))
            {
                GameOver();
            }

            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = +10;
            }
        }
        private void GameOver()
        {
            timer1.Stop();
            scorelabel.Text = $"Game Over!";
            playagain.Visible = true;
        }

        private void playagain_Click(object sender, EventArgs e)
        {
            form1 NewForm = new form1();
            NewForm.Show();
            this.Dispose(false);
        }
    }
}
