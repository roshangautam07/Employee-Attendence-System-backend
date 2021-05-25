namespace dotnet.Payload.Response
{
    public class Error
    {
        public string message { get; set; }
        public string status { get; set; }

        public Error(string message, string status)
        {
            this.message = message;
            this.status = status;
        }
    }
}