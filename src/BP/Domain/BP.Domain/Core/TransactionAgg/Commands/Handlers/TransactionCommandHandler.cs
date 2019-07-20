using BP.Domain.Core.MdrAgg.Repository;
using BP.Domain.Shared.Messages;
using BP.Domain.Shared.Notification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BP.Domain.Core.TransactionAgg.Commands.Handlers
{
    public class TransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Transaction>
    {
        private readonly IMdrRepository _mdrRepository;
        private readonly INotificationDomainService _notificationDomainService;

        public TransactionCommandHandler(INotificationDomainService notificationDomainService, IMdrRepository mdrRepository)
        {
            _notificationDomainService = notificationDomainService;
            _mdrRepository = mdrRepository;
        }

        async Task<Transaction> IRequestHandler<CreateTransactionCommand, Transaction>.Handle(CreateTransactionCommand createTransactionCommand, CancellationToken cancellationToken)
        {
            var mdrAdquirente = await _mdrRepository.GetById(createTransactionCommand.Adquirente);

            if (mdrAdquirente == null)
            {
                _notificationDomainService.Add(code: NotificationMessages.MdrAdquirenteNotExistKey, value: NotificationMessages.MdrAdquirenteNotExistValue);
            }

            return await Task.Run( () => Transaction.Create(0, "", "", "") );

        }

    }

}
