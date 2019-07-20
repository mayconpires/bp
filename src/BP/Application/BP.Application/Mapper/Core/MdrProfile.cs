using AutoMapper;
using BP.Domain.Core.MdrAgg;
using BP.Domain.Core.MdrAgg.EntityChild;
using BP.Domain.Core.MdrAgg.Enums;
using BP.Models.ViewModels.Core.MDR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Application.Mapper.Core
{
    public class MdrProfile : Profile
    {
        public MdrProfile()
        {
            CreateMap<Mdr, MdrGetResposeModel>();
            CreateMap<Taxa, TaxaGetResponseModel>();
            CreateMap<BandeiraTipo, BandeiraTipoModel> ();
        }

    }
}
