
void merge(int *C, int* Aux, int in, int m, int fim)
{
    for(int a = in; a<=fim; a++) Aux[a] = C[a];

	int j = m + 1;

    for(int k = in; k <= fim; k++)
    {
        if (in > m) C[k] = Aux[j++];
        else if(j > fim) C[k] = Aux[in++];
        else if (Aux[in] <= Aux[j]) C[k] = Aux[in++];
        else C[k] = Aux[j++];
    }	
}

void mergeSort(int *C, int* Aux, int in, int fim)
{
    totalCalls++;

    int m;

    if (fim > in)
    {
        m = (in + fim) / 2;
        mergeSort(C, Aux, in, m);
        mergeSort(C, Aux, m + 1, fim);
        merge(C, Aux, in, m, fim);
    }
}

void runMergeSort(int* array, int size)
{
    totalCalls=0;

    /* Aloca array auxiliar com o tamanho certo de elementos */
    int *Aux = (int*) malloc(size*sizeof(int));

    mergeSort(array,Aux,0,size-1);

    free(Aux);

    //printf("Total calls M: %d\n",totalCalls);
    cout << "Total calls M: " << totalCalls << "\n";
}
