using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Code.FERRAMENTAS
{

    public class FERRAMENTAS
    {
    }

    public class COMUNS
    {

        public DTOUsuario UsuarioInfo(int id)
        {            
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario usuario = bllu.CarregaModeloUsuario(id);
            
            return usuario;
        }

    }
}
