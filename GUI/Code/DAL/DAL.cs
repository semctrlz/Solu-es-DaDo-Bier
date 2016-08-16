using GUI.Code.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Code.DAL
{

    //Comuns
    
    public class DadosDaConexao
    {
        public static String servidor = @"tcp:SERVIDOR\SQLEXPRESSZ,49172";
        public static String banco = "ControleDeMateriais";
        public static String usuario = "sa";
        public static String senha = "dce285";

        public static String servidorB = @"BINGO\SQLEXPRESSZ";
        public static String bancoB = "ControleDeMateriais";
        public static String usuarioB = "sa";
        public static String senhaB = "shamboga152099";


        public static string name = System.Environment.MachineName;


        public static string StringDaConexao =
     name == "BINGO" ? @"Data Source=" + servidorB + ";Initial Catalog = " + bancoB + "; Persist Security Info=True;User ID = " + usuarioB + "; Password=" + senhaB :
     @"Data Source=" + servidor + ";Initial Catalog=" + banco + ";Persist Security Info=True;User ID=" + usuario + ";Password=" + senha;

    }

    public class DALConexao
    {
        private string _stringConexao;
        private SqlConnection _conexao;

        public DALConexao(string dadosConexao)
        {
            this._conexao = new SqlConnection();
            this.StringConexao = dadosConexao;
            this._conexao.ConnectionString = dadosConexao;

        }
        public String StringConexao
        {
            get { return this._stringConexao; }
            set { this._stringConexao = value; }
        }

        public SqlConnection ObjetoConexao
        {
            get { return this._conexao; }
            set { this._conexao = value; }
        }

        public void Conectar()
        {
            this._conexao.Open();
        }

        public void Desconectar()
        {
            this._conexao.Close();
        }
    }

    public class DALUsuario
    {
        private DALConexao conexao;

        public DALUsuario(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOUsuario obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into usuario (nome_usuario, login_usuario, senha_usuario, iniciais_usuario, id_unidade, permissao_usuario, email_usuario) " +
            "values (@nome, @login, @senha, @iniciais, @unidade, @permissao, @email); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", obj.NomeUsuario);
            cmd.Parameters.AddWithValue("@login", obj.LoginUsuario);
            cmd.Parameters.AddWithValue("@senha", obj.SenhaUsuario);
            cmd.Parameters.AddWithValue("@iniciais", obj.IniciaisUsuario);
            cmd.Parameters.AddWithValue("@unidade", obj.IdUnidade);
            cmd.Parameters.AddWithValue("@permissao", obj.PermissaoUsuario);
            cmd.Parameters.AddWithValue("@email", obj.EmailUsuario);

            conexao.Conectar();
            obj.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from usuario where (id_usuario) = (@codigo)";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Alterar(DTOUsuario obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update usuario set nome_usuario = (@nome), login_usuario = (@login)," +
                "iniciais_usuario = (@iniciais), id_unidade = (@unidade), " +
                "permissao_usuario = (@permissao), email_usuario = (@email) WHERE id_usuario = (@id);";
            cmd.Parameters.AddWithValue("@nome", obj.NomeUsuario);
            cmd.Parameters.AddWithValue("@login", obj.LoginUsuario);
            cmd.Parameters.AddWithValue("@iniciais", obj.IniciaisUsuario);
            cmd.Parameters.AddWithValue("@unidade", obj.IdUnidade);
            cmd.Parameters.AddWithValue("@permissao", obj.PermissaoUsuario);
            cmd.Parameters.AddWithValue("@email", obj.EmailUsuario);
            cmd.Parameters.AddWithValue("@id", obj.IdUsuario);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void AlterarSenha(DTOUsuario obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update usuario set senha_usuario = (@senha) WHERE id_usuario = (@id);";
            cmd.Parameters.AddWithValue("@senha", obj.SenhaUsuario);
            cmd.Parameters.AddWithValue("@id", obj.IdUsuario);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from usuario", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable LocalizarLogin(String usuario, string senha)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT COUNT(u.id_usuario) as cont_combinacao, id_usuario, nome_usuario, login_usuario, " +
                "senha_usuario, iniciais_usuario, u.id_unidade, permissao_usuario, email_usuario, n.nome_unidade FROM usuario u " +
                $"inner join unidade n on u.id_unidade = n.id_unidade WHERE login_usuario = '{usuario}' AND senha_usuario = '{senha}' " +
                "group by id_usuario, nome_usuario, login_usuario, senha_usuario, iniciais_usuario, u.id_unidade, permissao_usuario, " +
                "email_usuario, n.nome_unidade; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable LocalizaIp(String ip)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select count(u.id_usuario) as cont_combinacao, u.id_usuario, u.nome_usuario, u.login_usuario, " +
                "u.senha_usuario, u.iniciais_usuario, u.id_unidade, u.permissao_usuario, u.email_usuario, n.nome_unidade from autolog a " +
                "inner join usuario u on u.id_usuario = a.id_usuario inner join unidade n on u.id_unidade = n.id_unidade " +
                $"where cod_log = '{ip}' " +
                "group by u.id_usuario, u.nome_usuario, u.login_usuario, u.senha_usuario, u.iniciais_usuario, u.id_unidade, " +
                "u.permissao_usuario, u.email_usuario, n.nome_unidade; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListarConexoes(int id, string ip)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select cod_log from autolog where id_usuario = {id} and cod_log <> '{ip}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DTOUsuario CarregaModeloUsuario(int codigo)
        {
            DTOUsuario modelo = new DTOUsuario();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select id_usuario, nome_usuario, login_usuario, senha_usuario, iniciais_usuario, id_unidade, permissao_usuario, email_usuario from usuario where (id_usuario) =" + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdUsuario = Convert.ToInt32(registro["id_usuario"]);
                modelo.NomeUsuario = Convert.ToString(registro["nome_usuario"]);
                modelo.LoginUsuario = Convert.ToString(registro["login_usuario"]);
                modelo.SenhaUsuario = Convert.ToString(registro["senha_usuario"]);
                modelo.IniciaisUsuario = Convert.ToString(registro["iniciais_usuario"]);
                modelo.IdUnidade = Convert.ToInt32(registro["id_unidade"]);
                modelo.PermissaoUsuario = Convert.ToInt32(registro["permissao_usuario"]);
                modelo.EmailUsuario = Convert.ToString(registro["email_usuario"]);
            }
            return modelo;
        }

    }

    public class DALUnidade
    {
        string folder = @"Imagens\Unidades\";
        private DALConexao conexao;

        public DALUnidade(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOUnidade modelo, string foto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into unidade (nome_unidade, cod_unidade, gerente_unidade, comprador_unidade) " +
                              "values (@nome, @cod); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@nome", modelo.NomeUnidade);
            cmd.Parameters.AddWithValue("@cod", modelo.CodUnidade);

            conexao.Conectar();
            modelo.IdUnidade = Convert.ToInt32(cmd.ExecuteScalar());


            if (foto != "")
            {
                try
                {
                    var path = Path.Combine(folder, Path.GetFileName(foto));

                    if (!Directory.Exists(folder))

                    {
                        Directory.CreateDirectory(folder);

                        File.Copy(foto, folder + modelo.IdUnidade.ToString() + Path.GetExtension(foto));
                    }
                    else
                    {
                        if (File.Exists(folder + modelo.IdUnidade.ToString() + Path.GetExtension(foto)))
                        {
                            File.Delete(folder + modelo.IdUnidade.ToString() + Path.GetExtension(foto));
                        }

                        File.Copy(foto, folder + modelo.IdUnidade.ToString() + Path.GetExtension(foto));
                    }
                }
                catch { }



            }

            conexao.Desconectar();

        }

        public void Alterar(DTOUnidade modelo, string foto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update unidade set nome_unidade = (@nome), cod_unidade = (@cod) WHERE id_unidade = (@id);";

            cmd.Parameters.AddWithValue("@nome", modelo.NomeUnidade);
            cmd.Parameters.AddWithValue("@cod", modelo.CodUnidade);
            cmd.Parameters.AddWithValue("@id", modelo.IdUnidade);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            if (foto != "")
            {

                try
                {

                    var path = Path.Combine(folder, Path.GetFileName(foto));

                    if (!Directory.Exists(folder))

                    {
                        Directory.CreateDirectory(folder);

                        File.Copy(foto, folder + modelo.IdUnidade.ToString() + Path.GetExtension(foto));


                    }
                    else
                    {
                        if (File.Exists(folder + modelo.IdUnidade.ToString() + Path.GetExtension(foto)))
                        {
                            File.Delete(folder + modelo.IdUnidade.ToString() + Path.GetExtension(foto));
                        }


                        File.Copy(foto, folder + modelo.IdUnidade.ToString() + Path.GetExtension(foto));

                    }
                }

                catch { }



            }
            conexao.Desconectar();

        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from unidade where id_unidade = @id;";

            cmd.Parameters.AddWithValue("@id", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable ListarUnidades()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select cod_unidade, id_unidade from unidade", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from unidade", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DTOUnidade CarregaModeloUnidade(int codigo)
        {
            DTOUnidade modelo = new DTOUnidade();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from unidade where id_unidade =" + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdUnidade = Convert.ToInt32(registro["id_unidade"]);
                modelo.NomeUnidade = Convert.ToString(registro["nome_unidade"]);
                modelo.CodUnidade = Convert.ToString(registro["cod_unidade"]);


            }
            conexao.Desconectar();
            return modelo;

        }

        public DTOUnidade CarregaCodUnidade()
        {
            DTOUnidade modelo = new DTOUnidade();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select cod_unidade from unidade";
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdUnidade = Convert.ToInt32(registro["id_unidade"]);


            }
            conexao.Desconectar();
            return modelo;

        }


    }

    public class DALLLog
    {
        private DALConexao conexao;

        public DALLLog(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOLog modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into autolog (id_usuario, cod_log) " +
                              "values (@id, @cod); select @@IDENTITY;";


            cmd.Parameters.AddWithValue("@id", modelo.IdUsuario);
            cmd.Parameters.AddWithValue("@cod", modelo.CodLog);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int id, string ip)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from autolog where (id_usuario) = (@id) and (cod_log) = (@ip);";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ip", ip);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

    }    

    //CMV

    public class DALCmvGrupo
    {
        private DALConexao conexao;

        public DALCmvGrupo(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void IncluirGrupo(DTOCmvGrupo modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into cmv_grupo (id_unidade, cmv_grupo_nome, cmv_grupo_meta_valor, cmv_grupo_meta_percentual) " +
                              "values (@unidade, @nome, @valor, @percentual); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@unidade", modelo.idUnidade);
            cmd.Parameters.AddWithValue("@nome", modelo.cmvGrupoNome);
            cmd.Parameters.AddWithValue("@valor", modelo.cmvGrupoMetaValor);
            cmd.Parameters.AddWithValue("@percentual", modelo.cmvGrupoMetaPercentual);

            conexao.Conectar();
            modelo.idCmvGrupo = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public void AlterarGrupo(DTOCmvGrupo modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update cmv_grupo set cmv_grupo_meta_valor = (@valor), cmv_grupo_meta_percentual = (@percentual), cmv_grupo_nome = (@nome) where id_cmv_grupo = @id;";


            cmd.Parameters.AddWithValue("@valor", modelo.cmvGrupoMetaValor);
            cmd.Parameters.AddWithValue("@percentual", modelo.cmvGrupoMetaPercentual);
            cmd.Parameters.AddWithValue("@nome", modelo.cmvGrupoNome);
            cmd.Parameters.AddWithValue("@id", modelo.idCmvGrupo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void IncluirGrupoCusto(DTOCmvGrupo modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into cmv_grupo_custo (id_cmv_grupo, id_config_custo) " +
                              "values (@grupo, @conta); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@grupo", modelo.idCmvGrupo);
            cmd.Parameters.AddWithValue("@conta", modelo.IdConfigCusto);

            conexao.Conectar();
            modelo.idCmvGrupoCusto = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public void IncluirGrupoReceita(DTOCmvGrupo modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into cmv_grupo_receita (id_cmv_grupo, cod_receita) " +
                              "values (@grupo, @receita); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@grupo", modelo.idCmvGrupo);
            cmd.Parameters.AddWithValue("@receita", modelo.CodReceita);

            conexao.Conectar();
            modelo.idCmvGrupoReceita = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public void ExcluirGrupo(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();
            SqlCommand cmd3 = new SqlCommand();
            
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from cmv_grupo where id_cmv_grupo = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            cmd2.Connection = conexao.ObjetoConexao;
            cmd2.CommandText = "delete from cmv_grupo_custo where id_cmv_grupo = @id;";
            cmd2.Parameters.AddWithValue("@id", id);

            cmd3.Connection = conexao.ObjetoConexao;
            cmd3.CommandText = "delete from cmv_grupo_receita where id_cmv_grupo = @id;";
            cmd3.Parameters.AddWithValue("@id", id);
            
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void ExcluirGrupoCusto(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from cmv_grupo_custo where id_cmv_grupo_custo = @id;";

            cmd.Parameters.AddWithValue("@id", id);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void ExcluirGrupoCustoPorIdConfig(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from cmv_grupo_custo where id_config_custo = @id;";

            cmd.Parameters.AddWithValue("@id", id);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void ExcluirGrupoReceita(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from cmv_grupo_receita where id_cmv_grupo_receita = @id;";

            cmd.Parameters.AddWithValue("@id", id);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable LocalizarGrupo(int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_cmv_grupo, cmv_grupo_nome, cmv_grupo_meta_valor, cmv_grupo_meta_percentual from cmv_grupo where id_unidade = {unidade};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable LocalizarGrupoPorId(int id)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_cmv_grupo, cmv_grupo_nome, cmv_grupo_meta_valor, cmv_grupo_meta_percentual from cmv_grupo where id_cmv_grupo = {id};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable LocalizarGrupoCusto(int grupo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_cmv_grupo_custo, id_cmv_grupo, id_config_custo from cmv_grupo_custo where id_cmv_grupo = {grupo};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable LocalizarGrupoReceita(int grupo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_cmv_grupo_receita, cod_receita from cmv_grupo_receita where id_cmv_grupo = {grupo};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

    }

    public class DALConfigCusto
    {

        private DALConexao conexao;

        public DALConfigCusto(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOConfigCusto modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into config_custo (cod_setor, nome_setor, divisao_custo_setor, meta_percapta, meta_percentual, turno, id_unidade) " +
                              "values (@cod, @nome, @divisaoCusto, @metaPercapta, @metaPercentual, @turno, @unidade); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@cod", modelo.CodSetor);
            cmd.Parameters.AddWithValue("@nome", modelo.NomeSetor);
            cmd.Parameters.AddWithValue("@divisaoCusto", modelo.DivisaoCustoSetor);
            cmd.Parameters.AddWithValue("@metaPercapta", modelo.MetaPercapta);
            cmd.Parameters.AddWithValue("@metaPercentual", modelo.MetaPercentual);
            cmd.Parameters.AddWithValue("@turno", modelo.Turno);
            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Alterar(DTOConfigCusto modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update config_custo set cod_setor = (@cod), nome_setor = (@nome), divisao_custo_setor = (@divisaocusto), " +
                "meta_percapta = (@metaPercapta), meta_percentual = (@metaPercentual), turno = (@turno), id_unidade = (@unidade) where id_config_custo = (@id);";


            cmd.Parameters.AddWithValue("@cod", modelo.CodSetor);
            cmd.Parameters.AddWithValue("@nome", modelo.NomeSetor);
            cmd.Parameters.AddWithValue("@divisaoCusto", modelo.DivisaoCustoSetor);
            cmd.Parameters.AddWithValue("@metaPercapta", modelo.MetaPercapta);
            cmd.Parameters.AddWithValue("@metaPercentual", modelo.MetaPercentual);
            cmd.Parameters.AddWithValue("@turno", modelo.Turno);
            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@id", modelo.IdConfig);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from config_custo where id_config_custo = @id;";

            cmd.Parameters.AddWithValue("@id", id);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void ExcluirUnidade(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from config_custo where id_unidade = @id;";

            cmd.Parameters.AddWithValue("@id", id);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable LocalizarConfigCusto(int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_config_custo, cod_setor, nome_setor, divisao_custo_setor, meta_percapta, meta_percentual, turno, id_unidade from config_custo where id_unidade = {unidade} order by turno;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarConfigCustoPorId(int id)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_config_custo, cod_setor, nome_setor, divisao_custo_setor, meta_percapta, meta_percentual, turno, id_unidade from config_custo where id_config_custo = {id};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable ListarContasCadastradas(int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_config_custo, (cod_setor +' - '+ nome_setor) as setor, cod_setor from config_custo where id_unidade = {unidade} group by id_config_custo, nome_setor, cod_setor order by cod_setor;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable ListarContasPorUnidadeTurnoETipo(int unidade, string turno, string tipo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select con.cod_setor, con.nome_setor, con.turno, divisao_custo_setor, meta_percapta " +
        $"from config_custo con join conta_gerencial c on con.cod_setor = c.cod_setor where id_unidade= {unidade} and con.turno = '{turno}' and c.tipo_setor = '{tipo}'  order by turno, ordem_exib; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }
        
        public DataTable BuscaCodMaisNomeContaPeloId(int id)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select (cod_setor +' - '+ nome_setor) as setor from config_custo where id_config_custo = {id};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable BuscaCodMaisNomeConta(int unidade, string conta)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select (cod_setor +' - '+ nome_setor) as setor from config_custo where id_unidade = {unidade} and cod_setor = '{conta}' group by nome_setor, cod_setor order by cod_setor;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DTOConfigCusto CarregaModeloConfig(int id)
        {
            DTOConfigCusto modelo = new DTOConfigCusto();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = $"select * from config_custo where id_config_custo = {id};";
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();

                modelo.CodSetor = Convert.ToString(registro["cod_setor"]);
                modelo.NomeSetor = Convert.ToString(registro["nome_setor"]);
                modelo.DivisaoCustoSetor = Convert.ToDouble(registro["divisao_custo_setor"]);
                modelo.MetaPercapta = Convert.ToDouble(registro["meta_percapta"]);
                modelo.MetaPercentual = Convert.ToDouble(registro["meta_percentual"]);
                modelo.Turno = Convert.ToString(registro["turno"]);
                modelo.IdUnidade = Convert.ToInt32(registro["id_unidade"]);

            }
            conexao.Desconectar();
            return modelo;

        }


    }

    public class DALConfigReceita
    {

        private DALConexao conexao;

        public DALConfigReceita(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOConfigReceita modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into config_receita (id_unidade, cod_venda, nome_cod_venda, conta_gerencial, tipo_cod_venda, turno_cod_venda) " +
                              "values (@unidade, @cod, @nome, @conta, @tipo, @turno); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@cod", modelo.CodVenda);
            cmd.Parameters.AddWithValue("@nome", modelo.NomeCodVenda);
            cmd.Parameters.AddWithValue("@conta", modelo.ContaGerencial);
            cmd.Parameters.AddWithValue("@tipo", modelo.TipoCodVenda);
            cmd.Parameters.AddWithValue("@turno", modelo.TurnoCodVenda);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void ExcluirTudo(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from config_receita where id_unidade = @id;";

            cmd.Parameters.AddWithValue("@id", id);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from config_receita where id_config_receita = @id;";

            cmd.Parameters.AddWithValue("@id", id);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable LocalizarConfigReceita(int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_config_receita, cod_venda, nome_cod_venda, conta_gerencial, tipo_cod_venda, " +
                $"turno_cod_venda, id_unidade from config_receita where id_unidade = {unidade} order by turno_cod_venda, tipo_cod_venda;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

    }

    public class DALConfigImposto
    {

        private DALConexao conexao;

        public DALConfigImposto(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOConfigImposto modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into config_imposto (icms_a, pis_a, cofins_a, total_a, icms_b, pis_b, cofins_b, total_b, id_unidade) " +
                              "values (@icmsA, @pisA, @cofinsA, @totalA, @icmsB, @pisB, @cofinsB, @totalB, @unidade); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@icmsA", modelo.IcmsA);
            cmd.Parameters.AddWithValue("@pisA", modelo.PisA);
            cmd.Parameters.AddWithValue("@cofinsA", modelo.CofinsA);
            cmd.Parameters.AddWithValue("@totalA", modelo.TotalA);
            cmd.Parameters.AddWithValue("@icmsB", modelo.IcmsB);
            cmd.Parameters.AddWithValue("@pisB", modelo.PisB);
            cmd.Parameters.AddWithValue("@cofinsB", modelo.CofinsB);
            cmd.Parameters.AddWithValue("@totalB", modelo.TotalB);
            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);


            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from config_imposto where id_unidade = @id;";

            cmd.Parameters.AddWithValue("@id", id);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable localizar(int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select icms_a, pis_a, cofins_a, total_a, icms_b, pis_b, cofins_b, total_b, id_unidade from config_imposto where id_unidade = {unidade};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable localizarValoresTotaisImpostos(int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select total_a, total_b from config_imposto where id_unidade = {unidade};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }


    }

    public class DALConfigPax
    {

        private DALConexao conexao;

        public DALConfigPax(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOConfigPax modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into config_pax (config_dia_pax, config_dia_valor, id_unidade) " +
                              "values (@dia, @config, @unidade); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@dia", modelo.ConfigDiaPax);
            cmd.Parameters.AddWithValue("@config", modelo.ConfigDiaValor);
            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);


            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Alterar(DTOConfigPax dto)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update config_pax set config_dia_valor = (@valor) where config_dia_pax = (@dia) and id_unidade = (@id);";


            cmd.Parameters.AddWithValue("@valor", dto.ConfigDiaValor);
            cmd.Parameters.AddWithValue("@dia", dto.ConfigDiaPax);
            cmd.Parameters.AddWithValue("@id", dto.IdUnidade);


            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();


        }

        public void ExcluirTudo(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from config_pax where id_unidade = @id;";

            cmd.Parameters.AddWithValue("@id", id);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int id, string dia)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from config_pax where id_unidade = @id and config_dia_pax = @dia;";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@dia", dia);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable localizar(int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select config_dia_pax, config_dia_valor from config_pax where id_unidade = {unidade} order by config_dia_pax;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable localizarDia(int unidade, string dia)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select config_dia_valor from config_pax where id_unidade = {unidade} and config_dia_pax = '{dia}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

    }

    public class DALConfigUnidade
    {

        private DALConexao conexao;

        public DALConfigUnidade(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOConfigUnidade modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into config_unidade (id_unidade, tipo_config, config, id_usuario) " +
                              "values (@unidade, @tipo, @config, @usuario); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@tipo", modelo.TipoConfig);
            cmd.Parameters.AddWithValue("@config", modelo.Config);
            cmd.Parameters.AddWithValue("@usuario", modelo.IdUsuario);


            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }


        public void Alterar(DTOConfigUnidade modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update config_unidade set config = (@config) WHERE tipo_config = (@tipo) and id_unidade = (@unidade);";

            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@tipo", modelo.TipoConfig);
            cmd.Parameters.AddWithValue("@config", modelo.Config);


            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void AlterarU(DTOConfigUnidade modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update config_unidade set config = (@config) WHERE tipo_config = (@tipo) and id_unidade = (@unidade) and id_usuario = (@usuario);";

            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@tipo", modelo.TipoConfig);
            cmd.Parameters.AddWithValue("@config", modelo.Config);
            cmd.Parameters.AddWithValue("@usuario", modelo.IdUsuario);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }


        public DataTable LocalizarConfig(String tipo, int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select config from config_unidade where tipo_config = '{tipo}' and id_unidade = {unidade};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarConfigUsuario(String tipo, int unidade, int ususario)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select config from config_unidade where tipo_config = '{tipo}' and id_unidade = {unidade} and id_usuario = {ususario};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public void Excluir(string tipo, int unidade)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from config_unidade where tipo_config = @tipo and id_unidade = @unidade;";

            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@unidade", unidade);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void ExcluirPorUsuario(string tipo, int unidade, int usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from config_unidade where tipo_config = @tipo and id_unidade = @unidade and id_usuario = @usuario;";

            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@unidade", unidade);
            cmd.Parameters.AddWithValue("@usuario", usuario);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }


        public DTOConfigUnidade CarregaModeloConfig(String tipoConfig, int unidade)
        {
            DTOConfigUnidade modelo = new DTOConfigUnidade();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = $"select config from config_unidade where tipo_config = '{tipoConfig}' and id_unidade = {unidade};";
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();

                modelo.Config = Convert.ToString(registro["config"]);

            }
            conexao.Desconectar();
            return modelo;

        }

    }

    public class DALContasGerenciais
    {

        private DALConexao conexao;

        public DALContasGerenciais(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOContasGerenciais modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into conta_gerencial (cod_setor, nome_setor, tipo_setor) " +
                              "values (@cod, @nome, @tipo); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@cod", modelo.CodSetor);
            cmd.Parameters.AddWithValue("@nome", modelo.NomeSetor);
            cmd.Parameters.AddWithValue("@tipo", modelo.TipoSetor);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Alterar(DTOContasGerenciais modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update conta_gerencial set nome_setor = (@nome), tipo_setor = (@tipo) WHERE cod_setor = (@cod);";

            cmd.Parameters.AddWithValue("@cod", modelo.CodSetor);
            cmd.Parameters.AddWithValue("@nome", modelo.NomeSetor);
            cmd.Parameters.AddWithValue("@tipo", modelo.TipoSetor);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(string codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from conta_gerencial where cod_setor = @cod;";

            cmd.Parameters.AddWithValue("@cod", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable Localizar(String busca)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(busca, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarCodigo(string codigo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select * from conta_gerencial where cod_setor = {codigo} ;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DTOContasGerenciais CarregaModeloContaCodigo(string codigo)
        {
            DTOContasGerenciais modelo = new DTOContasGerenciais();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = $"select * from conta_gerencial where cod_setor = '{codigo}'";
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();

                modelo.CodSetor = Convert.ToString(registro["cod_setor"]);
                modelo.NomeSetor = Convert.ToString(registro["nome_setor"]);
                modelo.TipoSetor = Convert.ToString(registro["tipo_setor"]);

            }
            conexao.Desconectar();
            return modelo;

        }

    }

    public class DALDados

    {

        private DALConexao conexao;

        public DALDados(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTODados modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into venda (data_venda, grupo_venda, cancelados_venda, cortesias_venda, promocoes_venda, " +
                "quant_venda, quant_total_venda, valor_venda, valor_total_venda, id_unidade, id_usuario) " +
                "values (@data, @grupo, @cancelados, @cortesias, @promocoes, @quant, @quant_total, @valor, @valor_total, @unidade, @usuario" +
                "); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@data", modelo.DataVenda);
            cmd.Parameters.AddWithValue("@grupo", modelo.GrupoVenda);
            cmd.Parameters.AddWithValue("@cancelados", modelo.CanceladosVenda);
            cmd.Parameters.AddWithValue("@cortesias", modelo.CortesiasVenda);
            cmd.Parameters.AddWithValue("@promocoes", modelo.PromocoesVenda);
            cmd.Parameters.AddWithValue("@quant", modelo.QuantVenda);
            cmd.Parameters.AddWithValue("@quant_total", modelo.QuantTotalVenda);
            cmd.Parameters.AddWithValue("@valor", modelo.ValorVenda);
            cmd.Parameters.AddWithValue("@valor_total", modelo.ValorTotalVenda);
            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@usuario", modelo.IdUsuario);

            conexao.Conectar();
            modelo.IdVenda = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public void Excluir(DateTime data, int unidade)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from venda where data_venda = @data and id_unidade = @unidade;";

            cmd.Parameters.AddWithValue("@data", data.ToString("d"));
            cmd.Parameters.AddWithValue("@unidade", unidade);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable Localizar(DateTime data, int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT sum(valor_venda) as total FROM venda where data_venda = " + data.ToString("d") + " and id_unidade = " + unidade, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarVenda(DateTime datai, DateTime dataf, int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select data_venda, sum(valor_total_venda) as total from venda where id_unidade = {unidade} " +
                $"and data_venda >= '{datai}' and data_venda <= '{dataf}' group by data_venda order by data_venda; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarVendaDiaria(string busca)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(busca, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DTODados CarregaModeloVenda(DateTime data, int unidade)
        {
            DTODados modelo = new DTODados();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT sum(valor_venda) as total  FROM venda where data_venda = '" + data + "' and id_unidade = " + unidade + ";";
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.HasRows)
            {
                registro.Read();
                try
                {
                    modelo.Total = Convert.ToDouble(registro["total"]);
                }
                catch { }
            }
            conexao.Desconectar();
            return modelo;

        }

        
        public void IncluirPax(DTODados modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into pax (data_pax, turno_pax, pax, id_unidade, id_usuario, diaturno) " +
                "values (@data, @turno, @pax, @unidade, @usuario, @diaturno); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@data", modelo.DataPax);
            cmd.Parameters.AddWithValue("@turno", modelo.TurnoPax);
            cmd.Parameters.AddWithValue("@pax", modelo.Pax);
            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@usuario", modelo.IdUsuario);
            cmd.Parameters.AddWithValue("@diaturno", modelo.DiaTurno);

            conexao.Conectar();
            modelo.IdPax = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public void ExcluirPax(DateTime dataI, DateTime dataF, int unidade)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from pax where data_pax >= @datai and data_pax <= @dataf and id_unidade = @unidade;";

            cmd.Parameters.AddWithValue("@datai", dataI.ToString("d"));
            cmd.Parameters.AddWithValue("@dataf", dataF.ToString("d"));
            cmd.Parameters.AddWithValue("@unidade", unidade);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void ExcluirPaxDia(DateTime Dia, int unidade)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from pax where data_pax = @dia and id_unidade = @unidade;";

            cmd.Parameters.AddWithValue("@dia", Dia.ToString("d"));
            cmd.Parameters.AddWithValue("@unidade", unidade);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }


        public DataTable LocalizarPax(DateTime data, int unidade, int turno)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT pax FROM pax where data_pax = " + data.ToString("d") + " and turno_pax = " + turno + " and id_unidade = " + unidade, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarPaxDiario(DateTime datai, DateTime dataf, int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select data_pax, sum(pax) as pax from pax where id_unidade = {unidade} " +
                $"and data_pax >= '{datai}' and data_pax <= '{dataf}' group by data_pax; ; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }


        public DTODados CarregaModeloPax(DateTime data, int unidade)
        {
            DTODados modelo = new DTODados();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT sum(pax) as total FROM pax where data_pax = '" + data + "' and id_unidade = " + unidade + ";";
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.HasRows)
            {
                registro.Read();
                try
                {
                    modelo.Total = Convert.ToDouble(registro["total"]);
                }
                catch { }
            }
            conexao.Desconectar();
            return modelo;

        }
        
        public void IncluirCusto(DTODados modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into custo (data_custo, cod_item_custo, tipo_mov_custo, quant_mov_custo, valor_unitario_custo, " +
                "tipo_operacao_custo, descricao_custo, conta_gerencial_custo, tipo_doc_custo, documento_custo, movimento_custo, id_unidade, id_usuario, grupo) " +
                "values (@data, @cod, @tipo, @quant, @valor, @operacao, @descricao, @conta, @tipodoc, @doc, @movimento, @unidade, @usuario, @grupo " +
                "); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@data", modelo.DataCusto);
            cmd.Parameters.AddWithValue("@cod", modelo.CodItemCusto);
            cmd.Parameters.AddWithValue("@tipo", modelo.TipoMovCusto);
            cmd.Parameters.AddWithValue("@quant", modelo.QuantMovCusto);
            cmd.Parameters.AddWithValue("@valor", modelo.ValorUnitarioCusto);
            cmd.Parameters.AddWithValue("@operacao", modelo.TipoOperacaoCusto);
            cmd.Parameters.AddWithValue("@conta", modelo.ContaGerencialCusto);
            cmd.Parameters.AddWithValue("@tipodoc", modelo.TipoDocCusto);
            cmd.Parameters.AddWithValue("@descricao", modelo.DescricaoCusto);
            cmd.Parameters.AddWithValue("@doc", modelo.DocumentoCusto);
            cmd.Parameters.AddWithValue("@movimento", modelo.MovimentoCusto);
            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@usuario", modelo.IdUsuario);
            cmd.Parameters.AddWithValue("@grupo", modelo.Grupo);

            conexao.Conectar();
            modelo.IdCusto = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public void ExcluirCusto(DateTime datai, DateTime dataf, int unidade)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from custo where data_custo >= @datai and data_custo <= @dataf and id_unidade = @unidade;";

            cmd.Parameters.AddWithValue("@datai", datai.ToString("d"));
            cmd.Parameters.AddWithValue("@dataf", dataf.ToString("d"));
            cmd.Parameters.AddWithValue("@unidade", unidade);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable LocalizarCusto(DateTime data, int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT sum(valor_venda) as total FROM venda where data_venda = " + data.ToString("d") + " and id_unidade = " + unidade, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DTODados CarregaModeloCusto(DateTime data, int unidade)
        {
            DTODados modelo = new DTODados();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT sum(valor_venda) as total  FROM venda where data_venda = '" + data + "' and id_unidade = " + unidade + ";";
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.HasRows)
            {
                registro.Read();
                try
                {
                    modelo.Total = Convert.ToDouble(registro["total"]);
                }
                catch { }
            }
            conexao.Desconectar();
            return modelo;

        }



    }

    public class DALConsultasCMV
    {

        private DALConexao conexao;

        public DALConsultasCMV(DALConexao cx)
        {
            this.conexao = cx;
        }

        //Melhores
        //PAX - Turno se 1 = dia, se 0 = noite  -  CUSTO Turno se a = almoço  e j = jantar

        public DataTable TabelaCmvPorTurno(int unidade, DateTime diaI, DateTime diaF, string turnoCusto, int turnoPax)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select c.data_custo, sum(c.quant_mov_custo* c.valor_unitario_custo) as custo, " +
                "p.pax, sum((c.quant_mov_custo* c.valor_unitario_custo)/p.pax)as CMV from custo c left join pax p " +
                "on(p.id_unidade = c.id_unidade and c.data_custo = p.data_pax) left join config_pax cp on p.diaturno = cp.config_dia_pax " +
                "join config_custo cc on c.conta_gerencial_custo = cc.cod_setor " +
                $"where c.id_unidade = {unidade} and c.grupo = '01' and cp.config_dia_valor = {turnoPax} and cc.turno = '{turnoCusto}' and c.data_custo between '{diaI}' and '{diaF}' " +
                "group by c.data_custo, p.pax order by c.data_custo;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TabelaCustoPorTutno(int unidade, DateTime diaI, DateTime diaF, string turnoCusto)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select c.data_custo, sum(c.quant_mov_custo * c.valor_unitario_custo) as CUSTO from custo c "+
    "join config_custo cc on c.conta_gerencial_custo = cc.cod_setor "+
    $"where c.id_unidade = {unidade} and c.grupo = '01' and cc.turno = '{turnoCusto}' and c.data_custo between '{diaI}' and '{diaF}' "+
    "group by  c.data_custo order by c.data_custo;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TabelaPaxPorDia(int unidade, DateTime diaI, DateTime diaF)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT data_pax, sum(pax) as pax  FROM PAX "+
                $"where id_unidade = {unidade} and data_pax between '{diaI}' and '{diaF}' group by data_pax", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }



        //Organizadas

        public DataTable TabelaCusto(int unidade, DateTime diaI, DateTime diaF, string turno)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select c.data_custo, sum(c.quant_mov_custo * c.valor_unitario_custo * con.divisao_custo_setor) as total_Alimentos_E_Bebidas from custo c " +
        "join config_custo con on c.conta_gerencial_custo = con.cod_setor " +
        "join conta_gerencial cg on c.conta_gerencial_custo = cg.cod_setor " +
        "where(tipo_operacao_custo = '800.01' or(tipo_operacao_custo = '800.02' and c.conta_gerencial_custo = '9.5.02.106') or " +
        "tipo_operacao_custo = '110.2R' OR tipo_operacao_custo = '140.3A' OR tipo_operacao_custo = '110.2S' OR tipo_operacao_custo = '110.2E' OR tipo_operacao_custo = '110.2Y' OR tipo_operacao_custo = '110.2U' OR tipo_operacao_custo = '210.2B' OR tipo_operacao_custo = '191.0') " +
        $"AND data_custo between '{diaI}' and '{diaF}' and con.turno = '{turno}' and c.id_unidade = {unidade} and(cg.tipo_setor = 'a' or cg.tipo_setor = 'b') " +
        "group by c.data_custo;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }
        //Turno se 1 = dia, se 0 = noite
        public DataTable TabelaPax(int unidade, DateTime diaI, DateTime diaF, int turno)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select replace((str(datepart(dw, p.data_pax))+'.'+ str(c.config_dia_valor)), ' ','') as dia_turno, sum(p.pax) as pax, p.data_pax from pax p " +
                 "join config_pax c on replace((str(datepart(dw, data_pax)) + '.' + str(turno_pax)), ' ', '') = c.config_dia_pax " +
                 $"where data_pax between '{diaI}' and '{diaF}' and p.id_unidade = {unidade} and c.config_dia_valor = {turno} " +
                 "group by replace((str(datepart(dw, p.data_pax)) + '.' + str(c.config_dia_valor)), ' ', ''), p.data_pax " +
                 "order by data_pax; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TotalCustoAeBGeral(int unidade, DateTime diaI, DateTime diaF)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(c.quant_mov_custo* c.valor_unitario_custo) as total_Alimentos_E_Bebidas from custo c "+
                "join conta_gerencial cg on c.conta_gerencial_custo = cg.cod_setor "+
                "where(tipo_operacao_custo in('800.01', '110.2R', '140.3A', '110.2S', '110.2E', '110.2Y', '110.2U', '210.2B', '191.0', '800.90', '800.95') or "+
                $"(tipo_operacao_custo = '800.02' and c.conta_gerencial_custo = '9.5.02.106')) AND c.data_custo between '{diaI}' and '{diaF}' and c.id_unidade = {unidade}; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TotalCustoAeB(int unidade, DateTime diaI, DateTime diaF, string turno)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(c.quant_mov_custo* c.valor_unitario_custo* con.divisao_custo_setor) as total_Alimentos_E_Bebidas from custo c "+
                "join config_custo con on c.conta_gerencial_custo = con.cod_setor "+
                "join conta_gerencial cg on c.conta_gerencial_custo = cg.cod_setor "+
                "where(tipo_operacao_custo = '800.01' or(tipo_operacao_custo = '800.02' and c.conta_gerencial_custo = '9.5.02.106') or "+
                "tipo_operacao_custo = '110.2R' OR tipo_operacao_custo = '140.3A' OR tipo_operacao_custo = '110.2S' OR tipo_operacao_custo = '110.2E' OR tipo_operacao_custo = '110.2Y' OR tipo_operacao_custo = '110.2U' OR tipo_operacao_custo = '210.2B' OR tipo_operacao_custo = '191.0') "+
                $"AND data_custo between '{diaI}' and '{diaF}' and con.turno = '{turno}' and c.id_unidade = {unidade} and(cg.tipo_setor = 'a' or cg.tipo_setor = 'b'); ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }
        //Turno se 1 = dia, se 0 = noite
        public DataTable TotalPax(int unidade, DateTime diaI, DateTime diaF, int turno)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(p.pax) as paxN from pax p "+
                "join config_pax c on replace((str(datepart(dw, data_pax)) + '.' + str(turno_pax)), ' ', '') = c.config_dia_pax "+
                $"where data_pax between '{diaI}' and '{diaF}' and p.id_unidade = '{unidade}' and c.config_dia_valor = {turno}", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable LocalizarCustoPorSetor(int unidade, string tipo, DateTime dataI, DateTime dataF)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select g.nome_setor, sum(c.quant_mov_custo * c.valor_unitario_custo) as valor " +
                "from config_custo g inner join conta_gerencial t on g.cod_setor = t.cod_setor " +
                $"inner join custo c on g.cod_setor = c.conta_gerencial_custo where g.id_unidade = {unidade} and t.tipo_setor = '{tipo}' " +
                $" and c.data_custo >= '{dataI}' and c.data_custo <= '{dataF}' group by g.nome_setor;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable TotalMetaPorTipoETurno(int unidade, string tipo, string turno)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(g.meta_percapta) as valor from config_custo g " +
                $"inner join conta_gerencial t on g.cod_setor = t.cod_setor where g.id_unidade = {unidade} and t.tipo_setor = '{tipo}' and turno = '{turno}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TotalCustoPorSetorTipoETurno(int unidade, string tipo, DateTime dataI, DateTime dataF, string turno)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(c.quant_mov_custo * c.valor_unitario_custo * con.divisao_custo_setor) as total_Alimentos_Almoço from custo c "+
            "join config_custo con on c.conta_gerencial_custo = con.cod_setor "+
            "join conta_gerencial cg on c.conta_gerencial_custo = cg.cod_setor "+
            "where(descricao_custo = 'CONSUMO - CMV DIVERSOS - A&B' or(descricao_custo = 'CONSUMO - CMV DIVERSOS - DADO SHOP' and c.conta_gerencial_custo = '9.5.02.106') or "+
            "tipo_operacao_custo = '110.2R' OR tipo_operacao_custo = '140.3A' OR tipo_operacao_custo = '110.2S' OR tipo_operacao_custo = '110.2E' OR "+
            "tipo_operacao_custo = '110.2Y' OR tipo_operacao_custo = '110.2U' OR tipo_operacao_custo = '210.2B' OR tipo_operacao_custo = '191.0') " +
            $"AND data_custo >= '{dataI}' and data_custo <= '{dataF}' and con.turno = '{turno}' and cg.tipo_setor = '{tipo}' and c.id_unidade = {unidade}; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarCustoPorSetorTipoETurno(int unidade, string tipo, DateTime dataI, DateTime dataF, string turno)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(c.quant_mov_custo * c.valor_unitario_custo * con.divisao_custo_setor) as total_Alimentos_Almoço from custo c " +
            "join config_custo con on c.conta_gerencial_custo = con.cod_setor join conta_gerencial cg on c.conta_gerencial_custo = cg.cod_setor " +
            " where(descricao_custo = 'CONSUMO - CMV DIVERSOS - A&B' or(descricao_custo = 'CONSUMO - CMV DIVERSOS - DADO SHOP' and c.conta_gerencial_custo = '9.5.02.106') or "+
            " tipo_operacao_custo = '110.2R' OR tipo_operacao_custo = '140.3A' OR tipo_operacao_custo = '110.2S' OR tipo_operacao_custo = '110.2E' OR "+
            "tipo_operacao_custo = '110.2Y' OR tipo_operacao_custo = '110.2U' OR tipo_operacao_custo = '210.2B' OR tipo_operacao_custo = '191.0' or tipo_operacao_custo = '800.90' or tipo_operacao_custo = '800.95') " +
            $"AND data_custo >= '{dataI}' and data_custo <= '{dataF}' and con.turno = '{turno}' and cg.tipo_setor = '{tipo}' and c.id_unidade = {unidade}; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable TotalCustoPorTipo(int unidade, string tipo, DateTime dataI, DateTime dataF)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(c.quant_mov_custo * c.valor_unitario_custo) as total_Alimentos from custo c "+
                    "join conta_gerencial con on c.conta_gerencial_custo = con.cod_setor where (descricao_custo = 'CONSUMO - CMV DIVERSOS - A&B' or(descricao_custo = 'CONSUMO - CMV DIVERSOS - DADO SHOP' and c.conta_gerencial_custo = '9.5.02.106') or "+
                    "tipo_operacao_custo = '110.2R' OR tipo_operacao_custo = '140.3A' OR tipo_operacao_custo = '110.2S' OR tipo_operacao_custo = '110.2E' OR tipo_operacao_custo = '110.2Y' OR "+
                    $"tipo_operacao_custo = '110.2U' OR tipo_operacao_custo = '210.2B' OR tipo_operacao_custo = '191.0') AND data_custo >= '{dataI}' and data_custo <= '{dataF}' and con.tipo_setor = '{tipo}' and c.id_unidade = {unidade}; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable TotalCustoPorUnidadeDataEConta(int unidade, string conta, DateTime datai, DateTime dataf)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(quant_mov_custo * valor_unitario_custo) as total from custo "+
                $"where conta_gerencial_custo = '{conta}' and id_unidade = {unidade} and data_custo >= '{datai}' and data_custo <= '{dataf}'; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarReceitaTotal(DateTime dataI, DateTime dataF, int unidade)
        {

            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select sum(valor_total_venda) from venda where id_unidade = {unidade} " +
                $"and data_venda >= '{dataI}' and data_venda <= '{dataF}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizaReceitaGrupo(int unidade, DateTime dataI, DateTime dataF, string grupo)
        {

            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select sum(v.valor_total_venda) as valor_total from venda " +
                "v inner join config_receita c on v.grupo_venda = c.cod_venda " +
                $"where c.tipo_cod_venda = '{grupo}' and v.id_unidade = {unidade} and v.data_venda >= '{dataI}' and data_venda <= '{dataF}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizaReceitaDiversas(int unidade, DateTime dataI, DateTime dataF)
        {

            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select sum(v.valor_total_venda) as valor_total from venda " +
                "v inner join config_receita c on v.grupo_venda = c.cod_venda " +
                $"where c.tipo_cod_venda <> 'A' and c.tipo_cod_venda <> 'B' and v.id_unidade = {unidade} and v.data_venda >= '{dataI}' and data_venda <= '{dataF}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable VerificaSetorNoConfig(int unidade, string setor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select count(cod_setor) as contagem from config_custo " +
                $"where id_unidade = {unidade} and cod_setor = '{setor}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarPaxPorTurno(int unidade, DateTime dataI, DateTime dataF, int turno)
        {

            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select sum(pax) as pax from pax where id_unidade = {unidade} " +
                $"and data_pax >= '{dataI}' and data_pax <= '{dataF}' and turno_pax = {turno};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable ListarPaxPorUnidadeDataeTurno(int unidade, DateTime data, int turno)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select replace((str(datepart(dw, p.data_pax))+'.'+ str(c.config_dia_valor)), ' ','') as dia_turno, "+
                "sum(p.pax) as pax, p.data_pax from pax p join config_pax c on replace((str(datepart(dw, data_pax)) + '.' + str(turno_pax)), ' ', '') = c.config_dia_pax "+
                $"where p.id_unidade = '{unidade}' and data_pax = '{data}' and c.config_dia_valor = {turno} "+
                "group by replace((str(datepart(dw, p.data_pax)) + '.' + str(c.config_dia_valor)), ' ', ''), p.data_pax "+
                "order by data_pax; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;


        }

        public DataTable LocalizarCortesias(int unidade, DateTime dataI, DateTime dataF)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(VALOR_VENDA - valor_total_venda) as venda from venda " +
                $"where id_unidade = {unidade} and data_venda >= '{dataI}' and data_venda <= '{dataF}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarCodigosAcadastrar()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT c.cod_item_custo, c.id_unidade, a.nome_aeb, " +
                "count(a.nome_aeb) as contagem FROM CUSTO c left join aeb a on c.cod_item_custo = a.cod_aeb " +
                "group by c.cod_item_custo, c.id_unidade, a.nome_aeb order by contagem, c.cod_item_custo; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

    }

    public class DALAeB

    {

        private DALConexao conexao;

        public DALAeB(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOAeB modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into aeb (cod_aeb, nome_aeb, um_aeb, fc) values (@cod, @nome, @um, @fc);";

            cmd.Parameters.AddWithValue("@cod", modelo.CodAeb);
            cmd.Parameters.AddWithValue("@nome", modelo.NomeAeb);
            cmd.Parameters.AddWithValue("@um", modelo.UmAeb);
            cmd.Parameters.AddWithValue("@fc", modelo.Fc);


            conexao.Conectar();
            modelo.IdAeb = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public void Alterar(DTOAeB modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update aeb set cod_aeb = (@cod), nome_aeb = (@nome)," +
                "um_aeb = (@um), fc = (@fc) WHERE id_aeb = (@id);";

            cmd.Parameters.AddWithValue("@cod", modelo.CodAeb);
            cmd.Parameters.AddWithValue("@nome", modelo.NomeAeb);
            cmd.Parameters.AddWithValue("@um", modelo.UmAeb);
            cmd.Parameters.AddWithValue("@fc", modelo.Fc);
            cmd.Parameters.AddWithValue("@id", modelo.IdAeb);


            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void AlterarPorCod(DTOAeB modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update aeb set nome_aeb = (@nome)," +
                "um_aeb = (@um), fc = (@fc) WHERE cod_aeb = (@cod);";

            cmd.Parameters.AddWithValue("@cod", modelo.CodAeb);
            cmd.Parameters.AddWithValue("@nome", modelo.NomeAeb);
            cmd.Parameters.AddWithValue("@um", modelo.UmAeb);
            cmd.Parameters.AddWithValue("@fc", modelo.Fc);
            


            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void AlterarfcPorCod(DTOAeB modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update aeb set fc = (@fc) WHERE cod_aeb = (@cod);";

            cmd.Parameters.AddWithValue("@cod", modelo.CodAeb);
            cmd.Parameters.AddWithValue("@fc", modelo.Fc);
            cmd.Parameters.AddWithValue("@fc", modelo.Fc);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }


        public void Anterar(DTOAeB modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into aeb (cod_aeb, nome_aeb, um_aeb, fc) values (@cod, @nome, @um, @fc);";

            cmd.Parameters.AddWithValue("@cod", modelo.CodAeb);
            cmd.Parameters.AddWithValue("@nome", modelo.NomeAeb);
            cmd.Parameters.AddWithValue("@um", modelo.UmAeb);

            conexao.Conectar();
            modelo.IdAeb = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }


        public DTOAeB CarregaModeloAeB(string Codigo)
        {
            DTOAeB modelo = new DTOAeB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = $"SELECT cod_aeb, nome_aeb, um_aeb, fc FROM aeb where cod_aeb = '{Codigo}';";
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.HasRows)
            {
                registro.Read();
                try
                {
                    modelo.CodAeb = Convert.ToString(registro["cod_aeb"]);
                    modelo.NomeAeb = Convert.ToString(registro["nome_aeb"]); ;
                    modelo.UmAeb = Convert.ToString(registro["um_aeb"]); ;
                    modelo.Fc = Convert.ToDouble(registro["fc"]);
                }
                catch { }
            }
            conexao.Desconectar();
            return modelo;

        }

        public void ExcluirPorCod(string cod)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = $"delete FROM aeb where cod_aeb = '{cod}';";
            
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(DateTime data, int unidade)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from venda where data_venda = @data and id_unidade = @unidade;";

            cmd.Parameters.AddWithValue("@data", data.ToString("d"));
            cmd.Parameters.AddWithValue("@unidade", unidade);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }


        public DataTable Localizar(string cod)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select count(cod_aeb) as contagem from aeb where cod_aeb = '{cod}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarNome(string nome)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT cod_aeb, nome_aeb, um_aeb, fc FROM aeb where nome_aeb like '%{nome}%' order by cod_aeb;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarPorCod(string cod)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT nome_aeb, um_aeb, fc FROM aeb where cod_aeb = '{cod}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarVenda(DateTime datai, DateTime dataf, int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select data_venda, sum(valor_total_venda) as total from venda where id_unidade = {unidade} " +
                $"and data_venda >= '{datai}' and data_venda <= '{dataf}' group by data_venda order by data_venda; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarVendaDiaria(string busca)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(busca, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DTODados CarregaModeloVenda(DateTime data, int unidade)
        {
            DTODados modelo = new DTODados();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT sum(valor_venda) as total  FROM venda where data_venda = '" + data + "' and id_unidade = " + unidade + ";";
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.HasRows)
            {
                registro.Read();
                try
                {
                    modelo.Total = Convert.ToDouble(registro["total"]);
                }
                catch { }
            }
            conexao.Desconectar();
            return modelo;

        }
    }

    public class DALExcessoesCusto

    {
        private DALConexao conexao;

        public DALExcessoesCusto(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOExcessoesCusto modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into excessao_custo (tipo_operacao, acao, obs) values (@operacao, @acao, @obs);";

            cmd.Parameters.AddWithValue("@operacao", modelo.TipoOperacao);
            cmd.Parameters.AddWithValue("@acao", modelo.Acao);
            cmd.Parameters.AddWithValue("@obs", modelo.Obs);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from excessao_custo where id_excessao_custo = @id;";

            cmd.Parameters.AddWithValue("@id", id);            

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable Localizar()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_excessao_custo, tipo_operacao, acao, obs from excessao_custo order by tipo_operacao;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }


        public DataTable LocalizarId(int id)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select tipo_operacao, acao, obs from excessao_custo where id_excessao_custo = {id};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarTipoOperacao(string operacao)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select tipo_operacao, acao, obs from excessao_custo where tipo_operacao = '{operacao}';", conexao.StringConexao);

            da.Fill(tabela);

            return tabela;

        }
        
        public DTOExcessoesCusto CarregaModeloExcessaoCusto(string operacao)
        {
            DTOExcessoesCusto modelo = new DTOExcessoesCusto();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = $"select id_excessao_custo, tipo_operacao, acao, obs from excessao_custo where tipo_operacao = {operacao};";
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.HasRows)
            {
                registro.Read();
                try
                {
                    modelo.IdExcessaoCusto = Convert.ToInt32(registro["id_excessao_custo"]);
                    modelo.TipoOperacao = registro["tipo_operacao"].ToString();
                    modelo.Acao = Convert.ToInt32(registro["acao"]);
                    modelo.Obs = registro["obs"].ToString();

                }
                catch { }
            }
            conexao.Desconectar();
            return modelo;

        }
    }

    //Graficos

    public class DALGraficosCmv
    {

        private DALConexao conexao;

        public DALGraficosCmv(DALConexao cx)
        {
            this.conexao = cx;
        }

       
        public DataTable TabelaCustoPorGrupo(int unidade, DateTime diaI, DateTime diaF, int idGrupo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select cus.data_custo, sum(cus.quant_mov_custo*cus.valor_unitario_custo * cc.divisao_custo_setor) as custo from cmv_grupo g " +
                "join cmv_grupo_custo c on g.id_cmv_grupo = c.id_cmv_grupo " +
                "join config_custo cc on c.id_config_custo = cc.id_config_custo "+
                "join custo cus on cus.conta_gerencial_custo = cc.cod_setor "+
                $"where cc.id_unidade = {unidade} and g.id_cmv_grupo = {idGrupo} and cus.grupo = '01' and cus.data_custo between '{diaI}' and '{diaF}' "+
                "group by cus.data_custo; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TabelaCustoPorGrupos(int unidade, DateTime diaI, DateTime diaF, int idGrupo1, int idGrupo2, int idGrupo3, int idGrupo4, int idGrupo5)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select cus.data_custo, sum(cus.quant_mov_custo*cus.valor_unitario_custo * cc.divisao_custo_setor) as custo from cmv_grupo g " +
                "join cmv_grupo_custo c on g.id_cmv_grupo = c.id_cmv_grupo " +
                "join config_custo cc on c.id_config_custo = cc.id_config_custo " +
                "join custo cus on cus.conta_gerencial_custo = cc.cod_setor " +
                $"where cc.id_unidade = {unidade} and g.id_cmv_grupo in({idGrupo1},{idGrupo2},{idGrupo3},{idGrupo4},{idGrupo5}) and cus.grupo = '01' and cus.data_custo between '{diaI}' and '{diaF}' " +
                "group by cus.data_custo; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TabelaCustoPorConta(int unidade, DateTime diaI, DateTime diaF, int idGrupo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select cc.id_config_custo, (cc.cod_setor+' - '+cc.nome_setor) as conta, sum(cus.quant_mov_custo*cus.valor_unitario_custo * cc.divisao_custo_setor) as custo from cmv_grupo g " +

                    "join cmv_grupo_custo c on g.id_cmv_grupo = c.id_cmv_grupo " +
                    "join config_custo cc on c.id_config_custo = cc.id_config_custo "+
                    "join custo cus on cus.conta_gerencial_custo = cc.cod_setor " +
                    $"where cc.id_unidade = {unidade} and g.id_cmv_grupo = {idGrupo} and cus.grupo = '01' and cus.data_custo between '{diaI}' and '{diaF}' "+
                    "group by cc.cod_setor, cc.nome_setor, cc.id_config_custo order by sum(cus.quant_mov_custo* cus.valor_unitario_custo) asc; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }
        //Itens do setor
        public DataTable TabelaItensPorConta(int unidade, DateTime diaI, DateTime diaF, int idConta)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select cus.data_custo, cus.cod_item_custo, aeb.nome_aeb, cus.quant_mov_custo, cus.valor_unitario_custo, cast((cus.quant_mov_custo* cus.valor_unitario_custo * cc.divisao_custo_setor) AS NUMERIC(15,4))as Custo, cus.movimento_custo, cus.documento_custo from cmv_grupo g " +
                    "join cmv_grupo_custo c on g.id_cmv_grupo = c.id_cmv_grupo " +
                    "join config_custo cc on c.id_config_custo = cc.id_config_custo "+
                    "join custo cus on cus.conta_gerencial_custo = cc.cod_setor "+
                    "join aeb aeb on cus.cod_item_custo = aeb.cod_aeb "+
                    $"where cc.id_unidade = {unidade} and cc.id_config_custo = {idConta} and cus.grupo = '01' and cus.data_custo between '{diaI}' and '{diaF}' "+
                    "order by cus.data_custo, cus.cod_item_custo; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TotalCustoPorGrupo(int unidade, DateTime diaI, DateTime diaF, int idGrupo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(cus.quant_mov_custo* cus.valor_unitario_custo * cc.divisao_custo_setor) as custo from cmv_grupo g " +
                "join cmv_grupo_custo c on g.id_cmv_grupo = c.id_cmv_grupo " +
                "join config_custo cc on c.id_config_custo = cc.id_config_custo " +
                "join custo cus on cus.conta_gerencial_custo = cc.cod_setor " +
                $"where cc.id_unidade = {unidade} and g.id_cmv_grupo = {idGrupo} and cus.grupo = '01' and cus.data_custo between '{diaI}' and '{diaF}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TotalCustoPorGrupos(int unidade, DateTime diaI, DateTime diaF, int idGrupo1, int idGrupo2, int idGrupo3, int idGrupo4, int idGrupo5)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(cus.quant_mov_custo* cus.valor_unitario_custo * cc.divisao_custo_setor) as custo from cmv_grupo g " +
                "join cmv_grupo_custo c on g.id_cmv_grupo = c.id_cmv_grupo " +
                "join config_custo cc on c.id_config_custo = cc.id_config_custo " +
                "join custo cus on cus.conta_gerencial_custo = cc.cod_setor " +
                $"where cc.id_unidade = {unidade} and g.id_cmv_grupo in({idGrupo1},{idGrupo2},{idGrupo3},{idGrupo4},{idGrupo5}) and cus.grupo = '01' and cus.data_custo between '{diaI}' and '{diaF}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TabelaReceitaPorGrupo(int unidade, DateTime diaI, DateTime diaF, int idGrupo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select v.data_venda, sum(v.quant_total_venda) as venda_sem_cortesias, sum(v.quant_total_venda) as venda,"+
                "sum(v.valor_total_venda) as venda from cmv_grupo g "+
                "join cmv_grupo_receita r on g.id_cmv_grupo = r.id_cmv_grupo "+
                "join venda v on v.grupo_venda = r.cod_receita "+
                $"where v.id_unidade = {unidade} and g.id_cmv_grupo = {idGrupo} and v.data_venda between '{diaI}' and '{diaF}' "+
                "group by v.data_venda order by v.data_venda; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TabelaReceitaPorGrupos(int unidade, DateTime diaI, DateTime diaF, int idGrupo1, int idGrupo2, int idGrupo3, int idGrupo4, int idGrupo5)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select v.data_venda, sum(v.quant_total_venda) as venda_sem_cortesias, sum(v.quant_total_venda) as venda," +
                "sum(v.valor_total_venda) as venda from cmv_grupo g " +
                "join cmv_grupo_receita r on g.id_cmv_grupo = r.id_cmv_grupo " +
                "join venda v on v.grupo_venda = r.cod_receita " +
                $"where v.id_unidade = {unidade} and g.id_cmv_grupo in({idGrupo1},{idGrupo2},{idGrupo3},{idGrupo4},{idGrupo5}) and v.data_venda between '{diaI}' and '{diaF}' " +
                "group by v.data_venda order by v.data_venda; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TotalReceitaPorGrupo(int unidade, DateTime diaI, DateTime diaF, int idGrupo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(v.quant_total_venda) as venda_sem_cortesias, sum(v.quant_total_venda) as venda, "+
                "sum(v.valor_total_venda) as venda from cmv_grupo g "+
                "join cmv_grupo_receita r on g.id_cmv_grupo = r.id_cmv_grupo join venda v on v.grupo_venda = r.cod_receita "+
                $"where v.id_unidade = {unidade} and g.id_cmv_grupo = {idGrupo} and v.data_venda between '{diaI}' and '{diaF}'; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable TotalReceitaPorGrupos(int unidade, DateTime diaI, DateTime diaF, int idGrupo1, int idGrupo2, int idGrupo3, int idGrupo4, int idGrupo5)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select sum(v.quant_total_venda) as venda_sem_cortesias, sum(v.quant_total_venda) as venda, " +
                "sum(v.valor_total_venda) as venda from cmv_grupo g " +
                "join cmv_grupo_receita r on g.id_cmv_grupo = r.id_cmv_grupo join venda v on v.grupo_venda = r.cod_receita " +
                $"where v.id_unidade = {unidade} and g.id_cmv_grupo in({idGrupo1},{idGrupo2},{idGrupo3},{idGrupo4},{idGrupo5}) and v.data_venda between '{diaI}' and '{diaF}'; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }


        public DataTable MetaPorGrupo(int idGrupo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select cmv_grupo_meta_valor, cmv_grupo_meta_percentual from cmv_grupo where id_cmv_grupo = {idGrupo}; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }
        
    }
        
    //Materiais

    public class DALFornecedores
    {
        private DALConexao conexao;

        public DALFornecedores(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOFornecedor modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into fornecedor(fantasia_fornecedor, razao_fornecedor," +
                "fone1_fornecedor, fone2_fornecedor, email1_fornecedor, email2_fornecedor," +
                "endereco_logradouro_fornecedor, endereco_numero_fornecedor, endereco_complemento_fornecedor," +
                "endereco_bairro_fornecedor, endereco_cidade_fornecedor, endereco_estado_fornecedor," +
                "endereco_cep_fornecedor, contato_fornecedor, cnpj_fornecedor) values (@fantasia, @razao," +
                "@fone1, @fone2, @email1, @email2, @endereco_logradouro, @endereco_numero, @endereco_complemento," +
                "@endereco_bairro, @endereco_cidade, @endereco_estado, @endereco_cep, @contato, @cnpj); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@fantasia", modelo.FantasiaFornecedor);
            cmd.Parameters.AddWithValue("@razao", modelo.RazaoFornecedor);
            cmd.Parameters.AddWithValue("@fone1", modelo.Fone1Fornecedor);
            cmd.Parameters.AddWithValue("@fone2", modelo.Fone2Fornecedor);
            cmd.Parameters.AddWithValue("@email1", modelo.Email1Fornecedor);
            cmd.Parameters.AddWithValue("@email2", modelo.Email2Fornecedor);
            cmd.Parameters.AddWithValue("@endereco_logradouro", modelo.EnderecoLogradouroFornecedor);
            cmd.Parameters.AddWithValue("@endereco_numero", modelo.EnderecoNumeroFornecedor);
            cmd.Parameters.AddWithValue("@endereco_complemento", modelo.EnderecoComplementoFornecedor);
            cmd.Parameters.AddWithValue("@endereco_bairro", modelo.EnderecoBairroFornecedor);
            cmd.Parameters.AddWithValue("@endereco_cidade", modelo.EnderecoCidadeFornecedor);
            cmd.Parameters.AddWithValue("@endereco_estado", modelo.EnderecoEstadoFornecedor);
            cmd.Parameters.AddWithValue("@endereco_cep", modelo.EnderecoCepFornecedor);
            cmd.Parameters.AddWithValue("@contato", modelo.ContatoFornecedor);
            cmd.Parameters.AddWithValue("@cnpj", modelo.CnpjFornecedor);

            conexao.Conectar();
            modelo.IdFornecedor = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void Alterar(DTOFornecedor modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update fornecedor set fantasia_fornecedor = (@fantasia), razao_fornecedor = (@razao)," +
                "fone1_fornecedor = (@fone1), fone2_fornecedor = (@fone2), email1_fornecedor =(@email1), email2_fornecedor = (@email2)," +
                "endereco_logradouro_fornecedor = (@endereco_logradouro), endereco_numero_fornecedor = (@endereco_numero), endereco_complemento_fornecedor = (@endereco_complemento)," +
                "endereco_bairro_fornecedor = (@endereco_bairro), endereco_cidade_fornecedor = (@endereco_cidade), endereco_estado_fornecedor = (@endereco_estado)," +
                "endereco_cep_fornecedor = (@endereco_cep), contato_fornecedor = (@contato), cnpj_fornecedor = (@cnpj) WHERE id_fornecedor = (@id);";

            cmd.Parameters.AddWithValue("@fantasia", modelo.FantasiaFornecedor);
            cmd.Parameters.AddWithValue("@razao", modelo.RazaoFornecedor);
            cmd.Parameters.AddWithValue("@fone1", modelo.Fone1Fornecedor);
            cmd.Parameters.AddWithValue("@fone2", modelo.Fone2Fornecedor);
            cmd.Parameters.AddWithValue("@email1", modelo.Email1Fornecedor);
            cmd.Parameters.AddWithValue("@email2", modelo.Email2Fornecedor);
            cmd.Parameters.AddWithValue("@endereco_logradouro", modelo.EnderecoLogradouroFornecedor);
            cmd.Parameters.AddWithValue("@endereco_numero", modelo.EnderecoNumeroFornecedor);
            cmd.Parameters.AddWithValue("@endereco_complemento", modelo.EnderecoComplementoFornecedor);
            cmd.Parameters.AddWithValue("@endereco_bairro", modelo.EnderecoBairroFornecedor);
            cmd.Parameters.AddWithValue("@endereco_cidade", modelo.EnderecoCidadeFornecedor);
            cmd.Parameters.AddWithValue("@endereco_estado", modelo.EnderecoEstadoFornecedor);
            cmd.Parameters.AddWithValue("@endereco_cep", modelo.EnderecoCepFornecedor);
            cmd.Parameters.AddWithValue("@contato", modelo.ContatoFornecedor);
            cmd.Parameters.AddWithValue("@cnpj", modelo.CnpjFornecedor);
            cmd.Parameters.AddWithValue("@id", modelo.IdFornecedor);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from fornecedor where id_fornecedor = @id;";

            cmd.Parameters.AddWithValue("@id", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable LocalizarRazao(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from fornecedor where razao_fornecedor like '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarFantasia(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from fornecedor where fantasia_fornecedor like '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarCnpj(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from fornecedor where cnpj_fornecedor like '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DTOFornecedor CarregaModeloFornecedor(int codigo)
        {
            DTOFornecedor modelo = new DTOFornecedor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from fornecedor where id_fornecedor =" + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdFornecedor = Convert.ToInt32(registro["id_fornecedor"]);
                modelo.FantasiaFornecedor = Convert.ToString(registro["fantasia_fornecedor"]);
                modelo.RazaoFornecedor = Convert.ToString(registro["razao_fornecedor"]);
                modelo.Fone1Fornecedor = Convert.ToString(registro["fone1_fornecedor"]);
                modelo.Fone2Fornecedor = Convert.ToString(registro["fone2_fornecedor"]);
                modelo.Email1Fornecedor = Convert.ToString(registro["email1_fornecedor"]);
                modelo.Email2Fornecedor = Convert.ToString(registro["email2_fornecedor"]);
                modelo.EnderecoLogradouroFornecedor = Convert.ToString(registro["endereco_logradouro_fornecedor"]);
                modelo.EnderecoNumeroFornecedor = Convert.ToString(registro["endereco_numero_fornecedor"]);
                modelo.EnderecoComplementoFornecedor = Convert.ToString(registro["endereco_complemento_fornecedor"]);
                modelo.EnderecoBairroFornecedor = Convert.ToString(registro["endereco_bairro_fornecedor"]);
                modelo.EnderecoCidadeFornecedor = Convert.ToString(registro["endereco_cidade_fornecedor"]);
                modelo.EnderecoEstadoFornecedor = Convert.ToString(registro["endereco_estado_fornecedor"]);
                modelo.EnderecoCepFornecedor = Convert.ToString(registro["endereco_cep_fornecedor"]);
                modelo.ContatoFornecedor = Convert.ToString(registro["contato_fornecedor"]);
                modelo.CnpjFornecedor = Convert.ToString(registro["cnpj_fornecedor"]);

            }
            conexao.Desconectar();
            return modelo;

        }

    }

    public class DALGrupo
    {

        private DALConexao conexao;

        public DALGrupo(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOGrupo modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into grupo (codigo_grupo, nome_grupo, desc_grupo) " +
                              "values (@cod, @nome, @desc); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@cod", modelo.CodGrupo);
            cmd.Parameters.AddWithValue("@nome", modelo.NomeGrupo);
            cmd.Parameters.AddWithValue("@desc", modelo.DescGrupo);

            conexao.Conectar();
            modelo.IdGrupo = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public void Alterar(DTOGrupo modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update grupo set codigo_grupo = (@cod), nome_grupo = (@nome), desc_grupo = (@desc) WHERE id_grupo = (@id);";

            cmd.Parameters.AddWithValue("@cod", modelo.CodGrupo);
            cmd.Parameters.AddWithValue("@nome", modelo.NomeGrupo);
            cmd.Parameters.AddWithValue("@desc", modelo.DescGrupo);
            cmd.Parameters.AddWithValue("@id", modelo.IdGrupo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from grupo where id_grupo = @id;";

            cmd.Parameters.AddWithValue("@id", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from grupo", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarGrupo()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from grupo;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarCod(int Id)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from grupo where id_grupo = " + Id, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DTOGrupo CarregaModeloGrupo(int codigo)
        {
            DTOGrupo modelo = new DTOGrupo();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from grupo where id_grupo =" + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdGrupo = Convert.ToInt32(registro["id_grupo"]);
                modelo.CodGrupo = Convert.ToString(registro["codigo_grupo"]);
                modelo.NomeGrupo = Convert.ToString(registro["nome_grupo"]);
                modelo.DescGrupo = Convert.ToString(registro["desc_grupo"]);

            }
            conexao.Desconectar();
            return modelo;

        }

        public DTOGrupo BuscaCodigo(string codigo)
        {
            DTOGrupo modelo = new DTOGrupo();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from grupo where codigo_grupo =" + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdGrupo = Convert.ToInt32(registro["id_grupo"]);
                modelo.CodGrupo = Convert.ToString(registro["codigo_grupo"]);
                modelo.NomeGrupo = Convert.ToString(registro["nome_grupo"]);
                modelo.DescGrupo = Convert.ToString(registro["desc_grupo"]);

            }
            conexao.Desconectar();
            return modelo;
        }
    }

    public class DALInventario
    {
        private DALConexao conexao;

        public DALInventario(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOInventario modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into inventario (inventario, data_criacao_inv, data_mov_inv, id_unidade, id_produto, quant_inv, " +
                "id_usuario, concluido, tipo) " +
                "values (@inventario, @criacao, @mov, @unidade, @produto, @quant, @usuario, @concluido, @tipo); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@inventario", modelo.Inventario);
            cmd.Parameters.AddWithValue("@criacao", modelo.DataCriacaoInventario);
            cmd.Parameters.AddWithValue("@mov", modelo.DataMovInventario);
            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@produto", modelo.IdProduto);
            cmd.Parameters.AddWithValue("@quant", modelo.QuantInv);
            cmd.Parameters.AddWithValue("@usuario", modelo.IdUsuario);
            cmd.Parameters.AddWithValue("@concluido", modelo.Concluido);
            cmd.Parameters.AddWithValue("@tipo", modelo.Tipo);


            conexao.Conectar();
            modelo.IdInv = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public DataTable Localizar(string busca)
        {
            DataTable tabela = new DataTable();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(busca, conexao.StringConexao);

                da.Fill(tabela);


                return tabela;
            }
            catch
            {
                return tabela;
            }
        }
        
        public void Concluir(int inv)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update inventario set concluido = 'C' WHERE inventario = (@inv);";

            cmd.Parameters.AddWithValue("@inv", inv);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }


        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from inventario where inventario = @inv;";

            cmd.Parameters.AddWithValue("@inv", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }


    }

    public class DALMixUnidade
    {
        private string busca = "";
        private DALConexao conexao;

        public DALMixUnidade(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOMixUnidade modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into mix_unidade (id_unidade, id_produto, id_setor, estoque_min_setor) " +
                              "values (@unidade, @produto, @setor, @estoque); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@produto", modelo.IdProduto);
            cmd.Parameters.AddWithValue("@setor", modelo.IdSetor);
            cmd.Parameters.AddWithValue("@estoque", modelo.EstoqueMinimo);

            conexao.Conectar();
            modelo.IdMix = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public void Alterar(DTOMixUnidade modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update mix_unidade set id_unidade = (@unidade), id_produto = (@produto), id_setor = (@setor), estoque_min_setor = (@estoque) WHERE id_mix = (@id);";

            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@produto", modelo.IdProduto);
            cmd.Parameters.AddWithValue("@setor", modelo.IdSetor);
            cmd.Parameters.AddWithValue("@estoque", modelo.EstoqueMinimo);
            cmd.Parameters.AddWithValue("@id", modelo.IdMix);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from mix_unidade where id_mix = @id;";

            cmd.Parameters.AddWithValue("@id", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable Localizar(int unidade, int setor)
        {
            DataTable tabela = new DataTable();

            busca = "SELECT m.id_mix, m.id_unidade, u.cod_unidade, u.nome_unidade, " +
                "m.id_produto, p.nome_produto, p.marca_produto, p.modelo_produto, m.id_setor, " +
                "s.nome_setor, m.estoque_min_setor from mix_unidade m inner join setor s on m.id_setor " +
                "= s.id_setor inner join unidade u on m.id_unidade = u.id_unidade inner join produto p " +
                "on m.id_produto = p.id_produto WHERE m.id_unidade = " + unidade.ToString() + " and m.id_setor = " + setor.ToString();
            SqlDataAdapter da = new SqlDataAdapter(busca, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarValor(string busca)
        {
            DataTable tabela = new DataTable();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(busca, conexao.StringConexao);

                da.Fill(tabela);


                return tabela;
            }
            catch
            {
                return tabela;
            }
        }

        public DTOMixUnidade CarregaModeloMixUnidade(int codigo)
        {
            DTOMixUnidade modelo = new DTOMixUnidade();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from mix_unidade where id_mix =" + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdMix = Convert.ToInt32(registro["id_mix"]);
                modelo.IdUnidade = Convert.ToInt32(registro["id_unidade"]);
                modelo.IdProduto = Convert.ToInt32(registro["id_produto"]);
                modelo.IdSetor = Convert.ToInt32(registro["id_setor"]);
                modelo.EstoqueMinimo = Convert.ToInt32(registro["estoque_min_setor"]);

            }
            conexao.Desconectar();
            return modelo;

        }

        public DTOMixUnidade BuscaCodigo(string codigo)
        {
            DTOMixUnidade modelo = new DTOMixUnidade();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from mix_unidade where id_unidade =" + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdMix = Convert.ToInt32(registro["id_mix"]);
                modelo.IdUnidade = Convert.ToInt32(registro["id_unidade"]);
                modelo.IdProduto = Convert.ToInt32(registro["id_produto"]);
                modelo.IdSetor = Convert.ToInt32(registro["id_setor"]);
                modelo.EstoqueMinimo = Convert.ToInt32(registro["estoque_min_setor"]);

            }
            conexao.Desconectar();
            return modelo;
        }

    }

    public class DALMovimento
    {
        private DALConexao conexao;

        public DALMovimento(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOMovimento modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into movimentacao (lancamento, nf_mov, data_nf_mov, data_criacao_mov, data_mov, id_unidade, " +
                "id_produto, quant_mov, id_fornecedor, custo_unitario_mov, id_usuario, tipo_mov) " +
                "values (@lancamento, @nf, @dataNf, @dataCriacao, @dataMov, @unidade, @produto, @quant, @fornecedor, @custo, @usuario, " +
                "@tipo); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@lancamento", modelo.Lancamento);
            cmd.Parameters.AddWithValue("@nf", modelo.NfMov);
            cmd.Parameters.AddWithValue("@dataNf", modelo.DataNfMov);
            cmd.Parameters.AddWithValue("@dataCriacao", modelo.DataCriacaoMov);
            cmd.Parameters.AddWithValue("@dataMov", modelo.DataMov);
            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@produto", modelo.IdProduto);
            cmd.Parameters.AddWithValue("@quant", modelo.QuantMov);
            cmd.Parameters.AddWithValue("@fornecedor", modelo.IdFornecedor);
            cmd.Parameters.AddWithValue("@custo", modelo.CustoUnitMov);
            cmd.Parameters.AddWithValue("@usuario", modelo.IdUsuario);
            cmd.Parameters.AddWithValue("@tipo", modelo.TipoMov);

            conexao.Conectar();
            modelo.IdMov = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public void Alterar(DTOMovimento modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update movimentacao set lancamento = (@lancamento), nf_mov = (@nf), data_nf_mov = (@dataNf), data_criacao_mov = (@dataCriacao), " +
                "data_mov = (@dataMov), id_unidade = (@unidade), id_produto = (@produto), quant_mov = (@quant), id_fornecedor = (@fornecedor), " +
                "custo_unitario_mov = (@custo), id_usuario = (@usuario), tipo_mov = (@tipo) WHERE id_mov = (@id);";

            cmd.Parameters.AddWithValue("@lancamento", modelo.Lancamento);
            cmd.Parameters.AddWithValue("@nf", modelo.NfMov);
            cmd.Parameters.AddWithValue("@dataNf", modelo.DataNfMov);
            cmd.Parameters.AddWithValue("@dataCriacao", modelo.DataCriacaoMov);
            cmd.Parameters.AddWithValue("@dataMov", modelo.DataMov);
            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@produto", modelo.IdProduto);
            cmd.Parameters.AddWithValue("@quant", modelo.QuantMov);
            cmd.Parameters.AddWithValue("@fornecedor", modelo.IdFornecedor);
            cmd.Parameters.AddWithValue("@custo", modelo.CustoUnitMov);
            cmd.Parameters.AddWithValue("@usuario", modelo.IdUsuario);
            cmd.Parameters.AddWithValue("@id", modelo.IdMov);
            cmd.Parameters.AddWithValue("@tipo", modelo.TipoMov);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from movimentacao where lancamento = @lancamento;";

            cmd.Parameters.AddWithValue("@lancamento", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void ExcluirInv(int codigo, int forn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from movimentacao where nf_mov = @mov and id_fornecedor = @forn;";

            cmd.Parameters.AddWithValue("@mov", codigo);
            cmd.Parameters.AddWithValue("@forn", forn);


            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select n.cod_unidade, m.id_fornecedor, f.fantasia_fornecedor, m.nf_mov, m.data_nf_mov, m.data_mov, " +
                "m.id_produto, p.nome_produto, m.quant_mov, m.custo_unitario_mov, m.tipo_mov, m.id_usuario from movimentacao m inner join fornecedor f " +
                "on m.id_fornecedor = f.id_fornecedor inner join unidade n on m.id_unidade = n.id_unidade " +
                "inner join produto p on m.id_produto = p.id_produto where m.lancamento = " + valor, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarValor(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(valor, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarNf(int unidade, int fornecedor, int nf, DateTime emissao, DateTime entrada)
        {

            string busca1 = "select m.lancamento, max(m.nf_mov) as nf, f.fantasia_fornecedor, m.data_nf_mov, m.data_mov, " +
                "u.iniciais_usuario from movimentacao m " +
                "left join usuario u on m.id_usuario = u.id_usuario " +
                "left join fornecedor f on m.id_fornecedor = f.id_fornecedor where ";

            string busca2 = " group by m.lancamento, m.nf_mov, m.lancamento, m.data_nf_mov, m.data_mov, u.iniciais_usuario, f.fantasia_fornecedor " +
                    "order by m.nf_mov;";

            int quantFiltros = 0;

            if (unidade != 0)
            {
                busca1 = busca1 + " m.id_unidade = " + unidade;
                quantFiltros++;
            }

            if (fornecedor != 0)
            {

                if (quantFiltros > 0)
                {
                    busca1 = busca1 + " and";
                }
                busca1 = busca1 + " m.id_fornecedor = " + fornecedor;
                quantFiltros++;
            }

            if (nf != 0)
            {

                if (quantFiltros > 0)
                {
                    busca1 = busca1 + " and";
                }
                busca1 = busca1 + " m.nf_mov = " + nf;
                quantFiltros++;
            }


            if (emissao != DateTime.MinValue)
            {

                if (quantFiltros > 0)
                {
                    busca1 = busca1 + " and";
                }
                busca1 = busca1 + " m.data_nf_mov = " + emissao;
                quantFiltros++;
            }

            if (entrada != DateTime.MinValue)
            {

                if (quantFiltros > 0)
                {
                    busca1 = busca1 + " and";
                }
                busca1 = busca1 + " m.data_mov = " + entrada;
                quantFiltros++;
            }


            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(busca1 + busca2, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarInventario(int unidade)
        {
            DataTable tabela = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select p.cod_produto, p.nome_produto, p.marca_produto, p.modelo_produto, " +
                "sum(m.estoque_min_setor) as estoque_min from mix_unidade m " +
                "inner join produto p on m.id_produto = p.id_produto " +
                "where id_unidade =" + unidade +
                "group by p.cod_produto, p.nome_produto, p.marca_produto, p.modelo_produto;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DTOMovimento ConsultaNf(int nf, int forn)
        {

            DTOMovimento modelo = new DTOMovimento();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "select id_fornecedor, nf_mov from movimentacao where nf_mov = " + nf.ToString() + " and id_fornecedor = " + forn.ToString() + "group by id_fornecedor, nf_mov;";

            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();

                modelo.IdFornecedor = Convert.ToInt32(registro["id_fornecedor"]);


            }
            conexao.Desconectar();
            return modelo;

        }

        public DTOMovimento CarregaModeloMovimento(int codigo)
        {
            DTOMovimento modelo = new DTOMovimento();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from movimentacao where id_mov =" + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdMov = Convert.ToInt32(registro["id_mov"]);
                modelo.Lancamento = Convert.ToInt32(registro["lancamento"]);
                modelo.NfMov = Convert.ToInt32(registro["nf_mov"]);
                modelo.DataNfMov = Convert.ToDateTime(registro["data_nf_mov"]);
                modelo.DataCriacaoMov = Convert.ToDateTime(registro["data_criacao_mov"]);
                modelo.DataMov = Convert.ToDateTime(registro["data_mov"]);
                modelo.IdUnidade = Convert.ToInt32(registro["id_unidade"]);
                modelo.IdProduto = Convert.ToInt32(registro["id_produto"]);
                modelo.QuantMov = Convert.ToInt32(registro["quant_mov"]);
                modelo.IdFornecedor = Convert.ToInt32(registro["id_fornecedor"]);
                modelo.CustoUnitMov = Convert.ToDouble(registro["custo_unitario_mov"]);
                modelo.IdUsuario = Convert.ToInt32(registro["id_usuario"]);

            }
            conexao.Desconectar();
            return modelo;

        }

    }

    public class DALNfLancamento
    {


        private DALConexao conexao;

        public DALNfLancamento(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTONfLancamento modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into nf_lancamento (nf, lancamento) values (@nf, @lancamento); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@nf", modelo.Nf);
            cmd.Parameters.AddWithValue("@lancamento", modelo.Lancamento);

            conexao.Conectar();
            modelo.IdNfLancamento = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public void Alterar(DTONfLancamento modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update nf_lancamento set nf = (@nf), lancamento = (@lancamento) WHERE id_nf_lancamento = (@id);";

            cmd.Parameters.AddWithValue("@nf", modelo.Nf);
            cmd.Parameters.AddWithValue("@lancamento", modelo.Lancamento);
            cmd.Parameters.AddWithValue("@id", modelo.IdNfLancamento);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int nf, int lancamento)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from nf_lancamento where nf = @nf and lancamento = @lancamento;";

            cmd.Parameters.AddWithValue("@nf", nf);
            cmd.Parameters.AddWithValue("@lancamento", lancamento);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable Localizar(int nf)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from nf_lancamento where nf = " + nf, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DTONfLancamento CarregaModeloNfLancamento(int codigo)
        {
            DTONfLancamento modelo = new DTONfLancamento();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from nf_lancamento where id_nf_lancamento =" + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdNfLancamento = Convert.ToInt32(registro["id_nf_lancamento"]);
                modelo.Nf = Convert.ToInt32(registro["nf"]);
                modelo.Lancamento = Convert.ToInt32(registro["lancamento"]);

            }
            conexao.Desconectar();
            return modelo;

        }
    }

    public class DALProduto
    {
        private DALConexao conexao;
        public DALProduto(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOProduto modelo, string foto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into produto (nome_produto, cod_produto, id_grupo, marca_produto, modelo_produto, desc_produto, " +
                "ativo_produto, data_criacao_produto, id_usuario) values (@nome, @codigo, @grupo, @marca, @modelo, @desc, @ativo, @data, @usuario); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@nome", modelo.NomeProduto);
            cmd.Parameters.AddWithValue("@codigo", modelo.CodProduto);
            cmd.Parameters.AddWithValue("@grupo", modelo.GrupoProduto);
            cmd.Parameters.AddWithValue("@marca", modelo.MarcaProduto);
            cmd.Parameters.AddWithValue("@modelo", modelo.ModelodoProduto);
            cmd.Parameters.AddWithValue("@desc", modelo.DescProduto);
            cmd.Parameters.AddWithValue("@data", modelo.DataCriacaoProduto);
            cmd.Parameters.AddWithValue("@usuario", modelo.UsuarioCriacaoProduto);

            if (modelo.AtivoProduto == true)
            {
                cmd.Parameters.AddWithValue("@ativo", "1");
            }
            else
            {
                cmd.Parameters.AddWithValue("@ativo", "0");
            }

            conexao.Conectar();
            modelo.IdProduto = Convert.ToInt32(cmd.ExecuteScalar());
            DTOCaminhos mc = new DTOCaminhos();

            if (foto != "")
            {
                if (foto == "del")
                {
                    if (File.Exists(mc.Produtos + modelo.IdProduto.ToString() + ".jpg"))
                    {
                        File.Delete(mc.Produtos + modelo.IdProduto.ToString() + ".jpg");
                    }
                }
                else
                {
                    try
                    {
                        var path = Path.Combine(mc.Produtos, Path.GetFileName(foto));

                        if (!Directory.Exists(mc.Produtos))

                        {
                            Directory.CreateDirectory(mc.Produtos);

                            File.Copy(foto, mc.Produtos + modelo.IdProduto.ToString() + Path.GetExtension(foto));
                        }
                        else
                        {
                            if (File.Exists(mc.Produtos + modelo.IdProduto.ToString() + Path.GetExtension(foto)))
                            {
                                File.Delete(mc.Produtos + modelo.IdProduto.ToString() + Path.GetExtension(foto));
                            }

                            File.Copy(foto, mc.Produtos + modelo.IdProduto.ToString() + Path.GetExtension(foto));
                        }
                    }
                    catch { }

                }

            }



            conexao.Desconectar();

        }

        public void Alterar(DTOProduto modelo, string foto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update produto set nome_produto = (@nome), cod_produto = (@codigo), id_grupo = (@grupo), " +
            "marca_produto = (@marca), modelo_produto = (@modelo), desc_produto = (@desc), ativo_produto = (@ativo), " +
            "data_criacao_produto = (@data), id_usuario = (@usuario) WHERE id_produto = (@id);";

            cmd.Parameters.AddWithValue("@nome", modelo.NomeProduto);
            cmd.Parameters.AddWithValue("@codigo", modelo.CodProduto);
            cmd.Parameters.AddWithValue("@grupo", modelo.GrupoProduto);
            cmd.Parameters.AddWithValue("@marca", modelo.MarcaProduto);
            cmd.Parameters.AddWithValue("@modelo", modelo.ModelodoProduto);
            cmd.Parameters.AddWithValue("@desc", modelo.DescProduto);
            cmd.Parameters.AddWithValue("@data", modelo.DataCriacaoProduto);
            cmd.Parameters.AddWithValue("@usuario", modelo.UsuarioCriacaoProduto);

            if (modelo.AtivoProduto == true)
            {
                cmd.Parameters.AddWithValue("@ativo", "1");
            }
            else
            {
                cmd.Parameters.AddWithValue("@ativo", "0");
            }

            cmd.Parameters.AddWithValue("@id", modelo.IdProduto);

            conexao.Conectar();
            cmd.ExecuteNonQuery();

            if (foto != "")
            {
                DTOCaminhos mc = new DTOCaminhos();
                if (foto == "del")
                {
                    if (File.Exists(mc.Produtos + modelo.IdProduto.ToString() + ".jpg"))
                    {
                        File.Delete(mc.Produtos + modelo.IdProduto.ToString() + ".jpg");
                    }
                }
                else
                {
                    try
                    {

                        var path = Path.Combine(mc.Produtos, Path.GetFileName(foto));

                        if (!Directory.Exists(mc.Produtos))

                        {
                            Directory.CreateDirectory(mc.Produtos);

                            File.Copy(foto, mc.Produtos + modelo.IdProduto.ToString() + Path.GetExtension(foto));


                        }
                        else
                        {
                            if (File.Exists(mc.Produtos + modelo.IdProduto.ToString() + Path.GetExtension(foto)))
                            {
                                File.Delete(mc.Produtos + modelo.IdProduto.ToString() + Path.GetExtension(foto));
                            }


                            File.Copy(foto, mc.Produtos + modelo.IdProduto.ToString() + Path.GetExtension(foto));

                        }
                    }

                    catch { }
                }


            }

            conexao.Desconectar();

        }

        public void Excluir(int codigo)
        {
            DTOCaminhos mc = new DTOCaminhos();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from produto where id_produto = @id;";

            cmd.Parameters.AddWithValue("@id", codigo);

            if (File.Exists(mc.Produtos + codigo.ToString() + ".jpg"))
            {
                File.Delete(mc.Produtos + codigo.ToString() + ".jpg");
            }

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable LocalizarCod(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from produto where cod_produto = '" + valor + "'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarGeraCod(string CodGrupo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select p.nome_produto, g.codigo_grupo, p.cod_produto from produto p inner join grupo g on p.id_grupo = g.id_grupo where g.codigo_grupo = " + CodGrupo + " order by p.cod_produto;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarGrupo(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from produto where id_grupo like '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable LocalizarNome(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from produto where nome_produto like '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DataTable ConsultaProduto(String consulta)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DTOProduto CarregaModeloProduto(int codigo)
        {
            DTOProduto modelo = new DTOProduto();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from produto where id_produto =" + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdProduto = Convert.ToInt32(registro["id_produto"]);
                modelo.NomeProduto = Convert.ToString(registro["nome_produto"]);
                modelo.CodProduto = Convert.ToString(registro["cod_produto"]);
                modelo.GrupoProduto = Convert.ToInt32(registro["id_grupo"]);
                modelo.MarcaProduto = Convert.ToString(registro["marca_produto"]);
                modelo.ModelodoProduto = Convert.ToString(registro["modelo_produto"]);
                modelo.DescProduto = Convert.ToString(registro["desc_produto"]);
                modelo.DataCriacaoProduto = Convert.ToDateTime(registro["data_criacao_produto"]);
                modelo.UsuarioCriacaoProduto = Convert.ToInt32(registro["id_usuario"]);




                if (Convert.ToInt32(registro["ativo_produto"]) > 0)
                {
                    modelo.AtivoProduto = true;
                }
                else
                {
                    modelo.AtivoProduto = false;
                }


            }
            conexao.Desconectar();
            return modelo;

        }

    }

    public class DALSetor
    {

        private DALConexao conexao;

        public DALSetor(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOSetor modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into setor (nome_setor, id_unidade) " +
                              "values (@nome, @unidade); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@nome", modelo.NomeSetor);
            cmd.Parameters.AddWithValue("@unidade", modelo.IdUnidade);


            conexao.Conectar();
            modelo.IdSetor = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();

        }

        public void Alterar(DTOSetor modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update setor set nome_setor = (@nome), id_unidade = (@unidade) WHERE id_setor = (@id);";

            cmd.Parameters.AddWithValue("@nome", modelo.NomeSetor);
            cmd.Parameters.AddWithValue("@uniade", modelo.IdUnidade);
            cmd.Parameters.AddWithValue("@id", modelo.IdSetor);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from setor where id_setor = @id;";

            cmd.Parameters.AddWithValue("@id", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable Localizar(String consulta)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexao.StringConexao);
            da.Fill(tabela);
            return tabela;

        }

        public DTOSetor CarregaModeloSetor(int codigo)
        {
            DTOSetor modelo = new DTOSetor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from setor where id_setor =" + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdSetor = Convert.ToInt32(registro["id_setor"]);
                modelo.NomeSetor = Convert.ToString(registro["nome_setor"]);
                modelo.IdUnidade = Convert.ToInt32(registro["id_unidade"]);


            }
            conexao.Desconectar();
            return modelo;

        }


    }

    //Fichas Técnicas

    public class DALPratos
    {
        private DALConexao conexao;

        public DALPratos(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOPratos modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into prato(nome_prato, id_setor, cat, subcat, rendimento_prato, modo_preparo_prato, peso_prato, desc_prato, id_usuario, cod_prato) values " +
                "(@nome, @setor, @cat, @subcat, @rendimento, @preparo, @peso, @desc, @usuario, @cod); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@nome", modelo.NomePrato);
            cmd.Parameters.AddWithValue("@setor", modelo.IdSetor);
            cmd.Parameters.AddWithValue("@cat", modelo.Cat);
            cmd.Parameters.AddWithValue("@subcat", modelo.SubCat);
            cmd.Parameters.AddWithValue("@rendimento", modelo.RendimentoPrato);
            cmd.Parameters.AddWithValue("@preparo", modelo.ModoPreparoPrato);
            cmd.Parameters.AddWithValue("@peso", modelo.PesoPrato);
            cmd.Parameters.AddWithValue("@usuario", modelo.IdUsuario);
            cmd.Parameters.AddWithValue("@desc", modelo.DescPrato);
            cmd.Parameters.AddWithValue("@cod", modelo.CodPrato);

            conexao.Conectar();
            modelo.IdPrato = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void AddModPreparo(DTOPratos modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update prato set modo_preparo_prato = (@preparo), desc_prato = (@desc) WHERE id_prato = (@id);";
           
            cmd.Parameters.AddWithValue("@preparo", modelo.ModoPreparoPrato);
            cmd.Parameters.AddWithValue("@desc", modelo.DescPrato);
            cmd.Parameters.AddWithValue("@id", modelo.IdPrato);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Alterar(DTOPratos modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update prato set nome_prato = (@nome), id_setor = (@setor)," +
                "cat = (@cat), subcat = (@subcat), rendimento_prato =(@rendimento), modo_preparo_prato = (@preparo)," +
                "peso_prato = (@peso), desc_prato = (@desc), id_usuario = (@usuario) WHERE cod_prato = (@cod);";

            cmd.Parameters.AddWithValue("@nome", modelo.NomePrato);
            cmd.Parameters.AddWithValue("@setor", modelo.IdSetor);
            cmd.Parameters.AddWithValue("@cat", modelo.Cat);
            cmd.Parameters.AddWithValue("@subcat", modelo.SubCat);
            cmd.Parameters.AddWithValue("@rendimento", modelo.RendimentoPrato);
            cmd.Parameters.AddWithValue("@preparo", modelo.ModoPreparoPrato);
            cmd.Parameters.AddWithValue("@peso", modelo.PesoPrato);
            cmd.Parameters.AddWithValue("@desc", modelo.DescPrato);
            cmd.Parameters.AddWithValue("@usuario", modelo.IdUsuario);
            cmd.Parameters.AddWithValue("@cod", modelo.CodPrato);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(string codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from prato where cod_prato = @cod;";

            cmd.Parameters.AddWithValue("@cod", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable LocalizarNome(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select cod_prato from prato where nome_prato = '{valor}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable LocalizarNome2(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_prato, nome_prato, id_setor, cat, subcat, rendimento_prato, modo_preparo_prato, peso_prato from prato where nome_prato like '%{valor}%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable LocalizarPorCod(String cod)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_prato, nome_prato, id_setor, cat, subcat, rendimento_prato, modo_preparo_prato, peso_prato, desc_prato, id_usuario from prato where cod_prato = '{cod}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListaCodigos()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select cod_prato from prato;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable BuscaFichas(string busca)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"{busca};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListarIngredientes(string codigo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select cod_item, quant_ingrediente from ingredientes where cod_prato = '{codigo}';", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable CustoIngrediente(string codigo, int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select top 1 valor_unitario_custo from custo where id_unidade = {unidade} and cod_item_custo = '{codigo}' order by movimento_custo desc;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

    }

    public class DALIngredientes
    {
        private DALConexao conexao;

        public DALIngredientes(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOIngredientes modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into ingredientes(cod_item, cod_prato, quant_ingrediente) values " +
                "(@item, @prato, @quant); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@item", modelo.CodItem);
            cmd.Parameters.AddWithValue("@prato", modelo.CodPrato);
            cmd.Parameters.AddWithValue("@quant", modelo.QuantIngrediente);
            

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Alterar(DTOIngredientes modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update ingredientes set cod_item = (@item), cod_prato = (@prato)," +
                "quant_ingrediente = (@quant) WHERE id_ingrediente = (@id);";

            cmd.Parameters.AddWithValue("@item", modelo.CodItem);
            cmd.Parameters.AddWithValue("@prato", modelo.CodPrato);
            cmd.Parameters.AddWithValue("@quant", modelo.QuantIngrediente);
            cmd.Parameters.AddWithValue("@id", modelo.IdIngrediente);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void ExcluirPorPrato(string codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from ingredientes where cod_prato = @id;";

            cmd.Parameters.AddWithValue("@id", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from ingredientes where id_ingrediente = @id;";

            cmd.Parameters.AddWithValue("@id", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable CustoItem01(string cod, int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT TOP 1 id_custo, valor_unitario_custo FROM custo where cod_item_custo = '{cod}' "+
                $"and id_unidade = {unidade} and grupo = '01' ORDER BY id_custo DESC; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable CustoItemGeral(string cod, int unidade)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT TOP 1 id_custo, valor_unitario_custo FROM custo where cod_item_custo = '{cod}' " +
                $"and id_unidade = {unidade} ORDER BY id_custo DESC; ", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }


    }

    public class DALBuffet
    {
        private DALConexao conexao;

        public DALBuffet(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOBuffet modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into buffet(nome_buffet, desc_buffet) values " +
                "(@nome, @desc); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@nome", modelo.NomeBuffet);
            cmd.Parameters.AddWithValue("@desc", modelo.DescBuffet);

            conexao.Conectar();
            modelo.IdBuffet = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void Alterar(DTOBuffet modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update buffet set nome_bffet = (@nome), desc_buffet = (@desc) WHERE id_bufet = (@id);";

            cmd.Parameters.AddWithValue("@nome", modelo.NomeBuffet);
            cmd.Parameters.AddWithValue("@desc", modelo.DescBuffet);
            cmd.Parameters.AddWithValue("@id", modelo.IdBuffet);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from buffet where id_buffet = @id;";

            cmd.Parameters.AddWithValue("@id", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable Listar()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_buffet, nome_buffet, desc_buffet from buffet;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable LocalizarPorId(int id)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select nome_buffet, desc_buffet from buffet where id_buffet = {id};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }



    }

    public class DALCategoria
    {
        private DALConexao conexao;

        public DALCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOCategoria modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into categoria(nome_cat, desc_cat) values (@nome, @desc); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@nome", modelo.NomeCat);
            cmd.Parameters.AddWithValue("@desc", modelo.DescCat);

            conexao.Conectar();
            modelo.IdCat = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void Alterar(DTOCategoria modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update categoria set nome_cat = (@nome), desc_cat = (@desc) WHERE id_cat = (@id);";

            cmd.Parameters.AddWithValue("@nome", modelo.NomeCat);
            cmd.Parameters.AddWithValue("@desc", modelo.DescCat);
            cmd.Parameters.AddWithValue("@id", modelo.IdCat);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from categoria where id_cat = @id;";

            cmd.Parameters.AddWithValue("@id", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable LocalizarPorId(int id)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select nome_cat, desc_cat from categoria where id_cat = {id};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable Listar()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_cat, nome_cat, desc_cat from categoria;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }


    }

    public class DALSubCategoria
    {
        private DALConexao conexao;

        public DALSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(DTOSubCategoria modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into subcategoria(nome_scat, desc_scat) values (@nome, @desc); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@nome", modelo.NomeSCat);
            cmd.Parameters.AddWithValue("@desc", modelo.DescSCat);

            conexao.Conectar();
            modelo.IdSCat = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void Alterar(DTOSubCategoria modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update subcategoria set nome_scat = (@nome), desc_scat = (@desc) WHERE id_scat = (@id);";

            cmd.Parameters.AddWithValue("@nome", modelo.NomeSCat);
            cmd.Parameters.AddWithValue("@desc", modelo.DescSCat);
            cmd.Parameters.AddWithValue("@id", modelo.IdSCat);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from subcategoria where id_scat = @id;";

            cmd.Parameters.AddWithValue("@id", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public DataTable LocalizarPorId(int id)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select nome_scat, desc_scat from subcategoria where id_scat = {id};", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable Listar()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select id_scat, nome_scat, desc_scat from subcategoria;", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }
    }

}
