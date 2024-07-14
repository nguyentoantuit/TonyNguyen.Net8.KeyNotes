// See https://aka.ms/new-console-template for more information

#region C#12-Alisas any type

DrawPoint(1, 2);
DrawLine(1, 1, 5, 5);

void DrawPoint(int x, int y)
{
    Console.WriteLine("Draw a point with X={x} and Y={y}", x, y);
}

void DrawLine(int x1, int y1, int x2, int y2)
{
    Console.WriteLine($"Draw a line between Point({x1},{y1}) and Point({x2},{y2})");
}


#endregion

#region C#12-Collection Expression & spread operator


string[] JobTitlesV1 = new[] { "CEO", "CFO", "COO", "CRO" };
List<string> AddionalJobTitlesV2 = new List<string>
{
    "Head of Sustainability/Sustainability Manager",
    "Head of Finance/Finance Manager",
    "Head of Risk/Risk Manager"
};

//app.MapGet("/v1/job-titles", () => JobTitlesV1);
//app.MapGet("/v2/job-titles", () => GetJobTitles());

IEnumerable<string> GetJobTitles()
{
    return JobTitlesV1.Concat(AddionalJobTitlesV2);
}

#endregion

#region C#12-Primary Constructor

var tony = new Person("tony");
Console.Write(tony.Name);

var tonyUser = new User("tony.nguyen");
Console.WriteLine(tonyUser.Username);

public class User
{
    public string Username { get; private set; }
    
    public User(string username)
    {
        Username = username;
    }
}

public record Person
{
    public string Name { get; init; }

    public Person(string name)
    {
        Name = name;
    }
}

class UserController(IUserService userService)
{
    public User GetUser()
    {
        return userService.GetUser();
    }
}

interface IUserService
{
    User GetUser();
}

#endregion

