using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.API.Shared.Swagger
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class HideInDocsAttribute : Attribute
    {
    }
}
