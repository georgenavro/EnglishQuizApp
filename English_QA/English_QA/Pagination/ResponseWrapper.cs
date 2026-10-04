namespace English_QA.Pagination
{
    public class ResponseWrapper<T>
    { 
        public ResponseWrapper()
        {
            Data = default!;
            succeded = true;
            Message = string.Empty;
            Errors = new string[0];
        }
        public T Data { get; set; } = default!;
        public bool succeded { get; set;}
        public string Message { get; set; } = string.Empty;
        public string[] Errors { get; set; } = new string[0];
    }
}
