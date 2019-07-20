using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Models.Shared.Validation
{
    public class ValidationResponseModel
    {
        /// <summary>
        /// Nome da propriedade.
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Erros.
        /// </summary>
        public string[] Errors { get; set; }
    }
}
