using School.Repository;
using Semaine_5___Repository___UnitOfWork___SchoolApp.Models;
using Semaine_5___Repository___UnitOfWork___SchoolApp.UnitsOfWork;

internal class Program
{
    private static void Main(string[] args)
    {
        //IUnitOfWorkSchool unitOfWorkSchool = new UnitOfWorkSchoolMem();
        using (SchoolContext context = new SchoolContext())
        {
            IUnitOfWorkSchool unitOfWorkSchool = new UnitOfWorkSchoolSQL(context);

            ExB2a(unitOfWorkSchool);
            ExB2b(unitOfWorkSchool);
            ExB2c(unitOfWorkSchool);
            ExB2d(unitOfWorkSchool);
            ExC1(unitOfWorkSchool);
        }
    }
    private static void ExB2a(IUnitOfWorkSchool unitOfWorkSchool)
    {
        // EXERCICE B2a

        Console.WriteLine("\nAdding two sections :\n");

        IRepository<Section> sectionRepository = unitOfWorkSchool.SectionsRepository;

        string sectInfoName = "sectInfo";
        string sectDietName = "sectDiet";

        Section? sectionInfoFound = sectionRepository.SearchFor(s => s.Name == sectInfoName).FirstOrDefault();
        Section? sectionDietFound = sectionRepository.SearchFor(s => s.Name == sectDietName).FirstOrDefault();

        int countSectionInserts = 0;

        if (sectionInfoFound == null)
        {
            Section sectionOne = new Section { Name = sectInfoName };
            sectionRepository.Insert(sectionOne);
            Console.WriteLine("Section {0} added !", sectInfoName);
            countSectionInserts++;
        }

        if (sectionDietFound == null)
        {
            Section sectionTwo = new Section { Name = sectDietName };
            sectionRepository.Insert(sectionTwo);
            Console.WriteLine("Section {0} added !", sectDietName);
            countSectionInserts++;
        }

        if (countSectionInserts == 0)
        {
            Console.WriteLine("No section added.");
        }

    }

    private static void ExB2b(IUnitOfWorkSchool unitOfWorkSchool)
    {
        // EXERCICE B2b

        Console.WriteLine("\nSections list :\n");

        IRepository<Section> sectionRepository = unitOfWorkSchool.SectionsRepository;

        IList<Section> sections = sectionRepository.GetAll();

        foreach (Section section in sections)
        {
            Console.WriteLine(section.Name);
        }

    }

    private static void ExB2c(IUnitOfWorkSchool unitOfWorkSchool)
    {
        // EXERCICE B2c

        Console.WriteLine("\nAdding three students :\n");

        string sectInfoName = "sectInfo";
        string sectDietName = "sectDiet";

        IRepository<Section> sectionRepository = unitOfWorkSchool.SectionsRepository;
        IRepository<Student> studentRepository = unitOfWorkSchool.StudentsRepository;

        Section? sectInfo = sectionRepository.SearchFor(s => s.Name == sectInfoName).FirstOrDefault();
        Section? sectDiet = sectionRepository.SearchFor(s => s.Name == sectDietName).FirstOrDefault();

        string studentInfoNameOne = "studinfo1";
        string studentInfoNameTwo = "studinfo2";
        string studentDietNameOne = "studdiet";

        Student? studentInfoOneFound = studentRepository.SearchFor(s => s.Name == studentInfoNameOne).FirstOrDefault();
        Student? studentInfoTwoFound = studentRepository.SearchFor(s => s.Name == studentInfoNameOne).FirstOrDefault();
        Student? studentDietOneFound = studentRepository.SearchFor(s => s.Name == studentInfoNameOne).FirstOrDefault();

        int countStudentInserts = 0;

        if (studentInfoOneFound == null)
        {
            Student studentInfoOne = new Student { Firstname = "", Name = studentInfoNameOne, Section = sectInfo, YearResult = 100 };
            studentRepository.Insert(studentInfoOne);
            Console.WriteLine("Student {0} added !", studentInfoNameOne);
            countStudentInserts++;
        }

        if (studentInfoTwoFound == null)
        {
            Student studentInfoTwo = new Student { Firstname = "", Name = studentInfoNameTwo, Section = sectInfo, YearResult = 120 };
            studentRepository.Insert(studentInfoTwo);
            Console.WriteLine("Student {0} added !", studentInfoNameTwo);
            countStudentInserts++;
        }

        if (studentDietOneFound == null)
        {
            Student studentDietOne = new Student { Firstname = "", Name = studentDietNameOne, Section = sectDiet, YearResult = 110 };
            studentRepository.Insert(studentDietOne);
            Console.WriteLine("Student {0} added !", studentDietNameOne);
            countStudentInserts++;
        }

        if (countStudentInserts == 0)
        {
            Console.WriteLine("No student added.");
        }

    }

    private static void ExB2d(IUnitOfWorkSchool unitOfWorkSchool)
    {
        // EXERCICE B2d

        Console.WriteLine("\nStudents list :\n");

        IRepository<Student> studentRepository = unitOfWorkSchool.StudentsRepository;

        IList<Student> students = studentRepository.GetAll();

        foreach (Student student in students)
        {
            Console.WriteLine(student.Name);
        }

    }

    private static void ExC1(IUnitOfWorkSchool unitOfWorkSchool)
    {
        // EXERCICE C1

        Console.WriteLine("\nStudents by section :\n");

        IRepository<Student> studentRepository = unitOfWorkSchool.StudentsRepository;

        var sectionsStudents = studentRepository
            .GetAll()
            .GroupBy(s => s.SectionId)
            .Select(gp => new
            {
                SectionId = gp.Key,
                Students = gp.Select(gp => gp).OrderByDescending(s => s.YearResult)
            });

        foreach (var section in sectionsStudents)
        {
            Console.WriteLine("Section id : {0}", section.SectionId);

            Console.WriteLine("Students :");

            foreach (var student in section.Students)
            {
                Console.WriteLine("Student name : {0} ; student year result : {1}", student.Name, student.YearResult);
            }
        }

    }

}