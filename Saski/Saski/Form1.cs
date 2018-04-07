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
                                var Figur = new QaraFigur(IdFigur, a,Qarafigur);
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
                                var Figur = new QaraFigur(IdFigur, a, Qarafigur);
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
                               var Figur = new AgFigur(IdFigur, a, Agfigur);
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
                                var Figur = new AgFigur(IdFigur, a, Agfigur);
                                this.Controls.Add(Agfigur);
                            }
                        }
                    }

                    btn = new Button();
                    btn.Width = btnWitdh;
                    btn.Height = btnHeight;
                    btn.Location = new Point(LeftLoc,TopLoc);
                    btn.Click += new EventHandler(this.btn_Click);
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
        static bool Black;
        static bool White;
        static QaraFigur QaraDas;
        static Damalar Dama;
        static AgFigur Agdas;
        public void btn_Click(object sender, EventArgs e)
        {           
            Button buttonn = sender as Button;
            foreach (var item in Saski.Damalar.Damalarr)
            {
                if (item.btn.Location == buttonn.Location)
                {                    
                    Dama = item;
                }
            }
            try
            {
                if ((QaraDas.Id + 7 == Dama.Id || QaraDas.Id + 9 == Dama.Id || QaraDas.Id == Dama.Id) && Dama.Status == false && Black ==true)
                {
                    QaraDas.btn.Location = new Point(buttonn.Location.X + 15, buttonn.Location.Y + 15);
                    ClickSayi = 0;
                    Dama.Status = true;
                    QaraDas.Id = Dama.Id;
                    QaraDas.btn.Show();
                    ClickSayi = 0;
                    QaraDas.Status = true;
                    Dama.btn.Hide();
                }
            }
            catch
            {
               
            }
            try
            {
                if ((Agdas.Id - 7 == Dama.Id || Agdas.Id - 9 == Dama.Id || Agdas.Id == Dama.Id) && Dama.Status == false)
                {
                    Agdas.btn.Show();
                    Agdas.btn.Location = new Point(buttonn.Location.X + 15, buttonn.Location.Y + 15);
                    ClickSayi = 0;
                    Dama.Status = true;
                    Agdas.Id = Dama.Id;  
                    ClickSayi = 0;
                    Agdas.Status = true;
                  
                   
                }
            }
            catch
            {

            }

        }
        static int ClickSayi = 0;
        static bool F = true;
        static int Ide;
        public void Qarafigur_Click(object sender, EventArgs e)
        {
            ClickSayi++;
            Button buttonn = sender as Button;          
            foreach (var item in Saski.QaraFigur.Figurr)
            {
                if (item.btn.Location == buttonn.Location && ClickSayi==1)
                {
                    foreach (var item2 in Saski.Damalar.Damalarr)
                    {
                        if (item.Id==item2.Id)
                        {
                            QaraDas = item;
                            item2.Status = false;
                            Black = true;
                            White = false;
                        }
                    }
                    item.Status = false;
                    buttonn.Hide();
                }
            }

        
        }
        public void Agfigur_Click(object sender, EventArgs e)
        {
            ClickSayi++;
            Button buttonn = sender as Button;
            foreach (var item in Saski.AgFigur.Figurr)
            {
                if (item.btn.Location == buttonn.Location && ClickSayi == 1)
                {
                    foreach (var item2 in Saski.Damalar.Damalarr)
                    {
                        if (item.Id == item2.Id)
                        {
                            Agdas = item;
                            item2.Status = false;
                            Black = false;
                            White = true;
                        }
                    }
                    item.Status = false;
                    buttonn.Hide();
                }
            }

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
    class QaraFigur
    {
        public bool Status;
        public Button btn;
        public int Id;
        public static List<QaraFigur> Figurr = new List<QaraFigur>();
        public QaraFigur(int _Id, bool _f, Button _btn)
        {
            Id = _Id;
            Status = _f;
            btn = _btn;
            Figurr.Add(this);
        }
    }
    class AgFigur
    {
        public bool Status;
        public Button btn;
        public int Id;
        public static List<AgFigur> Figurr = new List<AgFigur>();
        public AgFigur(int _Id, bool _f, Button _btn)
        {
            Id = _Id;
            Status = _f;
            btn = _btn;
            Figurr.Add(this);
        }
    }
}
