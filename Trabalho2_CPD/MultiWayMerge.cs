using System; // Console
using System.Collections.Generic; // List e Queue
using System.Diagnostics; // Timer


namespace Lab_2
{
    partial class Ex_2 : Lab_2
    {
        void mergeSortedArrays(ref List<Queue<int>> input, ref List<int> output)
        {
            Stopwatch t = new Stopwatch(); // Timer
            int index_menor;
            bool ordenado = false;

            t.Restart(); // Zera e inicia o timer

            while (!ordenado) // Quando ordenado for verdadeiro, é pq todas as filas estão vazias e a lista output está ordenada
            {
                ordenado = true; // Ordenado até que se prove o contrário ;D

                index_menor = 0; // No início, o menor elemento é o do topo da primeira fila

                for (int i = 0; i < NUM_FILES; i++)
                {

                    if (input[i].Count > 0) // Se fila não possui elementos, pula para próxima
                    {
                        ordenado = false; // Aqui está a prova que não está ordenado, pois ainda existem dados nas filas
                        while (input[index_menor].Count == 0) index_menor++;
                        if (input[i].Peek() < input[index_menor].Peek()) // Método .Peek é equivalente ao topFromArray
                            index_menor = i; // Se algum elemento é menor que o index, torna-se o novo index
                    }

                }

                if(input[index_menor].Count > 0) output.Add(input[index_menor].Dequeue()); // Adiciona o menor elemento encontrado à lista 'output' (popFromArray)
                    
            }

            t.Stop();
            Console.WriteLine("Time: " + t.ElapsedTicks / 10 + " us"); // Cada 'Tick' são 100 nanosegundos
        }
    }
}
