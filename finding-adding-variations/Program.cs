using System;
using System.Collections.Generic;
using System.Linq;

namespace finding_adding_variations
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> variations = FindAddingVariationsV1(10);

            variations.ToList().ForEach(Console.WriteLine);
        }

        static IList<string> FindAddingVariationsV1(int number)
        {
            IList<string> variations = new List<string>();

            string variation;
            int first, second, result;

            for (int i = 0; i <= number / 2; i++)
            {
                first = i;
                second = number - i;
                result = first + second;

                variation = $"{first} + {second} = {result}";

                variations.Add(variation);
            }

            return variations;
        }

        static IList<string> FindAddingVariationsV2(int number)
        {
            IList<string> variations = new List<string>();
            IList<int[,]> items = new List<int[,]>();

            string variation;
            int first, second, result;

            for (int i = 0; i <= number; i++)
            {
                first = i;
                second = number - i;
                result = first + second;

                if (!items.ToList().Any(item => item[0, 0] == first || item[0, 1] == first))
                {
                    items.Add(new int[,] {{first, second}});

                    variation = $"{first} + {second} = {result}";

                    variations.Add(variation);
                }
            }

            return variations;
        }

        static IList<string> FindAddingVariationsV3(int number)
        {
            IList<string> variations = new List<string>();

            IList<(int, int)> items = new List<(int, int)>();

            string variation;
            int first, second, result;

            for (int i = 0; i <= number; i++)
            {
                first = i;
                second = number - i;
                result = first + second;

                if (!items.ToList().Any(tuple => tuple.Item1 == first || tuple.Item2 == first))
                {
                    items.Add((first, second));

                    variation = $"{first} + {second} = {result}";

                    variations.Add(variation);
                }
            }

            return variations;
        }
    }
}