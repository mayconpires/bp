using BP.Domain.Core.MdrAgg.Repository;
using BP.Domain.Core.TransactionAgg.Repository;
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
        private readonly INotificationDomainService _notificationDomainService;
        private readonly IMdrRepository _mdrRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionCommandHandler(INotificationDomainService notificationDomainService, IMdrRepository mdrRepository,
                                         ITransactionRepository transactionRepository)

        {
            _notificationDomainService = notificationDomainService;
            _mdrRepository = mdrRepository;
            _transactionRepository = transactionRepository;
        }

        async Task<Transaction> IRequestHandler<CreateTransactionCommand, Transaction>.Handle(CreateTransactionCommand transactionCmd, CancellationToken cancellationToken)
        {
            var mdrAdquirente = await _mdrRepository.GetById(transactionCmd.Adquirente);

            if (mdrAdquirente == null)  
            {
                _notificationDomainService.Add(code: NotificationMessages.MdrAdquirenteNotExistKey, value: NotificationMessages.MdrAdquirenteNotExistValue);
                return null;
            }

            var newTransaction = Transaction.Create(mdrAdquirente: mdrAdquirente,
                                                    valor: transactionCmd.Valor, 
                                                    tipo: transactionCmd.Tipo, 
                                                    bandeira: transactionCmd.Bandeira);

            newTransaction = _transactionRepository.Add(newTransaction);

            return newTransaction;
        }

    }

}
