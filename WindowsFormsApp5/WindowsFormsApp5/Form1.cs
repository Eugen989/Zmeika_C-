using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        short[][] pole;

        short point = 0;
        short snaik_col = 1;

        uint cicles = 0;

        bool new_telo = false;
        bool flag = false;

        byte vremianka = 0;
        byte dv = 3;
        byte dv_0 = 3;
        byte tik_1 = 0;
        byte tik_2 = 0;
        byte zp_tik;
        byte level = 0;

        List<PictureBox> pb = new List<PictureBox>();

        List<short> snaik_polozhenie_tul_x = new List<short>();
        List<short> snaik_polozhenie_tul_y = new List<short>();


        bool losing = false;

        Random r = new Random();

        public Form1()
        {
            
            InitializeComponent();
            backgraundimage1.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Игровой лес.jpg");
            backgraundimage1.BackgroundImageLayout = ImageLayout.Zoom;

            Loser.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Проигрышь.jpg");
            Loser.BackgroundImageLayout = ImageLayout.Zoom;

            Loser.Visible = false;

            pb.Add(pictureBox1); pb.Add(pictureBox2); pb.Add(pictureBox3); pb.Add(pictureBox4); pb.Add(pictureBox5); pb.Add(pictureBox6); pb.Add(pictureBox7); pb.Add(pictureBox8); pb.Add(pictureBox9); pb.Add(pictureBox10);
            pb.Add(pictureBox11); pb.Add(pictureBox12); pb.Add(pictureBox13); pb.Add(pictureBox14); pb.Add(pictureBox15); pb.Add(pictureBox16); pb.Add(pictureBox17); pb.Add(pictureBox18); pb.Add(pictureBox19); pb.Add(pictureBox20);
            pb.Add(pictureBox21); pb.Add(pictureBox22); pb.Add(pictureBox23); pb.Add(pictureBox24); pb.Add(pictureBox25); pb.Add(pictureBox26); pb.Add(pictureBox27); pb.Add(pictureBox28); pb.Add(pictureBox29); pb.Add(pictureBox30);
            pb.Add(pictureBox31); pb.Add(pictureBox32); pb.Add(pictureBox33); pb.Add(pictureBox34); pb.Add(pictureBox35); pb.Add(pictureBox36); pb.Add(pictureBox37); pb.Add(pictureBox38); pb.Add(pictureBox39); pb.Add(pictureBox40);
            pb.Add(pictureBox41); pb.Add(pictureBox42); pb.Add(pictureBox43); pb.Add(pictureBox44); pb.Add(pictureBox45); pb.Add(pictureBox46); pb.Add(pictureBox47); pb.Add(pictureBox48); pb.Add(pictureBox49); pb.Add(pictureBox50);
            pb.Add(pictureBox51); pb.Add(pictureBox52); pb.Add(pictureBox53); pb.Add(pictureBox54); pb.Add(pictureBox55); pb.Add(pictureBox56); pb.Add(pictureBox57); pb.Add(pictureBox58); pb.Add(pictureBox59); pb.Add(pictureBox60);
            pb.Add(pictureBox61); pb.Add(pictureBox62); pb.Add(pictureBox63); pb.Add(pictureBox64); pb.Add(pictureBox65); pb.Add(pictureBox66); pb.Add(pictureBox67); pb.Add(pictureBox68); pb.Add(pictureBox69); pb.Add(pictureBox70);
            pb.Add(pictureBox71); pb.Add(pictureBox72); pb.Add(pictureBox73); pb.Add(pictureBox74); pb.Add(pictureBox75); pb.Add(pictureBox76); pb.Add(pictureBox77); pb.Add(pictureBox78); pb.Add(pictureBox79); pb.Add(pictureBox80);
            pb.Add(pictureBox81); pb.Add(pictureBox82); pb.Add(pictureBox83); pb.Add(pictureBox84); pb.Add(pictureBox85); pb.Add(pictureBox86); pb.Add(pictureBox87); pb.Add(pictureBox88); pb.Add(pictureBox89); pb.Add(pictureBox90);
            pb.Add(pictureBox91); pb.Add(pictureBox92); pb.Add(pictureBox93); pb.Add(pictureBox94); pb.Add(pictureBox95); pb.Add(pictureBox96); pb.Add(pictureBox97); pb.Add(pictureBox98); pb.Add(pictureBox99); pb.Add(pictureBox100);
            
            sozd_pole();

            pole[0][0] = 1;
            snaik_polozhenie_tul_x.Add(0);
            snaik_polozhenie_tul_y.Add(0);

            zp_tik = (byte)r.Next(2,5);
        }

        void sozd_pole()
        {
            pole = new short[10][];
            for (short i = 0; i < 10; i++)
                pole[i] = new short[10];

            for (short i = 0; i < 10; i++)
                for (short j = 0; j < 10; j++)
                    pole[i][j] = 0;

            pole[0][0] = 1;

            for (short i = 0; i < 100; i++)
                zapolnenie(i,0);
            zapolnenie(0,1);
        }

        void zapolnenie(short n, short tip)
        {
            switch (tip)
            {
                case 0:
                    {
                        pb[n].BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Зелёный квадрат.jpg");
                        break;
                    }
                case 1:
                    {
                        pb[n].BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Змея туловище.jpg");
                        break;
                    }
                case 2:
                    {
                        pb[n].BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Коричневый квадрат.jpg");
                        break;
                    }
                case 3:
                    {
                        pb[n].BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Красное Яблоко.jpg");
                        break;
                    }
                default:
                    break;
            }
        }

        void Dvizhenie(short x_1, short y_1)
        {
            if (x_1 < 10 && y_1 < 10 && x_1 >= 0 && y_1 >= 0)
            {
                if (pole[y_1][x_1] != 1 && pole[y_1][x_1] != 2)
                {
                    if (pole[y_1][x_1] == 3)
                    {
                        point += 25;
                        new_telo = true;
                        snaik_polozhenie_tul_x.Add(snaik_polozhenie_tul_x[snaik_col - 1]);
                        snaik_polozhenie_tul_y.Add(snaik_polozhenie_tul_y[snaik_col - 1]);
                        snaik_col++;
                    }

                    if (snaik_col == 1)
                    {
                        pole[snaik_polozhenie_tul_y[0]][snaik_polozhenie_tul_x[0]] = 0;
                        snaik_polozhenie_tul_x[0] = x_1;
                        snaik_polozhenie_tul_y[0] = y_1;
                        pole[y_1][x_1] = 1;
                    }

                    else
                    {
                        for (short i = new_telo == true ? (short)(snaik_col - 2) : (short)(snaik_col - 1); i >= 0; i--)
                        {

                            if (i == 0)
                            {
                                snaik_polozhenie_tul_x[i] = x_1;
                                snaik_polozhenie_tul_y[i] = y_1;
                                pole[y_1][x_1] = 1;
                            }
                            else
                            {
                                if (i == (snaik_col - 1))
                                    pole[snaik_polozhenie_tul_y[i]][snaik_polozhenie_tul_x[i]] = 0;
                                snaik_polozhenie_tul_x[i] = snaik_polozhenie_tul_x[i - 1];
                                snaik_polozhenie_tul_y[i] = snaik_polozhenie_tul_y[i - 1];
                                if(level == 0)
                                    pole[snaik_polozhenie_tul_y[i]][snaik_polozhenie_tul_x[i]] = 1;
                                if (level == 1)
                                    pole[snaik_polozhenie_tul_x[i]][snaik_polozhenie_tul_y[i]] = 1;
                            }
                        }
                    }
                    new_telo = false;
                }
                else
                    losing = true;
            }
            else
                losing = true;
        }

        void izm_pole()
        {
            for (short i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    izm_cvet((short)j, (short)i, pole[i][j]);
                }
            }
        }

        void izm_cvet(short x,short y,short tip)
        {
            zapolnenie((short)(x + (y * 10)), tip);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (dv)
            {
                case 0:
                    {
                        if (dv_0 != 2)
                        {
                            Dvizhenie((short)(snaik_polozhenie_tul_x[0]), (short)(snaik_polozhenie_tul_y[0] - 1));
                            dv_0 = dv;
                        }
                        else
                            Dvizhenie((short)(snaik_polozhenie_tul_x[0]), (short)(snaik_polozhenie_tul_y[0] + 1));
                        break;
                    }
                case 1:
                    {
                        if (dv_0 != 3)
                        { 
                            Dvizhenie((short)(snaik_polozhenie_tul_x[0] - 1), (short)(snaik_polozhenie_tul_y[0]));
                            dv_0 = dv;
                        }
                        else
                            Dvizhenie((short)(snaik_polozhenie_tul_x[0] + 1), (short)(snaik_polozhenie_tul_y[0]));
                        break;
                    }
                case 2:
                    {
                        if (dv_0 != 0)
                        { 
                            Dvizhenie((short)(snaik_polozhenie_tul_x[0]), (short)(snaik_polozhenie_tul_y[0] + 1));
                            dv_0 = dv;
                        }
                        else
                            Dvizhenie((short)(snaik_polozhenie_tul_x[0]), (short)(snaik_polozhenie_tul_y[0] - 1));
                        break;
                    }
                case 3:
                    {
                        if (dv_0 != 1)
                        { 
                            Dvizhenie((short)(snaik_polozhenie_tul_x[0] + 1), (short)(snaik_polozhenie_tul_y[0]));
                            dv_0 = dv;
                        }
                        else
                            Dvizhenie((short)(snaik_polozhenie_tul_x[0] - 1), (short)(snaik_polozhenie_tul_y[0]));
                        break;
                    }
                default:
                    break;
            }
            if (losing)
            {
                    Loser.Visible = true;
            }
            else
            {
                tik_1++;
                cicles++;
                if (tik_1 == 6)
                {
                    short x, y;
                    if (tik_2 == zp_tik)
                    {
                        zp_tik = (byte)r.Next(1,3);
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                if (flag)
                                    break;
                                if (vremianka == zp_tik)
                                    flag = true;
                                if(pole[i][j] == 0)
                                    vremianka++;
                            }
                            if (flag)
                                break;
                        }
                        if (!flag)
                            zp_tik = vremianka;

                        flag = false;
                        vremianka = 0;

                        for (short i = 0; i < zp_tik; i++)
                            while (true)
                            {
                                x = (short)r.Next(10);
                                y = (short)r.Next(10);
                                if (pole[y][x] == 0)
                                {
                                    pole[y][x] = 2;
                                    break;
                                }
                            }
                        tik_2 = 0;
                        tik_1 = 0;
                        zp_tik = (byte)r.Next(1,4);
                    }
                    else
                    {
                        tik_1 = 0;
                        tik_2++;
                        while (true)
                        {
                            x = (short)r.Next(10);
                            y = (short)r.Next(10);
                            if (pole[y][x] == 0)
                            {
                                pole[y][x] = 3;
                                break;
                            }
                        }
                    }
                }
                izm_pole();
                label1.Text = $"{point}";
                label2.Text = $"{cicles}";
                label3.Text = $"{snaik_col}";
                //label4.Text = $"{}";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.W)
                dv = 0;
            if (e.KeyValue == (char)Keys.D)
                dv = 1;
            if (e.KeyValue == (char)Keys.S)
                dv = 2;
            if (e.KeyValue == (char)Keys.A)
                dv = 3;
            if (e.KeyValue == (char)Keys.Space)
            {
                if (timer1.Enabled == true)
                    timer1.Stop();
                else
                    timer1.Start();
            }
            if (e.KeyValue == (char)Keys.Escape)
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            level = 0;
            this.Controls.Remove(button1);
            this.Controls.Remove(button2);
            this.Controls.Remove(label4);
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            level = 1;
            this.Controls.Remove(button1);
            this.Controls.Remove(button2);
            this.Controls.Remove(label4);
            timer1.Start();
        }
    }
}
