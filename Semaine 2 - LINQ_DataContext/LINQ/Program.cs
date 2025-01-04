using LINQDataContext;
using static System.Collections.Specialized.BitVector32;

internal class Program
{
    private static void Main(string[] args)
    {
        DataContext dc = new DataContext();

        /// Exercice 1
        Student? jdepp = (from student in dc.Students
                          where student.Login == "jdepp"
                          select student)
                          .SingleOrDefault();

        Console.WriteLine("\nEXERCICE 1\n");

        if (jdepp != null)
        {
            Console.WriteLine(jdepp.Last_Name + " " + jdepp.First_Name);
        }

        /// Exercice 2.2

        var students22 = (from student in dc.Students
                          select new {
                              FullName = student.First_Name + " " + student.Last_Name,
                              Id = student.Student_ID
                          });

        Console.WriteLine("\nEXERCICE 2.2\n");

        foreach (var student in students22)
        {
            Console.WriteLine(student.Id + " " + student.FullName);
        }

        /// Exercice 3.1

        var students31 = (from student in dc.Students
                          where student.BirthDate.Year < 1955
                          select new {
                              LastName = student.Last_Name,
                              YearResult = student.Year_Result,
                              Status = student.Year_Result >= 12 ? "OK" : "KO" 
                          });

        Console.WriteLine("\nEXERCICE 3.1\n");

        foreach (var student in students31)
        {
            Console.WriteLine(student.LastName + " " + student.YearResult + " " + student.Status);
        }

        /// Exercice 3.4

        var students34 = (from student in dc.Students
                          where student.Year_Result <= 3
                          orderby student.Year_Result descending
                          select new
                          {
                              LastName = student.Last_Name,
                              YearResult = student.Year_Result,
                          });

        Console.WriteLine("\nEXERCICE 3.4\n");

        foreach (var student in students34)
        {
            Console.WriteLine(student.LastName + " " + student.YearResult);
        }

        /// Exercice 3.5

        var students35 = (from student in dc.Students
                          where student.Section_ID == 1110
                          orderby student.First_Name, student.Last_Name
                          select new
                          {
                              FullName = student.First_Name + " " + student.Last_Name,
                              YearResult = student.Year_Result,
                          }
                          );

        Console.WriteLine("\nEXERCICE 3.5\n");

        foreach (var student in students35)
        {
            Console.WriteLine(student.FullName + " " + student.YearResult);
        }

        /// Exercice 4.1

        double avgStudentsYearResult41 = (from student in dc.Students
                                      select student).Average(s => s.Year_Result);

        Console.WriteLine("\nEXERCICE 4.1\n");

        Console.WriteLine("\nAverage students year result : {0}\n", avgStudentsYearResult41);

        /// Exercice 4.5

        int countStudents45 = (from student in dc.Students
                                  select student).Count();

        Console.WriteLine("\nEXERCICE 4.5\n");

        Console.WriteLine("\nCount students : {0}\n", countStudents45);

        /// Exercice 5.1

        var students51 = dc.Students
            .GroupBy(s => s.Section_ID)
            .Select(group => new
            {
                SectionId = group.Key,
                MaxResult = group.Max(s => s.Year_Result)
            });

        Console.WriteLine("\nEXERCICE 5.1\n");

        foreach (var student in students51)
        {
            Console.WriteLine("Group id : " + student.SectionId + " ; Max year result : " + student.MaxResult);
        }

        /// Exercice 5.3

        var students53 = dc.Students
            .Where(s => s.BirthDate.Year >= 1970 &&  s.BirthDate.Year <= 1985)
            .GroupBy(s => s.BirthDate.Month)
            .Select(group => new
            {
                AvgResult = group.Average(s => s.Year_Result),
                BirthMonth = group.Max(s => s.BirthDate.Month)
            });

        Console.WriteLine("\nEXERCICE 5.3\n");

        foreach (var student in students53)
        {
            Console.WriteLine("Birth month : " + student.BirthMonth + " ; Average year result : " + student.AvgResult);
        }

        /// Exercice 5.5

        var coursesInfo55 = dc.Courses.Join(dc.Professors, c => c.Professor_ID, p => p.Professor_ID, (c, p) => new
        {
            CourseName = c.Course_Name,
            ProfessorName = p.Professor_Name,
            SectionId = p.Section_ID
        }).Join(dc.Sections, o => o.SectionId, s => s.Section_ID, (o, s) => new
        {
            CourseName = o.CourseName,
            ProfessorName = o.ProfessorName,
            SectionName = s.Section_Name
        });

        Console.WriteLine("\nEXERCICE 5.5\n");

        foreach (var courseInfo in coursesInfo55)
        {
            Console.WriteLine("Course Name : " + courseInfo.CourseName + " ; Professor Name : " + courseInfo.ProfessorName + " ; Section Name : " + courseInfo.SectionName);
        }

        /// Exercice 5.7

        var sections57 = dc.Professors
            .GroupBy(p => p.Section_ID)
            .Join(dc.Sections, g => g.Key, s => s.Section_ID, (g, s) => new
        {
            SectionId = g.Key,
            SectionName = s.Section_Name,
            ProfessorsNames = g.Select(p => p.Professor_Name).ToList()
        });

        Console.WriteLine("\nEXERCICE 5.7\n");

        foreach (var section in sections57)
        {
            Console.WriteLine("\nSection Id : " + section.SectionId + " ; Section Name : " + section.SectionName);
            Console.WriteLine("Professors :");
            foreach (var profName in section.ProfessorsNames)
            {
                Console.WriteLine(profName);
            }
        }



    }
}