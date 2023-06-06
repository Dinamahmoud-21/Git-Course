namespace MVCDemo.Models
{
    public static  class StudentBL
    {
        static List<Student> Students= new List<Student>();
        static StudentBL()
        {
            Students.Add(new Student() { Id=1,Name="Ahmed",Address="Alex",Image="1.png"});

            Students.Add(new Student() { Id = 2, Name = "Alaa", Address = "Menia", Image = "1.png" });
            Students.Add(new Student() { Id = 3, Name = "Basma", Address = "assiut", Image = "2.jpg" });
            Students.Add(new Student() { Id = 4, Name = "Mohamed", Address = "sohag", Image = "1.png" });
            Students.Add(new Student() { Id = 5, Name = "Ibrahim", Address = "Alex", Image = "1.png" });
        }
        public static List<Student> GetAll()
        {
            return Students;
        }

    }
}
