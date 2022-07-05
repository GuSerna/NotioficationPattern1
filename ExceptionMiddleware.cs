using Newtonsoft.Json;

namespace NotioficationPattern
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate.Invoke(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    var exAsCustomException = ex as CustomException;
                    context.Response.StatusCode = 422;

                    var obj = new { 
                        listMessages = exAsCustomException.ListMessage, 
                        message = exAsCustomException.Message, 
                        totalError = exAsCustomException.TotalMessages 
                    };

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(obj));

                }

                context.Response.StatusCode = 500;
                var obj2 = new { message = "Deu problema interno" };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(obj2));
            }
        }
    }
}
