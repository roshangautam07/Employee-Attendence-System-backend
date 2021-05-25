namespace dotnet.Payload.Response
{
    public class Success
    {
        public string message { get; set; }
        public string status { get; set; }

        public Success(string message, string status)
        {
            this.message = message;
            this.status = status;
        }
    }
        
    }
