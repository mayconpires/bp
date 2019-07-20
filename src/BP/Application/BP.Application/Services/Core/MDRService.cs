using AutoMapper;
using BP.Domain.Core.MdrAgg.Repository;
using BP.Domain.Core.TransactionAgg.Commands;
using BP.Interface.Application.Core.MDR;
using BP.Models.ViewModels.Core.MDR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BP.Application.Services.Core
{
    public class MdrService : IMdrService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _bus;
        private readonly IMdrRepository _mdrRepository;

        public MdrService(IMapper mapper, IMediator mediator, IMdrRepository mdrRepository)
        {
            _mapper = mapper;
            _bus = mediator;
            _mdrRepository = mdrRepository;
        }
            
        async Task<IEnumerable<MdrGetResposeModel>> IMdrService.Obter()
        {
            var mdrs = await _mdrRepository.GetAll();

            var mdrsModel =  _mapper.Map<IEnumerable<MdrGetResposeModel>>(mdrs);

            //var createTransactionCommand = new CreateTransactionCommand();
            //createTransactionCommand.Valor = 50;
            //await _bus.Send(createTransactionCommand);

            return mdrsModel;
        }

    }
}
