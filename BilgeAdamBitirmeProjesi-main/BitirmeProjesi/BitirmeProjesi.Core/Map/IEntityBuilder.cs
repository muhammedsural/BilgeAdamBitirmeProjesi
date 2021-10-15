using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Map
{
    public interface IEntityBuilder
    {
        void Build(ModelBuilder builder);
    }
}
