using BP.Domain.Core.MdrAgg;
using BP.Domain.Core.MdrAgg.Enums;
using BP.Domain.Core.MdrAgg.Repository;
using BP.Domain.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Infra.Data.Repository
{
    public class MdrRepository : IMdrRepository
    {
        Mdr IRepository<Mdr>.Add(Mdr entity)
        {
            throw new NotImplementedException();
        }

        Mdr IRepository<Mdr>.Get()
        {
            throw new NotImplementedException();
        }

        Task<List<Mdr>> IRepository<Mdr>.GetAll()
        {
            List<Mdr> mdrs = getMdrs();

            return Task.Run(() => mdrs);
        }

        private static List<Mdr> getMdrs()
        {
            List<Mdr> mdrs = new List<Mdr>();

            Mdr mdrAdquirenteA = Mdr.Criar(idAdquirente: "A", adquirente: "Adquirente A");

            mdrAdquirenteA.AddTaxa(BandeiraTipo.Visa, taxaCredito: 2.25m, taxaDebito: 2.00m);
            mdrAdquirenteA.AddTaxa(BandeiraTipo.Master, taxaCredito: 2.35m, taxaDebito: 1.98m);

            mdrs.Add(mdrAdquirenteA);

            Mdr mdrAdquirenteB = Mdr.Criar(idAdquirente: "B", adquirente: "Adquirente B");

            mdrAdquirenteB.AddTaxa(BandeiraTipo.Visa, taxaCredito: 2.50m, taxaDebito: 2.08m);
            mdrAdquirenteB.AddTaxa(BandeiraTipo.Master, taxaCredito: 2.65m, taxaDebito: 1.75m);

            mdrs.Add(mdrAdquirenteB);

            Mdr mdrAdquirenteC = Mdr.Criar(idAdquirente: "C", adquirente: "Adquirente C");

            mdrAdquirenteC.AddTaxa(BandeiraTipo.Visa, taxaCredito: 2.75m, taxaDebito: 2.16m);
            mdrAdquirenteC.AddTaxa(BandeiraTipo.Master, taxaCredito: 3.10m, taxaDebito: 1.58m);

            mdrs.Add(mdrAdquirenteC);
            return mdrs;
        }

        Task<Mdr> IRepository<Mdr>.GetById(string id)
        {
            var mdrs = getMdrs();

            var mdrAdquirente = mdrs?.FirstOrDefault(m => m.IdAdquirente.ToLower() == id.ToLower());

            return Task.Run(() => mdrAdquirente);
        }
    }
}
