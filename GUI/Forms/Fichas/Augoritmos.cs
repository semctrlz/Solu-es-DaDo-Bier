using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Forms.Fichas
{
    class Augoritmos
    {
        public double CustoIngrediente(string codigo, int unidade)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bll = new BLLPratos(cx);
            DataTable tabela = new DataTable();
            DataTable tabela2 = new DataTable();
            

            double CustoTotal = 0;

            //Se for Prato
            if (codigo.Substring(0, 2) == "20")
            {
                tabela2 = bll.LocalizarPorCod(codigo);
                try
                {
                    CustoTotal += CalculaCustoFicha(codigo, unidade) / Convert.ToDouble(tabela2.Rows[0][7]); ;
                }
                catch
                {
                    CustoTotal += 0;
                }
            }

            //Se for ingrediente
            else
            {

                CustoTotal += UltimaBaixaItem(codigo, unidade);

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
            DataTable tabela3 = new DataTable();
             
            tabela = bll.ListarIngredientes(codigo);

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                codItem = tabela.Rows[i][0].ToString();

                //Se for Prato
                if(codItem.Substring(0,2) == "20")
                {
                    tabela3 = bll.LocalizarPorCod(codItem);
                    try
                    {
                        CustoTotal += ((CalculaCustoFicha2(codItem, unidade) / Convert.ToDouble(tabela3.Rows[0][7])) * Convert.ToDouble(tabela.Rows[i][1].ToString()));
                    }
                    catch
                    {
                        CustoTotal += 0;
                    }
                    
                }

                //Se for ingrediente
                else
                {
                    CustoTotal += (UltimaBaixaItem(codItem, unidade) * Convert.ToDouble(tabela.Rows[i][1].ToString()));

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
            DataTable tabela3 = new DataTable();

            tabela = bll.ListarIngredientes(codigo);

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                codItem = tabela.Rows[i][0].ToString();

                //Se for Prato
                if (codItem.Substring(0, 2) == "20")
                {
                    tabela3 = bll.LocalizarPorCod(codItem);
                    try
                    {
                        CustoTotal2 += ((CalculaCustoFicha3(codItem, unidade) / Convert.ToDouble(tabela3.Rows[0][7])) * Convert.ToDouble(tabela.Rows[i][1].ToString()));
                    }
                    catch
                    {
                        CustoTotal2 += 0;
                    }
                }

                //Se for ingrediente
                else
                {
                    CustoTotal2 += (UltimaBaixaItem(codItem, unidade) * Convert.ToDouble(tabela.Rows[i][1].ToString()));


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
            DataTable tabela3 = new DataTable();

            tabela = bll.ListarIngredientes(codigo);

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                codItem = tabela.Rows[i][0].ToString();

                //Se for Prato
                if (codItem.Substring(0, 2) == "20")
                {
                    CustoTotal3 += 0;
                }

                //Se for ingrediente
                else
                {
                    CustoTotal3 += (UltimaBaixaItem(codItem, unidade) * Convert.ToDouble(tabela.Rows[i][1].ToString()));

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
            IncluiFoto(cod, "del");

        }

        public void IncluiFoto(String cod, string foto)
        {
            DTOCaminhos mc = new DTOCaminhos();

            if (foto != "")
            {
                if (foto == "del")
                {
                    if (File.Exists(mc.FT + cod + ".jpg"))
                    {
                        File.Delete(mc.FT + cod + ".jpg");
                    }
                }
                else
                {
                    try
                    {
                        var path = Path.Combine(mc.FT, Path.GetFileName(foto));

                        if (!Directory.Exists(mc.FT))

                        {
                            Directory.CreateDirectory(mc.FT);

                            File.Copy(foto, mc.FT + cod + Path.GetExtension(foto));
                        }
                        else
                        {
                            if (File.Exists(mc.FT + cod + Path.GetExtension(foto)))
                            {
                                File.Delete(mc.FT + cod + Path.GetExtension(foto));
                            }

                            File.Copy(foto, mc.FT + cod + Path.GetExtension(foto));
                        }
                    }
                    catch { }

                }

            }
        }

        private Double UltimaBaixaItem(string codigo, int unidade)
        {
            double custoMedio = 0;
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLIngredientes blli = new BLLIngredientes(cx);
            DataTable tabela = new DataTable();

            tabela = blli.Custo01(codigo, unidade);
            try
            {
                custoMedio = Convert.ToDouble(tabela.Rows[0][1]);
            }
            catch
            {
                custoMedio = 0;
            }
            
            return custoMedio;

        }

    }



}
