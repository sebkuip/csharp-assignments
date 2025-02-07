namespace assignment1
{
    public class Programmer
    {
        String name;
        Speciality speciality;

        public Programmer(String name)
        {
            this.name = name;
            this.speciality = Speciality.Unknown;
        }

        public Programmer(String name, Speciality speciality) : this(name) 
        {
            this.speciality = speciality;
        }

        public void print()
        {
            Console.WriteLine($"Name: {this.name}, Specialty: {this.speciality}");
        }
    }
}
