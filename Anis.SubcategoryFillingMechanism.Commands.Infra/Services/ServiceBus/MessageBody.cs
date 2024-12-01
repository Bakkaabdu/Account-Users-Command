namespace Anis.SubcategoryFillingMechanism.Commands.Infra.Services.ServiceBus
{
    public class MessageBody
    {
        public Guid AggregateId { get; set; }
        public int Sequence { get; set; }
        public string? UserId { get; set; }
        public required string Type { get; set; }
        public required object Data { get; set; }
        public DateTime DateTime { get; set; }
        public int Version { get; set; }
    }
}
