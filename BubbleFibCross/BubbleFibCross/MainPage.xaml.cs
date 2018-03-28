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
            var list = GetRandomList();

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

        private void BubbleSort(int[] numbers)
        {
            int tmp;
            for (int i = 0; i < numbers.Length-1; i++)           
                for (int j = 0; j < numbers.Length-1; j++) // Kör igenom listan en gång för varje element i den
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        tmp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = tmp;

                    }
                }

           /* var text = "";

            foreach (var num in numbers)
            {
                text += $"{num}\n";
            }

            ResultLabel.Text = text; */


           
        }

        private int[] GetRandomList()
        {
            // http://utbweb.its.ltu.se/~filves-3/bub/RandomIntegers10000.txt

            var text = new WebClient().DownloadString(new Uri("http://utbweb.its.ltu.se/~filves-3/bub/RandomIntegers10000.txt"));

            return Array.ConvertAll(text.Split(new[] { Environment.NewLine }, StringSplitOptions.None), int.Parse);

            
            
        }
           
    }    
}
