using System; // Console, String e Convert
using System.Collections.Generic; // List e Queue
using System.IO; // Manipulação de arquivos

namespace Lab_2
{
    partial class Ex_2 : Lab_2
    {
        Ex_1 a1 = new Ex_1(); // Instancia objeto para acessar os métodos do Ex_1
        RadixSort RX = new RadixSort(); // Instancia objeto para acessar os métodos do RadixSort 

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------- */

        public void ex2()
        {
            
            List<Queue<int>> input = new List<Queue<int>>(); // Cria uma lista de filas (cada fila recebe os números de um arquivo)
            List<int> output = new List<int>(); // Cria lista para receber os dados de saída

            /* ------------------- Lê os arquivos de entrada e armazena os dados na fila ----------------------- */

            le_arquivo_ex2(ref input);

            /* --------------------------------- DESCOMENTE UM DOS MÉTODOS ABAIXO PARA REALIZAR O MERGE ---------------------------------- */

            //ordenacaoTrivial(ref input, ref output);
            //mergeSortedArrays(ref input, ref output);
            //mergeWithSelectionTree(ref input, ref output);

            /* ------------------ Checa se está ordenado -----------------------*/

            Console.Write("Ordenado? ");
            if (a1.isArraySorted(output))
            {
                Console.WriteLine("Sim"); // Se estiver, salva os dados no diretório abaixo
                salva_arquivo_ex2(output);
            }
            else Console.WriteLine("Não");
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        void le_arquivo_ex2(ref List<Queue<int>> input)
        {
            int a, i, j;
            for (i = 0; i < NUM_FILES; i++)
            {
                Queue<int> fila = new Queue<int>(); // Instancia uma outra fila que guardará os números do arquivo 'i'

                string fileName = String.Format("C:/Users/xandi/OneDrive/Documentos/UFRGS/Classificação e Pesquisa de Dados - 2018_2/Lab_2/sorted/file{0:00}.txt", i);
                //Console.WriteLine("ENTRADA: " + fileName);
                
                using (TextReader sr = File.OpenText(fileName)) // Abre o arquivo fileName e o fecha ao final do escopo (using)
                {
                    char[] s = new char[6]; // Buffer para armazenar a cadeia de caracteres do número lido
                    j = 0;
                    while (sr.Peek() != -1 && j++ < INPUT_SIZE) // Enquanto n chegar no final do arquivo
                    {
                        try // Tenta ler o próximo dígito. Se for -1 (fim de arquivo), vai ocorrer OverflowException e termina a leitura
                        {
                            a = 0;
                            while (Char.IsDigit(Convert.ToChar((sr.Peek())))) // Enquanto o próximo caracter for um dígito (0 - 9) (final de arquivo é -1 e n pode ser convertido em char)
                            {
                                s[a] = Convert.ToChar(sr.Read()); // Adiciona o caracter no buffer
                                a++; // Avança para a próxima posição do buffer
                            }
                            string num = new string(s); // Converte o buffer char[] para string
                            fila.Enqueue(Convert.ToInt32(num)); // Converte para inteiro e adiciona à fila

                            while (!Char.IsDigit(Convert.ToChar(sr.Peek()))) sr.Read(); // Enquanto n achar um dígito, vai avançando no arquivo
                        }
                        catch { }; // Não faz nada se chegar no final do arquivo
                        
                    }
                    // fila.Enqueue(-1); // Marcador de final da fila - USAR SOMENTE COM O mergeWithSelectionTree
                }
                input.Add(fila); // Adiciona fila à lista
            }
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        void salva_arquivo_ex2(List<int> output)
        {
            string fileName = String.Format("C:/Users/xandi/OneDrive/Documentos/UFRGS/Classificação e Pesquisa de Dados - 2018_2/Lab_2/sorted/fileA.txt");

            using (TextWriter sr = File.CreateText(fileName)) // Abre o arquivo para escrita
            {
                Console.WriteLine("SAIDA: " + fileName + "\n\n");
                Queue<int> fila_aux = new Queue<int>(output); // Criar uma fila auxiliar foi necessário pois o int de output[int] não cobre os 50.000.000 de elementos
                for (long element = 0; element < output.Count; element++)
                {
                    sr.Write(String.Format("{0:000000} \r", fila_aux.Dequeue())); // Escreve no arquivo o número com 6 algarismos e um espaço
                }
            }
        }
    }
}
