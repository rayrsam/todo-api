namespace todo_api.Common
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<string> Tag { get; set; }
        public int Status { get; set; }
    }
}
