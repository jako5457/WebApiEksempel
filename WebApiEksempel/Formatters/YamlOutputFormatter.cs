using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using SharpYaml.Serialization;
using System.Text;

namespace WebApiEksempel.Formatters
{
    public class YamlOutputFormatter : TextOutputFormatter
    {

        public YamlOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/x-yaml"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-yaml"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var httpContext = context.HttpContext;
            var serviceProvider = httpContext.RequestServices;
            var logger = serviceProvider.GetRequiredService<ILogger<YamlOutputFormatter>>();

            var serializer = new Serializer();
            string serialized = serializer.Serialize(context.Object);

            httpContext.Response.WriteAsync(serialized);

            return Task.CompletedTask;
        }
    }
}
