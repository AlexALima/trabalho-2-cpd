using System; // Console
using System.Collections.Generic; // Listas

namespace Lab_2
{
    partial class Ex_1 : Lab_2
    {
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public void runMergeSort(ref List<int> array)
        {
            int[] Aux = new int[array.Count];
            totalCalls = 0; 

            mergeSort(ref array, ref Aux, 0, array.Count - 1);

            Console.WriteLine("Total calls: " + totalCalls);
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        void merge(ref List<int> C, ref int[] Aux, int i, int m, int f)
        {
            for (int a = i; a <= f; a++) Aux[a] = C[a];

            int j = m + 1;

            for(int k = i; k <= f; k++)
            {
                if (i > m) C[k] = Aux[j++];
                else if(j > f) C[k] = Aux[i++];
                else if (Aux[i] <= Aux[j]) C[k] = Aux[i++];
                else C[k] = Aux[j++];
            }

        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        void mergeSort(ref List<int> C, ref int[] Aux, int i, int f)
        {
            totalCalls++;
            int m;

            if (f > i)
            {
                m = (i + f) / 2;
                mergeSort(ref C, ref Aux, i, m);
                mergeSort(ref C, ref Aux, m + 1, f);
                merge(ref C, ref Aux, i, m, f);
            }
        }

    }
}
