using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

namespace ConsoleUI
{
    class Program
    {       

        static void Main(string[] args)
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    var result = paymentProcessor.MakePayment($"Demo{ i }", i);

                    Console.WriteLine(result.TransactionAmount);
                }

                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Skipped invalid record " + getInnerException(ex));
                }
                catch (FormatException ex)
                {
                    if(i != 5)
                    {
                        Console.WriteLine($"Formatting Issue " + getInnerException(ex));
                    }
                    
                }

                catch(NullReferenceException ex)
                {
                    Console.WriteLine($"Null value for item {i} " + getInnerException(ex));
                }
                
                catch (Exception ex)
                {
                    Console.WriteLine($"Payment skipped for payment with {i} items " + getInnerException(ex));                    
                }
            }
            Console.ReadKey();
        }

        public static string getInnerException(Exception ex)
        {
            if (ex.InnerException != null)
            {               
                return ex.Message; 
            }

            return "";

        }

    }
}
