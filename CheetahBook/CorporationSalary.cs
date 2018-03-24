using System;

namespace CheetahBook
{
    // SRM407
    public class CorporationSalary
    {
        long[] salaries;

        public CorporationSalary()
        {
            var reader = new System.IO.StreamReader("Inputs_CorporationSalary.txt");
            Console.SetIn(reader);
        }

        public long TotalSalary(string[] relations)
        {
            this.salaries = new long[relations.Length];

            var total = 0L;
            for (var i = 0; i < relations.Length; i++)
            {
                total += CalcSalary(i, relations);
            }
            return total;
        }

        private long CalcSalary(int i, string[] relations)
        {
            if (this.salaries[i] == 0)
            {
                var salary = 0L;
                var relation = relations[i];
                for (var j = 0; j < relation.Length; j++)
                {
                    // If i th person has any subordinates, then calc
                    // each subordinantes' salary and sum those up as
                    // his/her salary.
                    if (relation[j] == 'Y')
                    {
                        salary += CalcSalary(j, relations);
                    }
                }
                // If i th person has no subordinates, then his/her salary
                // should be 1.
                this.salaries[i] = salary > 0 ? salary : 1;
            }
            return this.salaries[i];
        }

        public void Solve()
        {
            Console.WriteLine("CorporationSalary");
            var n = int.Parse(Console.ReadLine());
            var relations = new string[n];
            for (var i = 0; i < n; i++)
            {
                relations[i] = Console.ReadLine();
            }
            var total = TotalSalary(relations);
            Console.WriteLine($"{total}");
        }
    }
}
