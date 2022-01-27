using prototype.Application;
using prototype.Application.Interfaces;

namespace prototype.infrastructure
{
    public class PrototypeRepository : IPrototypeRepository
    {
        private ICollection<PrototypeDto> _prototypes;

        public PrototypeRepository()
        {
            _prototypes = new List<PrototypeDto>();
        }

        public async Task<PrototypeDto> ReadPrototype(Guid Id)
        {
            PrototypeDto prototype = _prototypes.FirstOrDefault(x => x.Id == Id);
            await Task.CompletedTask;

            if (prototype == null) return new();

            return prototype;
        }

        public async Task<ICollection<PrototypeDto>> ReadPrototypes()
        {
            await Task.CompletedTask;
            return _prototypes;
        }

        public async Task<PrototypeDto> WritePrototype(PrototypeDto prototype)
        {
            _prototypes.Add(prototype);
            await Task.CompletedTask;

            return prototype;

        }
    }
}