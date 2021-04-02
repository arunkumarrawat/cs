using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class AverageSalaryExcludingtheMinimumandMaximumSalary_1491
    {

        public double Average(int[] salary)
        {
            double result = 0;
            Array.Sort(salary);

            for (int i = 1; i <= salary.Length - 2; i++)
            {
                result += salary[i];
            }

            return result / (salary.Length - 2);

        }

        public static void main()
        {
            int[] g = new int[] { 6000, 5000, 4000, 3000, 2000, 1000 };

            AverageSalaryExcludingtheMinimumandMaximumSalary_1491 x = new AverageSalaryExcludingtheMinimumandMaximumSalary_1491();
            Console.WriteLine(x.Average(g));

        }
    }
}
