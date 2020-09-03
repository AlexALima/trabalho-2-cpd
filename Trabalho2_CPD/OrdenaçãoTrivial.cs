using System; // Console
using System.Collections.Generic; // List e Queue
using System.Diagnostics; // Timer


namespace Lab_2
{
    partial class Ex_2 : Lab_2
    {
        void ordenacaoTrivial(ref List<Queue<int>> input, ref List<int> output)
        {
            Stopwatch t = new Stopwatch(); // Timer
            int a, b;

            for (a = 0; a < NUM_FILES; a++)
                for (b = 0; b < INPUT_SIZE; b++) output.Add(input[a].Dequeue()); // Concatena todos os elementos das filas na lista 'output'

            t.Restart(); // Zera e inicia o timer

            /* DESCOMENTE UM DOS MÉTODOS ABAIXO PARA ORDENAR O ARRAY */

            //a1.runMergeSort(ref output);
            //a1.runQuickSort(ref output);
            //a1.bubbleSort(ref output);
            //a1.insertionSort(ref output);
            //output.Sort(); // Ordenação padrão do C#

            t.Stop();
            Console.WriteLine("Time: " + t.ElapsedTicks/10 + " us"); // Cada 'Tick' são 100 nanosegundos
        }
    }
}
