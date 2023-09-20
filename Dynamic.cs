using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    
    class Program
    {
        static Dictionary<string, long> CompanyName_Value = new Dictionary<string, long>();
        static Dictionary<long, long> Value_Profit = new Dictionary<long, long>();
        static long Compare(long a, long b)
        {
            return (a > b) ? a : b;
        }
  
        static long knapSack(long W, long[] value,long[] Profit, long n)
        {
            // jaye val profit bezar jaye wt val 

            int Num = Profit.Length;
            long[,] arr2 = new long[Num + 1, W + 1];



            for (int j = 0; j <= n; j++)
            {
                for (int i = 0; i <= W; i++)
                {
                    if (i == 0 || j == 0)
                    {
                        arr2[j, i] = 0;
                    }
                    else if (value[j - 1] <= i)
                    {
                        arr2[j, i] = Compare(Profit[j - 1] + arr2[j - 1, i - value[j - 1]], arr2[j - 1, i]);
                      
                    }
                    else{
                        arr2[j, i] = arr2[j - 1, i];
                        
                    }
                     
                   
                }
            }
         

            long M = W;
            long[] Result = new long[n];
            int count = 0;
            while (n != 0)
            {
                if(arr2[n, M] != arr2[n - 1, M])
                {
                    var keysWithMatchingValues = CompanyName_Value.Where(p => p.Value == value[n - 1]).Select(p => p.Key);
                    foreach (var key in keysWithMatchingValues)     
                    Console.WriteLine($"\tSaham with company Name :  {key}  and Weight or Value: {value[n-1]} and Profit:  {Profit[n-1]} is choised");
                    M = M - value[n - 1];
                    Result[count] = value[n - 1];
                    count++;
                }
                n--;

            }

            return arr2[Num, W];

            

        }
           
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of  inputs:");


            int Num;
            Num = Int32.Parse(Console.ReadLine());
            //Dictionary<string, long> CompanyName_Value = new Dictionary<string, long>();
            //Dictionary<long, long> Value_Profit = new Dictionary<long, long>();


            Console.WriteLine("Enter The companies Name and their values each value must be after the company Name:");
            for (int i = 0; i < Num; i++)
            {

                
                string first;
                long second = 0;
                Console.WriteLine($"Enter The company Name :{i}");

                first = Console.ReadLine();
                Console.WriteLine($"Enter The Value :{i}");
                second = long.Parse(Console.ReadLine());
                CompanyName_Value.Add(first, second);

            }

            long[] valueOfsaham = new long[Num];
            long[] ProfitOfsaham = new long[Num];
            int k = 0;
            foreach (KeyValuePair<string, long> ele1 in CompanyName_Value)
            {
                Console.WriteLine($"ENter the Profit for this Company:{ele1.Key} with this Value{ele1.Value}");
                valueOfsaham[k] = ele1.Value;               
              
                long profit;
                profit = long.Parse(Console.ReadLine());
                ProfitOfsaham[k] = profit;
                Value_Profit.Add(ele1.Value, profit);
                k++;
            }
         


            Console.WriteLine("Your Inputs are :\nvalueOfsaham  -  Profit ");
            foreach (KeyValuePair<long, long> ele1 in Value_Profit)
            {
                Console.WriteLine("{0}              :     {1} ",
                            ele1.Key, ele1.Value);
            }

            Console.WriteLine();

            // long[] val = new long[] { 60, 100, 120 };
            //long[] wt = new long[] { 10, 20, 30 };

            Console.WriteLine("Please Enter The Max limit:\n");
            long W = long.Parse(Console.ReadLine());
            //int n = val.Length;
             long n = valueOfsaham.Length;
            System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
            SW.Start();
            Console.WriteLine(knapSack(W, valueOfsaham , ProfitOfsaham, n));
            SW.Stop();
            Console.WriteLine(SW.ElapsedMilliseconds.ToString());

            //long[] Result = new long[n];

            //for (int i = 0; i < n; i++)
            //{
            //    Result
            //}



            Console.ReadLine();
        }
    }
}
