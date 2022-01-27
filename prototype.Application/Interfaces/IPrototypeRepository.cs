using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototype.Application.Interfaces
{
    public interface IPrototypeRepository
    {
        Task<ICollection<PrototypeDto>> ReadPrototypes();

        Task<PrototypeDto> ReadPrototype(Guid Id);

        Task<PrototypeDto> WritePrototype(PrototypeDto prototype); 
    }
}
