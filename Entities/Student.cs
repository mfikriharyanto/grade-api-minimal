namespace Grade.Api.Entities;

public class Student
{
    private static int seedId = 1;

    public int Id { get; set; }
    public string Name { get; set; }

    public Student(string name)
    {
        Name = name;
    }

    public static int GetSeedId()
    {
        return seedId++;
    }
}