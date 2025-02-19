using System.Collections.Generic;

namespace TestProject1
{
    internal class TestMethods
    {
        // Función auxiliar para determinar si un numero es primo.
        // Retorna true si el numero es primo, false en caso contrario
        private static bool IsPrime(uint num)
        {
            // Los números menores a 2 no son primos
            if (num < 2) 
                return false;

            // Se itera desde 2 hasta la raiz cuadrada de num para comprobar si tiene divisores,
            for (uint i = 2; i * i <= num; i++)
            {
                // Si num es divisible por i (2), no es primo
                if (num % i == 0)
                    return false;
            }
            // Si no se encontro ningun divisor, el numero es primo
            return true;
        }

        // Función para encontrar el primer numero primo en una pila 
        // Se convierte la pila a un arreglo para recorrerla en el mismo orden de desapilado (la cima es el índice 0
        // Si se encuentra un número primo, se retorna; de lo contrario, se retorna 0
        internal static uint StackFirstPrime(Stack<uint> stack)
        {
            // Convertimos la pila a un arreglo; el método ToArray() devuelve los elementos 
            // en el orden en que se desapilarían (índice 0 = cima de la pila)
            uint[] elementos = stack.ToArray(); // Recorremos el arreglo de elementos
            foreach (uint num in elementos) {   // Si el número es primo, se retorna inmediatamente
                if (IsPrime(num))  // Si ningún elemento es primo, se retorna 0
                    return num; 
            }
            return 0;
        }

        // Función para eliminar el primer número primo encontrado en la pila
        // Se utiliza una pila auxiliar para almacenar temporalmente los elementos hasta encontrar el primo
        // Luego se reconstruye la pila original preservando el orden de los elementos restantes.
        internal static Stack<uint> RemoveFirstPrime(Stack<uint> stack)
        {
            // Creamos una pila auxiliar para almacenar los elementos.
            Stack<uint> aux = new Stack<uint>();
            // Bandera para indicar si ya se eliminó un primo.
            bool removed = false;

            // Mientras la pila original no esté vacía...
            while (stack.Count > 0)
            {
                // Extraemos (desapilamos) el elemento superior
                uint num = stack.Pop();
                // Si aún no se ha eliminado ningún primo y el número es primo...
                if (!removed && IsPrime(num))
                {
                    removed = true;  // Marcamos que se encontró y se eliminará el primer primo encontrado
                    continue; // Omitimos agregar este número a la pila auxiliar
                }
                // Si no se cumple lo anterior, agregamos el elemento a la pila auxiliar
                aux.Push(num);
            }

            // Reconstruimos la pila original a partir de la auxiliar para preservar el orden. 
            while (aux.Count > 0)
            {
                stack.Push(aux.Pop());
            }

            // Retornamos la pila modificada (sin el primer primo encontrado) ejemplo: 1, 2, 4, 5 (sin el 3) por poner un ejemplo
            return stack;
        }

        // Función para crear una cola a partir de los elementos de una pila
        // Se recorre la pila en su orden de enumeración (de la cima al fondo) y se encola cada elemento.
        internal static Queue<uint> CreateQueueFromStack(Stack<uint> stack)
        {
            // Creamos una nueva cola vacía.
            Queue<uint> queue = new Queue<uint>();
            // Recorremos la pila; la enumeracion de la pila es de la cima al fondo
            foreach (uint num in stack)
            {
                // Se encola cada elemento en el mismo orden
                queue.Enqueue(num);
            }
            // Retornamos la cola resultante
            return queue;
        }

        // Función para convertir una pila en una lista, respetando el orden de la pila (cima a fondo).
        internal static List<uint> StackToList(Stack<uint> stack)
        {
            // Convertir la pila a lista respetando el orden de enumeración (de cima a fondo)
            // Se crea una lista vacía.
            List<uint> list = new List<uint>();
            // Se recorre la pila en su orden de enumeración.
            foreach (uint num in stack)
            {
                // Se añade cada elemento a la lista
                list.Add(num);
            }
            // Retornamos la lista construida
            return list;
        }

        // Función para ordenar una lista de enteros de forma ascendente usando bubble sort (implementación manual)
        // y luego determinar si un valor específico se encuentra en la lista.
        internal static bool FoundElementAfterSorted(List<int> list, int value)
        {
            // Implementación manual del algoritmo bubble sort para ordenar la lista.
            int n = list.Count;
            // Se realizan n-1 pasadas sobre la lista.
            for (int i = 0; i < n - 1; i++)
            {
                // En cada pasada se comparan elementos adyacentes.
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Si el elemento actual es mayor que el siguiente, se intercambian.
                    if (list[j] > list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            // Una vez ordenada la lista, se recorre para buscar el valor especificado.
            foreach (int num in list)
            {
                // Si se encuentra el valor, se retorna true.
                if (num == value)
                    return true;
            }
            // Si no se encuentra el valor, se retorna false
            return false;
        }
    }
}