﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop store = new Shop("Леденцы Дюшес ", " Счастливая 42в ", " Кондитерский универсам ", " 8(989)999-22-90 ", " dysha_store@mail.ru", 45);
            Shop store2 = new Shop("Шоколадки Милка", " Печальная 40 ", " Кондитерский универсам ", " 8(928)199-99-22 ", " shok_milka_store@mail.ru", 55);
            store.GetShopInfo();
            int newstoreroom = 31; store._shoparea += newstoreroom;
            store.GetShopInfo();
            int storeroom = 22; store._shoparea -= storeroom;
            store.GetShopInfo();
            Console.WriteLine(store == store2);
            Shop shop3 = new Shop("Шоколадки Милка ", " Печальная 40 ", " Кондитерский универсам ", " 8(928)199-99-22 ", " shok_milka_store@mail.ru", 55);
            shop3.AddShop();
            shop3.GetShopInfo();
        }
    }
    class Shop
    {
        public string _nameShop { get; set; }
        public string _addressShop { get; set; }
        public string _profShop { get; set; }
        public string _emailShop { get; set; }
        public string _phoneShop { get; set; }
        public int _shoparea { get; set; }
        //GetSet Methods

        //Constructor
        public Shop(string name, string address, string profshop, string phoneshope, string email, int shoparea)
        {
            _nameShop = name;
            _addressShop = address;
            _profShop = profshop;
            _phoneShop = phoneshope;
            _emailShop = email;
            _shoparea = shoparea;
        }

        public Shop()
        {

        }

        public static int operator +(Shop shoparea, int addshoparea)
        {
            shoparea._shoparea += addshoparea;
            return shoparea._shoparea;
        }
        public static bool operator ==(Shop shoparea, Shop othersharea)
        {
            return shoparea._shoparea == othersharea._shoparea;
        }
        public static bool operator !=(Shop shoparea, Shop othersharea)
        {
            return shoparea._shoparea != othersharea._shoparea;
        }
        public static bool operator <(Shop shoparea, Shop othersharea)
        {
            return shoparea._shoparea < othersharea._shoparea;
        }
        public static bool operator >(Shop shoparea, Shop othersharea)
        {
            return shoparea._shoparea > othersharea._shoparea;
        }
        public static int operator -(Shop shoparea, int reduceshoparea)
        {
            shoparea._shoparea -= reduceshoparea;
            return shoparea._shoparea;
        }
        public Shop AddShop()
        {
            //не могу понять почему не работает метод добавления 
            Shop shop;
            Console.Write("Введите название магазина:"); string shname = Console.ReadLine();
            Console.Write("Введите адресс магазина:"); string addres = Console.ReadLine();
            Console.Write("Введите профиль магазина:"); string profShop = Console.ReadLine();
            Console.Write("Введите номер телефона магазина:"); string phonenumber = Console.ReadLine();
            Console.Write("Введите эл.почту магазина:"); string email = Console.ReadLine();
            Console.Write("Введите площадь магазина:"); int area = Int32.Parse(Console.ReadLine());
            shop = new Shop(shname, addres, profShop, phonenumber, email, area);
            return shop;
        }
        public override string ToString()
        {
            return " Магазин: " + _nameShop + ";\n Адресс: " + _addressShop + ";\n Профиль магазина: " + _profShop + ";\n Номер телефона: " + _phoneShop + ";\n Адресс эл.почты: " + _emailShop + ";\n Площадь: " + _shoparea.ToString() + " квадратных метров";
        }
        public void GetShopInfo()
        {
            Console.WriteLine(ToString());
        }

        public override bool Equals(object obj)
        {
            return obj is Shop shop &&
                   _nameShop == shop._nameShop &&
                   _addressShop == shop._addressShop &&
                   _profShop == shop._profShop &&
                   _emailShop == shop._emailShop &&
                   _phoneShop == shop._phoneShop &&
                   _shoparea == shop._shoparea;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(_nameShop);
            hash.Add(_addressShop);
            hash.Add(_profShop);
            hash.Add(_emailShop);
            hash.Add(_phoneShop);
            hash.Add(_shoparea);
            return hash.ToHashCode();
        }
    }
}
