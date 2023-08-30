using SwaggerDemoApp.Enums;

namespace SwaggerDemoApp.Infrastructure
{
    public class Response<T>
    { 
        public ResponseType ResponseType { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;

        public static Response<T> Create(ResponseType type, T? Data, string message)
        {
            return new Response<T> { ResponseType = type, Data = Data, Message = message };
        }
    }
}