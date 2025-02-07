namespace assignment1
{
    public class Team
    {
        List<Programmer> programmers;
        public Team()
        {
            programmers = new List<Programmer>();
        }

        public void AddProgrammer(Programmer p)
        {
            programmers.Add(p);
        }

        public void PrintAllTeamMembers()
        {
            foreach(Programmer p  in programmers)
            {
                p.print();
            }
        }
    }
}
