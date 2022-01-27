using prototype.Application;
using prototype.Application.Interfaces;

namespace prototype.infrastructure.Services
{
    public class PrototypeService : IPrototypeService
    {
        private readonly IPrototypeRepository _prototypeRepository;

        public PrototypeService(IPrototypeRepository prototypeRepository)
        {
            _prototypeRepository = prototypeRepository;
        }

        public async Task<ICollection<PrototypeDto>> ReadPrototypes()
        {
            var prototypes = await _prototypeRepository.ReadPrototypes();

            return prototypes;
        }

        public async Task<PrototypeDto> ReadPrototype(Guid id)
        {
            var prototype = await _prototypeRepository.ReadPrototype(id);

            return prototype;
        }
        
        public async Task<PrototypeDto> WritePrototype(PrototypeDto prototype)
        {
            // Do some other service related things,
            // lets say: retrieve data from third-party service and add it here
            prototype.Description = "New data from third-party service";

            // Persist (Write to Database)
            prototype = await _prototypeRepository.WritePrototype(prototype);

            return prototype;

        }

    }
}
