using System;
using System.Collections;

namespace Yatest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // A number
            string a = "1737331";
            // B number
            string b = "0009";
            Console.WriteLine(Maximizenumber(a,b));

            //исходный массив
            int[] array = { 1000,12,890,100,7450,999,6000};
            //массив, отсортированный по сумме цифр 
            int[] result = Sortarraybysumofdigits(array);
            for(int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
        //максимизация числа A путём замены цифр числа B
        public static string Maximizenumber(string anumber,string bnumber)
        {
            //массивы из цифр
            int[] aarray;
            int[] barray;
            //проверка на то, являются ли строки числами
            bool isValid = int.TryParse(anumber,out int a) && int.TryParse(bnumber, out int b);
            //в случае успешной проверки
            if (isValid)
            {
                //заполнение массивов цифр
                aarray = anumber.ToCharArray().Select(i => int.Parse(i.ToString())).ToArray();
                barray = bnumber.ToCharArray().Select(i => int.Parse(i.ToString())).ToArray();
                //сортировка массива из цифр B в порядке убывания
                Array.Sort(barray);
                Array.Reverse(barray);
                //счётчик количества использованных цифр числа B
                int c = 0;
                //цикл по цифрам числа A
                for (int i = 0; i < aarray.Length; i++)
                {
                    //остановка работы цикла при использовании всех цифр числа B
                    if (c+1> barray.Length) break;
                    //если цифра числа A меньше цифры числа B, замена на цифру числа B
                    if (aarray[i] < barray[c])
                    {
                        aarray[i] = barray[c];
                        c++;
                    }
                }
                //возврат результата работы алгоритма в виде строки
                return string.Join("",aarray);
            }
            else throw new Exception("Строки не являются числами");
        }
        //сортировка чисел в массиве согласно сумме их цифр
        public static int[] Sortarraybysumofdigits(int[] array)
        {
            //создание отсортированного массива
            int[] result = array;
            //сортировка "пузырьком"
            for(int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length - i - 1; j++)
                {
                    //подсчёт суммы цифр чисел
                    int sum1 = result[j].ToString().ToCharArray().Select(i => int.Parse(i.ToString())).Sum();
                    int sum2 = result[j + 1].ToString().ToCharArray().Select(i => int.Parse(i.ToString())).Sum();
                    if (sum1 > sum2)
                    {
                        int k = result[j];
                        result[j] = result[j+1];
                        result[j+1] = k;
                    }
                }
                   
            }
            return result;
        }
    }
}