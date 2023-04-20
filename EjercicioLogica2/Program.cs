using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioLogica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            int resultado = 1;

            Console.WriteLine("Escribe el numero para obtener factorial:");
            numero = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numero; i++)
            {
                resultado = resultado * i;
            }
            Console.WriteLine("El factorial de " + numero + " es: " + resultado);

            Console.ReadKey();
        }
    }
}

