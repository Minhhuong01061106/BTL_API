using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackDemo
{
    // Lớp đại diện cho một đồ vật
    public class Item
    {
        public int Index { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
        public double Ratio => Value / Weight; //

        public Item(int index, double weight, double value)
        {
            Index = index;
            Weight = weight;
            Value = value;
        }
    }



    public class FractionalKnapsackGreedy
    {
        public static (double totalValue, List<string> selections) Solve(double[] values,double[] weights,double capacity)
        {
            int n = values.Length;
            var items = new List<Item>();
            var selections = new List<string>();

            for (int i = 0; i < n; i++)
            {
                items.Add(new Item(i + 1, weights[i], values[i]));
            }

            items = items.OrderByDescending(item => item.Ratio).ToList();

            double totalValue = 0;
            double remainingCapacity = capacity;

            foreach (var item in items)
            {
                if (remainingCapacity <= 0)
                    break;

                if (remainingCapacity >= item.Weight)
                {
                    // Lấy toàn bộ đồ vật
                    totalValue += item.Value;
                    remainingCapacity -= item.Weight;
                    selections.Add($"Lay toan bo Đo vat {item.Index}: {item.Weight}kg, gia tri {item.Value}");
                }
                else
                {
                    // Lấy một phần đồ vật
                    double fraction = remainingCapacity / item.Weight;
                    double takenValue = item.Value * fraction;
                    totalValue += takenValue;
                    selections.Add($"Lay {fraction:P1} Đo vat {item.Index}: {remainingCapacity}kg, gia tri {takenValue:F2}");
                    remainingCapacity = 0; // Túi đã đầy
                }
            }

            return (totalValue, selections);
        }

        public static void Main()
        {
            Console.WriteLine("=== FRACTIONAL KNAPSACK - THUAT TOAN THAM LAM TOI UU ===");

            double[] values = { 60, 100, 120 };
            double[] weights = { 10, 20, 30 };
            double capacity = 50;

            Console.WriteLine($"\nSuc chua tui: {capacity}kg");
            Console.WriteLine("Danh sach đo vat:");
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"  Đo vat {i + 1}: {weights[i]}kg, gia tri {values[i]}, ty le {values[i] / weights[i]:F2}");
            }

            var (totalValue, selections) = Solve(values, weights, capacity);

            Console.WriteLine("\nCac buoc chon:");
            foreach (var step in selections)
            {
                Console.WriteLine($"  {step}");
            }

            Console.WriteLine($"\nTong gia tri toi uu: {totalValue:F2}");
        }
    }
}