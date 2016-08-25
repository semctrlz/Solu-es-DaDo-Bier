using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Code.DTO;
using GUI.Code.DAL;
using System.Data;
using System.Net;
using System.Net.Sockets;

namespace GUI.Code.BLL
{
    #region Comuns

    public class BLLUsuario
    {
        private DALConexao conexao;
        
        public string IpLocal()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Impossível localizar o ip local desta máquina.");
        }

        public BLLUsuario(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOUsuario modelo)
        {
            if (modelo.NomeUsuario.Trim().Length == 0)
            {
                throw new Exception("O nome de usuário é obrigatório.");
            }

            if (modelo.LoginUsuario.Trim().Length == 0)
            {
                throw new Exception("O login do usuário é obrigatório.");
            }

            if (modelo.SenhaUsuario.Trim().Length == 0)
            {
                throw new Exception("A senha do usuário é obrigatória.");
            }

            if (modelo.IniciaisUsuario.Trim().Length == 0)
            {
                throw new Exception("As iniciais do Usuário devem ser preenchidas.");
            }

            if (modelo.IdUnidade <= 0)
            {
                throw new Exception("A unidade do Usuário deve ser prenchida.");
            }

            if (modelo.PermissaoUsuario <= 0)
            {
                throw new Exception("A Permissão do Usuário deve ser preenchida.");
            }


            //Tratamento das informações

            modelo.NomeUsuario = modelo.NomeUsuario.ToUpper();
            modelo.IniciaisUsuario = modelo.IniciaisUsuario.ToUpper();
            modelo.LoginUsuario = modelo.LoginUsuario.ToUpper();
            modelo.EmailUsuario = modelo.EmailUsuario.ToUpper();


            DALUsuario DALobj = new DALUsuario(conexao);
            DALobj.Incluir(modelo);
        }

        public void Excluir(int codigo)
        {
            DALUsuario DALobj = new DALUsuario(conexao);
            DALobj.Excluir(codigo);
        }

        public void Alterar(DTOUsuario modelo)
        {
            if (modelo.NomeUsuario.Trim().Length == 0)
            {
                throw new Exception("O nome de usuário é obrigatório.");
            }

            if (modelo.LoginUsuario.Trim().Length == 0)
            {
                throw new Exception("O login do usuário é obrigatório.");
            }

            if (modelo.SenhaUsuario.Trim().Length == 0)
            {
                throw new Exception("A senha do usuário é obrigatória.");
            }

            if (modelo.IniciaisUsuario.Trim().Length == 0)
            {
                throw new Exception("As iniciais do Usuário devem ser preenchidas.");
            }

            if (modelo.IdUnidade <= 0)
            {
                throw new Exception("A unidade do Usuário deve ser prenchida.");
            }

            if (modelo.PermissaoUsuario <= 0)
            {
                throw new Exception("A Permissão do Usuário deve ser preenchida.");
            }

            //Tratamento das informações

            modelo.NomeUsuario = modelo.NomeUsuario.ToUpper();
            modelo.IniciaisUsuario = modelo.IniciaisUsuario.ToUpper();
            modelo.LoginUsuario = modelo.LoginUsuario.ToUpper();


            DALUsuario DALobj = new DALUsuario(conexao);
            DALobj.Alterar(modelo);
        }

        public void AlterarSenha(DTOUsuario modelo)
        {
            DALUsuario DALobj = new DALUsuario(conexao);
            DALobj.AlterarSenha(modelo);
        }
        
        public DataTable Localizar(String valor)
        {
            DALUsuario DALobj = new DALUsuario(conexao);
            return DALobj.Localizar(valor);
        }

        public DataTable LocalizarPorId(int id)
        {
            DALUsuario DALobj = new DALUsuario(conexao);
            return DALobj.LocalizarPorId(id);
        }


        public DataTable ListarConexoes(int id)
        {
            DALUsuario DALobj = new DALUsuario(conexao);
            return DALobj.ListarConexoes(id, IpLocal());
        }

        public DataTable LocalizarLogin(string usuario, string senha)
        {
            DALUsuario DALobj = new DALUsuario(conexao);
            return DALobj.LocalizarLogin(usuario, senha);
        }

        public DataTable LocalizarIp(string ip)
        {
            DALUsuario DALobj = new DALUsuario(conexao);
            return DALobj.LocalizaIp(ip);
        }

