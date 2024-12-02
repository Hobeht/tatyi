using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tatyi
{
    internal class Program
    {

        static (int, List<int>) Knapsack(List<int> values, List<int> weights, int capacity)
        {
            int n = values.Count;
            int[,] dp = new int[n + 1, capacity + 1];


            for (int i = 1; i <= n; i++)
            {
                for (int w = 0; w <= capacity; w++)
                {
                    if (weights[i - 1] <= w)
                    {
                        dp[i, w] = Math.Max(dp[i - 1, w], dp[i - 1, w - weights[i - 1]] + values[i - 1]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }


            List<int> selectedItems = new List<int>();
            int remainingCapacity = capacity;
            for (int i = n; i > 0 && remainingCapacity > 0; i--)
            {
                if (dp[i, remainingCapacity] != dp[i - 1, remainingCapacity])
                {
                    selectedItems.Add(i - 1);
                    remainingCapacity -= weights[i - 1];
                }
            }

            selectedItems.Reverse();
            return (dp[n, capacity], selectedItems);
        }

        static void Main(string[] args)
        {
            string[] elsosor = Console.ReadLine().Split(' ');
            int N = int.Parse(elsosor[0]);
            int K = int.Parse(elsosor[1]);
            List<int> súly = new List<int>();
            List<int> hasznos = new List<int>();
            string[] sor = Console.ReadLine().Split(' ');
            string[] sor2 = Console.ReadLine().Split(' ');
            for (int i = 0; i < N; i++)
            {

                súly.Add(int.Parse(sor[i]));
                hasznos.Add(int.Parse(sor2[i]));

            }
            (int maxValue, List<int> selectedItems) = Knapsack(hasznos, súly, K);

            Console.WriteLine(maxValue);
            Console.WriteLine(selectedItems.Count);
            for (int i = 0; i < selectedItems.Count; i++)
            {
                selectedItems[i] += 1;
            }
            Console.WriteLine(string.Join(", ", selectedItems));
            

            









        }
    }
}
