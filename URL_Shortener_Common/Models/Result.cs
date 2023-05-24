namespace URL_Shortener_Common.Models
{
    public class Result
    {
        public string Message { get; set; }

        public IEnumerable<string> AdditionalMessages { get; set; }

        public bool Completed { get; set; }

        public Result()
        {

        }

        public Result(string message, bool completed)
        {
            Message = message;
            Completed = completed;
        }
    }
}
