using Microsoft.Extensions.Primitives;

namespace SerilogSample.Extentions
{
    public static class HttpContextCorrelationExtension
    {

        public static string GetCorrelationId(this HttpContext httpContext)
        {
            httpContext.Request.Headers.TryGetValue("IKC-Correlation-Id", out StringValues correlationId);


            if (string.IsNullOrEmpty(correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
                httpContext.Request.Headers.Add("IKC-Correlation-Id", correlationId);
            }

            return correlationId;
        }


    }
}
