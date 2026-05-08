namespace TaskCaseAPI.DTOs
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }

        public required string Title { get; set; }
        public required string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
