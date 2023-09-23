﻿using System.ComponentModel.DataAnnotations;
using Adopet.API.Util;

namespace Adopet.API.Dominio.Entity
{
    internal class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public TipoPet Tipo { get; set; }
        public Cliente? Proprietario { get; set; }
    }
}
