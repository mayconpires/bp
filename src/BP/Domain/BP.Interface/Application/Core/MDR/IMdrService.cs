using BP.Models.ViewModels.Core.MDR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BP.Interface.Application.Core.MDR
{
    public interface IMdrService
    {

        Task<IEnumerable<MdrGetResposeModel>> Obter();

    }
}
