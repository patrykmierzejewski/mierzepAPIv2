using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MierzepAPIv2.Application.Common.Interfaces
{
    public interface IOmdbClient
    {
        public Task<string> GetMovieAsync(string searchFilter, CancellationToken cancellationToken);
    }
}
