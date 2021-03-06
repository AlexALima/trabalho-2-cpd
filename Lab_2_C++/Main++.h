#include <stdio.h> /* fopen, fprintf, fscanf, stderr */
#include <stdlib.h> /* srand, malloc, free */
#include <time.h> /* time */
#include <string.h> /* memcpy */
#include <sys/time.h>   /* struct timeval, gettimeofday */
#include <iostream> // cout, cin

using namespace std; 

#define NUM_FILES 50
#define INPUT_SIZE 100000
#define MERGED_OUTPUT_SIZE NUM_FILES*INPUT_SIZE

int totalCalls;

int isArraySorted(int* array, int size);

int* readFile(char* fileName);
void writeFile(char* fileName, int* C, int size);

int isArraySorted(int* array, int size)
{
    int i;
    for(i=0;i<size-1;i++){
        if(array[i]>array[i+1])
            return 0;
    }
    return 1;
}

/*****************************/
/*          Timer            */
/*****************************/

typedef struct{
    struct timeval start;
    struct timeval end;
} Timer;

void startTimer(Timer* t);
float stopTimer(Timer* t);

void startTimer(Timer* t)
{
    gettimeofday(&(t->start), NULL);
}

float stopTimer(Timer *t)
{
    gettimeofday(&(t->end), NULL);

    if (t->start.tv_usec > t->end.tv_usec) {
        t->end.tv_usec += 1000000;
        t->end.tv_sec--;
    }

    return (float)(t->end.tv_sec - t->start.tv_sec) +
           ((float)t->end.tv_usec - (float)t->start.tv_usec)/1000000.0;
}

/*****************************/
/* Entrada e Saida - Arquivos*/
/*****************************/

int* readFile(char* fileName)
{
	/* Aloca array com o tamanho certo de elementos */
	int *C = (int*)malloc(INPUT_SIZE * sizeof(int));

	/* Abre arquivo */
	FILE* fp;
	fp = fopen(fileName, "r");
	if (fp == NULL) {
		fprintf(stderr, "Can't open input file '%s'!\n", fileName);
		return C;
	}

	/* Le arquivo */
	int i;
	for (i = 0; i<INPUT_SIZE; i++) {
		fscanf(fp, "%d", &(C[i]));
	}

	fclose(fp);

	return C;
}

void writeFile(char* fileName, int* C, int size)
{
	/* Abre arquivo */
	FILE* fp;
	fp = fopen(fileName, "w");
	if (fp == NULL) {
		fprintf(stderr, "Can't open output file '%s'!\n", fileName);
		return;
	}

	/* Escreve arquivo */
	int i;
	for (i = 0; i<size; i++) {
		fprintf(fp, "%06d ", C[i]);
		if (i % 20 == 19)
			fprintf(fp, "\n");
	}

	fclose(fp);
}

