using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping;

public interface IAutoMapper<Tsource, TDetination>
{
    public TDestination Map<Tsource, TDestination>(Tsource s);
}
