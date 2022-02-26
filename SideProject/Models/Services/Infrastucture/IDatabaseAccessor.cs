using System;
using System.Data;
using System.Threading.Tasks;

namespace SideProject.Models.Services.Infrastucture
{
    public interface IDatabaseAccessor
    {
        Task<DataSet> QueryAsync(FormattableString query);
    }
}