using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class TodoModel
{
    public long id { get; set; }
    public string task { get; set; } = string.Empty;
    public DateTime deadline { get; set; }
    public bool isCompleted { get; set; }
}

