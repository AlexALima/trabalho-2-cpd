using System.Collections.Generic; // Listas

namespace Lab_2
{
    partial class Ex_1 : Lab_2
    {
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public void bubbleSort(ref List<int> C) // Ordena o vetor invertendo pares de trás pra frente, onde o maior sempre vai pra 'direita'
        {
            int m = C.Count - 1, k = 0, temp;
            bool troca;

            totalCalls = 0;

            do
            {
                troca = false;
                for (int i = 0; i < m; i++) // Percorre o vetor até a posição da última troca (ou até o fim, na primeira varredura)
                {
                    if (C[i] > C[i + 1]) // Se, em um par, o elemento da 'esquerda' for maior que o da 'direita', inverte
                    {
                        temp = C[i];
                        C[i] = C[i + 1];
                        C[i + 1] = temp;

                        k = i; // Posição da troca
                        troca = true;
                        totalCalls++;
                    }
                }
                m = k; // Posição da última troca
            } while (troca);
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public void insertionSort(ref List<int> C) // Ordena o vetor inserindo os elementos (aqui chamarei de cartas, em alusão a um baralho) movendo os elementos menores para o início do vetor
        {
            int carta, i;
            totalCalls = 0;

            for (int j = 1; j < C.Count; j++)
            {
                carta = C[j]; // A carta é o segundo elemento da varredura
                i = j - 1; // Índice anterior ao da carta (o primeiro da varredura)

                while ((i >= 0) && (C[i] > carta)) // Enquanto o elemento i for maior que a carta, a carta vai 'andando' para trás
                {
                    C[i + 1] = C[i]; // Avança o elemento i uma posição (a posição da carta) (1)
                    i--; totalCalls++; // i é decrementado para a carta ir uma posição para trás
                }
                C[i + 1] = carta; // Se i não foi decrementado, a carta vai para a posição j (pois i = j - 1), ou seja, anda uma posição pra 'frente'
            }
        }

    }
}
