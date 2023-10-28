using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadeDeTrabajo : IDisposable
    {
        //Aqui hay que poner una interfaces DAL por cada tabla de la BD//
        IDepartamentoDAL _departamentoDAL { get; }
        ICargosDAL _cargosDAL { get; }

        IUsuariosDAL _usuariosDAL { get; }  
        IRolDAL _rolDAL { get; }

        //hasta las interfaces//

        bool Complete();
    }
}
