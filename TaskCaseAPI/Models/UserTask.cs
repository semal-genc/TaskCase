namespace TaskCaseAPI.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
