
int partition(int* C, int pi, int pf)
{
    int aux, i = pi + 1, j = pf, pivo = pi; //  Posição  do  pivô (primeiro  elemento) 

    while (j > i)
    {
        while ((C[i] <= C[pivo]) && (i < pf)) i++;
        while ((C[j] > C[pivo]) && (j > pi)) j--;
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

void quickSort(int* C, int i, int f)
{

    totalCalls++;

    if (f >= i)
    {
        int p = partition(C, i, f);
        quickSort(C, i, p - 1);
        quickSort(C, p + 1, f);
    }


}

void runQuickSort(int* array, int size)
{
    totalCalls=0;

    quickSort(array,0,size-1);

    cout << "Total calls Q: " << totalCalls << "\n";

}
