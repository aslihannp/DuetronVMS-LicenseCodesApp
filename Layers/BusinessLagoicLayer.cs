﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.BusinessLogicLayer
{
    public class BLL
    {
        //bu katman using interface ile db logic layer arasında duran ve verinin kontrolünü sağlayan katmandır
        DatabaseLogicLayer.DLL dll;

        public BLL()
        {
            dll = new DatabaseLogicLayer.DLL();

        }
    
        public int SistemKontrolu(string kullaniciAdi, string sifre)
        {
            if (!string.IsNullOrEmpty(kullaniciAdi) && !string.IsNullOrEmpty(sifre))
            {
                Entities.UsersTable us = new Entities.UsersTable()
                {
                    KullaniciAdi = kullaniciAdi,
                    Sifre = sifre
                };



            return dll.SistemKontrolu(us);
            }
            else
                return -1;
        }
        public int MusteriEkle(int UC,string Clientname )
        {
            if (!string.IsNullOrEmpty(Clientname) && UC!=0)
            {
                Entities.ClientTable nesne = new Entities.ClientTable()
                {
                    UC = UC,
                    ClientName = Clientname
                };
                return dll.MusteriEkle(nesne); 
               
            }
            else
                return -1; // eksik parametre hatası

        }

        public int MusteriDuzenle(int UC,string Clientname)
        {
            if (UC != 0)
            {
                Entities.ClientTable nesneDuzenle = new Entities.ClientTable() {
                    UC = UC,
                    ClientName = Clientname
                };
                return dll.MusteriDüzenle(nesneDuzenle);
            }
            else
            {
                return -1;
            }
        }

        public int MusteriSil(int UC,out string hata)
        {
            hata = "";
            if (UC!=0)
            {
                Entities.ClientTable nesneSil = new Entities.ClientTable()
                {
                    UC = UC,
                 

                };
                return dll.MusteriSil(nesneSil,out hata);
            }
            else
                return - 1;
        }

        public int SatisKaydiEkle(int ULC, int UC,string ClientName, int Kamera,int nvr,int videoDuvar, int IsIstasyonu,int Keyboard, DateTime SatisTarihi,string LisansKodu, string DonanimId,string Notes, out string errorMes)
        {
            errorMes = "";
            if (ULC != 0 && UC != 0 && !string.IsNullOrEmpty(LisansKodu))
            {
                Entities.SalesTable satisNesne = new Entities.SalesTable()
                {
                    ULC = ULC,
                    UC = UC,
                    ClientName = ClientName,
                    Camera = Kamera,
                    NVR = nvr,
                    VideoDuvar = videoDuvar,
                    IsIstasyonu = IsIstasyonu,
                    Keyboard = Keyboard,
                    SatisTarihi = SatisTarihi,
                    LisansKodu = LisansKodu,
                    DonanimID = DonanimId,
                    Notes=Notes

                };
                return dll.SatisKaydiEkle(satisNesne,out errorMes);
            }
            else
                return -1; 
        }

        public int SatisKaydiDuzenle(int ULC, int UC, int Kamera, int nvr, int videoDuvar, int IsIstasyonu, int Keyboard, DateTime SatisTarihi, string LisansKodu, string DonanimId,string notes)
        {
            if (ULC != 0 && UC != 0 )
            {
                Entities.SalesTable satisNesne = new Entities.SalesTable()
                {
                    ULC = ULC,
                    //UC = UC,
                    //ClientName = ClientName,
                    Camera = Kamera,
                    NVR = nvr,
                    VideoDuvar = videoDuvar,
                    IsIstasyonu = IsIstasyonu,
                    Keyboard = Keyboard,
                    SatisTarihi = SatisTarihi,
                    LisansKodu = LisansKodu,
                    DonanimID = DonanimId,
                    Notes=notes

                };
                return dll.SatisKaydiDuzenle(satisNesne);
            }
            else
                return -1;
        }

        public int SatisKaydiSil(int ULC)
        {
            if (ULC != 0)
            {
                Entities.SalesTable satisNesne = new Entities.SalesTable()
                {
                    ULC = ULC,
                   
                };



                return dll.SatisKaydiSil(satisNesne);
            }
            else
                return -1;
        }





    }

   
}
