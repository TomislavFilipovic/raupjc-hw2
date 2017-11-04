using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_02_07
{
    class Program
    {
        
        private static async Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }
        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThis(10) + await IKnowWhoKnowsThis(5);
        }
        private static async Task<int >IKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSum(n);
        }
        //  Ignore  this  part.
        static void Main(string[] args)
        {
            // Main  method  is the  only  method  that
            // can ’t be  marked  with  async.
            // What we are  doing  here is just a way  for us to  simulate
            // async -friendly  environment  you  usually  have  with
            // other .NET  application  types (like  web apps , win  apps  etc.)
            //  Ignore  main  method , you  can  just  focus on LetsSayUserClickedAButtonOnGuiMethod() as a
            // first  method  in the  call  hierarchy.
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }
        private static async Task<int> FactorialDigitSum(int n)
        {
            return await Task.Run(() => CalcFact(n));
        }

        private static int CalcFact(int n)
        {
            int result = 1;
            if (n > 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
            }
            int sum = 0;
            while (result != 0)
            {
                sum += result % 10;
                result /= 10;
            }
           
            return sum;
        }
    }
}
