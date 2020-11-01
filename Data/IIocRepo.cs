using System.Collections.Generic;
using System.Threading.Tasks;
using iocs_analizer_api.Models;

namespace iocs_analizer_api.Data
{
    public interface IIocRepo
    {
        Task SaveChangesAsync();

        Task<IEnumerable<Ioc>> GetAllIocsAsync();

        Task<Ioc> GetIocByIdAsync(int id);

        Task CreateIocAsync(Ioc ioc);

        void UpdateIoc(Ioc ioc);

        void DeleteIoc(Ioc ioc);
    }
}