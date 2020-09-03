#include "Main++.h"

#include "MultiWayMerge.h"
#include "MergeSelectionTree.h"

#include "MergeSort.h"
#include "QuickSort.h"

void ex2()
{
    int i;
    char fileName[20];
    Timer t;
    float time;

    /* Array de ponteiros para 'NUM_FILES' arrays de dados */
    int* input[NUM_FILES];

    /* Le arquivos de entrada (ja ordenados) */
    for(i=0;i<NUM_FILES;i++){

        /* Le arquivo de entrada e coloca os dados no array 'input[i]' */
        sprintf(fileName,"sorted/file%02d.txt",i);
        cout << "Entrada: " << fileName << "\n";
        input[i] = readFile(fileName);
    }

    /* Aloca array de saida que ira conter todos os dados de entrada */
    int* output = (int*) malloc(MERGED_OUTPUT_SIZE*sizeof(int));

    /* Copia (concatena) dados de entrada no array de saida */
    for(i=0;i<NUM_FILES;i++){
        memcpy(&output[i*INPUT_SIZE],input[i],INPUT_SIZE*sizeof(int));
    }

    printf("ordenado? %s\n",(isArraySorted(output,MERGED_OUTPUT_SIZE)?"sim":"nao"));

    startTimer(&t);

    /* DESCOMENTE UM DOS METODOS ABAIXO PARA ORDENAR O ARRAY DE SAIDA */
//    runQuickSort(output,MERGED_OUTPUT_SIZE);
//    runMergeSort(output, MERGED_OUTPUT_SIZE);
    mergeSortedArrays(input,output,NUM_FILES,INPUT_SIZE);
//    mergeWithSelectionTree(input,output,NUM_FILES,MERGED_OUTPUT_SIZE);

    time = stopTimer(&t);
    //printf("Time %f\n",time);
    cout << "Time: " << time << "\n";

    printf("ordenado? %s\n",(isArraySorted(output,MERGED_OUTPUT_SIZE)?"sim":"nao"));
	
    /* salva arquivo de saida */
    sprintf(fileName,"sorted/output.txt");
    //printf("SAIDA: %s\n",fileName);
    cout << "Saida: " << fileName << "\n";
    writeFile(fileName,output,MERGED_OUTPUT_SIZE);
}
