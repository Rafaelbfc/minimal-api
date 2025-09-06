﻿using Microsoft.EntityFrameworkCore;
using Minimal_API.Dominio.Entidades;

namespace Minimal_API.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration _configuracaoAppSettings;
        public DbContexto(IConfiguration configuracaoAppSettings)
        { 
            _configuracaoAppSettings = configuracaoAppSettings;

        }

        public DbSet<Administrador> administradores { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if(optionsBuilder.IsConfigured)

            { 
            var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql");
            if (!string.IsNullOrEmpty(stringConexao)) 
            {
                optionsBuilder.UseMySql(
                    stringConexao,
                    ServerVersion.AutoDetect(stringConexao)
                );
            }
            }
        }

    }
}
