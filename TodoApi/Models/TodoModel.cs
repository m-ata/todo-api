namespace TodoApi.Models;

public class TodoModel
{
    public long id { get; set; }
    public string name { get; set; } = string.Empty;
    public long deadline { get; set; }
    public bool isComplete { get; set; }
}

