using System; // Console
using System.Collections.Generic; // Listas
using System.IO; // Manipulação de arquivos
using System.Diagnostics; // Timer

namespace Lab_2
{
    partial class RadixSort : Lab_2
    {
        Ex_1 a1 = new Ex_1(); // Instancia objeto para acessar os métodos do Ex_1 
        Stopwatch t = new Stopwatch(); // Timer

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------- */

        public void Radix_Sort()
        {
            int a, b, c, d;
            double time;

            List<int> input = new List<int>();
            List<int>[] L1 = new List<int>[10]; // Array de listas que servirão de 'caixas' para o ordenamento
            for (a = 0; a < 10; a++) L1[a] = new List<int>(); // Inicializa as listas

            string fileName = String.Format("C:/Users/xandi/OneDrive/Documentos/UFRGS/Classificação e Pesquisa de Dados - 2018_2/Lab_2/Time_RXS.txt"); // Arquivo texto para salvar o tempo de execução do método
            using (TextWriter sr = File.AppendText(fileName)) // Abre o arquivo para escrita
            {
                for (int i = 0; i < NUM_FILES; i++)
                {
                    a1.le_arquivo_ex1(ref input, i);

                    b = 10;

                    t.Restart(); // Zera e inicia o timer

                    for (c = 0; c < 10; c++) // De 0 a 9
                    {
                        for (a = 0; a < input.Count; a++) // De 0 até o fim do arquivo
                        {
                            d = caixa(input[a], b); // Calcula com qual 'caixa' o número deve ser posto
                            L1[d].Add(input[a]);
                        }
                        input.Clear();
                        for (a = 0; a < 10; a++) input.AddRange(L1[a]); // Concatena todas as caixas
                        for (a = 0; a < 10; a++) L1[a].Clear(); // Limpa todas as caixas (listas) do vetor de listas
                        b *= 10;
                    }

                    t.Stop();
                    time = t.ElapsedTicks / 10.0; // Recebe o tempo em us (cada 'Tick' são 100 nanosegundos)
                    Console.WriteLine("Time: " + time + " us");

                    sr.WriteLine(time); // Salva o tempo num arquivo texto

                    Console.Write("Ordenado? ");
                    if (a1.isArraySorted(input))
                    {
                        Console.WriteLine("Sim");
                        salva_arquivo_RXS(input, i);
                    }
                    else
                    {
                        Console.WriteLine("Não");
                    }
                    input.Clear();
                }
            }
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------- */

            void salva_arquivo_RXS(List<int> input, int i)
        {
            string fileName = String.Format("C:/Users/xandi/OneDrive/Documentos/UFRGS/Classificação e Pesquisa de Dados - 2018_2/Lab_2/sorted/fileRXS{0:00}.txt", i);

            using (TextWriter sr = File.CreateText(fileName)) // Abre o arquivo para escrita
            {
                Console.WriteLine("SAIDA: " + fileName + "\n");
                for (int element = 0; element < input.Count; element++)
                {
                    sr.Write(String.Format("{0:000000} \r", input[element])); // Escreve no arquivo o número com 6 algarismos e um espaço
                }
            }
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------- */

        int caixa(int a, int b)
        {
            a %= b; 
            return a /= (b/10);
        }

    }
}
