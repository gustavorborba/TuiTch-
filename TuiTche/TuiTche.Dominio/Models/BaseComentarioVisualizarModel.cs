﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio.Models
{
    public abstract class BaseComentarioVisualizarModel
    {
        public int IdPublicacao { get; set; }
        public string Texto { get; set; }
        public string Username { get; set; }
        public DateTime DataComentario { get; set; }
    }
}
