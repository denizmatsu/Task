
namespace WebApplication1.Workers
{

    public class Response<T>
    {
        public bool Succeeded { get; private set; }
        public string ErrorMessage { get; private set; }
        public IEnumerable<string> Errors { get; private set; }
        public T Data { get; private set; }

        public Response()
        {
        }

        public static Response<T> Succeed(T data)
        {
            return new Response<T> { Succeeded = true, Data = data };
        }

        public static Response<T> Fail(string errorMessage)
        {
            return new Response<T> { Succeeded = false, ErrorMessage = errorMessage };
        }

        public static Response<T> Fail(IEnumerable<string> errors)
        {
            return new Response<T> { Succeeded = false, Errors = errors };
        }
    }
}
