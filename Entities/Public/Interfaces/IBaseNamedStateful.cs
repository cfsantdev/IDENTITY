using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Public.Interfaces
{
    public interface IBaseNamedStateful : IBase, IBaseNamed, IBaseStateful
    {
    }
}
