﻿using Core.Entities;

namespace Core.Services
{
    public interface ILogradouroService
    {
        public int Create(IEnumerable<Logradouro> logradouro, Cliente cliente);

        public int Create(Logradouro logradouro);

        public void Edit(IEnumerable<Logradouro> logradouros);

        public void Edit(Logradouro logradouros);

        public void DeleteAllFromCliente(int ClienteId);

        public Logradouro? Get(int Id);

        public IEnumerable<Logradouro?> GetAll();

        public IEnumerable<Logradouro?> GetAllFromCliente(int ClienteId);

        public void Delete(int id);
    }
}