﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio.Models;

namespace TuiTche.Dominio.Mapper
{
    public interface IComentarioVisualizarMapper
    {
        BaseComentarioVisualizarModel EntityToModel(Comentario comentario);
    }
}
