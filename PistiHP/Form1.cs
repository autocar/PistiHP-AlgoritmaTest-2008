using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PistiHP
{
    public partial class Form1 : Form
    {

        string a,sonkart,str,copi,kescpu,kes1;
        Int32 i, j, x, y,kartSay,kartSay2,sira=1,kont,k,kartkont;
        Int32[,] kart=new Int32[13,4];
        String[]  ilk= new String[5];
        String[] oyuncu = new String[4];
        String[] oyuncuKes = new String[4];
        String[] cpu = new String[4];
        String[,] oyuncuAll = new String[13, 4];
        String[,] cpuAll = new String[13, 4];

        Int32[] kontrol = new Int32[52];

        private Random x1;
        private Random x2;


        public Form1()
        {
            InitializeComponent();
        }

        private void reset()
        {
            listBoxChat.Items.Clear();
            listBoxIlk.Items.Clear();
            listBoxAllKart.Items.Clear();
            listBoxBil.Items.Clear();
            listBoxBilgisayar.Items.Clear();
            listBoxBilgisayarWin.Items.Clear();
            listBoxOy.Items.Clear();
            listBoxOyuncu.Items.Clear();
            listBoxOyuncuWin.Items.Clear();
            listBoxYer.Items.Clear();
            sira = 1;
            for (i = 0; i <= 13 - 1; i++)
            {
                for (j = 0; j <= 4 - 1; j++)
                {
                    oyuncuAll[i, j] = "";
                    cpuAll[i, j] = "";
                    kart[i, j] = 1;
                }
            }
            for (i = 0; i <= 4 - 1; i++)
            {
                oyuncuKes[i] = "";
                oyuncu[i] = "";
                cpu[i] = "";
            }
            for (i = 0; i <= 5 - 1; i++)
            {
                ilk[i] = "";
            }
        }
      
        private string  kartAd(int x,int y)
        {
            if (x >= 0 && x <= 9 && y == 0) { a = "Snek_" + (x + 1); }
            if (x >= 0 && x <= 9 && y == 1) { a = "Maca_" + (x + 1); }
            if (x >= 0 && x <= 9 && y == 2) { a = "Karo_" + (x + 1); }
            if (x >= 0 && x <= 9 && y == 3) { a = "Kupa_" + (x + 1); }
            if (x == 10 && y == 0)          { a = "Snek_Vale" ; }
            if (x == 10 && y == 1)          { a = "Maca_Vale"; }
            if (x == 10 && y == 2)          { a = "Karo_Vale"; }
            if (x == 10 && y == 3)          { a = "Kupa_Vale";  }
            if (x == 11 && y == 0)          { a = "Snek_Kýz"; }
            if (x == 11 && y == 1)          { a = "Maca_Kýz" ;}
            if (x == 11 && y == 2)          { a = "Karo_Kýz";}
            if (x == 11 && y == 3)          { a = "Kupa_Kýz" ;}
            if (x == 12 && y == 0)          { a = "Snek_Papaz" ; }
            if (x == 12 && y == 1)          { a = "Maca_Papaz" ;}
            if (x == 12 && y == 2)          { a = "Karo_Papaz" ;}
            if (x == 12 && y == 3)          { a = "Kupa_Papaz"; }

            return a;
        }

        private void allKartDoldur()
        {
            listBoxAllKart.Items.Clear();
            for (i = 0; i <= 13 - 1; i++)
            {
                for (j = 0; j <= 4 - 1; j++)
                {
                    if (kart[i, j] == 1) { listBoxAllKart.Items.Add(kartAd(i, j)); }
                }
            }
        }

        private void ilkKartlar()
        {
            Quick x1 = new Quick();
            Quick x2 = new Quick();
            
            
                kartSay = 1;
            etiket:
                ilk[0] = "dolu";
                x=x1.Next(12);
                y=x2.Next(3);
                if (kart[x, y] == 0)
                {
                    goto etiket;
                }
                else
                {
                    kart[x , y] = 0;
                    ilk[kartSay] = kartAd(x , y);
                    listBoxIlk.Items.Add(kartAd(x, y));
                    kartSay++;
                    sonkart = kartAd(x, y);
                    if (kartSay == 5) 
                    {
                      
                    } 
                    else 
                    { 
                        goto etiket; 
                    }
                   
                }
                listBoxIlk.Items.RemoveAt(3);
                listBoxYer.Items.Add(sonkart); 
                label9.Text = sonkart;
                allKartDoldur();
        
        }

        

        private void kartVer()
        {
            Quick x1 = new Quick();
            Quick x2 = new Quick();
            

            listBoxBil.Items.Clear();
            listBoxOy.Items.Clear();
            kartSay = 0;
            kartSay2 = 0;
        etiket:
            y = x1.Next(3);
            x= x2.Next(12);
           
            if (kart[x, y] == 0)
            {
                goto etiket;
            }
            else
            {
                kart[x, y] = 0;
                if (kartSay == 4) 
                {
                    cpu[kartSay2] = kartAd(x, y);
                    listBoxBil.Items.Add(kartAd(x, y));
                    kartSay = 3;
                    kartSay2++;
                } 
                else 
                {
                    oyuncu[kartSay] = kartAd(x, y);
                    listBoxOy.Items.Add(kartAd(x, y));
                }
                kartSay++;
                if (kartSay2 == 4)
                {
                }
                else
                {
                    goto etiket;
                }

            }
        //    kartSay = 0;
        //etiket2:
        //    x = x1.Next(0, 12);
        //    y = x2.Next(0, 3);
        //    if (kart[x, y] == 0)
        //    {
        //        goto etiket2;
        //    }
        //    else
        //    {
        //        kart[x, y] = 0;
        //        oyuncu[kartSay] = kartAd(x, y);
        //        listBoxOy.Items.Add(kartAd(x, y));
        //        kartSay++;
        //        if (kartSay == 4)
        //        {
        //        }
        //        else
        //        {
        //            goto etiket2;
        //        }

        //    }
            allKartDoldur();
    
            button1.Visible = false;
           // timer1.Enabled = true;
        }

        private void oyuncuOyna()
        {
            a = ""; 
           
            if (sira == 1)
            { 
                if (listBoxOy.Items.Count != 0)
                {

                    a = listBoxOy.SelectedItem.ToString();

                    listBoxYer.Items.Add(a);
                    for (i = 0; i <= 3; i++)
                    {
                        if (oyuncu[i] == a)
                        {
                            //oyuncuKes[i] = "";
                            oyuncu[i] = "";
                            listBoxOy.Items.Clear();
                            for (j = 0; j <= 3; j++)
                            {
                                if (oyuncu[j] != "")
                                    listBoxOy.Items.Add(oyuncu[j]);
                            }
                            
                            break;
                        }

                    }


                    if (listBoxOy.Items.Count != 0)
                    {
                        listBoxOy.SetSelected(0, true);
                    }
                    //yerden kart kazanma
                    str = a.Remove(0, 4);

                    if (sonkart != "")
                    {
                        copi = sonkart.Remove(0, 4);
                        // sira = 0;
                        if ((copi == str) || (str == "_Vale"))
                        {
                            listBoxOyuncu.Items.AddRange(listBoxIlk.Items);
                            listBoxIlk.Items.Clear();
                            listBoxOyuncu.Items.AddRange(listBoxYer.Items);
                            listBoxYer.Items.Clear();
                            listBoxChat.Items.Add("Oyuncu1: " + a+ " ile Masadaki Kartlarý Silip Süpürdü :)");
                             a = "";  
                        }
                    }
                    //yerden kart kazanma bitiþ
                    sonkart = a;
                    if (a == "")
                    {
                        label9.Text = "Boþ";
                    }
                    else
                    {
                        label9.Text = a;
                    }
                }
                sira = 0;
                timer1.Enabled = true;
            }
        }


        private void cpuOyna()
        {
            Quick x1 = new Quick();
            Quick x2 = new Quick();
            Dispose(x2);
            if (sonkart == ""  && sira==0)
            {
                for (i = 0; i <= 3; i++)
                {
                    if (cpu[i] != ""){ kescpu = cpu[i].Remove(0, 4); }
                    for (k = 0; k <= 3; k++)
                    {
                        if (oyuncu[k] != "") { oyuncuKes[k] = oyuncu[k].Remove(0, 4); }
                    }

                    if (kescpu != oyuncuKes[0] && kescpu != oyuncuKes[1] && kescpu != oyuncuKes[2] && kescpu != oyuncuKes[3] && cpu[i]!="" && sonkart=="")
                    {
                        sira = 1;
                        kont = 0;
                        a = cpu[i];
                        cpu[i] = "";
                        listBoxBil.Items.Clear();
                        listBoxYer.Items.Add(a);
                        for (k = 0; k <= 3; k++)
                        {
                            if (cpu[k] != "")
                                listBoxBil.Items.Add(cpu[k]);
                        }
                        sonkart = a;
                        label9.Text = a;
                        break;

                    }
                }
                if (kont == 1 && sonkart=="")
                {
                      sira = 1;
                      x = x1.Next(3);
                      a = cpu[x];
                      cpu[i] = "";
                      listBoxBil.Items.Clear();
                      listBoxYer.Items.Add(a);
                      for (k = 0; k <= 3; k++)
                      {
                          if (cpu[k] != "")
                              listBoxBil.Items.Add(cpu[k]);
                      }
                  }
                  sonkart = a;
                  label9.Text = a;

              }
            if(sonkart!="" && sira==0)
            {
                
                for (i = 0; i <= 3; i++)
                {
                    if (cpu[i] != ""){  kescpu = cpu[i].Remove(0, 4);   }   
                    kes1 = sonkart.Remove(0, 4);
                    if (kescpu == kes1) //yerdeki son kart pc ninkiyle aynýysa
                    {
                        sira = 1;
                        kont = 0;
                        a = cpu[i];
                        cpu[i] = "";
                        listBoxYer.Items.Add(a);
                        listBoxBil.Items.Clear();
                        for (k = 0; k <= 3; k++)
                        {
                            if (cpu[k] != ""){  listBoxBil.Items.Add(cpu[k]);    }     
                        }
                        //yerden kart kazanma
                            listBoxBilgisayar.Items.AddRange(listBoxIlk.Items);
                            listBoxIlk.Items.Clear();
                            listBoxBilgisayar.Items.AddRange(listBoxYer.Items);
                            listBoxYer.Items.Clear();
                            sonkart = "";
                            label9.Text = "Boþ";
                        //yerden kart kazanma bitiþ
                           listBoxChat.Items.Add("Cpu: " + a + " ile Masadaki Kartlarý Topladý :)");
                        break;
                    }
                    else if(kescpu == "_Vale")
                    {
                        sira = 1;
                        kont = 0;
                        a = cpu[i];
                        cpu[i] = "";
                        listBoxYer.Items.Add(a);
                        listBoxBil.Items.Clear();
                        for (k = 0; k <= 3; k++)
                        {
                            if (cpu[k] != ""){  listBoxBil.Items.Add(cpu[k]);   }  
                        }
                        //yerden kart kazanma
                            listBoxBilgisayar.Items.AddRange(listBoxIlk.Items);
                            listBoxIlk.Items.Clear();
                            listBoxBilgisayar.Items.AddRange(listBoxYer.Items);
                            listBoxYer.Items.Clear();
                            sonkart = "";
                            label9.Text = "Boþ";
                        //yerden kart kazanma bitiþ
                            listBoxChat.Items.Add("Cpu: " + a +" ile Masadaki Kartlarý Cebe Ýndirdi. Bilgisayar Senin Kaðýtlatýný Görüo :)");
                        break;
                    }


                }
                for (i = 0; i <= 3; i++)
                {
                    if (cpu[i] != "") {   kescpu = cpu[i].Remove(0, 4);   }
                    for (k = 0; k <= 3; k++)
                    {
                        if (oyuncu[k] != "") { oyuncuKes[k] = oyuncu[k].Remove(0, 4); }
                    }
                    if (kescpu != oyuncuKes[0] && kescpu != oyuncuKes[1] && kescpu != oyuncuKes[2] && kescpu != oyuncuKes[3] && cpu[i]!="" && sonkart!="")
                    {
                        sira = 1;
                        kont = 0;
                        a = cpu[i];
                        cpu[i] = "";
                        listBoxYer.Items.Add(a);
                        listBoxBil.Items.Clear();
                        for (k = 0; k <= 3; k++)
                        {
                            if (cpu[k] != "") {   listBoxBil.Items.Add(cpu[k]);   }
                                
                        }
                        sonkart = a;
                        label9.Text = a;
                        break;

                    }
                }
                //if (kont == 1 && sira == 0)
                //{
                //    sira = 1;
                //    x = x1.Next(0, 3);
                //    a = cpu[x];
                //    cpu[i] = "";
                //    listBoxBil.Items.Clear();
                //    listBoxYer.Items.Add(a);
                //    for (k = 0; k <= 3; k++)
                //    {
                //        if (cpu[k] != "")
                //            listBoxBil.Items.Add(cpu[k]);
                //    }
                //}


                //sonkart = a;
                //if (a == "")
                //{
                //    label9.Text = "Boþ";
                //}
                //else { label9.Text = a; }

            }
        }



        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            reset();  
            allKartDoldur();
            ilkKartlar();
            kartVer();

            timer1.Enabled = true;     
        }
   


        private void Form1_Load(object sender, EventArgs e)
        {

            reset();
            allKartDoldur();

        }

        private void listBoxOy_DoubleClick(object sender, EventArgs e)
        {
            oyuncuOyna();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            label9.Text = sonkart;
            if (listBoxBil.Items.Count == 0)
            {
               // kartVer();
                button1.Visible = true;
                timer1.Enabled = false;
            }
                kont = 1;
            if (listBoxYer.Items.Count == 0) { sonkart = ""; label9.Text = "bos"; }
            if (sira == 1)
            {

                listBoxBil.BackColor = Color.Black;
                listBoxOy.BackColor = Color.Red;
                timer1.Enabled = false;
            }
            if (sira == 0) 
            {
                cpuOyna();
                listBoxBil.BackColor = Color.Red;
                listBoxOy.BackColor = Color.Black;
            }
            

        }

       

 

       
        private void button1_Click(object sender, EventArgs e)
        {
            kartVer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBoxAllKart.Visible = !listBoxAllKart.Visible;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBoxBil.Visible = !listBoxBil.Visible;
        }

        


    }
}