using System; // Console
using System.Collections.Generic; // List e Queue
using System.Diagnostics; // Timer

namespace Lab_2
{
    partial class Ex_2 : Lab_2
    {
        ///    PAI = (i-1)/2
        ///    FILHO DIREITO = (i+1)*2
        ///    FILHO ESQUERDO = (2*i) + 1    

        int raiz, n, menor, filho_d, filho_e;
        bool folha;
        Stopwatch t = new Stopwatch(); // Timer

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------- */

        void mergeWithSelectionTree(ref List<Queue<int>> input, ref List<int> output)
        {
            t.Restart(); // Zera e inicia o timer

            int[] a_heap = new int[(num_nodos_heap())]; // Cria array com o número de nodos necessários para a árvore

            build_heap(ref a_heap, ref input); // Constrói o heap inicial, eliminando os elementos vazios (-1) e puxando dados até a raíz

            while (output.Count < MERGED_OUTPUT_SIZE) output.Add(popFromSelectionTree(ref a_heap, ref input));

            t.Stop();
            Console.WriteLine("Time: " + t.ElapsedTicks / 10 + " us"); // Cada 'Tick' são 100 nanosegundos
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------- */

        void build_heap(ref int[] a_heap, ref List<Queue<int>> input)
        {
            int i, j;

            for (i = 0; i < num_nodos_heap(); i++) a_heap[i] = -1; // Todos os elementos da heap recebem indicador -1 (vazio)

            for(i = NUM_FILES - 1, j = a_heap.Length - 1; i >= 0; i--, j--) a_heap[j] = input[i].Dequeue(); // Coloca o topo das filas nas folhas

            while (a_heap[0] == -1) popFromSelectionTree(ref a_heap, ref input); // Faz popFromSelectionTree até chegar algum valor na raíz
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------- */

        int popFromSelectionTree(ref int[] a_heap, ref List<Queue<int>> input)
        {
            raiz = a_heap[0];
            n = 0;
            folha = false;
            
            while (!folha) // Enquanto não chegar em uma folha
            {
                if ((n + 1) * 2 > a_heap.Length) // Se o filho direito é um valor maior que o fim da heap, chegou numa folha
                {
                    folha = true; // Chegou numa folha

                    a_heap[n] = input[n + 1 - NUM_FILES].Dequeue(); // Puxa dado da fila correspondente (equivalente ao popFromArray)
                    input[n + 1 - NUM_FILES].Enqueue(1000000); // Adiciona 1.000.000 ao final da fila
                }
                else
                {
                    filho_d = (n + 1) * 2; filho_e = (2 * n) + 1;

                    if (a_heap[filho_e] <= a_heap[filho_d]) menor = filho_e; // Esquerdo
                    else menor = filho_d; // Direito

                    a_heap[n] = a_heap[menor];
                    n = menor;
                }
                    filho_d = (n + 1) * 2; filho_e = (2 * n) + 1; // Chegou numa folha
            }
            return raiz;
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------- */

        int num_nodos_heap() // Calcula o número de nodos (elemntos do vetor) necessários para a heap
        {
            int nodos, exp2;

            for (exp2 = 1, nodos = 0; exp2 < NUM_FILES; exp2 *= 2) nodos += exp2; // Calcula os nodos de uma árvore binária até que o número de folhas seja o mais próximo (menor) que o número de arquivos

            nodos += 2 * (NUM_FILES - (exp2/2)); // Calcula o resto das folhas necessárias para atingir o número de arquivos (Se houver dúvidas sobre essa fórmula é só me perguntar)

            return nodos;
        }
       
    }
}


