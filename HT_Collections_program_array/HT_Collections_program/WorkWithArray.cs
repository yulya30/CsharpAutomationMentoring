using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_Collections_program
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] givenNewArray = new int[15] { 1, 2, 34, 22, 78, 45, 89, 99, 31, 33, 123, 456, 29, 90, 111};
            Console.WriteLine("Write the int value for 'n' which will show you this number of array values");
            int EnteredValueFirstTask = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            if (EnteredValueFirstTask >= 0 & EnteredValueFirstTask <= givenNewArray.Length)
            {
                for (i = 0; i < EnteredValueFirstTask; i++ )
                {
                    Console.WriteLine($"{givenNewArray[i]} ");
                }
            }
            else 
            {
                Console.WriteLine("The value you entered not in arry demantion");
            }
            Console.WriteLine("Write the int value for 'n' which will show you this number of array values");
            int EnteredValueSecondTask = Convert.ToInt32(Console.ReadLine());
            if (EnteredValueSecondTask >= 0 & EnteredValueSecondTask <= givenNewArray.Length)
            {
                for (i = givenNewArray.Length - 1; i >= givenNewArray.Length - EnteredValueSecondTask; i--)
                {
                    Console.WriteLine($"{givenNewArray[i]} ");
                }
            }
            else
            {
                Console.WriteLine("The value you entered not in arry demantion");
            }
            Console.ReadKey();
        }
    }
}
