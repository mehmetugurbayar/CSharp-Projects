using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusParaHesap
{
    class Program /*programa kaç öğrenci yada kaç tam olduğunu söyler 
                    makine ne kadar ücret istediğini söyler
                     para verilir para üstü hesaplanır verilir
                     eğer para eksik verilirse parayı eksik verdiniz desin (şu kadar daha para verin der (ilk verilen paradan bilet miktarını çıkar))
                     */
    {

        static void Main(string[] args)
        {
            Otobus oto = new Otobus();



            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("*************|E-BUS'E HOŞGELDİNİZ|**************\n================================================\n");
                Console.WriteLine("Öğrenci için  1'e Basın      Fiyat: 1.75 TL");
                Console.WriteLine("Tam için      2'e Basın      Fiyat: 3.90 TL ");
                int musteritercihi = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (musteritercihi)
                {
                    #region Ogrenci
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Kaç kişi: ");
                        oto.ogrenci_mik = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Ödeyeceğiniz Ücret: " + oto.OgrenciFiyatHesap(oto.ogrenci_mik) + " " + oto.Tl);

                        Console.Write("Parayı Ver : ");
                        oto.Ogr_para = Convert.ToDouble(Console.ReadLine());


                        if (oto.Ogr_para <= oto.OgrenciFiyatHesap(oto.ogrenci_mik) && oto.Ogr_para != oto.OgrenciFiyatHesap(oto.ogrenci_mik))
                        {

                            Console.WriteLine("Eksik Para Verdiniz");
                            double eksikparakurtarici = Math.Abs(oto.OgrParaUstu(oto.Ogr_para));
                            Console.WriteLine(eksikparakurtarici + " TLDaha Para Veriniz.  \n \n");
                            Console.WriteLine("Parayı Ver:");
                            oto.Ogr_para = Convert.ToDouble(Console.ReadLine());
                            if (oto.Ogr_para < eksikparakurtarici) //eksik verilen paranın devamını almak için 
                            {
                                Console.WriteLine("İşleminiz İptal Ediliyor.....");  //eğer yine eksik para verilirse işlem iptal edilir ve başa döner
                                Console.WriteLine("Lütfen Tekrar Deneyiniz.");

                                break;
                            }
                            else if (oto.Ogr_para == eksikparakurtarici) //eğer para tam verilirse biter
                            {
                                Console.Clear();
                                Console.Write("E-BUS İYİ YOLCULUKLAR DİLER");
                                break;
                            }

                            else
                            {

                                double ogr_para_kurtarici = oto.Ogr_para - eksikparakurtarici;  //eğer fazla para verirse para üstünü verecek 
                                Console.Write("Para Üstünüz: " + ogr_para_kurtarici + " " + oto.Tl);


                                break;

                            }

                        }
                        else
                        {
                            Console.Write("Para Üstünüz: " + oto.OgrParaUstu(oto.Ogr_para) + " " + oto.Tl);
                            Console.WriteLine("\n E-BUS İYİ YOLCULUKLAR DİLER \n");
                        }

                        break;
                    #endregion

                    case 2: // TAM BİLET KISMI 
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        Console.Write("Kaç kişi: ");
                        oto.tambilet_mik = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ödeyeceğiniz Ücret: " + oto.TamBilet(oto.tambilet_mik) + " " + oto.Tl);
                        Console.Write("Parayı Verin: ");
                        oto.Tam_para = Convert.ToDouble(Console.ReadLine());

                        if (oto.Tam_para <= oto.TamBilet(oto.tambilet_mik) && oto.Tam_para != oto.TamBilet(oto.tambilet_mik))
                        {

                            Console.WriteLine("Eksik Para Verdiniz");
                            double eksikparakurtarici = Math.Abs(oto.TamParaUstu(oto.Tam_para));
                            Console.WriteLine(eksikparakurtarici + " TL Daha Para Veriniz.  \n \n");
                            Console.WriteLine("Parayı Ver:");
                            oto.Tam_para = Convert.ToDouble(Console.ReadLine());
                            if (oto.Tam_para < eksikparakurtarici) //eksik verilen paranın devamını almak için 
                            {
                                Console.WriteLine("İşleminiz İptal Ediliyor.....");  //eğer yine eksik para verilirse işlem iptal edilir ve başa döner
                                Console.WriteLine("Lütfen Tekrar Deneyiniz.");

                                break;
                            }
                            else if (oto.Tam_para == eksikparakurtarici) //eğer para tam verilirse biter
                            {
                                Console.Clear();
                                Console.Write("E-BUS İYİ YOLCULUKLAR DİLER");
                                break;
                            }

                            else
                            {
                                double tam_para_kurtarici = oto.Tam_para - eksikparakurtarici;  //eğer fazla para verirse para üstünü verecek 
                                Console.Write("Para Üstünüz: " + tam_para_kurtarici + " " + oto.Tl + " \n ");

                                break;

                            }

                        }
                        else
                        {
                            Console.Write("Para Üstünüz: " + oto.TamParaUstu(oto.Tam_para) + " " + oto.Tl + " \n ");
                            Console.WriteLine(" E-BUS İYİ YOLCULUKLAR DİLER \n");
                        }
                        break;

                    default:
                        Console.WriteLine("Yanlış Giriş Yaptınız..");
                        break;


                }
            }
        }
    }
    class Otobus
    {
        public double ogrenci_mik;
        public int tambilet_mik;
        private double tam_para;
        private double ogr_para;
        public string Tl = " TL";

        public double Ogr_para
        {
            get
            {
                return this.ogr_para;
            }
            set
            {


                ogr_para = value;
            }
        }

        public double Tam_para
        {
            get
            {
                return this.tam_para;
            }
            set
            {
                tam_para = value;
            }
        }

        public double TamParaUstu(double para)
        {
            double sonuc;
            sonuc = Tam_para - TamBilet(tambilet_mik); //verilen paradan binen tam sayısının tl değeri çıkarılır
            return sonuc;
        }
        public double OgrParaUstu(double para) //ogrenci için paraüstü hesabı
        {
            double sonuc;
            sonuc = Ogr_para - OgrenciFiyatHesap(ogrenci_mik); // verilen paradan binen öğrenci sayısının tl değeri çıkarılır
            return sonuc;

        }
        public double OgrenciFiyatHesap(double kac_ogrenci) //öğrenci için ücret hesabı
        {
            double fiyat = 1.75;
            double sonuc = kac_ogrenci * fiyat;
            return sonuc;
        }
        public double TamBilet(double kac_kisi)//tam için ücret hesabı 
        {
            double tam = 3.90;
            double sonuc = kac_kisi * tam;
            return sonuc;
        }
    }
}
