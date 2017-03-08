using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using WebActivatorEx;
using Sample;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Sample
{
	public class SwaggerConfig
	{
		public static void Register()
		{
			var thisAssembly = typeof(SwaggerConfig).Assembly;

			GlobalConfiguration.Configuration
				.EnableSwagger(c =>
					{


						c.SingleApiVersion("v1", "Sample");
					});
		}
	}

	/// <summary>
	/// If you would prefer to control the Swagger Operation ID
	/// values globally, uncomment this class, as well as the 
	/// call above that wires this Operation Filter into 
	/// the pipeline.
	/// </summary>
	/*
    internal class IncludeParameterNamesInOperationIdFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters != null)
            {
                // Select the capitalized parameter names
                var parameters = operation.parameters.Select(
                    p => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(p.name));

                // Set the operation id to match the format "OperationByParam1AndParam2"
                operation.operationId = $"{operation.operationId}By{string.Join("And", parameters)}";
            }
        }
    }
    */
}