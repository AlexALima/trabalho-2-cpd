#include "Lab2_aux.h"

#include "MergeSort.h"
#include "QuickSort.h"

void ordenacao_trivial(int* output, int size){
	
	Timer t;
    float time;
    
	// Copia (concatena) dados de entrada no array de saida 
	
    for(i=0;i<NUM_FILES;i++){
        memcpy(&output[i*INPUT_SIZE],input[i],INPUT_SIZE*sizeof(int));
    }

    printf("ordenado? %s\n",(isArraySorted(output,MERGED_OUTPUT_SIZE)?"sim":"nao"));

    startTimer(&t);
    
    /* DESCOMENTE UM DOS METODOS ABAIXO PARA ORDENAR O ARRAY DE SAIDA */
    
    runMergeSort(output, size);
    //runQuickSort(output, size);
    
    time = stopTimer(&t);
    
    printf("Time %f\n",time);

    printf("ordenado? %s\n",(isArraySorted(output,MERGED_OUTPUT_SIZE)?"sim":"nao"));
    
    return;
}


