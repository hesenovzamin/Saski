using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saski
{
    public partial class Form1 : Form
    {
        public List<Button> Damalar = new List<Button>();
        public List<Button> Figur = new List<Button>();
        public Button btn;
        public Button Agfigur;
        public Button Qarafigur;
        public int LeftLoc = 0;
        public int TopLoc = 0;
        public int FigurLeftLoc = 0;
        public int Count = 1;
        public int btnHeight = 60;
        public int btnWitdh = 60;

        public Form1()
        {
            InitializeComponent();
            this.Height = (btnHeight * 8)+40;
            this.Width = (btnWitdh * 8)+17;

            for (int i = 1; i <= 8; i++)
            {
                LeftLoc = 0;
                for (int j = 1; j <= 8; j++)
                {
                    if (i <= 3)
                    {
                        if (i % 2 == 0)
                        {
                            if (j % 2 != 0)
                            {
                                Qarafigur = new Button();
                                Qarafigur.Width = 30;
                                Qarafigur.Height = 30;
                                Qarafigur.Location = new Point(LeftLoc + 15, TopLoc + 15);
                                Qarafigur.BackColor = Color.Green;
                                this.Controls.Add(Qarafigur);
                            }
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                Qarafigur = new Button();
                                Qarafigur.Width = 30;
                                Qarafigur.Height = 30;
                                Qarafigur.Location = new Point(LeftLoc + 15, TopLoc + 15);
                                Qarafigur.BackColor = Color.Green;
                                this.Controls.Add(Qarafigur);
                            }
                        }
                        }
                    if (i >= 6)
                    {
                        if (i % 2 == 0)
                        {
                            if (j % 2 != 0)
                            {
                                Agfigur = new Button();
                                Agfigur.Width = 30;
                                Agfigur.Height = 30;
                                Agfigur.Location = new Point(LeftLoc + 15, TopLoc + 15);
                                Agfigur.BackColor = Color.Red;
                                this.Controls.Add(Agfigur);
                            }
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                Agfigur = new Button();
                                Agfigur.Width = 30;
                                Agfigur.Height = 30;
                                Agfigur.Location = new Point(LeftLoc + 15, TopLoc + 15);
                                Agfigur.BackColor = Color.Red;
                                this.Controls.Add(Agfigur);
                            }
                        }
                    }

                    btn = new Button();
                    btn.Width = btnWitdh;
                    btn.Height = btnHeight;
                    btn.Location = new Point(LeftLoc,TopLoc);
                    btn.Click += new EventHandler(this.btn_Click);
                    btn.TabIndex = 0;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Gray;
                    btn.FlatAppearance.BorderSize = 1;
                    Controls.Add(btn);
                    

                    Count++;
                   
                    if (i % 2 != 0)
                    {
                        if (j % 2 == 0)
                        {
                            btn.BackColor = Color.Black;
                            btn.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            btn.BackColor = Color.Black;
                            btn.ForeColor = Color.White;
                        }
                    }
                    
                    LeftLoc += btnWitdh;

                }
                TopLoc += 60;
                Damalar.Add(btn);
            }

        }
        public void btn_Click(object sender, EventArgs e)
        {

        }
    }
}
