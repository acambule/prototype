namespace prototype.Application.Interfaces
{
    public interface IPrototypeService
    {
        public Task<ICollection<PrototypeDto>> ReadPrototypes();

        public Task<PrototypeDto> ReadPrototype(Guid id);

        public Task<PrototypeDto> WritePrototype(PrototypeDto prototype);
    }
}
