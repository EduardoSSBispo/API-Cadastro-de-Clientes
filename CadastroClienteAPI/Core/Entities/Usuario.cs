﻿namespace Core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public byte[] HashSenha { get; set; }

        public byte[] SaltSenha { get; set; }
    }
}
