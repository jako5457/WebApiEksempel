using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using SharpYaml.Serialization;
using System.Text;

namespace WebApiEksempel.Formatters
{
    public class YamlInputFormatter : TextInputFormatter
    {
        public YamlInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/x-yaml"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-yaml"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var httpContext = context.HttpContext;
            var serviceProvider = httpContext.RequestServices;
            var logger = serviceProvider.GetRequiredService<ILogger<YamlOutputFormatter>>();

            var serializer = new Serializer();

            logger.LogInformation("Desrializing from Yaml");
            object? obj = serializer.Deserialize(httpContext.Request.Body,context.ModelType);

            if (obj == null)
            {
                return InputFormatterResult.FailureAsync();
            }
            
            return InputFormatterResult.SuccessAsync(obj);
        }
    }
}
