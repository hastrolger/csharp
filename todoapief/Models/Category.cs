using System.Text.Json.Serialization;

namespace todoapief;

public class Category {
    public Guid CategoryId { get; set;}
    public string CategoryName { get; set;}
    public string CategoryDescription { get; set;}
    public int Weight { get; set;}

    [JsonIgnore]
    public virtual ICollection<Task> Tasks { get; set; }
}