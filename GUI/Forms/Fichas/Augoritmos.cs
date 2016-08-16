using GUI.Code.BLL;
using GUI.Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Forms.Fichas
{
    class Augoritmos
    {
        public double CustoIngrediente(string codigo, int unidade)
        {
            double CustoTotal = 0;

            //Se for Prato
            if (codigo.Substring(0, 2) == "20")
            {
                CustoTotal += CalculaCustoFicha(codigo, unidade);
            }

            //Se for ingrediente
            else
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLIngredientes blli = new BLLIngredientes(cx);
                DataTable tabela = blli.Custo01(codigo, unidade);
                CustoTotal += Convert.ToDouble(tabela.Rows[0][1]);
            }


            return CustoTotal;
        }

        public double CalculaCustoFicha(string codigo, int unidade)
        {
            double CustoTotal = 0;
            string codItem = "";
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bll = new BLLPratos(cx);

            DataTable tabela = new DataTable();
            DataTable Tabela2 = new DataTable();

            tabela = bll.ListarIngredientes(codigo);

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                codItem = tabela.Rows[i][0].ToString();

                //Se for Prato
                if(codItem.Substring(0,2) == "20")
                {
                    CustoTotal += CalculaCustoFicha2(codItem, unidade);
                }

                //Se for ingrediente
                else
                {
                Tabela2 = bll.CustoIngrediente(codItem, unidade);
                CustoTotal += Convert.ToDouble(Tabela2.Rows[0][0]) * Convert.ToDouble(tabela.Rows[i][1]);
                }

            }

            return CustoTotal;
        }

        private Double CalculaCustoFicha2(string codigo, int unidade)
        {
            double CustoTotal2 = 0;
            string codItem = "";
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bll = new BLLPratos(cx);

            DataTable tabela = new DataTable();
            DataTable Tabela2 = new DataTable();

            tabela = bll.ListarIngredientes(codigo);

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                codItem = tabela.Rows[i][0].ToString();

                //Se for Prato
                if (codItem.Substring(0, 2) == "20")
                {
                    CustoTotal2 += CalculaCustoFicha3(codItem, unidade);
                }

                //Se for ingrediente
                else
                {
                    Tabela2 = bll.CustoIngrediente(codItem, unidade);
                    CustoTotal2 += Convert.ToDouble(Tabela2.Rows[0][0]) * Convert.ToDouble(tabela.Rows[i][1]);
                }

            }

            return CustoTotal2;
        }

        private Double CalculaCustoFicha3(string codigo, int unidade)
        {
            double CustoTotal3 = 0;
            string codItem = "";
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bll = new BLLPratos(cx);

            DataTable tabela = new DataTable();
            DataTable Tabela2 = new DataTable();

            tabela = bll.ListarIngredientes(codigo);

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                codItem = tabela.Rows[i][0].ToString();

                //Se for Prato
                if (codItem.Substring(0, 2) == "20")
                {
                    CustoTotal3 += CalculaCustoFicha3(codItem, unidade);
                }

                //Se for ingrediente
                else
                {
                    Tabela2 = bll.CustoIngrediente(codItem, unidade);
                    CustoTotal3 += Convert.ToDouble(Tabela2.Rows[0][0]) * Convert.ToDouble(tabela.Rows[i][1]);
                }

            }

            return CustoTotal3;
        }

        public void ExcluirPrato(string cod)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

            // Exclui prato
            BLLPratos bllp = new BLLPratos(cx);
            try
            {
                bllp.Excluir(cod);
            }
            catch
            {
                throw new Exception("Erro ao excluir Prato!");
            }

            //Exclui ingredientes referentes ao prato
            BLLIngredientes blli = new BLLIngredientes(cx);
            try
            {

                blli.ExcluirPorPrato(cod);
            }
            catch
            {
                throw new Exception("Erro ao excluir Ingrediente!");
            }

            //excluir prato da tabela AEB
            BLLAeB bllaeb = new BLLAeB(cx);

            try
            {
                bllaeb.ExcluirPorCod(cod);
            }
            catch
            {
                throw new Exception("Erro ao excluir Aeb!");
            }

            //Exclui imagem referente ao prato (se houver)


        }


    }



}
