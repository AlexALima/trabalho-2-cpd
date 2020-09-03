using System; // Console
using System.Collections.Generic; // Listas

namespace Lab_2
{
    partial class Ex_1 : Lab_2
    {
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public void runQuickSort(ref List<int> array)
        {
            totalCalls = 0;

            quickSort(ref array, 0, array.Count - 1);

            Console.WriteLine("Total calls: " + totalCalls);

        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        int partition(ref List<int> C, int pos_inicio, int pos_final)
        {
            int aux, i = pos_inicio + 1, j = pos_final, pivo = pos_inicio; //  Posição  do  pivô (primeiro  elemento) 

            while (j > i)
            {
                while ((C[i] <= C[pivo]) && (i < pos_final)) i++;
                while ((C[j] > C[pivo]) && (j > pos_inicio)) j--;
                if ((i < j) && (C[i] > C[j]))
                {
                    aux = C[i];
                    C[i] = C[j];
                    C[j] = aux;
                }
            }
            if (C[j] < C[pivo])
            {
                aux = C[pivo];
                C[pivo] = C[j];
                C[j] = aux;
            }
            return j;
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        void quickSort(ref List<int> C, int i, int f)
        {

            totalCalls++;

            if (f >= i)
            {
                int p = partition(ref C, i, f);
                quickSort(ref C, i, p - 1);
                quickSort(ref C, p + 1, f);
            }
        }
    }
}
