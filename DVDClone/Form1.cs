using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDClone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int[] pDirection = new int[] { 6, 2 };
        public int[] VHSpeed = Physics.SpeedRandomizer();

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 10;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point pLocation = panel1.Location;

            // Every 10ms the panel is moving by VHSpeed[X, Y]/20 
            if(pDirection[0] == 6 && pDirection[1] == 2)
            {
                panel1.Location = new Point(pLocation.X + (VHSpeed[0] / 20), pLocation.Y + (VHSpeed[1] / 20));
                panel1.BackColor = Color.Gold;
            }
            else if(pDirection[0] == 6 && pDirection[1] == 8)
            {
                panel1.Location = new Point(pLocation.X + (VHSpeed[0] / 20), pLocation.Y - (VHSpeed[1] / 20));
                panel1.BackColor = Color.CadetBlue;
            }
            else if (pDirection[0] == 4 && pDirection[1] == 2)
            {
                panel1.Location = new Point(pLocation.X - (VHSpeed[0] / 20), pLocation.Y + (VHSpeed[1] / 20));
                panel1.BackColor = Color.FloralWhite;
            }
            else if (pDirection[0] == 4 && pDirection[1] == 8)
            {
                panel1.Location = new Point(pLocation.X - (VHSpeed[0] / 20), pLocation.Y - (VHSpeed[1] / 20));
                panel1.BackColor = Color.DeepPink;
            }

            // pDirection[X, Y] 2 DOWN, 8 UP, 4 LEFT, 6 RIGHT
            int[] PNCLocation = new int[] { pLocation.X, pLocation.Y };
            if (PNCLocation[1] <= 0)
            {
                pDirection[1] = 2;
            }
            else if(PNCLocation[1] + 145 >= 720)
            {
                pDirection[1] = 8;
            }
            else if(PNCLocation[0] + 220 >= 1270)
            {
                pDirection[0] = 4;
            }
            else if(PNCLocation[0] <= 0)
            {
                pDirection[0] = 6;
            }
        }
    }

    public class Physics
    {
        public static int[] SpeedRandomizer()
        {
            var rand = new Random(Convert.ToInt32(long.Parse(DateTime.UtcNow.ToString("ffffff"))));
            int[] VHSpeed = new int[] { rand.Next(50, 110), rand.Next(50, 90) };
            return VHSpeed;
        }
    }
}
