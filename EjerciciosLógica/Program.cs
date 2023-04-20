using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosLógica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] MatrizA = new int[10, 10];
            int[,] MatrizB = new int[10, 10];
            int[,] MatrizResultado = new int[10, 10];

            Console.WriteLine("Ingresando Matriz A");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("Ingrese posicion [" + i + "," + j + "]: ");
                    string linea;
                    linea = Console.ReadLine();
                    MatrizA[i, j] = int.Parse(linea);
                }
            }

            Console.WriteLine("Ingresando Matriz B");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("Ingrese posicion [" + i + "," + j + "]: ");
                    string linea;
                    linea = Console.ReadLine();
                    MatrizB[i, j] = int.Parse(linea);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    MatrizResultado[i, j] = MatrizA[i, j] + MatrizB[i, j];
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Resultado");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(MatrizResultado[i, j] + " ");
                }

            }
            Console.ReadKey();
        }
    }
}

