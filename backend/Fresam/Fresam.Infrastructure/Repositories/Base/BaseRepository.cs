using Fresam.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Infrastructure.Repositories.Base;

public abstract class BaseRepository
{
    protected readonly DapperContext Context;

    protected BaseRepository(DapperContext context)
    {
        Context = context;
    }
}
