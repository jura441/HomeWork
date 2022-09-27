using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//double f, c;
//Console.WriteLine("Введите значения Цельсия");
//c = Convert.ToDouble(Console.ReadLine());
//f = c * 9 / 5 + 32;
//Console.WriteLine(c + "Градус Цельсия в Фаренгейт" + f + "F");

//Console.WriteLine("Введите значение Фаренгейта");
//f = Convert.ToDouble(Console.ReadLine());
//c = (f - 32) * 5 / 9;
//Console.WriteLine(f + "Фаренгейт в Цельсий" + c + "C");
//c = (f - 32) * 5 / 9;
//Console.WriteLine(f + "f в Цельсий" + c + "C");
//Console.ReadLine();



double num1, num2, num3, num4;
int result;

Console.WriteLine("Введите 1 цифру");
num1 = Double.Parse(Console.ReadLine());
Console.WriteLine("Введите 2 цифру");
num2 = Double.Parse(Console.ReadLine());
Console.WriteLine("Введите 3 цифру");
num3 = Double.Parse(Console.ReadLine());
Console.WriteLine("Введите 4 цифру");
num4 = Double.Parse(Console.ReadLine());

result = (int)num1 * 1000 + (int)num2 * 100 + (int)num3 * 10 + (int)num4;
Console.WriteLine("Полученный результат = {0}", result);