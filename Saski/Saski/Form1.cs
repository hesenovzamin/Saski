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
        public bool f = false;
        public int IdDama = 1;
        public int IdFigur = 1;
        public bool a = true;

        public Form1()
        {
            InitializeComponent();
            this.Height = (btnHeight * 8)+40;
            this.Width = (btnWitdh * 8)+17;

            for (int i = 1; i <= 8; i++)
            {
                f = false;
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
                                f = true;
                                Qarafigur.Width = 30;
                                Qarafigur.Click += new EventHandler(this.Qarafigur_Click);
                                Qarafigur.Height = 30;
                                Qarafigur.Location = new Point(LeftLoc + 15, TopLoc + 15);
                                Qarafigur.BackColor = Color.Green;
                                this.Controls.Add(Qarafigur);
                                var Figur = new Figur(IdFigur, a,Qarafigur);
                            }
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                Qarafigur = new Button();
                                f = true;
                                Qarafigur.Width = 30;
                                Qarafigur.Height = 30;
                                Qarafigur.Click += new EventHandler(this.Qarafigur_Click);
                                Qarafigur.Location = new Point(LeftLoc + 15, TopLoc + 15);
                                Qarafigur.BackColor = Color.Green;
                                this.Controls.Add(Qarafigur);
                                var Figur = new Figur(IdFigur, a, Qarafigur);
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
                                f = true;
                                Agfigur.Width = 30;
                                Agfigur.Height = 30;
                                Agfigur.Click += new EventHandler(this.Agfigur_Click);
                                Agfigur.Location = new Point(LeftLoc + 15, TopLoc + 15);
                                Agfigur.BackColor = Color.Red;
                                this.Controls.Add(Agfigur);
                                var Figur = new Figur(IdFigur, a, Agfigur);
                            }
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                Agfigur = new Button();
                                f = true;
                                Agfigur.Width = 30;
                                Agfigur.Height = 30;
                                Agfigur.Click += new EventHandler(this.Agfigur_Click);
                                Agfigur.Location = new Point(LeftLoc + 15, TopLoc + 15);
                                Agfigur.BackColor = Color.Red;
                                var Figur = new Figur(IdFigur, a, Agfigur);
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
                    var Dama = new Damalar(IdDama,f,btn);
                   
                    IdDama++;
                    IdFigur++;

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
            
            }

        }
        static int DamaClickSayi = 0;
        static int id;
        static Figur Das;
        static Damalar Dama;
        public void btn_Click(object sender, EventArgs e)
        {
            
            Button buttonn = sender as Button;
            foreach (var item in Saski.Damalar.Damalarr)
            {
                if (item.btn.Location == buttonn.Location)
                {
                    id = item.Id;
                    Dama = item;
                }
            }
            foreach (var item in Saski.Figur.Figurr)
            {
                if (id ==item.Id)
                {
                    Dama.Status = true;
                    item.btn.Show();
                   
                }
            }
            foreach (var item in Saski.Figur.Figurr)
            {
                if (item.Status == false)
                {
                    Das = item;
                }
            }
            if ((Das.Id -7==id || Das.Id -9 == id || Das.Id + 7 == id || Das.Id + 9 == id) && Dama.Status==false)
            {
                Das.btn.Location = new Point(buttonn.Location.X + 15, buttonn.Location.Y + 15);
                ClickSayi = 0;
                Dama.Status = true;
                Das.Id = Dama.Id;
                Das.btn.Show();
            }
        }
        static int ClickSayi = 0;
        static bool F = true;
        static int Ide;
        public void Qarafigur_Click(object sender, EventArgs e)
        {
            ClickSayi++;
            Button buttonn = sender as Button;          
            foreach (var item in Saski.Figur.Figurr)
            {
                if (item.btn.Location == buttonn.Location && ClickSayi==1)
                {
                    foreach (var item2 in Saski.Damalar.Damalarr)
                    {
                        if (item.Id==item2.Id)
                        {
                            item2.Status = false;
                        }
                    }
                    item.Status = false;
                    buttonn.Hide();
                }
            }

        
        }
        public void Agfigur_Click(object sender, EventArgs e)
        {
          
       
        }
    }
    class Damalar
    {
        public bool Status;
        public Button btn;
        public int Id;
        public static List<Damalar> Damalarr = new List<Damalar>();
        public Damalar(int _Id,bool _f,Button _btn)
        {
            Id = _Id;
            Status = _f;
            btn = _btn;
            Damalarr.Add(this);
        }
    }
    class Figur
    {
        public bool Status;
        public Button btn;
        public int Id;
        public static List<Figur> Figurr = new List<Figur>();
        public Figur(int _Id, bool _f, Button _btn)
        {
            Id = _Id;
            Status = _f;
            btn = _btn;
            Figurr.Add(this);
        }
    }
}
