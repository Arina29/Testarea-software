using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TriangleTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter triangle dimensions:");
            var a = Console.ReadLine();
            var b = Console.ReadLine();
            var c = Console.ReadLine();
            int i, j, k;
            bool msg = int.TryParse(a, out i) == true && int.TryParse(b, out j)== true && int.TryParse(c, out k) == true;
            if (msg == false)
            {
                Console.WriteLine("Values contains symbols or characters");
            }
            else
            {
                int[] values = new int[3] {Int32.Parse(a), Int32.Parse(b), Int32.Parse(c)};

                if (values[0] <= 0 || values[1] <= 0 || values[2] <= 0)
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (values[0] + values[1] <= values[2] || values[0] + values[2] <= values[1] ||
                         values[1] + values[2] <= values[0])
                {
                    Console.WriteLine("Not a triangle");
                }
                else if (values.Distinct().Count() == 1)
                {
                    Console.WriteLine("Equilateral triangle!");
                }
                else if (values.Distinct().Count() == 2)
                {
                    Console.WriteLine("Isoscel triangle!");
                }
                else
                {
                    Console.WriteLine("Scalen triangle");
                }
            }

            Console.ReadKey();
        }
    }
}
