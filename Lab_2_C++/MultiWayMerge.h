#include <vector>  

int head_of_file[NUM_FILES]; // usado para indicar onde esta o proximo dado nao-lido de cada array

int topFromArray(int** input, int k)
{
    if(head_of_file[k]<INPUT_SIZE)
        return input[k][head_of_file[k]];
    else
        return 10000000;
}

int popFromArray(int** input, int k)
{
    if(head_of_file[k]<INPUT_SIZE)
        return input[k][head_of_file[k]++];
    else
        return 10000000;
}

void mergeSortedArrays(int** input, int* output, int num_file, int size_file)
{
	int i, j = 0;
	
	for(i = 0; i < num_file; i++) head_of_file[i] = 0;
	
	int index_menor, ordenado = false;
	
	while (!ordenado) // Quando ordenado for verdadeiro, é pq todas as filas estão vazias e o vetor out está ordenada
    {
        ordenado = true; // Ordenado até que se prove o contrário ;D

        index_menor = 0; // No início, o menor elemento é o do topo da primeira fila

        for (i = 0; i < num_file; i++)
        {

            if (head_of_file[i] != num_file) // Se fila não possui elementos, pula para próxima
            {
                ordenado = false; // Aqui está a prova que não está ordenado, pois ainda existem dados nas filas
                if (input[i][head_of_file[i]] < input[index_menor][head_of_file[i]]) index_menor = i; // Se algum elemento é menor que o index, torna-se o novo index
            }

        }

        if(!(input[head_of_file[index_menor]])) // Se estiver vazio é pq todos os vetores estão vazios e o programa sai do laço while
		{
			output[j]=(input[index_menor][head_of_file[i-1]]); // Adiciona o menor elemento encontrado ao vetor 'output'
			head_of_file[i-1]++; j++;
		}
                    
    }


}
