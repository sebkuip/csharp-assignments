namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        public void Start()
        {
            Team team = new Team();
            Programmer programmer1 = new Programmer("Peter", Speciality.Csharp);
            team.AddProgrammer(programmer1);
            Programmer programmer2 = new Programmer("Kevin", Speciality.Java);
            team.AddProgrammer(programmer2);
            Programmer programmer3 = new Programmer("John", Speciality.Csharp);
            team.AddProgrammer(programmer3);
            Programmer programmer4 = new Programmer("Susan", Speciality.Java);
            team.AddProgrammer(programmer4);
            Programmer programmer5 = new Programmer("Emma");
            team.AddProgrammer(programmer5);
            team.PrintAllTeamMembers();
        }
    }
}
