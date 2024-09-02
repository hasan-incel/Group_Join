namespace GroupJoin
{
    class Program
    {
        public class Student
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public int ClassId { get; set; }
        }

        public class Class
        {
            public int ClassId { get; set; }
            public string ClassName { get; set; }
        }

        static void Main()
        {
            // Öğrenci verilerini tanımlıyoruz
            List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
            new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 2 },
            new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 1 },
            new Student { StudentId = 4, StudentName = "Fatma", ClassId = 3 },
            new Student { StudentId = 5, StudentName = "Ahmet", ClassId = 2 }
        };

            // Sınıf verilerini tanımlıyoruz
            List<Class> classes = new List<Class>
        {
            new Class { ClassId = 1, ClassName = "Matematik" },
            new Class { ClassId = 2, ClassName = "Türkçe" },
            new Class { ClassId = 3, ClassName = "Kimya" }
        };

            // Group Join işlemi
            var result = from c in classes
                         join s in students on c.ClassId equals s.ClassId into studentGroup
                         select new
                         {
                             ClassName = c.ClassName,
                             Students = studentGroup.Select(s => s.StudentName)
                         };

            // Sonuçları ekrana yazdırıyoruz
            foreach (var group in result)
            {
                Console.WriteLine($"Sınıf: {group.ClassName}");
                Console.WriteLine("Öğrenciler:");
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"- {student}");
                }
                Console.WriteLine();
            }
        }
    }
}