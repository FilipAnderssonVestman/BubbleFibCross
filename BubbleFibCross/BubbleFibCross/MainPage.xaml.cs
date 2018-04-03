using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BubbleFibCross;
using System.Net.Http;
using System.Net;
using System.IO;

namespace BubbleFibCross
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}		

		private void Fibonacci_Clicked(object sender, EventArgs e)
		{
            var before = DateTime.Now;
            FibonacciSequence(Int32.Parse(FibPicker.Items[FibPicker.SelectedIndex].ToString()));
            var totalTime = DateTime.Now - before;

            ResultLabel.Text = totalTime.TotalMilliseconds.ToString() + " millisekunder";
        }
        

		private void Bubble_Clicked(object sender, EventArgs e)
		{
            var list = GetListVeryUgly(BubPicker.Items[BubPicker.SelectedIndex].ToString());  

            var before = DateTime.Now;
            BubbleSort(list);
            var totalTime = DateTime.Now - before;

            ResultLabel.Text = totalTime.TotalMilliseconds.ToString() + " millisekunder";            
		}
        

        private int FibonacciSequence(int value)
        {
            if (value < 2)
                return value;

            return FibonacciSequence(value - 2) + FibonacciSequence(value - 1);
        }

        private int[] GetListVeryUgly(string value)
        {
            switch (value)
            {
                case "Best Case 10 000":
                    return GetOrderedList(10000, false);
                case "Best Case 20 000":
                    return GetOrderedList(20000, false);
                case "Best Case 30 000":
                    return GetOrderedList(30000, false);
                case "Best Case 40 000":
                    return GetOrderedList(40000, false);
                case "Best Case 50 000":
                    return GetOrderedList(50000, false);
                case "Worst Case 10 000":
                    return GetOrderedList(10000, true);
                case "Worst Case 20 000":
                    return GetOrderedList(20000, true);
                case "Worst Case 30 000":
                    return GetOrderedList(30000, true);
                case "Worst Case 40 000":
                    return GetOrderedList(40000, true);
                case "Worst Case 50 000":
                    return GetOrderedList(50000, true);
                case "Random 10 000":
                    return GetRandomList(10000);
                case "Random 20 000":
                    return GetRandomList(20000);
                case "Random 30 000":
                    return GetRandomList(30000);
                case "Random 40 000":
                    return GetRandomList(40000);
                case "Random 50 000":
                    return GetRandomList(50000);
                default:
                    break;
            }

            return null;
        }

        private void BubbleSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length-1; i++)           
                for (int j = 0; j < numbers.Length-1; j++)   // Kör igenom listan en gång för varje element i den
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        var tmp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = tmp;
                    }
                }
        }

        private int[] GetOrderedList (int amount, bool reversed)
        {
            var numbers = Enumerable.Range(1, amount).ToArray();

            if (reversed)
                Array.Reverse(numbers);

            return numbers;            
        }

        private int[] GetRandomList(int amount)
        {
            var text = new WebClient().DownloadString(new Uri("http://utbweb.its.ltu.se/~filves-3/bub/RandomIntegers" + amount + ".txt"));
           
            return Array.ConvertAll(text.Split(','), int.Parse);
        }               
           
    }    
}
