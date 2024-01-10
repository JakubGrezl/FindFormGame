using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindFormGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            Random r = new Random();

            int numberOfForms = r.Next(5, 25);

            bool winUsed = false;

            for (int i = 0; i <= numberOfForms; i++)
            {
                Form f = new Form();
                f.StartPosition = FormStartPosition.Manual;
                f.Width = 250;
                f.Height = 250;
                f.Location = new Point(r.Next(0, screenWidth - f.Width), r.Next(0, screenHeight - f.Height));
                if (r.Next(0, 100) <= 25)
                {
                    Button b = new Button();
                    if (!winUsed)
                    {
                        b.Text = "NAŠEL JSI MĚ!!!";
                        b.Click += FindButton_Click;
                        winUsed = true;
                    }
                    else
                    {
                        b.Text = "NEMAČKEJ MĚ!!!";
                        b.Click += LostButton_Click;
                    }
                    b.Size = new Size(100, 25);
                    b.Location = new Point((f.Width / 2) - b.Width, (f.Height / 2) - b.Height);
                    b.Enabled = true;
                    b.BringToFront();



                    f.Controls.Add(b);
                }
                f.BringToFront();
                f.Show();
                Singleton.Instance.forms.Add(f);
            }
            this.Visible = false;
        }

        void FindButton_Click(object sender, EventArgs e)
        {
            Singleton.Instance.Won(this);
        }

        void LostButton_Click(object sender, EventArgs e)
        {
            Singleton.Instance.Lost();
        }

    }
}
