using Backend.Infra.Api.ChangeRecord.DTO.Interfaces;
using Backend.Infra.Api.ChangeRecord.Interfaces;
using Backend.Infra.Base;
using Newtonsoft.Json;
using NJsonSchema.Converters;
using System.Runtime.Serialization;

namespace Backend.Infra.Api.ChangeRecord
{
    [JsonConverter(typeof(JsonInheritanceConverter), "discriminator")]
    [KnownType(typeof(IChangeRecordDTO))]
    public class ChangeRecord : BaseNamedStateful, IChangeRecord
    {
        public Guid RecordIdentifier { get; set; }
        public string? SerializedPrevious { get; set; }
        public string? SerializedCurrent { get; set; }
    }
}
