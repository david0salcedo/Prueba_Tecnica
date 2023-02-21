using System.Text.Json;


namespace TEST.Services.HandlerExeption
{
    namespace GlobalErrorHandling.Models
    {
        public class ErrorDetails
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public override string ToString()
            {
                return JsonSerializer.Serialize(this);
            }
        }
    }
}
