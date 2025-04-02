using System;
using CRMApplicationAPI.Common;
using CRMApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMApplicationAPI.Services
{
    public class ClientService : IBaseService<Cliente>
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> Create(Cliente entity)
        {
            _context.Clientes.Add(entity);
            _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Cliente> Update(Cliente entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
