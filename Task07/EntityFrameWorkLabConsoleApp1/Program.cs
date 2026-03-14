using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;    

public class Student{

    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }

}

public class  ApplicationDbContext : DbContext
{
    public DbSet<Student> students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StudentDb;Trusted_Connection=True;");
    }


}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new ApplicationDbContext())
        {
            context.Database.EnsureCreated();
            var student = new Student
            {
                Name = "John Doe",
                Age = 20,
                Grade = "A"
            };
            context.students.Add(student);
            context.SaveChanges();
            var students = context.students.ToList();
            foreach (var s in students)
            {
                Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}, Grade: {s.Grade}");
            }
        }
    }
}