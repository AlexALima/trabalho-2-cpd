using System; // Console, String, Random e Convert
using System.Collections.Generic; // Listas
using System.Diagnostics; // Timer
using System.IO; // Manipulação de arquivos

namespace Lab_2
{
    partial class Ex_1 : Lab_2
    {

        public void ex1()
        {
            Stopwatch t = new Stopwatch(); // Timer
            List<int> input = new List<int>(); // Os números serão armazenados em uma lista, sem tamanho fixo
            List<double> tempos = new List<double>();
            
            /* ------------------- Lê o arquivo e armazena os dados na lista 'input' ----------------------- */

            for (int i = 0; i < NUM_FILES; i++)
            {
                le_arquivo_ex1(ref input, i);

                t.Restart(); // Zera e inicia o timer

                /* --------------------------------- DESCOMENTE UM DOS MÉTODOS ABAIXO PARA ORDENAR OS ARQUIVOS ---------------------------------- */

                //runMergeSort(ref input); 
                //runQuickSort(ref input);
                //bubbleSort(ref input);
                //insertionSort(ref input);
                //input.Sort(); // Ordenação padrão do C#

                t.Stop();
                Console.WriteLine("Time: " + t.ElapsedTicks / 10 + " us"); // Cada 'Tick' são 100 nanosegundos


                /* ------------------ Checa se está ordenado ----------------------- */

                Console.Write("Ordenado? ");
                if (isArraySorted(input))
                {
                    Console.WriteLine("Sim");
                    salva_arquivo_ex1(input, i);
                }
                else
                {
                    Console.WriteLine("Não");
                }
               

            }
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        int totalCalls;

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public bool isArraySorted(List<int> array)
        {
            for (int i = 0; i < array.Count - 1; i++)
            {
                if (array[i] > array[i + 1])
                    return false;
            }
            return true;
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public void le_arquivo_ex1(ref List<int> input, int i)
        {
            int a, j = 0;
            input.Clear();

            string fileName = String.Format("C:/Users/xandi/OneDrive/Documentos/UFRGS/Classificação e Pesquisa de Dados - 2018_2/Lab_2/files/file{0:00}.txt", i);
            Console.WriteLine("ENTRADA: " + fileName);

            using (TextReader sr = File.OpenText(fileName)) // Abre o arquivo de texto 'fileName' para leitura e o fecha ao final do escopo (using)
            {
                
                char[] s = new char[6]; // Buffer para armazenar a cadeia de caracteres do número lido
                while (sr.Peek() != -1 && j < INPUT_SIZE) // Enquanto não chegar no final do arquivo ou no limite de INPUT_SIZE
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
                        input.Add(Convert.ToInt32(num)); // Converte para inteiro e adiciona à lista

                        while (!Char.IsDigit(Convert.ToChar(sr.Peek()))) sr.Read(); // Enquanto n achar um dígito, vai avançando no arquivo
                    }
                    catch{}; // Não faz nada se chegar no final do arquivo
                    j++;
                }
            }
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public void salva_arquivo_ex1(List<int> input, int i)
        {
            string fileName = String.Format("C:/Users/xandi/OneDrive/Documentos/UFRGS/Classificação e Pesquisa de Dados - 2018_2/Lab_2/sorted/file{0:00}.txt", i);

            using (TextWriter sr = File.CreateText(fileName)) // Abre o arquivo para escrita
            {
                Console.WriteLine("SAIDA: " + fileName + "\n\n");
                for (int element = 0; element < input.Count; element++)
                {
                    sr.Write(String.Format("{0:000000} \r", input[element])); // Escreve no arquivo o número com 6 algarismos e um espaço
                }
            }
        }
    }
}