        public DTOUsuario CarregaModeloUsuario(int codigo)
        {
            DALUsuario DALobj = new DALUsuario(conexao);
            return DALobj.CarregaModeloUsuario(codigo);
        }
        
    }

    public class BLLUnidade
    {
        private DALConexao conexao;

        public BLLUnidade(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOUnidade modelo, string foto)
        {

            //verifica o preenchimento do nome da unidade
            if (modelo.NomeUnidade.Trim().Length == 0)
            {
                throw new Exception("O nome da unidade não pode ficar em branco.");
            }
            //verifica o preenchimento do código da unidade
            if (modelo.CodUnidade.ToString() == "")
            {
                throw new Exception("Código da unidade inválido.");
            }

            //Tratamento dos dados

            modelo.NomeUnidade = modelo.NomeUnidade.Trim().ToUpper();

            DALUnidade DALobj = new DALUnidade(conexao);
            DALobj.Incluir(modelo, foto);

        }

        public void Alterar(DTOUnidade modelo, string foto)
        {

            if (modelo.IdUnidade <= 0)
            {
                throw new Exception("Selecione um registro para alterar.");
            }
            //verifica o preenchimento do nome da unidade
            if (modelo.NomeUnidade.Trim().Length == 0)
            {
                throw new Exception("O nome da unidade não pode ficar em branco.");
            }
            //verifica o preenchimento da razão social do fornecedor
            if (modelo.CodUnidade.Trim().Length == 0)
            {
                throw new Exception("Código da unidade inválido.");
            }


            //Tratamento dos dados

            modelo.NomeUnidade = modelo.NomeUnidade.Trim().ToUpper();

            DALUnidade DALobj = new DALUnidade(conexao);
            DALobj.Alterar(modelo, foto);
        }

        public void Excluir(int codigo)
        {
            DALUnidade DALobj = new DALUnidade(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(String valor)
        {
            DALUnidade DALobj = new DALUnidade(conexao);
            return DALobj.Localizar(valor);
        }

        public DataTable ListarUnidades()
        {
            DALUnidade DALobj = new DALUnidade(conexao);
            return DALobj.ListarUnidades();
        }

        public DataTable LocalizarCod(String valor)
        {
            DALUnidade DALobj = new DALUnidade(conexao);
            return DALobj.Localizar(valor);
        }

        public DTOUnidade CarregaModeloUnidade(int codigo)
        {
            DALUnidade DALobj = new DALUnidade(conexao);
            return DALobj.CarregaModeloUnidade(codigo);
        }
    }

    public class BLLLog
    {
        private DALConexao conexao;

        public BLLLog(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOLog modelo)
        {

            DALLLog DALobj = new DALLLog(conexao);
            DALobj.Incluir(modelo);

        }

        public void excluir(int id, string ip)
        {
            
            DALLLog DALobj = new DALLLog(conexao);
            DALobj.Excluir(id, ip);
        }


    }

    #endregion

    #region CMV

    public class BLLConfigCusto
    {
        private DALConexao conexao;

        public BLLConfigCusto(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOConfigCusto modelo)
        {

            DALConfigCusto DALobj = new DALConfigCusto(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOConfigCusto modelo)
        {

            DALConfigCusto DALobj = new DALConfigCusto(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int id)
        {
            DALConfigCusto DALobj = new DALConfigCusto(conexao);
            DALobj.Excluir(id);
        }

        


        public void ExcluirUnidade(int id)
        {
            DALConfigCusto DALobj = new DALConfigCusto(conexao);
            DALobj.ExcluirUnidade(id);
        }

        public DataTable LocalizarConfig(int unidade)
        {
            DALConfigCusto DALobj = new DALConfigCusto(conexao);
            return DALobj.LocalizarConfigCusto(unidade);
        }

        public DataTable LocalizarConfigPorId(int id)
        {
            DALConfigCusto DALobj = new DALConfigCusto(conexao);
            return DALobj.LocalizarConfigCustoPorId(id);
        }


        public DataTable ListarContas(int unidade)
        {
            DALConfigCusto DALobj = new DALConfigCusto(conexao);
            return DALobj.ListarContasCadastradas(unidade);
        }

        public DataTable ListarContasPorUnidadeTurnoETipo(int unidade, string turno, string tipo)
        {
            DALConfigCusto DALobj = new DALConfigCusto(conexao);
            return DALobj.ListarContasPorUnidadeTurnoETipo(unidade, turno, tipo);
        }

        public DataTable BuscaContaMaisNome(int unidade, string conta)
        {
            DALConfigCusto DALobj = new DALConfigCusto(conexao);
            return DALobj.BuscaCodMaisNomeConta(unidade, conta);
        }

        public DataTable BuscaContaMaisNomePeloId(int id)
        {
            DALConfigCusto DALobj = new DALConfigCusto(conexao);
            return DALobj.BuscaCodMaisNomeContaPeloId(id);
        }

        public DTOConfigCusto CarregaModeloConfig(int id)
        {
            DALConfigCusto DALobj = new DALConfigCusto(conexao);
            return DALobj.CarregaModeloConfig(id);
        }
    }

    public class BLLConfigReceita
    {
        private DALConexao conexao;

        public BLLConfigReceita(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOConfigReceita modelo)
        {

            modelo.NomeCodVenda = modelo.NomeCodVenda.ToUpper();

            DALConfigReceita DALobj = new DALConfigReceita(conexao);
            DALobj.Incluir(modelo);

        }
        
        public void Excluir(int id)
        {
            DALConfigReceita DALobj = new DALConfigReceita(conexao);
            DALobj.Excluir(id);
        }

        public void ExcluirTudo(int id)
        {
            DALConfigReceita DALobj = new DALConfigReceita(conexao);
            DALobj.ExcluirTudo(id);
        }

        public DataTable LocalizarConfig(int unidade)
        {
            DALConfigReceita DALobj = new DALConfigReceita(conexao);
            return DALobj.LocalizarConfigReceita(unidade);
        }        
    }

    public class BLLConfigPax
    {
        private DALConexao conexao;

        public BLLConfigPax(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOConfigPax modelo)
        {

            DALConfigPax DALobj = new DALConfigPax(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOConfigPax modelo)
        {

            DALConfigPax DALobj = new DALConfigPax(conexao);
            DALobj.Alterar(modelo);

        }

        public void Excluir(int id, string dia)
        {
            DALConfigPax DALobj = new DALConfigPax(conexao);
            DALobj.Excluir(id, dia);
        }

        public void ExcluirTudo(int id)
        {
            DALConfigPax DALobj = new DALConfigPax(conexao);
            DALobj.ExcluirTudo(id);
        }

        public DataTable Localizar(int unidade)
        {
            DALConfigPax DALobj = new DALConfigPax(conexao);
            return DALobj.localizar(unidade);
        }

        public DataTable LocalizarDia(int unidade, string dia)
        {
            DALConfigPax DALobj = new DALConfigPax(conexao);
            return DALobj.localizarDia(unidade, dia);
        }

    }

    public class BLLConfigImposto
    {
        private DALConexao conexao;

        public BLLConfigImposto(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOConfigImposto modelo)
        {
            DALConfigImposto DALobj = new DALConfigImposto(conexao);
            DALobj.Incluir(modelo);
        }
        
        public void Excluir(int id)
        {
            DALConfigImposto DALobj = new DALConfigImposto(conexao);
            DALobj.Excluir(id);
        }
        
        public DataTable Localizar(int unidade)
        {
            DALConfigImposto DALobj = new DALConfigImposto(conexao);
            return DALobj.localizar(unidade);
        }

        public DataTable localizarValoresTotaisImpostos(int unidade)
        {
            DALConfigImposto DALobj = new DALConfigImposto(conexao);
            return DALobj.localizarValoresTotaisImpostos(unidade);
        }

    }

    public class BLLConfigUnidade
    {
        private DALConexao conexao;

        public BLLConfigUnidade(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOConfigUnidade modelo)
        {

            DALConfigUnidade DALobj = new DALConfigUnidade(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOConfigUnidade modelo)
        {



            //verifica o preenchimento do nome da conta
            if (modelo.Config.Trim().Length == 0)
            {
                throw new Exception("Selecione uma configuração para continuar.");
            }

            //Tratamento dos dados

            DALConfigUnidade DALobj = new DALConfigUnidade(conexao);
            DALobj.Alterar(modelo);
        }

        public void AlterarU(DTOConfigUnidade modelo)
        {
            //verifica o preenchimento do nome da conta
            
            DALConfigUnidade DALobj = new DALConfigUnidade(conexao);
            DALobj.AlterarU(modelo);
        }

        public void Excluir(string tipo, int unidade)
        {
            DALConfigUnidade DALobj = new DALConfigUnidade(conexao);
            DALobj.Excluir(tipo, unidade);
        }

        public void ExcluirporUsuario(string tipo, int unidade, int usuario)
        {
            DALConfigUnidade DALobj = new DALConfigUnidade(conexao);
            DALobj.ExcluirPorUsuario(tipo, unidade, usuario);
        }
        
        public DataTable LocalizarConfig(String tipoConfig, int unidade)
        {
            DALConfigUnidade DALobj = new DALConfigUnidade(conexao);
            return DALobj.LocalizarConfig(tipoConfig, unidade);
        }

        public DataTable LocalizarConfigUsuario(String tipoConfig, int unidade, int usuario)
        {
            DALConfigUnidade DALobj = new DALConfigUnidade(conexao);
            return DALobj.LocalizarConfigUsuario(tipoConfig, unidade, usuario);
        }

        public DTOConfigUnidade CarregaModeloConfig(String tipoConfig, int unidade)
        {
            DALConfigUnidade DALobj = new DALConfigUnidade(conexao);
            return DALobj.CarregaModeloConfig(tipoConfig, unidade);
        }

        public class BLLUsuario
        {
            private DALConexao conexao;
            public BLLUsuario(DALConexao cx)
            {
                this.conexao = cx;
            }
            public void Incluir(DTOUsuario modelo)
            {
                if (modelo.NomeUsuario.Trim().Length == 0)
                {
                    throw new Exception("O nome de usuário é obrigatório.");
                }

                if (modelo.LoginUsuario.Trim().Length == 0)
                {
                    throw new Exception("O login do usuário é obrigatório.");
                }

                if (modelo.SenhaUsuario.Trim().Length == 0)
                {
                    throw new Exception("A senha do usuário é obrigatória.");
                }

                if (modelo.IniciaisUsuario.Trim().Length == 0)
                {
                    throw new Exception("As iniciais do Usuário devem ser preenchidas.");
                }

                if (modelo.IdUnidade <= 0)
                {
                    throw new Exception("A unidade do Usuário deve ser prenchida.");
                }

                if (modelo.PermissaoUsuario <= 0)
                {
                    throw new Exception("A Permissão do Usuário deve ser preenchida.");
                }


                //Tratamento das informações

                modelo.NomeUsuario = modelo.NomeUsuario.ToUpper();
                modelo.IniciaisUsuario = modelo.IniciaisUsuario.ToUpper();
                modelo.LoginUsuario = modelo.LoginUsuario.ToUpper();


                DAL.DALUsuario DALobj = new DALUsuario(conexao);
                DALobj.Incluir(modelo);
            }
            public void Excluir(int codigo)
            {
                DALUsuario DALobj = new DALUsuario(conexao);
                DALobj.Excluir(codigo);
            }
            public void Alterar(DTOUsuario modelo)
            {
                if (modelo.NomeUsuario.Trim().Length == 0)
                {
                    throw new Exception("O nome de usuário é obrigatório.");
                }

                if (modelo.LoginUsuario.Trim().Length == 0)
                {
                    throw new Exception("O login do usuário é obrigatório.");
                }

                if (modelo.SenhaUsuario.Trim().Length == 0)
                {
                    throw new Exception("A senha do usuário é obrigatória.");
                }

                if (modelo.IniciaisUsuario.Trim().Length == 0)
                {
                    throw new Exception("As iniciais do Usuário devem ser preenchidas.");
                }

                if (modelo.IdUnidade <= 0)
                {
                    throw new Exception("A unidade do Usuário deve ser prenchida.");
                }

                if (modelo.PermissaoUsuario <= 0)
                {
                    throw new Exception("A Permissão do Usuário deve ser preenchida.");
                }

                //Tratamento das informações

                modelo.NomeUsuario = modelo.NomeUsuario.ToUpper();
                modelo.IniciaisUsuario = modelo.IniciaisUsuario.ToUpper();
                modelo.LoginUsuario = modelo.LoginUsuario.ToUpper();


                DALUsuario DALobj = new DALUsuario(conexao);
                DALobj.Alterar(modelo);
            }
            public void AlterarSenha(DTOUsuario modelo)
            {


                DALUsuario DALobj = new DALUsuario(conexao);
                DALobj.AlterarSenha(modelo);
            }
            public DataTable Localizar(String valor)
            {
                DALUsuario DALobj = new DALUsuario(conexao);
                return DALobj.Localizar(valor);
            }
            public DTOUsuario CarregaModeloUsuario(int codigo)
            {
                DALUsuario DALobj = new DALUsuario(conexao);
                return DALobj.CarregaModeloUsuario(codigo);
            }

        }

        public class BLLUnidade
        {
            private DALConexao conexao;

            public BLLUnidade(DALConexao cx)
            {
                this.conexao = cx;
            }

            public void Incluir(DTOUnidade modelo, string foto)
            {

                //verifica o preenchimento do nome da unidade
                if (modelo.NomeUnidade.Trim().Length == 0)
                {
                    throw new Exception("O nome da unidade não pode ficar em branco.");
                }
                //verifica o preenchimento do código da unidade
                if (modelo.CodUnidade.ToString() == "")
                {
                    throw new Exception("Código da unidade inválido.");
                }

                //Tratamento dos dados

                modelo.NomeUnidade = modelo.NomeUnidade.Trim().ToUpper();

                DALUnidade DALobj = new DALUnidade(conexao);
                DALobj.Incluir(modelo, foto);

            }

            public void Alterar(DTOUnidade modelo, string foto)
            {


                if (modelo.IdUnidade <= 0)
                {
                    throw new Exception("Selecione um registro para alterar.");
                }
                //verifica o preenchimento do nome da unidade
                if (modelo.NomeUnidade.Trim().Length == 0)
                {
                    throw new Exception("O nome da unidade não pode ficar em branco.");
                }
                //verifica o preenchimento da razão social do fornecedor
                if (modelo.CodUnidade.Trim().Length == 0)
                {
                    throw new Exception("Código da unidade inválido.");
                }


                //Tratamento dos dados

                modelo.NomeUnidade = modelo.NomeUnidade.Trim().ToUpper();

                DALUnidade DALobj = new DALUnidade(conexao);
                DALobj.Alterar(modelo, foto);
            }

            public void Excluir(int codigo)
            {
                DALUnidade DALobj = new DALUnidade(conexao);
                DALobj.Excluir(codigo);
            }

            public DataTable Localizar(String valor)
            {
                DALUnidade DALobj = new DALUnidade(conexao);
                return DALobj.Localizar(valor);
            }

            public DataTable ListarUnidades()
            {
                DataTable dt = new DataTable();
                DALUnidade DALobj = new DALUnidade(conexao);
                return DALobj.ListarUnidades();
            }

            public DataTable LocalizarCod(String valor)
            {
                DALUnidade DALobj = new DALUnidade(conexao);
                return DALobj.Localizar(valor);
            }

            public DTOUnidade CarregaModeloUnidade(int codigo)
            {
                DALUnidade DALobj = new DALUnidade(conexao);
                return DALobj.CarregaModeloUnidade(codigo);
            }
        }
    }
    
    public class BLLContasGerenciais
    {

        private DALConexao conexao;

        public BLLContasGerenciais(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOContasGerenciais modelo)
        {

            //verifica o preenchimento do código da conta
            if (modelo.CodSetor.Trim().Length < 10)
            {
                throw new Exception("O código do setor deve ter 10 dígitos, no formato 0.0.00.000.");
            }
            //verifica o preenchimento do nome da conta
            if (modelo.NomeSetor.Trim().Length == 0)
            {
                throw new Exception("O nome do setor não pode ficar em branco.");
            }

            //Tratamento dos dados

            modelo.NomeSetor = modelo.NomeSetor.Trim().ToUpper();

            DALContasGerenciais DALobj = new DALContasGerenciais(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOContasGerenciais modelo)
        {


            //verifica o preenchimento do código da conta
            if (modelo.CodSetor.Trim().Length < 10)
            {
                throw new Exception("O código do setor deve ter 10 dígitos, no formato 0.0.00.000.");
            }
            //verifica o preenchimento do nome da conta
            if (modelo.NomeSetor.Trim().Length == 0)
            {
                throw new Exception("O nome do setor não pode ficar em branco.");
            }

            //Tratamento dos dados

            modelo.NomeSetor = modelo.NomeSetor.Trim().ToUpper();


            DALContasGerenciais DALobj = new DALContasGerenciais(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(string codigo)
        {
            DALContasGerenciais DALobj = new DALContasGerenciais(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(String valor)
        {
            DALContasGerenciais DALobj = new DALContasGerenciais(conexao);
            return DALobj.Localizar(valor);
        }

        public DataTable LocalizarGrupo(string codigo)
        {
            DALContasGerenciais DALobj = new DALContasGerenciais(conexao);
            return DALobj.LocalizarCodigo(codigo);
        }

        public DTOContasGerenciais CarregaModeloContaCodigo(String codigo)
        {
            DALContasGerenciais DALobj = new DALContasGerenciais(conexao);
            return DALobj.CarregaModeloContaCodigo(codigo);
        }

    }

    public class BLLAeB
    {

        private DALConexao conexao;

        public BLLAeB(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOAeB modelo)
        {
            
            modelo.NomeAeb = modelo.NomeAeb.Trim().ToUpper();
            modelo.CodAeb = modelo.CodAeb.Trim();

            DALAeB DALobj = new DALAeB(conexao);
            DALobj.Incluir(modelo);

        }

        public void AlterarPorCod(DTOAeB modelo)
        {

            modelo.NomeAeb = modelo.NomeAeb.Trim().ToUpper();
            modelo.CodAeb = modelo.CodAeb.Trim();

            DALAeB DALobj = new DALAeB(conexao);
            DALobj.AlterarPorCod(modelo);

        }


        public DTOAeB CarregaModeloAeB(string codigo)
        {
            DALAeB DALobj = new DALAeB(conexao);
            return DALobj.CarregaModeloAeB(codigo);
        }


        public void Excluir(DateTime data, int unidade)
        {
            DALAeB DALobj = new DALAeB(conexao);
            DALobj.Excluir(data, unidade);
        }


        public void ExcluirPorCod(string cod)
        {
            DALAeB DALobj = new DALAeB(conexao);
            DALobj.ExcluirPorCod(cod);
        }

        public DataTable Localizar(String valor)
        {
            DALAeB DALobj = new DALAeB(conexao);
            return DALobj.Localizar(valor);
        }

        public DataTable localizarPorCod(String cod)
        {
            DALAeB DALobj = new DALAeB(conexao);
            return DALobj.LocalizarPorCod(cod);
        }


        public DataTable LocalizarNome(String valor)
        {
            DALAeB DALobj = new DALAeB(conexao);
            return DALobj.LocalizarNome(valor);
        }
        

    }

    public class BLLExcessoesCusto
    {
        private DALConexao conexao;

        public BLLExcessoesCusto(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOExcessoesCusto modelo)
        {
            modelo.TipoOperacao = modelo.TipoOperacao.Trim().ToUpper();
            modelo.Obs = modelo.Obs.Trim();

            DALExcessoesCusto DALobj = new DALExcessoesCusto(conexao);
            DALobj.Incluir(modelo);
        }
        
        public void Excluir(int id)
        {
            DALExcessoesCusto DALobj = new DALExcessoesCusto(conexao);
            DALobj.Excluir(id);
        }

        public DataTable Localizar()
        {
            DALExcessoesCusto DALobj = new DALExcessoesCusto(conexao);
            return DALobj.Localizar();
        }

        public DataTable LocalizarId(int id)
        {
            DALExcessoesCusto DALobj = new DALExcessoesCusto(conexao);
            return DALobj.LocalizarId(id);
        }

        public DataTable LocalizarTipoOperacao(string operacao)
        {
            DALExcessoesCusto DALobj = new DALExcessoesCusto(conexao);
            return DALobj.LocalizarTipoOperacao(operacao);
        }

        public DTOExcessoesCusto CarregaModeloExcessaoCusto(String operacao)
        {
            DALExcessoesCusto DALobj = new DALExcessoesCusto(conexao);
            return DALobj.CarregaModeloExcessaoCusto(operacao);
        }

    }

    public class BLLDados
    {
        private DALConexao conexao;

        public BLLDados(DALConexao cx)
        {
            this.conexao = cx;
        }

        #region Venda

        public void Incluir(DTODados modelo)
        {

            DALDados DALobj = new DALDados(conexao);
            DALobj.Incluir(modelo);
        }

        public void Excluir(DateTime data, int unidade)
        {
            DALDados DALobj = new DALDados(conexao);
            DALobj.Excluir(data, unidade);
        }

        public void Localizar(DateTime data, int unidade)
        {
            DALDados DALobj = new DALDados(conexao);
            DALobj.Localizar(data, unidade);
        }

        public DataTable LocalizarReceitaTotal(DateTime dataI, DateTime dataF, int unidade)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.LocalizarReceitaTotal(dataI, dataF, unidade);

        }

        public DataTable LocalizarCodigosAcadastrar()
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.LocalizarCodigosAcadastrar();

        }

        public DTODados CarregaModeloVenda(DateTime data, int unidade)
        {
            DALDados DALobj = new DALDados(conexao);
            return DALobj.CarregaModeloVenda(data, unidade);
        }

        #endregion

        #region Pax

        public void IncluirPax(DTODados modelo)
        {

            DALDados DALobj = new DALDados(conexao);
            DALobj.IncluirPax(modelo);
        }

        public void ExcluirPax(DateTime dataI, DateTime dataF, int unidade)
        {
            DALDados DALobj = new DALDados(conexao);
            DALobj.ExcluirPax(dataI, dataF, unidade);
        }

        public void ExcluirPaxDia(DateTime Dia, int unidade)
        {
            DALDados DALobj = new DALDados(conexao);
            DALobj.ExcluirPaxDia(Dia, unidade);
        }

        public void LocalizarPax(DateTime data, int unidade, int turno)
        {
            DALDados DALobj = new DALDados(conexao);
            DALobj.LocalizarPax(data, unidade, turno);
        }

        public DataTable LocalizarPaxDiario(DateTime dataI, DateTime dataF, int unidade)
        {
            DALDados DALobj = new DALDados(conexao);
            return DALobj.LocalizarPaxDiario(dataI, dataF, unidade);
        }

        public DataTable LocalizarVendaDiaria(String valor)
        {
            DALDados DALobj = new DALDados(conexao);
            return DALobj.LocalizarVendaDiaria(valor);
        }

        public DataTable LocalizarVenda(DateTime dataI, DateTime dataF, int unidade)
        {
            DALDados DALobj = new DALDados(conexao);
            return DALobj.LocalizarVenda(dataI, dataF, unidade);
        }

        public DTODados CarregaModeloPax(DateTime data, int unidade)
        {
            DALDados DALobj = new DALDados(conexao);
            return DALobj.CarregaModeloPax(data, unidade);
        }

        #endregion

        #region Custo

        public void IncluirCusto(DTODados modelo)
        {
            DALDados DALobj = new DALDados(conexao);
            DALobj.IncluirCusto(modelo);
        }

        public void ExcluirCusto(DateTime datai, DateTime dataf, int unidade)
        {
            DALDados DALobj = new DALDados(conexao);
            DALobj.ExcluirCusto(datai, dataf, unidade);
        }

        public void LocalizarCusto(DateTime data, int unidade, int turno)
        {
            DALDados DALobj = new DALDados(conexao);
            DALobj.LocalizarPax(data, unidade, turno);
        }

        public DTODados CarregaModeloCusto(DateTime data, int unidade, int turno)
        {
            DALDados DALobj = new DALDados(conexao);
            return DALobj.CarregaModeloCusto(data, unidade);
        }

        #endregion

    }

    public class BLLConsultaCMV
    {
        private DALConexao conexao;

        public BLLConsultaCMV(DALConexao cx)
        {
            this.conexao = cx;
        }

        //Organizadas
        public DataTable TabelaCmvPorTurno(int unidade, DateTime dataI, DateTime dataF, string turnoCusto, int turnoPax)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.TabelaCmvPorTurno(unidade, dataI, dataF, turnoCusto, turnoPax);
        }

        public DataTable TabelaCustoPorTutno(int unidade, DateTime diaI, DateTime diaF, string turnoCusto)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.TabelaCustoPorTutno(unidade, diaI, diaF, turnoCusto);
        }

        public DataTable TabelaPaxPorDia(int unidade, DateTime diaI, DateTime diaF)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.TabelaPaxPorDia(unidade, diaI, diaF);
        }

        public DataTable TabelaPax(int unidade, DateTime diaI, DateTime diaF, int turno)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.TabelaPax(unidade, diaI, diaF, turno);
        }

        public DataTable TotalCustoAeBGeral(int unidade, DateTime diaI, DateTime diaF)
        { 
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.TotalCustoAeBGeral(unidade, diaI, diaF);
        }

        public DataTable TotalCustoAeB(int unidade, DateTime diaI, DateTime diaF, string turno)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.TotalCustoAeB(unidade, diaI, diaF, turno);
        }

        public DataTable TotalPax(int unidade, DateTime diaI, DateTime diaF, int turno)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.TotalPax(unidade, diaI, diaF, turno);
        }






        public DataTable LocalizarCustoPorSetor(int unidade, string tipo, DateTime dataI, DateTime dataF)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.LocalizarCustoPorSetor(unidade, tipo, dataI, dataF);
        }

        public DataTable TotalCustoPorSetorTipoETurno(int unidade, string tipo, DateTime dataI, DateTime dataF, string turno)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.TotalCustoPorSetorTipoETurno(unidade, tipo, dataI, dataF, turno);
        }

        public DataTable TotalCustoPorTipo(int unidade, string tipo, DateTime dataI, DateTime dataF)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.TotalCustoPorTipo(unidade, tipo, dataI, dataF);
        }

        public DataTable TotalCustoPorUnidadeDataEConta(int unidade, string conta, DateTime datai, DateTime dataf)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.TotalCustoPorUnidadeDataEConta(unidade, conta, datai, dataf);
        }

        public DataTable VerificaSetorNoConfig(int unidade, string setor)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.VerificaSetorNoConfig(unidade, setor);
        }


        public DataTable TotalMetaPorTipoETurno(int unidade, string tipo, string turno)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.TotalMetaPorTipoETurno(unidade, tipo, turno);
        }


        public DataTable LocalizarCustoPorSetorTipoETurno(int unidade, string tipo, DateTime dataI, DateTime dataF, string turno)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.LocalizarCustoPorSetorTipoETurno(unidade, tipo, dataI, dataF, turno);
        }
        
            public DataTable ListarPaxPorUnidadeDataeTurno(int unidade, DateTime data, int turno)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.ListarPaxPorUnidadeDataeTurno(unidade, data, turno);
        }


        public DataTable LocalizarReceitaTotal(int unidade, DateTime dataI, DateTime dataF)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.LocalizarReceitaTotal(dataI, dataF, unidade);
        }

        public DataTable LocalizarPaxPorTurno(int unidade, DateTime dataI, DateTime dataF, int turno)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.LocalizarPaxPorTurno(unidade, dataI, dataF, turno);
        }

        public DataTable LocalizarCortesias(int unidade, DateTime dataI, DateTime dataF)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.LocalizarCortesias(unidade, dataI, dataF);
        }

        public DataTable LocalizaReceitaGrupo(int unidade, DateTime dataI, DateTime dataF, string grupo)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.LocalizaReceitaGrupo(unidade, dataI, dataF, grupo);
        }

        public DataTable LocalizaReceitaDiversas(int unidade, DateTime dataI, DateTime dataF)
        {
            DALConsultasCMV DALobj = new DALConsultasCMV(conexao);
            return DALobj.LocalizaReceitaDiversas(unidade, dataI, dataF);
        }

    }

    public class BLLCmvGrupo
    {
        private DALConexao conexao;

        public BLLCmvGrupo(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void IncluirGrupo(DTOCmvGrupo modelo)
        {

            DALCmvGrupo DALobj = new DALCmvGrupo(conexao);
            DALobj.IncluirGrupo(modelo);

        }

        public void Alterar(DTOCmvGrupo modelo)
        {
            DALCmvGrupo DALobj = new DALCmvGrupo(conexao);
            DALobj.AlterarGrupo(modelo);
        }

        public void IncluirGrupoCusto(DTOCmvGrupo modelo)
        {

            DALCmvGrupo DALobj = new DALCmvGrupo(conexao);
            DALobj.IncluirGrupoCusto(modelo);

        }

        public void ExcluirGrupoCustoPorId(int id)
        {
            DALCmvGrupo DALobj = new DALCmvGrupo(conexao);
            DALobj.ExcluirGrupoCustoPorIdConfig(id);
        }

        public void IncluirGrupoReceita(DTOCmvGrupo modelo)
        {

            DALCmvGrupo DALobj = new DALCmvGrupo(conexao);
            DALobj.IncluirGrupoReceita(modelo);

        }

        public DataTable LocalizarGrupo(int unidade)
        {
            DALCmvGrupo DALobj = new DALCmvGrupo(conexao);
            return DALobj.LocalizarGrupo(unidade);
        }

        public DataTable LocalizarGrupoPorId(int id)
        {
            DALCmvGrupo DALobj = new DALCmvGrupo(conexao);
            return DALobj.LocalizarGrupoPorId(id);
        }

        public DataTable LocalizarGrupoCusto(int grupo)
        {
            DALCmvGrupo DALobj = new DALCmvGrupo(conexao);
            return DALobj.LocalizarGrupoCusto(grupo);
        }

        public DataTable LocalizarGrupoReceita(int grupo)
        {
            DALCmvGrupo DALobj = new DALCmvGrupo(conexao);
            return DALobj.LocalizarGrupoReceita(grupo);
        }

        public void ExcluirGrupo(int id)
        {
            DALCmvGrupo DALobj = new DALCmvGrupo(conexao);
            DALobj.ExcluirGrupo(id);
        }

        public void ExcluirGrupoCusto(int id)
        {
            DALCmvGrupo DALobj = new DALCmvGrupo(conexao);
            DALobj.ExcluirGrupoCusto(id);
        }

        public void ExcluirGrupoReceita(int id)
        {
            DALCmvGrupo DALobj = new DALCmvGrupo(conexao);
            DALobj.ExcluirGrupoReceita(id);
        }

    }

    public class BLLCmvGraficos
    {
        private DALConexao conexao;

        public BLLCmvGraficos(DALConexao cx)
        {
            this.conexao = cx;
        }

        public DataTable TabelaCustoPorGrupo(int unidade, DateTime diaI, DateTime diaF, int idGrupo)
        {
            DALGraficosCmv DALobj = new DALGraficosCmv(conexao);
            return DALobj.TabelaCustoPorGrupo(unidade, diaI, diaF, idGrupo);
        }

        public DataTable TabelaCustoPorGrupos(int unidade, DateTime diaI, DateTime diaF, int idGrupo1, int idGrupo2, int idGrupo3, int idGrupo4, int idGrupo5)
        {
            DALGraficosCmv DALobj = new DALGraficosCmv(conexao);
            return DALobj.TabelaCustoPorGrupos(unidade, diaI, diaF, idGrupo1, idGrupo2, idGrupo3, idGrupo4, idGrupo5);
        }

        public DataTable TabelaCustoPorConta(int unidade, DateTime diaI, DateTime diaF, int idGrupo)
        {
            DALGraficosCmv DALobj = new DALGraficosCmv(conexao);
            return DALobj.TabelaCustoPorConta(unidade, diaI, diaF, idGrupo);
        }

        public DataTable TabelaItensPorConta(int unidade, DateTime diaI, DateTime diaF, int idConta)
        {
            DALGraficosCmv DALobj = new DALGraficosCmv(conexao);
            return DALobj.TabelaItensPorConta(unidade, diaI, diaF, idConta);
        }

        public DataTable TotalCustoPorGrupo(int unidade, DateTime diaI, DateTime diaF, int idGrupo)
        {
            DALGraficosCmv DALobj = new DALGraficosCmv(conexao);
            return DALobj.TotalCustoPorGrupo(unidade, diaI, diaF, idGrupo);
        }

        public DataTable TotalCustoPorGrupos(int unidade, DateTime diaI, DateTime diaF, int idGrupo1, int idGrupo2, int idGrupo3, int idGrupo4, int idGrupo5)
        {
            DALGraficosCmv DALobj = new DALGraficosCmv(conexao);
            return DALobj.TotalCustoPorGrupos(unidade, diaI, diaF, idGrupo1, idGrupo2, idGrupo3, idGrupo4, idGrupo5);
        }

        public DataTable TabelaReceitaPorGrupo(int unidade, DateTime diaI, DateTime diaF, int idGrupo)
        {
            DALGraficosCmv DALobj = new DALGraficosCmv(conexao);
            return DALobj.TabelaReceitaPorGrupo(unidade, diaI, diaF, idGrupo);
        }

        public DataTable TabelaReceitaPorGrupos(int unidade, DateTime diaI, DateTime diaF, int idGrupo1, int idGrupo2, int idGrupo3, int idGrupo4, int idGrupo5)
        {
            DALGraficosCmv DALobj = new DALGraficosCmv(conexao);
            return DALobj.TabelaReceitaPorGrupos(unidade, diaI, diaF, idGrupo1, idGrupo2, idGrupo3, idGrupo4, idGrupo5);
        }

        public DataTable TotalReceitaPorGrupo(int unidade, DateTime diaI, DateTime diaF, int idGrupo)
        {
            DALGraficosCmv DALobj = new DALGraficosCmv(conexao);
            return DALobj.TotalReceitaPorGrupo(unidade, diaI, diaF, idGrupo);
        }

        public DataTable TotalReceitaPorGrupos(int unidade, DateTime diaI, DateTime diaF, int idGrupo1, int idGrupo2, int idGrupo3, int idGrupo4, int idGrupo5)
        {
            DALGraficosCmv DALobj = new DALGraficosCmv(conexao);
            return DALobj.TotalReceitaPorGrupos(unidade, diaI, diaF, idGrupo1, idGrupo2, idGrupo3, idGrupo4, idGrupo5);
        }

        public DataTable MetaPorGrupo(int idGrupo)
        {
            DALGraficosCmv DALobj = new DALGraficosCmv(conexao);
            return DALobj.MetaPorGrupo(idGrupo);
        }

    }

    #endregion

    #region Materiais

    public class BLLFornecedor
    {
        private DALConexao conexao;

        public BLLFornecedor(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOFornecedor modelo)
        {

            //verifica o preenchimento da fantazia do fornecedor
            if (modelo.FantasiaFornecedor.Trim().Length == 0)
            {
                throw new Exception("O nome fantasia do fornecedor não pode ficar em branco.");
            }
            //verifica o preenchimento da razão social do fornecedor
            if (modelo.RazaoFornecedor.Trim().Length == 0)
            {
                throw new Exception("A razão social do fornecedor não pode ficar em branco.");
            }
            //verifica o preenchimento do telefone principal do fornecedor
            if (modelo.Fone1Fornecedor.Trim().Length == 0)
            {
                throw new Exception("O telefone principal do fornecedor deve ser preenchido.");
            }
            //verifica o preenchimento do email principal do fornecedor
            if (modelo.Email1Fornecedor.Trim().Length == 0)
            {
                throw new Exception("O e-mail principal do fornecedor deve ser preenchido.");
            }
            //verifica o preenchimento do Logradouro do fornecedor
            if (modelo.Email1Fornecedor.Trim().Length == 0)
            {
                throw new Exception("O e-mail principal do fornecedor deve ser preenchido.");
            }
            //verifica o preenchimento do número do fornecedor
            if (modelo.EnderecoNumeroFornecedor.Trim().Length == 0)
            {
                throw new Exception("O número do fornecedor deve ser preenchido.");
            }
            //verifica o preenchimento da cidade do fornecedor
            if (modelo.EnderecoCidadeFornecedor.Trim().Length == 0)
            {
                throw new Exception("A cidade do fornecedor deve ser preenchido.");
            }
            //verifica o preenchimento do estado do fornecedor
            if (modelo.EnderecoEstadoFornecedor.Trim().Length == 0)
            {
                throw new Exception("O estado do fornecedor deve ser preenchido.");
            }
            //verifica o preenchimento do cnpj do fornecedor
            if (modelo.CnpjFornecedor.Trim().Length == 0)
            {
                throw new Exception("O cnpj do fornecedor deve ser preenchido.");
            }

            //Tratamento dos dados

            modelo.FantasiaFornecedor = modelo.FantasiaFornecedor.Trim().ToUpper();
            modelo.RazaoFornecedor = modelo.RazaoFornecedor.Trim().ToUpper();
            modelo.Email1Fornecedor = modelo.Email1Fornecedor.Trim().ToLower();
            modelo.Email2Fornecedor = modelo.Email2Fornecedor.Trim().ToLower();
            modelo.EnderecoLogradouroFornecedor = modelo.EnderecoLogradouroFornecedor.Trim().ToUpper();
            modelo.EnderecoNumeroFornecedor = modelo.EnderecoNumeroFornecedor.Trim().ToUpper();
            modelo.EnderecoComplementoFornecedor = modelo.EnderecoComplementoFornecedor.Trim().ToUpper();
            modelo.EnderecoBairroFornecedor = modelo.EnderecoBairroFornecedor.Trim().ToUpper();
            modelo.EnderecoCidadeFornecedor = modelo.EnderecoCidadeFornecedor.Trim().ToUpper();
            modelo.EnderecoEstadoFornecedor = modelo.EnderecoEstadoFornecedor.Trim().ToUpper();
            modelo.ContatoFornecedor = modelo.ContatoFornecedor.Trim().ToUpper();

            DALFornecedores DALobj = new DALFornecedores(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOFornecedor modelo)
        {

            if (modelo.IdFornecedor <= 0)
            {
                throw new Exception("Selecione um registro para alterar.");
            }
            //verifica o preenchimento da fantazia do fornecedor
            if (modelo.FantasiaFornecedor.Trim().Length == 0)
            {
                throw new Exception("O nome fantasia do fornecedor não pode ficar em branco.");
            }
            //verifica o preenchimento da razão social do fornecedor
            if (modelo.RazaoFornecedor.Trim().Length == 0)
            {
                throw new Exception("A razão social do fornecedor não pode ficar em branco.");
            }
            //verifica o preenchimento do telefone principal do fornecedor
            if (modelo.Fone1Fornecedor.Trim().Length == 0)
            {
                throw new Exception("O telefone principal do fornecedor deve ser preenchido.");
            }
            //verifica o preenchimento do email principal do fornecedor
            if (modelo.Email1Fornecedor.Trim().Length == 0)
            {
                throw new Exception("O e-mail principal do fornecedor deve ser preenchido.");
            }
            //verifica o preenchimento do Logradouro do fornecedor
            if (modelo.Email1Fornecedor.Trim().Length == 0)
            {
                throw new Exception("O e-mail principal do fornecedor deve ser preenchido.");
            }
            //verifica o preenchimento do número do fornecedor
            if (modelo.EnderecoNumeroFornecedor.Trim().Length == 0)
            {
                throw new Exception("O número do fornecedor deve ser preenchido.");
            }
            //verifica o preenchimento da cidade do fornecedor
            if (modelo.EnderecoCidadeFornecedor.Trim().Length == 0)
            {
                throw new Exception("A cidade do fornecedor deve ser preenchido.");
            }
            //verifica o preenchimento do estado do fornecedor
            if (modelo.EnderecoEstadoFornecedor.Trim().Length == 0)
            {
                throw new Exception("O estado do fornecedor deve ser preenchido.");
            }
            //verifica o preenchimento do cnpj do fornecedor
            if (modelo.CnpjFornecedor.Trim().Length == 0)
            {
                throw new Exception("O cnpj do fornecedor deve ser preenchido.");
            }

            //Tratamento dos dados

            modelo.FantasiaFornecedor = modelo.FantasiaFornecedor.Trim().ToUpper();
            modelo.RazaoFornecedor = modelo.RazaoFornecedor.Trim().ToUpper();
            modelo.Email1Fornecedor = modelo.Email1Fornecedor.Trim().ToLower();
            modelo.Email2Fornecedor = modelo.Email2Fornecedor.Trim().ToLower();
            modelo.EnderecoLogradouroFornecedor = modelo.EnderecoLogradouroFornecedor.Trim().ToUpper();
            modelo.EnderecoNumeroFornecedor = modelo.EnderecoNumeroFornecedor.Trim().ToUpper();
            modelo.EnderecoComplementoFornecedor = modelo.EnderecoComplementoFornecedor.Trim().ToUpper();
            modelo.EnderecoBairroFornecedor = modelo.EnderecoBairroFornecedor.Trim().ToUpper();
            modelo.EnderecoCidadeFornecedor = modelo.EnderecoCidadeFornecedor.Trim().ToUpper();
            modelo.EnderecoEstadoFornecedor = modelo.EnderecoEstadoFornecedor.Trim().ToUpper();
            modelo.ContatoFornecedor = modelo.ContatoFornecedor.Trim().ToUpper();

            DALFornecedores DALobj = new DALFornecedores(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALFornecedores DALobj = new DALFornecedores(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable LocalizarRazao(String valor)
        {
            DALFornecedores DALobj = new DALFornecedores(conexao);
            return DALobj.LocalizarRazao(valor);
        }

        public DataTable LocalizarFantasia(String valor)
        {
            DALFornecedores DALobj = new DALFornecedores(conexao);
            return DALobj.LocalizarFantasia(valor);
        }

        public DataTable LocalizarCnpj(String valor)
        {
            DALFornecedores DALobj = new DALFornecedores(conexao);
            return DALobj.LocalizarCnpj(valor);
        }

        public DTOFornecedor CarregaModeloFornecedor(int codigo)
        {
            DALFornecedores DALobj = new DALFornecedores(conexao);
            return DALobj.CarregaModeloFornecedor(codigo);
        }

    }

    public class BLLGrupo
    {
        private DALConexao conexao;

        public BLLGrupo(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOGrupo modelo)
        {

            //verifica o preenchimento do código da unidade
            if (modelo.CodGrupo.Trim().Length < 2)
            {
                throw new Exception("O código do produto deve ter 2 dígitos.");
            }
            //verifica o preenchimento do nome do grupo
            if (modelo.NomeGrupo.Trim().Length == 0)
            {
                throw new Exception("O nome do grupo não pode ficar em branco.");
            }

            //Tratamento dos dados

            modelo.NomeGrupo = modelo.NomeGrupo.Trim().ToUpper();
            modelo.DescGrupo = modelo.DescGrupo.Trim().ToUpper();

            DALGrupo DALobj = new DALGrupo(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOGrupo modelo)
        {


            //verifica o preenchimento do código da unidade
            if (modelo.CodGrupo.Trim().Length < 2)
            {
                throw new Exception("O código do produto deve ter 2 dígitos.");
            }
            //verifica o preenchimento do nome do grupo
            if (modelo.NomeGrupo.Trim().Length == 0)
            {
                throw new Exception("O nome do grupo não pode ficar em brancoo.");
            }

            //Tratamento dos dados

            modelo.NomeGrupo = modelo.NomeGrupo.Trim().ToUpper();
            modelo.DescGrupo = modelo.DescGrupo.Trim().ToUpper();

            DALGrupo DALobj = new DALGrupo(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALGrupo DALobj = new DALGrupo(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(String valor)
        {
            DALGrupo DALobj = new DALGrupo(conexao);
            return DALobj.Localizar(valor);
        }

        public DataTable LocalizarGrupo()
        {
            DALGrupo DALobj = new DALGrupo(conexao);
            return DALobj.LocalizarGrupo();
        }

        public DataTable LocalizarCod(int Id)
        {
            DALGrupo DALobj = new DALGrupo(conexao);
            return DALobj.LocalizarCod(Id);
        }


        public DataTable LocalizarCod(String valor)
        {
            DALGrupo DALobj = new DALGrupo(conexao);
            return DALobj.Localizar(valor);
        }

        public DTOGrupo CarregaModeloGrupo(int codigo)
        {
            DALGrupo DALobj = new DALGrupo(conexao);
            return DALobj.CarregaModeloGrupo(codigo);
        }
    }

    public class BLLInventario
    {

        private DALConexao conexao;

        public BLLInventario(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOInventario modelo)
        {

            //Tratamento dos dados

            //Se necessário colocar aqui a formatação de data e tals

            DALInventario DALobj = new DALInventario(conexao);
            DALobj.Incluir(modelo);

        }

        public void Concluir(int inv)
        {


            DALInventario DALobj = new DALInventario(conexao);
            DALobj.Concluir(inv);
        }

        public DataTable Localizar(String valor)
        {
            DALInventario DALobj = new DALInventario(conexao);
            return DALobj.Localizar(valor);
        }

        public void Excluir(int codigo)
        {
            DALInventario DALobj = new DALInventario(conexao);
            DALobj.Excluir(codigo);
        }
        
    }
    
    public class BLLMixUnidade
    {

        private DALConexao conexao;

        public BLLMixUnidade(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOMixUnidade modelo)
        {

            //verifica o preenchimento dos dados

            if (modelo.IdProduto.ToString() == "")
            {
                throw new Exception("Escolha um produto para adicionar ao mix.");
            }

            if (modelo.IdSetor.ToString() == "")
            {
                throw new Exception("Escolha o setor para adicionar ao mix.");
            }

            if (modelo.IdUnidade.ToString() == "")
            {
                throw new Exception("O campo unidade deve ser preenchido.");
            }

            if (modelo.EstoqueMinimo.ToString() == "")
            {
                throw new Exception("O campo estoque mínimo deve ser preenchido.");
            }


            //Tratamento dos dados


            DALMixUnidade DALobj = new DALMixUnidade(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOMixUnidade modelo)
        {


            //verifica o preenchimento dos dados

            if (modelo.IdProduto == 0)
            {
                throw new Exception("Escolha um produto para adicionar ao mix.");
            }

            if (modelo.IdSetor == 0)
            {
                throw new Exception("Escolha o setor para adicionar ao mix.");
            }

            if (modelo.IdUnidade == 0)
            {
                throw new Exception("O campo unidade deve ser preenchido.");
            }

            //Tratamento dos dados

            DALMixUnidade DALobj = new DALMixUnidade(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALMixUnidade DALobj = new DALMixUnidade(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(int unidade, int setor)
        {
            DALMixUnidade DALobj = new DALMixUnidade(conexao);
            return DALobj.Localizar(unidade, setor);
        }

        public DataTable LocalizarValor(string busca)
        {
            DALMixUnidade DALobj = new DALMixUnidade(conexao);
            return DALobj.LocalizarValor(busca);
        }


        public DTOMixUnidade CarregaModeloMixUnidade(int codigo)
        {
            DALMixUnidade DALobj = new DALMixUnidade(conexao);
            return DALobj.CarregaModeloMixUnidade(codigo);
        }

    }

    public class BLLMovimento
    {
        private DALConexao conexao;

        public BLLMovimento(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOMovimento modelo)
        {


            //Tratamento dos dados

            //Se necessário colocar aqui a formatação de data e tals

            DALMovimento DALobj = new DALMovimento(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOMovimento modelo)
        {


            //Tratamento dos dados

            //Se necessário colocar aqui a formatação de data e tals

            DALMovimento DALobj = new DALMovimento(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALMovimento DALobj = new DALMovimento(conexao);
            DALobj.Excluir(codigo);
        }

        public void ExcluirInv(int codigo, int forn)
        {
            DALMovimento DALobj = new DALMovimento(conexao);
            DALobj.ExcluirInv(codigo, forn);
        }


        public DataTable Localizar(String valor)
        {
            DALMovimento DALobj = new DALMovimento(conexao);
            return DALobj.Localizar(valor);
        }

        public DataTable LocalizarValor(String valor)
        {
            DALMovimento DALobj = new DALMovimento(conexao);
            return DALobj.LocalizarValor(valor);
        }


        public DataTable LocalizarNf(int unidade, int fornecedor, int nf, DateTime emissao, DateTime entrada)
        {
            DALMovimento DALobj = new DALMovimento(conexao);
            return DALobj.LocalizarNf(unidade, fornecedor, nf, emissao, entrada);
        }

        public DataTable LocalizarInventario(int unidade)
        {

            DALMovimento DALobj = new DALMovimento(conexao);
            return DALobj.LocalizarInventario(unidade);

        }

        public DTOMovimento CarregaModeloMovimento(int codigo)
        {
            DALMovimento DALobj = new DALMovimento(conexao);
            return DALobj.CarregaModeloMovimento(codigo);
        }

        public DTOMovimento ConsultaNf(int nf, int forn)
        {
            DALMovimento DALobj = new DALMovimento(conexao);
            return DALobj.ConsultaNf(nf, forn);
        }
    }

    public class BLLNfLancamento
    {

        private DALConexao conexao;

        public BLLNfLancamento(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTONfLancamento modelo)
        {

            DALNfLancamento DALobj = new DALNfLancamento(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTONfLancamento modelo)
        {

            DALNfLancamento DALobj = new DALNfLancamento(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int nf, int lancamento)
        {
            DALNfLancamento DALobj = new DALNfLancamento(conexao);
            DALobj.Excluir(nf, lancamento);
        }

        public DataTable Localizar(int nf)
        {
            DALNfLancamento DALobj = new DALNfLancamento(conexao);
            return DALobj.Localizar(nf);
        }

        public DTONfLancamento CarregaModeloGrupo(int codigo)
        {
            DALNfLancamento DALobj = new DALNfLancamento(conexao);
            return DALobj.CarregaModeloNfLancamento(codigo);
        }



    }

    public class BLLProduto
    {

        private DALConexao conexao;
        public BLLProduto(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOProduto modelo, string foto)
        {
            if (modelo.NomeProduto.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório.");
            }

            if (modelo.GrupoProduto <= 0)
            {
                throw new Exception("O nome do grupo é obrigatório.");
            }

            if (modelo.MarcaProduto.Trim().Length == 0)
            {
                throw new Exception("É obrigatório definir uma marca.");
            }

            if (modelo.ModelodoProduto.Trim().Length == 0)
            {
                throw new Exception("O modelo do produto deve ser preenchido.");
            }


            //Tratamento das informações

            modelo.NomeProduto = modelo.NomeProduto.Trim().ToUpper();
            modelo.MarcaProduto = modelo.MarcaProduto.Trim().ToUpper();
            modelo.ModelodoProduto = modelo.ModelodoProduto.Trim().ToUpper();
            modelo.DescProduto = modelo.DescProduto.Trim().ToUpper();




            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Incluir(modelo, foto);
        }

        public void Alterar(DTOProduto modelo, string foto)
        {
            if (modelo.NomeProduto.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório.");
            }

            if (modelo.GrupoProduto <= 0)
            {
                throw new Exception("O nome do grupo é obrigatório.");
            }

            if (modelo.MarcaProduto.Trim().Length == 0)
            {
                throw new Exception("É obrigatório definir uma marca.");
            }

            if (modelo.ModelodoProduto.Trim().Length == 0)
            {
                throw new Exception("O modelo do produto deve ser preenchido.");
            }

            //Tratamento das informações

            modelo.NomeProduto = modelo.NomeProduto.Trim().ToUpper();
            modelo.MarcaProduto = modelo.MarcaProduto.Trim().ToUpper();
            modelo.ModelodoProduto = modelo.ModelodoProduto.Trim().ToUpper();
            modelo.DescProduto = modelo.DescProduto.Trim().ToUpper();


            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Alterar(modelo, foto);
        }

        public void Excluir(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable LocalizarCod(String valor)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.LocalizarCod(valor);
        }

        public DataTable LocalizarGeraCod(string CodGrupo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.LocalizarGeraCod(CodGrupo);
        }



        public DataTable ConsultaProduto(String valor)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.ConsultaProduto(valor);
        }

        public DataTable LocalizarGrupo(String valor)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.LocalizarGrupo(valor);
        }

        public DataTable LocalizarNome(String valor)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.LocalizarNome(valor);
        }

        public DTOProduto CarregaModeloProduto(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.CarregaModeloProduto(codigo);
        }

    }

    public class BLLSetor
    {
        private DALConexao conexao;

        public BLLSetor(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOSetor modelo)
        {

            //verifica o preenchimento da unidade
            if (modelo.IdUnidade.ToString().Trim() == "")
            {
                throw new Exception("A unidade do setor deve ter 2 dígitos.");
            }
            //verifica o preenchimento do nome do setor
            if (modelo.NomeSetor.Trim().Length == 0)
            {
                throw new Exception("O nome do setor não pode ficar em brancoo.");
            }

            //Tratamento dos dados

            modelo.NomeSetor = modelo.NomeSetor.Trim().ToUpper();

            DALSetor DALobj = new DALSetor(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOSetor modelo)
        {


            //verifica o preenchimento da unidade
            if (modelo.IdUnidade.ToString().Trim().Length < 2)
            {
                throw new Exception("A unidade do setor deve ter 2 dígitos.");
            }
            //verifica o preenchimento do nome do setor
            if (modelo.NomeSetor.Trim().Length == 0)
            {
                throw new Exception("O nome do setor não pode ficar em brancoo.");
            }

            //Tratamento dos dados

            modelo.NomeSetor = modelo.NomeSetor.Trim().ToUpper();

            DALSetor DALobj = new DALSetor(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALSetor DALobj = new DALSetor(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(String valor)
        {
            DALSetor DALobj = new DALSetor(conexao);
            return DALobj.Localizar(valor);
        }

        public DTOSetor CarregaModeloGrupo(int codigo)
        {
            DALSetor DALobj = new DALSetor(conexao);
            return DALobj.CarregaModeloSetor(codigo);
        }
        
    }

    #endregion

    #region Fichas técnicas

    public class BLLPratos
    {
        private DALConexao conexao;

        public BLLPratos(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOPratos modelo)
        {



            //verifica o preenchimento do código da unidade
            if (modelo.NomePrato.Trim().Length == 0)
            {
                throw new Exception("O nome do prato não pode ficar em branco.");
            }
            //verifica o preenchimento do nome do grupo
            if (modelo.IdSetor <= 0)
            {
                throw new Exception("Escolha um buffet para atribuir este prato.");
            }


            //Tratamento dos dados
            modelo.NomePrato = modelo.NomePrato.Replace("\'", "");
            modelo.NomePrato = modelo.NomePrato.Replace("\"", "");

            modelo.NomePrato = modelo.NomePrato.Trim().ToUpper();
            modelo.ModoPreparoPrato = modelo.ModoPreparoPrato.Trim();
            modelo.DescPrato = modelo.DescPrato.Trim();

            DALPratos DALobj = new DALPratos(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOPratos modelo)
        {

            //verifica o preenchimento do código da unidade
            if (modelo.NomePrato.Trim().Length == 0)
            {
                throw new Exception("O nome do prato não pode ficar em branco.");
            }
            //verifica o preenchimento do nome do grupo
            if (modelo.IdSetor.ToString() == "")
            {
                throw new Exception("Escolha um buffet para atribuir este prato.");
            }

            if (modelo.Cat.ToString() == "")
            {
                throw new Exception("Escolha uma categoria para atribuir este prato.");
            }

            //Tratamento dos dados

            modelo.NomePrato = modelo.NomePrato.Replace("\'", "");
            modelo.NomePrato = modelo.NomePrato.Replace("\"", "");

            modelo.NomePrato = modelo.NomePrato.Trim().ToUpper();
            modelo.ModoPreparoPrato = modelo.ModoPreparoPrato.Trim();
            modelo.DescPrato = modelo.DescPrato.Trim();

            DALPratos DALobj = new DALPratos(conexao);
            DALobj.Alterar(modelo);

        }

        public void AddModoPreparo(DTOPratos modelo)
        {

                       
            modelo.ModoPreparoPrato = modelo.ModoPreparoPrato.Trim();
            modelo.DescPrato = modelo.DescPrato.Trim();

            DALPratos DALobj = new DALPratos(conexao);
            DALobj.AddModPreparo(modelo);

        }

        public void Excluir(string codigo)
        {
            DALPratos DALobj = new DALPratos(conexao);
            DALobj.Excluir(codigo);

        }

        public DataTable LocalizarNome(String valor)
        {
            DALPratos DALobj = new DALPratos(conexao);
            return DALobj.LocalizarNome(valor);

        }

        public DataTable LocalizarPorCod(String cod)
        {
            DALPratos DALobj = new DALPratos(conexao);
            return DALobj.LocalizarPorCod(cod);

        }


        public DataTable BuscaFichas(String busca)
        {
            DALPratos DALobj = new DALPratos(conexao);
            return DALobj.BuscaFichas(busca);

        }

        public DataTable ListarCodigos()
        {
            DALPratos DALobj = new DALPratos(conexao);
            return DALobj.ListaCodigos();

        }
        public DataTable ListarIngredientes(string codigo)
        {
            DALPratos DALobj = new DALPratos(conexao);
            return DALobj.ListarIngredientes(codigo);

        }

        public DataTable CustoIngrediente(string codigo, int unidade)
        {
            DALPratos DALobj = new DALPratos(conexao);
            return DALobj.CustoIngrediente(codigo, unidade);

        }


    }

    public class BLLIngredientes
    {
        private DALConexao conexao;

        public BLLIngredientes(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOIngredientes modelo)
        {
                        
            //verifica o preenchimento do PRATO
            if (modelo.CodPrato == "")
            {
                throw new Exception("O nome do prato não pode ficar em branco.");
            }
            //verifica o preenchimento da quantidade
            if (modelo.QuantIngrediente <= 0)
            {
                throw new Exception("Q quantidade do ingrediente nao pode ficar zero.");
            }
            
            DALIngredientes DALobj = new DALIngredientes(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOIngredientes modelo)
        {


            //verifica o preenchimento do PRATO
            if (modelo.CodPrato == "")
            {
                throw new Exception("O nome do prato não pode ficar em branco.");
            }
            //verifica o preenchimento da quantidade
            if (modelo.QuantIngrediente <= 0)
            {
                throw new Exception("Q quantidade do ingrediente nao pode ficar zero.");
            }

            DALIngredientes DALobj = new DALIngredientes(conexao);
            DALobj.Alterar(modelo);

        }

        public void Excluir(int codigo)
        {
            DALIngredientes DALobj = new DALIngredientes(conexao);
            DALobj.Excluir(codigo);
        }

        public void ExcluirPorPrato(string codigo)
        {
            DALIngredientes DALobj = new DALIngredientes(conexao);
            DALobj.ExcluirPorPrato(codigo);
        }

        public DataTable Custo01(string cod, int unidade)
        {
            DALIngredientes DALobj = new DALIngredientes(conexao);
            return DALobj.CustoItem01(cod, unidade);
        }

        public DataTable CustoGeral(string cod, int unidade)
        {
            DALIngredientes DALobj = new DALIngredientes(conexao);
            return DALobj.CustoItemGeral(cod, unidade);
        }

    }

    public class BLLBuffet
    {
        private DALConexao conexao;

        public BLLBuffet(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOBuffet modelo)
        {

            //verifica o preenchimento do ingrediente
            if (modelo.NomeBuffet.Trim().Length == 0)
            {
                throw new Exception("Escolha um nome para o buffet.");
            }

            //Trata os dados
            modelo.NomeBuffet = modelo.NomeBuffet.Trim().ToUpper();
            if(modelo.DescBuffet != "")
            {
                modelo.DescBuffet = modelo.DescBuffet.Trim();
            }

            DALBuffet DALobj = new DALBuffet(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOBuffet modelo)
        {

            //verifica o preenchimento do ingrediente
            if (modelo.NomeBuffet.Trim().Length == 0)
            {
                throw new Exception("Escolha um nome para o buffet.");
            }

            //Trata os dados
            modelo.NomeBuffet = modelo.NomeBuffet.Trim().ToUpper();
            if (modelo.DescBuffet != "")
            {
                modelo.DescBuffet = modelo.DescBuffet.Trim();
            }

            DALBuffet DALobj = new DALBuffet(conexao);
            DALobj.Alterar(modelo);

        }

        public void Excluir(int codigo)
        {
            DALBuffet DALobj = new DALBuffet(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Listar()
        {
            DALBuffet DALobj = new DALBuffet(conexao);
            return DALobj.Listar();
        }

        public DataTable localizarPorId(int id)
        {
            DALBuffet DALobj = new DALBuffet(conexao);
            return DALobj.LocalizarPorId(id);
        }

    }

    public class BLLCategoria
    {
        private DALConexao conexao;

        public BLLCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOCategoria modelo)
        {

            //verifica o preenchimento do ingrediente
            if (modelo.NomeCat.Trim().Length == 0)
            {
                throw new Exception("Escolha um nome para a categoria.");
            }

            //Trata os dados
            modelo.NomeCat = modelo.NomeCat.Trim().ToUpper();
            if (modelo.DescCat != "")
            {
                modelo.DescCat = modelo.DescCat.Trim();
            }

            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOCategoria modelo)
        {

            //verifica o preenchimento do ingrediente
            if (modelo.NomeCat.Trim().Length == 0)
            {
                throw new Exception("Escolha um nome para a categoria.");
            }

            //Trata os dados
            modelo.NomeCat = modelo.NomeCat.Trim().ToUpper();
            if (modelo.DescCat != "")
            {
                modelo.DescCat = modelo.DescCat.Trim();
            }

            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable localizarPorId(int id)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.LocalizarPorId(id);
        }

        public DataTable Listar()
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.Listar();

        }

    }

    public class BLLSubCategoria
    {
        private DALConexao conexao;

        public BLLSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOSubCategoria modelo)
        {

            //verifica o preenchimento do ingrediente
            if (modelo.NomeSCat.Trim().Length == 0)
            {
                throw new Exception("Escolha um nome para a categoria.");
            }

            //Trata os dados
            modelo.NomeSCat = modelo.NomeSCat.Trim().ToUpper();
            if (modelo.DescSCat != "")
            {
                modelo.DescSCat = modelo.DescSCat.Trim();
            }

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(DTOSubCategoria modelo)
        {

            //verifica o preenchimento do ingrediente
            if (modelo.NomeSCat.Trim().Length == 0)
            {
                throw new Exception("Escolha um nome para a categoria.");
            }

            //Trata os dados
            modelo.NomeSCat = modelo.NomeSCat.Trim().ToUpper();
            if (modelo.DescSCat != "")
            {
                modelo.DescSCat = modelo.DescSCat.Trim();
            }

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable localizarPorId(int id)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.LocalizarPorId(id);
        }

        public DataTable Listar()
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.Listar();

        }

    }

    #endregion
}
