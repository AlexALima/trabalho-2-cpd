#include "Lab2_aux.h"

int partition(int* C, int pi, int pf)
{
    /*TODO: Implementar o metodo */


}

void quickSort(int* C, int i, int f)
{

    totalCalls++;

    /*TODO: Implementar o metodo */


}

void runQuickSort(int* array, int size)
{
    totalCalls=0;

    quickSort(array,0,size-1);

    printf("Total calls %d\n",totalCalls);

}
