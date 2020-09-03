#include "Main++.h"

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
        cout << "Entrada: " << fileName << "\n";
        input[i] = readFile(fileName);

        /* ordena array */

        startTimer(&t);

        /* DESCOMENTE UM DOS METODOS ABAIXO PARA ORDENAR O ARRAY */
        //runMergeSort(input[i],INPUT_SIZE);
        runQuickSort(input[i],INPUT_SIZE);

        time = stopTimer(&t);
        cout << "Time " << time << "\n";

        /* checa se esta ordenado */
        cout << "Ordenado? ";
        if(isArraySorted(input[i],INPUT_SIZE)){
            cout << "Sim" << "\n";
            /* salva arquivo de saida */
            sprintf(fileName,"sorted/file%02d.txt",i);
            //printf("SAIDA: %s\n\n",fileName);
            cout << "Saida: " << fileName << "\n\n";
            writeFile(fileName,input[i],INPUT_SIZE);
        }else{
            cout << "Nao" << "\n";
        }

        free(input[i]);
        
    }
}

