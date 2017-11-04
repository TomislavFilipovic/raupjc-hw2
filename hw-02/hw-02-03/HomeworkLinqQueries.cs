using System.Linq;
using hw_02;
using hw_02_04;

namespace hw_02_4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.OrderBy(e=>e).GroupBy(e => e).Select(e=>"Broj "+e.Key+" ponavlja se "+e.Count()+ " puta").ToArray();
        }
        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(s => s.Students.All(e=>e.Gender == Gender.Male)).ToArray();
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            return universityArray.Where(e => e.Students.Length < universityArray.Average(s => s.Students.Length))
                .ToArray();
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(e => e.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.SelectMany(e => e.Students.Where(h=>e.Students.All(g => g.Gender == Gender.Male) || e.Students.All(p=>p.Gender==Gender.Female))).Distinct().ToArray();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(e => e.Students).GroupBy(s => s.Jmbag).Select(h => universityArray.SelectMany(e=>e.Students).Where(i=>i.Jmbag==h.Key && h.Count()>=2).Distinct().ToArray()).SelectMany(d=>d).ToArray();
        }


    }
}