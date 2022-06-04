using ElectronicStore.Data.Base;
using ElectronicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Data.Service
{
    public class ProducerService:EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(DatabaseContext context):base(context)
        {

        }
    }
}
