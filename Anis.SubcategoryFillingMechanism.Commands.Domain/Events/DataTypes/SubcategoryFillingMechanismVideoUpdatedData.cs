using Anis.SubcategoryFillingMechanism.Commands.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes
{
    public record SubcategoryFillingMechanismVideoUpdatedData(String FillingMechanismVideoUrl) : IEventData 
        
    {
        public EventType Type => EventType.SubcategoryFillingMechanismVideoUpdated;
    }
}
