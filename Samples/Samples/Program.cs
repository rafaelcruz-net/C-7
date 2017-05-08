using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Tuplas

            var numbers = new int[] { 10, 20, 30 };

            //Forma antiga de declaração
            Tuple<int, int> scalarValue = new Tuple<int, int>(numbers.Count(), numbers.Sum());
            Console.WriteLine($"Qtd:{scalarValue.Item1}, Soma:{scalarValue.Item2}");

            var tuple = (numbers.Count(), numbers.Sum());
            Console.WriteLine($"Qtd:{tuple.Item1}, Soma:{tuple.Item2}");

            var tupleComNomes = (Quantidade: numbers.Count(), Soma: numbers.Sum());
            Console.WriteLine($"Qtd:{tupleComNomes.Quantidade}, Soma:{tupleComNomes.Soma}");

            (int quantidade, int soma) tupleDeclarada = (numbers.Count(), numbers.Sum());
            Console.WriteLine($"Qtd:{tupleDeclarada.quantidade}, Soma:{tupleDeclarada.soma}");

            //var novaTupla = FormaTupla(numbers.Count(), numbers.Sum());
            //Console.WriteLine($"Qtd:{novaTupla.Quantidade}, Soma:{novaTupla.Soma}");

            #endregion

            #region Local Functions
            IEnumerable<int> FindTodosNumeroPar(int[] list)
            {
                foreach (var item in list)
                {
                    if (item % 2 == 0)
                        yield return item;
                }
            }

            var x = FindTodosNumeroPar(new int[] { 1, 2, 3, 4, 5, 6, 7, 20, 21, 23, 22, 24, 25 });

            foreach (var item in x)
                Console.WriteLine($"Numero par:{item}");

            #endregion

            #region Ref Local & Ref Return

            ref int Max(ref int x1, ref int x2)
            {
                if (x1 > x2)
                    return ref x1;
                return ref x2;
            }

            int[] Numbers = new int[] { 12, 20, 13, 21, 24, 25 };

            ref int result = ref Numbers[0];

            for (int i = 0; i < Numbers.Length; i++)
                result = Max(ref result, ref Numbers[i]);

            Console.WriteLine($"Maior número é :{result}");

            #endregion

            #region Pattern Matching 

            void Soma(object[] list, ref int xTotal)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    switch (list[i])
                    {
                        case int z when z > 0:
                            xTotal += z;
                            break;
                        case int t when t < 0:
                            throw new Exception("Números negativos não são legais");
                        case object[] y:
                            Soma(y, ref xTotal);
                            break;
                    }
                }
            }
            var pattern = new object[] { 12, 20, 13, new object[] { 21, 24, 25 } };

            int total = 0;

            Soma(pattern, ref total);

            Console.WriteLine($"Soma Pattern Matching é :{total}");

            #endregion

            #region Digit Separators
            int digit = 1_000_000_000;
            Console.WriteLine($"Digitos Separadores: {digit}");
            #endregion

            #region Binary Separators
            int binary = 0b1010_1111_1100_1111;
            Console.WriteLine($"Digitos Separadores: {binary}");
            #endregion

            Console.ReadKey();

        }

        //public static (int, int) FormaTupla(int quantidade, int soma)
        //{
        //    return (Quantidade: quantidade, Soma: soma);
        //}

        //public static (int Quantidade, int Soma) FormaTupla(int quantidade, int soma)
        //{
        //    return (Quantidade: quantidade, Soma: soma);
        //}
    }
}
