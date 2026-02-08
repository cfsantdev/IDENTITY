using AutoMapper;
using Backend.Infra.Api.ChangeRecord.DTO.Interfaces;
using Backend.Infra.Assemblies;
using Newtonsoft.Json;

namespace Backend.Infra.Api.ChangeRecord.DTO
{
    public class ChangeRecordDTO : ChangeRecord, IChangeRecordDTO
    {
        public ChangeRecordDTO()
        {
        }

        public object? Previous(out Type type)
        {
            type = AssembliesManagement.i.GetType(this.Name);

            return JsonConvert.DeserializeObject(this.SerializedPrevious, type);
        }

        public object? Current(out Type type)
        {
            type = AssembliesManagement.i.GetType(this.Name);

            return JsonConvert.DeserializeObject(this.SerializedCurrent, type);
        }
    }
}