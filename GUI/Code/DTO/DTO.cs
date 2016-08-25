using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Code.DTO
{
    #region Comuns

    public class DTOCaminhos
    {
        public static string name = System.Environment.MachineName;

        public static string Rede =
     name == "BINGO" ? "" :
     @"\\SERVIDOR\data\Suprimentos\";

        public string Pasta
        {
            get { return Rede + @"ControleDeMateriais\"; }
        }

        public string BakcupDatabase
        {
            get { return this.Pasta + @"Backup Database\"; }
        }

        public string Imagem
        {
            get { return this.Pasta + @"Imagens\"; }
        }

        public string Unidades
        {
            get { return this.Imagem + @"Unidades\"; }

        }

        public string Produtos
        {
            get { return this.Imagem + @"Produtos\"; }

        }

        public string FT
        {
            get { return this.Imagem + @"Fichas\"; }

        }

        public string Icones
        {
            get { return this.Imagem + @"Icones\"; }

        }

        public string Wallpaper
        {
            get { return this.Imagem + @"Wallpaper\"; }

        }


    }

    public class DTOUsuario
    {

        private int id_usuario;
        public int IdUsuario
        {
            get
            {
                return this.id_usuario;
            }
            set
            {
                this.id_usuario = value;
            }
        }

        private String nome_usuario;
        public String NomeUsuario
        {
            get
            {
                return this.nome_usuario;
            }
            set
            {
                this.nome_usuario = value;
            }
        }

        private String login_usuario;
        public String LoginUsuario
        {
            get
            {
                return this.login_usuario;
            }
            set
            {
                this.login_usuario = value;
            }
        }

        private String senha_usuario;
        public String SenhaUsuario
        {
            get { return this.senha_usuario; }
            set { this.senha_usuario = value; }
        }

        private String iniciais_usuario;
        public String IniciaisUsuario
        {
            get
            {
                return this.iniciais_usuario;
            }
            set
            {
                this.iniciais_usuario = value;
            }
        }

        private int id_unidade;
        public int IdUnidade
        {
            get
            {
                return this.id_unidade;
            }
            set
            {
                this.id_unidade = value;
            }
        }

        private int permissao_usuario;
        public int PermissaoUsuario
        {
            get
            {
                return this.permissao_usuario;
            }
            set
            {
                this.permissao_usuario = value;
            }

        }

        private String email_usuario;
        public String EmailUsuario
        {
            get
            {
                return this.email_usuario;
            }
            set
            {
                this.email_usuario = value;
            }
        }
    }
    
    public class DTOUnidade
    {


        private int id_unidade;
        public int IdUnidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

        private string nome_unidade;
        public string NomeUnidade
        {
            get { return this.nome_unidade; }
            set { this.nome_unidade = value; }
        }

        private string cod_unidade;
        public string CodUnidade
        {
            get { return this.cod_unidade; }
            set { this.cod_unidade = value; }
        }
        
    }

    #endregion

    #region CMV

    public class DTODados
    {

        #region Venda

        private int id_venda;

        public int IdVenda
        {
            get { return this.id_venda; }
            set { this.id_venda = value; }
        }

        private DateTime data_venda;

        public DateTime DataVenda
        {
            get { return this.data_venda; }
            set { this.data_venda = value; }
        }

        private int grupo_venda;

        public int GrupoVenda
        {
            get { return this.grupo_venda; }
            set { this.grupo_venda = value; }
        }

        private double cancelados_venda;

        public double CanceladosVenda
        {
            get { return this.cancelados_venda; }
            set { this.cancelados_venda = value; }
        }

        private double cortesias_venda;

        public double CortesiasVenda
        {
            get { return this.cortesias_venda; }
            set { this.cortesias_venda = value; }
        }

        private double promocoes_venda;

        public double PromocoesVenda
        {
            get { return this.promocoes_venda; }
            set { this.promocoes_venda = value; }
        }

        private double quant_venda;

        public double QuantVenda
        {
            get { return this.quant_venda; }
            set { this.quant_venda = value; }
        }

        private double quant_total_venda;

        public double QuantTotalVenda
        {
            get { return this.quant_total_venda; }
            set { this.quant_total_venda = value; }
        }

        private double valor_venda;

        public double ValorVenda
        {
            get { return this.valor_venda; }
            set { this.valor_venda = value; }
        }

        private double valor_total_venda;

        public double ValorTotalVenda
        {
            get { return this.valor_total_venda; }
            set { this.valor_total_venda = value; }
        }

        private double total;

        public double Total
        {
            get { return this.total; }
            set { this.total = value; }
        }

        #endregion

        #region Pax

        private int id_pax;

        public int IdPax
        {
            get { return this.id_pax; }
            set { this.id_pax = value; }
        }

        private DateTime data_pax;

        public DateTime DataPax
        {
            get { return this.data_pax; }
            set { this.data_pax = value; }
        }

        private int turno_pax;

        public int TurnoPax
        {
            get { return this.turno_pax; }
            set { this.turno_pax = value; }
        }

        private double pax;

        public double Pax
        {
            get { return this.pax; }
            set { this.pax = value; }
        }

        private string diaturno;

        public string DiaTurno
        {
            get { return this.diaturno; }
            set { this.diaturno = value; }
        }

        #endregion

        #region Custo

        private int id_custo;

        public int IdCusto
        {
            get { return this.id_custo; }
            set { this.id_custo = value; }
        }

        private DateTime data_custo;

        public DateTime DataCusto
        {
            get { return this.data_custo; }
            set { this.data_custo = value; }
        }

        private string descricao_custo;

        public string DescricaoCusto
        {
            get { return this.descricao_custo; }
            set { this.descricao_custo = value; }
        }

        private string cod_item_custo;

        public string CodItemCusto
        {
            get { return this.cod_item_custo; }
            set { this.cod_item_custo = value; }
        }

        private string tipo_mov_custo;

        public string TipoMovCusto
        {
            get { return this.tipo_mov_custo; }
            set { this.tipo_mov_custo = value; }
        }

        private double quant_mov_custo;

        public double QuantMovCusto
        {
            get { return this.quant_mov_custo; }
            set { this.quant_mov_custo = value; }
        }

        private double valor_unitario_custo;

        public double ValorUnitarioCusto
        {
            get { return this.valor_unitario_custo; }
            set { this.valor_unitario_custo = value; }
        }

        private string tipo_operacao_custo;

        public string TipoOperacaoCusto
        {
            get { return this.tipo_operacao_custo; }
            set { this.tipo_operacao_custo = value; }
        }

        private string conta_gerencial_custo;

        public string ContaGerencialCusto
        {
            get { return this.conta_gerencial_custo; }
            set { this.conta_gerencial_custo = value; }
        }

        private string tipo_doc_custo;

        public string TipoDocCusto
        {
            get { return this.tipo_doc_custo; }
            set { this.tipo_doc_custo = value; }
        }

        private string documento_custo;

        public string DocumentoCusto
        {
            get { return this.documento_custo; }
            set { this.documento_custo = value; }
        }

        private int movimento_custo;

        public int MovimentoCusto
        {
            get { return this.movimento_custo; }
            set { this.movimento_custo = value; }
        }

        private string grupo;

        public string Grupo
        {
            get { return this.grupo; }
            set { this.grupo = value; }
        }

        #endregion

        #region Comuns

        private int id_unidade;

        public int IdUnidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

        private int id_usuario;

        public int IdUsuario
        {
            get { return this.id_usuario; }
            set { this.id_usuario = value; }
        }

        #endregion


    }

    public class DTOCmvGrupo
    {
        private int id_unidade;

        public int idUnidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

        private int id_cmv_grupo;

        public int idCmvGrupo
        {
            get { return this.id_cmv_grupo; }
            set { this.id_cmv_grupo = value; }
        }

        private string cmv_grupo_nome;

        public string cmvGrupoNome
        {
            get { return this.cmv_grupo_nome; }
            set { this.cmv_grupo_nome = value; }
        }

        private double cmv_grupo_meta_valor;

        public double cmvGrupoMetaValor
        {
            get { return this.cmv_grupo_meta_valor; }
            set { this.cmv_grupo_meta_valor = value; }
        }

        private double cmv_grupo_meta_percentual;

        public double cmvGrupoMetaPercentual
        {
            get { return this.cmv_grupo_meta_percentual; }
            set { this.cmv_grupo_meta_percentual = value; }
        }

        private int id_cmv_grupo_custo;

        public int idCmvGrupoCusto
        {
            get { return this.id_cmv_grupo_custo; }
            set { this.id_cmv_grupo_custo = value; }
        }

        private int id_config_custo;

        public int IdConfigCusto
        {
            get { return this.id_config_custo; }
            set { this.id_config_custo = value; }
        }

        private int id_cmv_grupo_receita;

        public int idCmvGrupoReceita
        {
            get { return this.id_cmv_grupo_receita; }
            set { this.id_cmv_grupo_receita = value; }
        }

        private int cod_receita;

        public int CodReceita
        {
            get { return this.cod_receita; }
            set { this.cod_receita = value; }
        }

    }

    public class DTOAeB
    {
        private int id_aeb;

        public int IdAeb
        {
            get { return this.id_aeb; }
            set { this.id_aeb = value; }
        }

        private string cod_aeb;

        public string CodAeb
        {
            get { return this.cod_aeb; }
            set { this.cod_aeb = value; }
        }

        private string nome_aeb;

        public string NomeAeb
        {
            get { return this.nome_aeb; }
            set { this.nome_aeb = value; }
        }

        private string um_aeb;

        public string UmAeb
        {
            get { return this.um_aeb; }
            set { this.um_aeb = value; }
        }

        private double fc;

        public double Fc
        {
            get { return this.fc; }
            set { this.fc = value; }
        }

    }

    public class DTOConfigCusto
    {
        private int id_config_custo;

        public int IdConfig
        {
            get { return this.id_config_custo; }
            set { this.id_config_custo = value; }
        }

        private int id_unidade;

        public int IdUnidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

        private string cod_setor;

        public string CodSetor
        {
            get { return this.cod_setor; }
            set { this.cod_setor = value; }
        }

        private string nome_setor;

        public string NomeSetor
        {
            get { return this.nome_setor; }
            set { this.nome_setor = value; }
        }

        private string turno;

        public string Turno
        {
            get { return this.turno; }
            set { this.turno = value; }
        }

        private double divisao_custo_setor;

        public double DivisaoCustoSetor
        {
            get { return this.divisao_custo_setor; }
            set { this.divisao_custo_setor = value; }
        }

        private double meta_percapta;

        public double MetaPercapta
        {
            get { return this.meta_percapta; }
            set { this.meta_percapta = value; }
        }

        private double meta_percentual;

        public double MetaPercentual
        {
            get { return this.meta_percentual; }
            set { this.meta_percentual = value; }
        }
        
    }

    public class DTOConfigReceita
    {
        private int id_unidade;

        public int IdUnidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

        private int cod_venda;

        public int CodVenda
        {
            get { return this.cod_venda; }
            set { this.cod_venda = value; }
        }

        private string nome_cod_venda;

        public string NomeCodVenda
        {
            get { return this.nome_cod_venda; }
            set { this.nome_cod_venda = value; }
        }

        private int conta_gerencial;

        public int ContaGerencial
        {
            get { return this.conta_gerencial; }
            set { this.conta_gerencial = value; }
        }

        private string tipo_cod_venda;

        public string TipoCodVenda
        {
            get { return this.tipo_cod_venda; }
            set { this.tipo_cod_venda = value; }
        }

        private string turno_cod_venda;

        public string TurnoCodVenda
        {
            get { return this.turno_cod_venda; }
            set { this.turno_cod_venda = value; }
        }
        
    }

    public class DTOConfigImposto
    {
        private int id_unidade;

        public int IdUnidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

        private double icms_a;

        public double IcmsA
        {
            get { return this.icms_a; }
            set { this.icms_a = value; }
        }

        private double icms_b;

        public double IcmsB
        {
            get { return this.icms_b; }
            set { this.icms_b = value; }
        }

        private double pis_a;

        public double PisA
        {
            get { return this.pis_a; }
            set { this.pis_a = value; }
        }

        private double pis_b;

        public double PisB
        {
            get { return this.pis_b; }
            set { this.pis_b = value; }
        }

        private double cofins_a;

        public double CofinsA
        {
            get { return this.cofins_a; }
            set { this.cofins_a = value; }
        }

        private double cofins_b;

        public double CofinsB
        {
            get { return this.cofins_b; }
            set { this.cofins_b = value; }
        }

        private double total_a;

        public double TotalA
        {
            get { return this.total_a; }
            set { this.total_a = value; }
        }

        private double total_b;

        public double TotalB
        {
            get { return this.total_b; }
            set { this.total_b = value; }
        }

    }

    public class DTOConfigPax
    {
        private string config_dia_pax;

        public string ConfigDiaPax
        {
            get { return this.config_dia_pax; }
            set { this.config_dia_pax = value; }
        }

        private int id_unidade;

        public int IdUnidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

        private bool config_dia_valor;

        public bool ConfigDiaValor
        {
            get { return this.config_dia_valor; }
            set { this.config_dia_valor = value; }
        }

    }

    public class DTOConfigUnidade
    {

        private int id_config;

        public int IdConfig
        {
            get { return this.id_config; }
            set { this.id_config = value; }
        }

        private int id_unidade;

        public int IdUnidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

        private int id_usuario;

        public int IdUsuario
        {
            get { return this.id_usuario; }
            set { this.id_usuario = value; }
        }

        private string tipo_config;

        public string TipoConfig
        {
            get { return this.tipo_config; }
            set { this.tipo_config = value; }
        }

        private string config;

        public string Config
        {
            get { return this.config; }
            set { this.config = value; }
        }


    }

    public class DTOContasGerenciais
    {
        private string cod_setor;

        public string CodSetor
        {
            get { return this.cod_setor; }
            set { this.cod_setor = value; }
        }

        private string nome_setor;

        public string NomeSetor
        {
            get { return this.nome_setor; }
            set { this.nome_setor = value; }
        }

        private string tipo_setor;

        public string TipoSetor
        {
            get { return this.tipo_setor; }
            set { this.tipo_setor = value; }
        }
    }

    public class DTOExcessoesCusto
    {
        private int id_excessao_custo;

        public int IdExcessaoCusto
        {
            get { return this.id_excessao_custo; }
            set { this.id_excessao_custo = value; }
        }

        private string tipo_operacao;

        public string TipoOperacao
        {
            get { return this.tipo_operacao; }
            set { this.tipo_operacao = value; }
        }

        private int acao;

        public int Acao
        {
            get { return this.acao; }
            set { this.acao = value; }
        }

        private string obs;

        public string Obs
        {
            get { return this.obs; }
            set { this.obs = value; }
        }
    }


    #endregion

    #region Materiais

    public class DTOFornecedor
    {
        private int id_fornecedor;

        public int IdFornecedor
        {
            get { return this.id_fornecedor; }
            set { this.id_fornecedor = value; }
        }
        private string fantasia_fornecedor;

        public String FantasiaFornecedor
        {
            get { return this.fantasia_fornecedor; }
            set { this.fantasia_fornecedor = value; }
        }

        private string razao_fornecedor;

        public String RazaoFornecedor
        {
            get { return this.razao_fornecedor; }
            set { this.razao_fornecedor = value; }
        }

        private string fone1_fornecedor;

        public String Fone1Fornecedor
        {
            get { return this.fone1_fornecedor; }
            set { this.fone1_fornecedor = value; }
        }

        private string fone2_fornecedor;

        public String Fone2Fornecedor
        {
            get { return this.fone2_fornecedor; }
            set { this.fone2_fornecedor = value; }
        }

        private string email1_fornecedor;

        public String Email1Fornecedor
        {
            get { return this.email1_fornecedor; }
            set { this.email1_fornecedor = value; }
        }

        private string email2_fornecedor;

        public String Email2Fornecedor
        {
            get { return this.email2_fornecedor; }
            set { this.email2_fornecedor = value; }
        }

        private string endereco_logradouro_fornecedor;

        public String EnderecoLogradouroFornecedor
        {
            get { return this.endereco_logradouro_fornecedor; }
            set { this.endereco_logradouro_fornecedor = value; }
        }

        private string endereco_numero_fornecedor;

        public String EnderecoNumeroFornecedor
        {
            get { return this.endereco_numero_fornecedor; }
            set { this.endereco_numero_fornecedor = value; }
        }

        private string endereco_complemento_fornecedor;

        public String EnderecoComplementoFornecedor
        {
            get { return this.endereco_complemento_fornecedor; }
            set { this.endereco_complemento_fornecedor = value; }
        }

        private string endereco_bairro_fornecedor;

        public String EnderecoBairroFornecedor
        {
            get { return this.endereco_bairro_fornecedor; }
            set { this.endereco_bairro_fornecedor = value; }
        }

        private string endereco_cidade_fornecedor;

        public String EnderecoCidadeFornecedor
        {
            get { return this.endereco_cidade_fornecedor; }
            set { this.endereco_cidade_fornecedor = value; }
        }

        private string endereco_estado_fornecedor;

        public String EnderecoEstadoFornecedor
        {
            get { return this.endereco_estado_fornecedor; }
            set { this.endereco_estado_fornecedor = value; }
        }

        private string endereco_cep_fornecedor;

        public String EnderecoCepFornecedor
        {
            get { return this.endereco_cep_fornecedor; }
            set { this.endereco_cep_fornecedor = value; }
        }

        private string contato_fornecedor;

        public String ContatoFornecedor
        {
            get { return this.contato_fornecedor; }
            set { this.contato_fornecedor = value; }
        }

        private string cnpj_fornecedor;

        public String CnpjFornecedor
        {
            get { return this.cnpj_fornecedor; }
            set { this.cnpj_fornecedor = value; }
        }


    }

    public class DTOGrupo
    {

        private int id_grupo;

        public int IdGrupo
        {
            get { return this.id_grupo; }
            set { this.id_grupo = value; }
        }

        private string codigo_grupo;

        public string CodGrupo
        {
            get { return this.codigo_grupo; }
            set { this.codigo_grupo = value; }
        }

        private string nome_grupo;

        public string NomeGrupo
        {
            get { return this.nome_grupo; }
            set { this.nome_grupo = value; }
        }

        private string desc_grupo;

        public string DescGrupo
        {
            get { return this.desc_grupo; }
            set { this.desc_grupo = value; }
        }

    }

    public class DTOInventario
    {

        private int id_inv;
        public int IdInv
        {
            get { return this.id_inv; }
            set { this.id_inv = value; }
        }


        private int inventario;
        public int Inventario
        {
            get { return this.inventario; }
            set { this.inventario = value; }
        }

        private DateTime data_criacao_inv;
        public DateTime DataCriacaoInventario
        {
            get { return this.data_criacao_inv; }
            set { this.data_criacao_inv = value; }
        }

        private DateTime data_mov_inv;
        public DateTime DataMovInventario
        {
            get { return this.data_mov_inv; }
            set { this.data_mov_inv = value; }
        }

        private int id_unidade;
        public int IdUnidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

        private int id_produto;
        public int IdProduto
        {
            get { return this.id_produto; }
            set { this.id_produto = value; }
        }

        private int quant_inv;
        public int QuantInv
        {
            get { return this.quant_inv; }
            set { this.quant_inv = value; }
        }

        private int id_usuario;
        public int IdUsuario
        {
            get { return this.id_usuario; }
            set { this.id_usuario = value; }
        }

        public string concluido;
        public string Concluido
        {
            get { return this.concluido; }
            set { this.concluido = value; }
        }

        public string tipo;
        public string Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

    }

    public class DTOLog
    {

        private int id_usuario;

        public int IdUsuario
        {
            get { return this.id_usuario; }
            set { this.id_usuario = value; }
        }

        private string cod_log;

        public string CodLog
        {
            get { return this.cod_log; }
            set { this.cod_log = value; }
        }

    }

    public class DTOMixUnidade
    {
        private int id_mix;

        public int IdMix
        {
            get { return this.id_mix; }
            set { this.id_mix = value; }
        }

        private int id_unidade = 0;

        public int IdUnidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

        private int id_produto = 0;

        public int IdProduto
        {
            get { return this.id_produto; }
            set { this.id_produto = value; }
        }

        private int id_setor = 0;

        public int IdSetor
        {
            get { return this.id_setor; }
            set { this.id_setor = value; }
        }

        private int estoque_min_setor;

        public int EstoqueMinimo
        {
            get { return this.estoque_min_setor; }
            set { this.estoque_min_setor = value; }
        }

    }

    public class DTOMovimento
    {
        private int id_mov;

        public int IdMov
        {
            get { return this.id_mov; }
            set { this.id_mov = value; }
        }

        private int lancamento;

        public int Lancamento
        {
            get { return this.lancamento; }
            set { this.lancamento = value; }
        }

        private int nf_mov;

        public int NfMov
        {
            get { return this.nf_mov; }
            set { this.nf_mov = value; }
        }

        private DateTime data_nf_mov;

        public DateTime DataNfMov
        {
            get { return this.data_nf_mov; }
            set { this.data_nf_mov = value; }
        }

        private DateTime data_criacao_mov;

        public DateTime DataCriacaoMov
        {
            get { return this.data_criacao_mov; }
            set { this.data_criacao_mov = value; }
        }

        private DateTime data_mov;

        public DateTime DataMov
        {
            get { return this.data_mov; }
            set { this.data_mov = value; }
        }

        private int id_unidade;

        public int IdUnidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

        private int id_produto;

        public int IdProduto
        {
            get { return this.id_produto; }
            set { this.id_produto = value; }
        }

        private int quant_mov;

        public int QuantMov
        {
            get { return this.quant_mov; }
            set { this.quant_mov = value; }
        }

        private int id_fornecedor;

        public int IdFornecedor
        {
            get { return this.id_fornecedor; }
            set { this.id_fornecedor = value; }
        }

        private double custo_unitario_mov;

        public double CustoUnitMov
        {
            get { return this.custo_unitario_mov; }
            set { this.custo_unitario_mov = value; }
        }

        private int id_usuario;

        public int IdUsuario
        {
            get { return this.id_usuario; }
            set { this.id_usuario = value; }
        }

        private string tipo_mov;

        public string TipoMov
        {
            get { return this.tipo_mov; }
            set { this.tipo_mov = value; }
        }


    }

    public class DTONfLancamento
    {

        private int id_nf_lancamento;

        public int IdNfLancamento
        {
            get { return this.id_nf_lancamento; }
            set { this.id_nf_lancamento = value; }
        }

        private int nf;

        public int Nf
        {
            get { return this.nf; }
            set { this.nf = value; }
        }

        private int lancamento;

        public int Lancamento
        {
            get { return this.lancamento; }
            set { this.lancamento = value; }
        }

    }

    public class DTOProduto
    {

        private int id_produto;

        public int IdProduto
        {
            get { return this.id_produto; }
            set { this.id_produto = value; }
        }
        private string nome_produto;

        public String NomeProduto
        {
            get { return this.nome_produto; }
            set { this.nome_produto = value; }
        }

        private string um_produto;

        public String UmProduto
        {
            get { return this.um_produto; }
            set { this.um_produto = value; }
        }

        private string cod_produto;

        public String CodProduto
        {
            get { return this.cod_produto; }
            set { this.cod_produto = value; }
        }

        private int id_grupo;

        public int GrupoProduto
        {
            get { return this.id_grupo; }
            set { this.id_grupo = value; }
        }

        private string marca_produto;

        public String MarcaProduto
        {
            get { return this.marca_produto; }
            set { this.marca_produto = value; }
        }

        private string modelo_produto;

        public String ModelodoProduto
        {
            get { return this.modelo_produto; }
            set { this.modelo_produto = value; }
        }

        private string desc_produto;

        public String DescProduto
        {
            get { return this.desc_produto; }
            set { this.desc_produto = value; }
        }

        private bool ativo_produto;

        public bool AtivoProduto
        {
            get { return this.ativo_produto; }
            set { this.ativo_produto = value; }
        }

        private DateTime data_criacao_produto;

        public DateTime DataCriacaoProduto
        {
            get { return this.data_criacao_produto; }
            set { this.data_criacao_produto = value; }
        }


        private int id_iusuario;

        public int UsuarioCriacaoProduto
        {
            get { return this.id_iusuario; }
            set { this.id_iusuario = value; }
        }

    }

    public class DTOSetor
    {


        private int id_setor;

        public int IdSetor
        {
            get { return this.id_setor; }
            set { this.id_setor = value; }
        }

        private string nome_setor;

        public string NomeSetor
        {
            get { return this.nome_setor; }
            set { this.nome_setor = value; }
        }

        private int id_unidade;

        public int IdUnidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

    }

    #endregion
    
    #region Fichas técnicas

    public class DTOPratos
    {
        private int id_prato;

        public int IdPrato
        {
            get { return this.id_prato; }
            set { this.id_prato = value; }
        }

        private string nome_prato;

        public string NomePrato
        {
            get { return this.nome_prato; }
            set { this.nome_prato = value; }
        }

        private int id_setor;

        public int IdSetor
        {
            get { return this.id_setor; }
            set { this.id_setor = value; }
        }

        private int cat;

        public int Cat
        {
            get { return this.cat; }
            set { this.cat = value; }
        }

        private int subcat;

        public int SubCat
        {
            get { return this.subcat; }
            set { this.subcat = value; }
        }

        private double rendimento_prato;

        public double RendimentoPrato
        {
            get { return this.rendimento_prato; }
            set { this.rendimento_prato = value; }
        }

        private string modo_preparo_prato;

        public string ModoPreparoPrato
        {
            get { return this.modo_preparo_prato; }
            set { this.modo_preparo_prato = value; }
        }

        private string desc_prato;

        public string DescPrato
        {
            get { return this.desc_prato; }
            set { this.desc_prato = value; }
        }

        private double peso_prato;

        public double PesoPrato
        {
            get { return this.peso_prato; }
            set { this.peso_prato = value; }
        }

        private int id_usuario;

        public int IdUsuario
        {
            get { return this.id_usuario; }
            set { this.id_usuario = value; }
        }

        private string cod_prato;

        public string CodPrato
        {
            get { return this.cod_prato; }
            set { this.cod_prato = value; }
        }


    }

    public class DTOIngredientes
    {
        private int id_ingrediente;

        public int IdIngrediente
        {
            get { return this.id_ingrediente; }
            set { this.id_ingrediente = value; }
        }

        private string cod_item;

        public string CodItem
        {
            get { return this.cod_item; }
            set { this.cod_item = value; }
        }

        private string cod_prato;

        public string CodPrato
        {
            get { return this.cod_prato; }
            set { this.cod_prato = value; }
        }

        private double quant_ingrediente;

        public double QuantIngrediente
        {
            get { return this.quant_ingrediente; }
            set { this.quant_ingrediente = value; }
        }
    }

    public class DTOBuffet
    {
        private int id_buffet;

        public int IdBuffet
        {
            get { return this.id_buffet; }
            set { this.id_buffet = value; }
        }

        private string nome_buffet;

        public string NomeBuffet
        {
            get { return this.nome_buffet; }
            set { this.nome_buffet = value; }
        }

        private string desc_buffet;

        public string DescBuffet
        {
            get { return this.desc_buffet; }
            set { this.desc_buffet = value; }
        }

    }

    public class DTOCategoria
    {
        private int id_cat;

        public int IdCat
        {
            get { return this.id_cat; }
            set { this.id_cat = value; }
        }

        private string nome_cat;

        public string NomeCat
        {
            get { return this.nome_cat; }
            set { this.nome_cat = value; }
        }

        private string desc_cat;

        public string DescCat
        {
            get { return this.desc_cat; }
            set { this.desc_cat = value; }
        }

    }

    public class DTOSubCategoria
    {
        private int id_scat;

        public int IdSCat
        {
            get { return this.id_scat; }
            set { this.id_scat = value; }
        }

        private string nome_scat;

        public string NomeSCat
        {
            get { return this.nome_scat; }
            set { this.nome_scat = value; }
        }

        private string desc_scat;

        public string DescSCat
        {
            get { return this.desc_scat; }
            set { this.desc_scat = value; }
        }

    }
    
    #endregion


}

