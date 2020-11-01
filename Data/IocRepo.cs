using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iocs_analizer_api.Models;
using Microsoft.EntityFrameworkCore;

namespace iocs_analizer_api.Data
{
    public class IocRepo : IIocRepo
    {
        private readonly AppDbContext _context;

        public IocRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ioc>> GetAllIocsAsync()
        {
            return await _context.Iocs.ToListAsync();
        }

        public async Task<Ioc> GetIocByIdAsync(int id)
        {
            return await _context.Iocs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateIocAsync(Ioc ioc)
        {
            if (ioc == null)
                throw new ArgumentNullException(nameof(ioc));

            await _context.Iocs.AddAsync(ioc);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateIoc(Ioc ioc)
        {
            _context.Iocs.Update(ioc);
        }

        public void DeleteIoc(Ioc ioc)
        {
            if (ioc == null)
                throw new ArgumentNullException(nameof(ioc));

            _context.Iocs.Remove(ioc);
        }
    }
}