using System;
using System.Collections.Generic;

namespace TestProject1
{
    internal class Sandbox
    {
        // Método auxiliar para imprimir el contenido de una pila (de cima a fondo).
        private static void PrintStack<T>(Stack<T> stack)
        {
            Console.WriteLine("Contenido de la pila (cima a fondo):");
            foreach (T item in stack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // Método auxiliar para imprimir el contenido de una cola (del frente al final).
        private static void PrintQueue<T>(Queue<T> queue)
        {
            Console.WriteLine("Contenido de la cola (frente a final):");
            foreach (T item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // Método auxiliar para imprimir el contenido de una lista.
        private static void PrintList<T>(List<T> list)
        {
            Console.WriteLine("Contenido de la lista:");
            foreach (T item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            // ******************************************
            // Ensayo para StackFirstPrime y RemoveFirstPrime
            // ******************************************
            // Creamos una pila con números enteros (< 100).
            Stack<uint> stack = new Stack<uint>(new uint[] { 2, 34, 67, 89, 12, 45, 78, 56, 23, 90, 14, 38 });
            Console.WriteLine("----- Ensayo de StackFirstPrime -----");
            PrintStack(stack);

            // Llamamos a la función que retorna el primer número primo en el orden de desapilado.
            uint primerPrimo = TestMethods.StackFirstPrime(stack);
            Console.WriteLine("Primer primo encontrado en la pila: " + primerPrimo);
            // Se espera que se imprima 23, según el criterio del taller.

            // Ensayo para RemoveFirstPrime: usamos una copia de la misma pila.
            Stack<uint> stackParaRemover = new Stack<uint>(new uint[] { 2, 34, 67, 89, 12, 45, 78, 56, 23, 90, 14, 38 });
            TestMethods.RemoveFirstPrime(stackParaRemover);
            Console.WriteLine("Pila después de remover el primer primo:");
            PrintStack(stackParaRemover);

            // ******************************************
            // Ensayo para CreateQueueFromStack
            // ******************************************
            Console.WriteLine("\n----- Ensayo de CreateQueueFromStack -----");
            // Usamos la pila original (sin modificar) para crear la cola.
            Queue<uint> queue = TestMethods.CreateQueueFromStack(stack);
            PrintQueue(queue);

            // ******************************************
            // Ensayo para StackToList
            // ******************************************
            Console.WriteLine("\n----- Ensayo de StackToList -----");
            List<uint> listFromStack = TestMethods.StackToList(stack);
            PrintList(listFromStack);

            // ******************************************
            // Ensayo para FoundElementAfterSorted
            // ******************************************
            Console.WriteLine("\n----- Ensayo de FoundElementAfterSorted -----");
            // Creamos una lista con números enteros.
            List<int> list = new List<int> { -50, 23, 87, -12, 4, 95, -66, 8, 32, -71, 42, -18 };
            // Llamamos a la función para ordenar la lista manualmente (bubble sort) y buscar el valor -50.
            bool found = TestMethods.FoundElementAfterSorted(list, -50);
            Console.WriteLine("¿Se encontró el elemento -50 en la lista ordenada? " + found);
            // Imprimimos la lista ordenada para confirmar el resultado.
            Console.WriteLine("Lista ordenada:");
            PrintList(list);

            // Pausa para ver los resultados en la consola.
            Console.ReadLine();
        }
    }
}
