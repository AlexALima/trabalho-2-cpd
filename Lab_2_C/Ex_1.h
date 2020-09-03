#include "Lab2_aux.h"
#include "MergeSort.h"
#include "QuickSort.h"

void ex1()
{
    int i;
    char fileName[20];
    Timer t;
    float time;

    /* Array de ponteiros para 'NUM_FILES' arrays de dados */
    int* input[NUM_FILES];

    /* ordena cada um dos arquivos de entrada */
    for(i=0;i<NUM_FILES;i++){

        /* Le arquivo de entrada e coloca os dados no array 'input[i]' */
        sprintf(fileName,"files/file%02d.txt",i);
        printf("ENTRADA: %s\n",fileName);
        input[i] = readFile(fileName);

        /* ordena array */

        startTimer(&t);

        /* DESCOMENTE UM DOS METODOS ABAIXO PARA ORDENAR O ARRAY */
        //runMergeSort(input[i],INPUT_SIZE);
        //runQuickSort(input[i],INPUT_SIZE);

        time = stopTimer(&t);
        printf("Time %f\n",time);

        /* checa se esta ordenado */
        printf("ordenado? ");
        if(isArraySorted(input[i],INPUT_SIZE)){
            printf("sim\n");

            /* salva arquivo de saida */
            sprintf(fileName,"sorted/file%02d.txt",i);
            printf("SAIDA: %s\n",fileName);
            writeFile(fileName,input[i],INPUT_SIZE);
        }else{
            printf("nao\n");
        }

        free(input[i]);
    }
}

int isArraySorted(int* array, int size)
{
    int i;
    for(i=0;i<size-1;i++){
        if(array[i]>array[i+1])
            return 0;
    }
    return 1;
}
