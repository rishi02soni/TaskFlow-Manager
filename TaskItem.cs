namespace TaskFlowManager
{
    public class TaskItem
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string title)
        {
            Title = title;
            IsCompleted = false;
        }

        public override string ToString()
        {
            return $"{Title}|{IsCompleted}";
        }

        public static TaskItem FromString(string data)
        {
            string[] parts = data.Split('|');
            return new TaskItem(parts[0])
            {
                IsCompleted = bool.Parse(parts[1])
            };
        }
    }
}
