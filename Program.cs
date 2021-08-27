using System;
//using System.Linq;

namespace ParadigmaChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int length;
            int[] elements;
            bool firstZero = true;

            Console.WriteLine("Quantos elementos deseja inserir a árvore?");
            length = int.Parse(Console.ReadLine());
            if (length < 2)
            {
                Console.WriteLine("Precisa de no mínimo três elementos");
                Main(null);
            }
            elements = new int[length];
            Console.WriteLine($"Insira os {length} elementos da arvaores");
            for (int i = 0; i < length; i++)
            {
                var element = int.Parse(Console.ReadLine());

                //if (!elements.Any(x => x == element) || (element == 0 && firstZero))
                if (!elements.AlreadyExists(element) || (element == 0 && firstZero))
                    elements[i] = element;
                else
                {
                    Console.WriteLine($"Não pode inserir valores duplicados, insira um valor diferente de {element} ");
                    i--;
                    continue;
                }
                firstZero = !(element == 0);

            }
            int rootIndex = elements.GetRootIndex();
            Console.Write("Array de entrada: ");
            elements.WriteElements();
            Console.WriteLine($"Raiz: {elements[rootIndex]} ");

            Console.Write("Galhos esquerdos são: ");
            elements.GetElementsByRange(0, rootIndex).Sort().WriteElements();

            Console.Write("Galhos direitos são: ");
            elements.GetElementsByRange(rootIndex + 1, length).Sort().WriteElements();


        }

    }
    public static class Helpers
    {
        public static int GetRootIndex(this int[] values)
        {
            int max = values[0];
            int rootIndex = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (max < values[i])
                {
                    max = values[i];
                    rootIndex = i;
                }
            }
            return rootIndex;
        }
        public static int[] Sort(this int[] values)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    if (values[i] < values[j])
                    {
                        int aux = values[i];
                        values[i] = values[j];
                        values[j] = aux;
                    }
                }
            }
            return values;
        }

        public static int[] GetElementsByRange(this int[] values, int startIndex, int endIndex)
        {
            var elements = new int[endIndex - startIndex];

            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = values[startIndex + i];
            }
            return elements;
        }
        public static void WriteElements(this int[] values)
        {
            Console.Write("[");
            for (int i = 0; i < values.Length; i++)
            {
                if (i != 0)
                    Console.Write(",");
                Console.Write($"{values[i]}");
            }
            Console.WriteLine("]");
            //Console.WriteLine($"[{string.Join(',', values)}]");
        }
        public static bool AlreadyExists(this int[] values, int element)
        {
            bool exists = false;
            for (int i = 0; i < values.Length; i++)
            {
                exists = values[i] == element;
                if (exists)
                    break;
            }
            return exists;
        }

    }
}
