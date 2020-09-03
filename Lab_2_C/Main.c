#include "Lab2_aux.h"


/*************/
/* PRINCIPAL */
/*************/


int main()
{
    srand(time(NULL));

    /* inicializa indicadores do inicio de cada array */
    for(int k=0;k<NUM_FILES;k++)
        head_of_file[k]=0;

    /* Exercicio 1 */
    ex1();

    /* Exercicio 2 */
//    ex2();
	
    return 0;
}

