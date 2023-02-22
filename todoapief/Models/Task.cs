//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace todoapief;

public class Task {
    //[Key]
    public Guid TaskId { get; set; }

    //[ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }

    //[Required]
    //[MaxLength(200)]
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public Priority TaskPriority { get; set; } 
    public DateTime CreatedAt { get; set; }
    public  virtual Category Category { get; set; }


    //[NotMapped] este atributo permite que esta columna no se cree en la BD
    public string Summary { get; set; }
}

public enum Priority {
    Low, 
    Medium, 
    High
    
}