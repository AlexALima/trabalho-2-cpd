#include "Lab2_aux.h"

void merge(int *C, int* Aux, int i, int m, int f)
{
    /*TODO: Implementar o metodo */


}

void mergeSort(int *C, int* Aux, int i, int f)
{
    totalCalls++;

    /*TODO: Implementar o metodo */


}

void runMergeSort(int* array, int size)
{
    totalCalls=0;

    /* Aloca array auxiliar com o tamanho certo de elementos */
    int *Aux = (int*) malloc(size*sizeof(int));

    mergeSort(array,Aux,0,size-1);

    free(Aux);

    printf("Total calls %d\n",totalCalls);
}
