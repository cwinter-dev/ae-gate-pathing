using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Swashbuckle.AutoRestExtensions
{
    public class EnumTypeSchemaFilter : ISchemaFilter
    {
        public EnumTypeSchemaFilter()
        {
        }

        public EnumTypeSchemaFilter(bool modelAsString)
        {
            _modelAsString = modelAsString;
        }

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                var array = new OpenApiArray();
                array.AddRange(Enum.GetNames(context.Type).Select(n => new OpenApiString(n)));
                // NSwag
                schema.Extensions.Add("x-enumNames", array);
                // Openapi-generator
                schema.Extensions.Add("x-enum-varnames", array);
                // Autorest
                schema.Extensions.Add("x-ms-enum", array);
            }
            // var type = Nullable.GetUnderlyingType(context.Type) ?? context.Type;
            // System.Diagnostics.Debug.WriteLine(type.FullName);
            // if (type.IsEnum)
            // {
            //     // Add enum type information once
            //     if (schema.Extensions.ContainsKey("x-ms-enum")) return;

            //     if (_modelAsString)
            //     {
            //         schema.Extensions.Add("x-ms-enum", new
            //         {
            //             name = type.Name,
            //             modelAsString = _modelAsString
            //         });
            //     }
            //     else
            //     {
            //         var valuesList = new System.Collections.Generic.List<object>();
            //         foreach (var fieldInfo in type.GetFields())
            //         {
            //             if (fieldInfo.FieldType.IsEnum)
            //             {
            //                 var fName = fieldInfo.Name;
            //                 var fValue = (int)fieldInfo.GetRawConstantValue()!;
            //                 valuesList.Add(new { value = fValue, description = fName, name = fName });
            //             }
            //         }
            //         schema.Extensions.Add("x-ms-enum", new
            //         {
            //             name = type.Name,
            //             modelAsString = _modelAsString,
            //             values = valuesList
            //             //Values:
            //             /*
            //             accountType:
            //               type: string
            //               enum:
            //               - Standard_LRS
            //               - Standard_ZRS
            //               - Standard_GRS
            //               - Standard_RAGRS
            //               - Premium_LRS
            //               x-ms-enum:
            //                 name: AccountType
            //                 modelAsString: false
            //                 values:
            //                 - value: Standard_LRS
            //                   description: Locally redundant storage.
            //                   name: StandardLocalRedundancy
            //                 - value: Standard_ZRS
            //                   description: Zone-redundant storage.
            //                 - value: Standard_GRS
            //                   name: StandardGeoRedundancy
            //                 - value: Standard_RAGRS
            //                 - value: Premium_LRS
            //             */
            //         });
            //     }
            // }
        }

        private readonly bool _modelAsString;
    }
}