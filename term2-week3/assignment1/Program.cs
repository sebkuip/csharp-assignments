namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            List<Course> gradeList = ReadGradeList(3);
            DisplayGradeList(gradeList);
        }

        int ReadInt(string question)
        {
            Console.Write(question);
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        int ReadInt(string question, int minValue, int maxValue)
        {
            bool valid = false;
            int input = 0;
            while (!valid)
            {
                input = ReadInt(question);
                if (minValue <= input && input <= maxValue)
                {
                    valid = true;
                }
            }
            return input;
        }

        string ReadString(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        PracticalGrade ReadPracticalGrade(string question)
        {
            PracticalGrade practicalGrade = (PracticalGrade)Enum.Parse(typeof(PracticalGrade), ReadString(question));
            return practicalGrade;
        }

        void DisplayPracticalGrade(PracticalGrade practicalGrade)
        {
            Console.WriteLine($"Practical grade: {practicalGrade}");
        }

        Course ReadCourse(string question)
        {
            Course course = new Course();
            course.name = ReadString(question);
            return course;
        }

        void DisplayCourse(Course course)
        {
            Console.WriteLine(course.name);
        }

        List<Course> ReadGradeList(int nrOfCourses) { 
            List<Course> gradeList = new List<Course>();
            for (int i = 0; i < nrOfCourses; i++)
            {
                Console.WriteLine("Enter a course.");
                Course course = ReadCourse("Name of the course: ");
                course.theoryGrade = ReadInt($"Theory grade for {course.name}: ", 0, 100);
                Console.WriteLine("0. None 1. Absent 2. Insufficient 3. SUfficient 4. Good");
                course.practicalGrade = ReadPracticalGrade($"Practical grade for {course.name}: ");
                Console.WriteLine();
                gradeList.Add(course);
                
            }
            return gradeList;
        }

        void DisplayGradeList (List<Course> gradeList)
        {
            bool cumLaude = true;
            bool passed = true;

            foreach(Course course in gradeList)
            {
                Console.WriteLine($"{course.name} : {course.theoryGrade} {course.practicalGrade}");
                if (!course.CumLaude())
                {
                    cumLaude = false;
                }
                if (!course.Passed())
                {
                    passed = false;
                }
            }
            if (cumLaude)
            {
                Console.WriteLine("Congratulations, you graduated Cum Laude!");
            } else if (passed)
            {
                Console.WriteLine("Congratulations, you graduated!");
            } else
            {
                Console.WriteLine("Too bad, you did not graduate, you got 2 retakes.");
            }
        }
    }

    enum PracticalGrade
    {
        None,
        Absent,
        Insufficient,
        Sufficient,
        Good
    }

    class Course
    {
        public string name;
        public int theoryGrade;
        public PracticalGrade practicalGrade;

        public bool Passed()
        {
            return theoryGrade >= 55 && (practicalGrade.Equals(PracticalGrade.Sufficient) || practicalGrade.Equals(PracticalGrade.Good));
        }

        public bool CumLaude()
        {
            return theoryGrade >= 80 && practicalGrade.Equals(PracticalGrade.Good);
        }
    }
}
