using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
                if (codItem.Substring(0, 2) == "20")
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

        public void paraPDF(bool img, string codigoP, string caminho, int unidade)
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bllp = new BLLPratos(cx);
            DataTable tabela = bllp.LocalizarPorCod(codigoP);

            DTOCaminhos dto = new DTOCaminhos();

            string nomePrato, codigo, desc, preparo, imagem, nome_cat, nome_setor, nome_scat;
            double rendimento, peso, total, totalKg, totalPorcao;
            int id_setor, id_cat, id_subcat;

            // Preenche dados da Ficha
            codigo = codigoP;
            nomePrato = tabela.Rows[0][1].ToString();
            desc = tabela.Rows[0][8].ToString();
            preparo = tabela.Rows[0][6].ToString();
            rendimento = Convert.ToDouble(tabela.Rows[0][5]);
            peso = Convert.ToDouble(tabela.Rows[0][7]);
            id_setor = Convert.ToInt32(tabela.Rows[0][2]);
            id_cat = Convert.ToInt32(tabela.Rows[0][3]);
            id_subcat = Convert.ToInt32(tabela.Rows[0][4]);
            imagem = "";
            nome_setor = "";
            nome_cat = "";
            nome_scat = "";
            total = CalculaCustoFicha(codigoP, unidade);
            totalKg = 0;
            totalPorcao = 0;

            if (peso > 0)
            {
                totalKg = total / peso;
            }

            if (rendimento > 0)
            {
                totalPorcao = total / rendimento;
            }


            if (File.Exists(dto.FT + codigoP + ".jpg") && img)
            {
                imagem = (dto.FT + codigoP + ".jpg");
            }

            //Carrega setor, categoria e subcategoria

            BLLBuffet bllsetor = new BLLBuffet(cx);
            DataTable tabelasetor = bllsetor.localizarPorId(id_setor);

            nome_setor = tabelasetor.Rows[0][0].ToString();

            BLLCategoria bllcat = new BLLCategoria(cx);
            DataTable tabelacat = bllcat.localizarPorId(id_cat);

            if (tabelacat.Rows.Count > 0)
            {
                nome_cat = tabelacat.Rows[0][0].ToString();
            }


            BLLSubCategoria bllscat = new BLLSubCategoria(cx);
            DataTable tabelascat = bllscat.localizarPorId(id_subcat);

            if (tabelascat.Rows.Count > 0)
            {
                nome_scat = tabelascat.Rows[0][0].ToString();
            }


            //Exportar para pdf

            iTextSharp.text.Font Titulo = FontFactory.GetFont("Segoe UI Light", 15, BaseColor.BLACK);
            iTextSharp.text.Font subtitulo = FontFactory.GetFont("Verdana", 8, 1, BaseColor.BLACK);
            iTextSharp.text.Font texto = FontFactory.GetFont("Segoe UI", 8, BaseColor.BLACK);


            Document doc = new Document(iTextSharp.text.PageSize.A4, 5, 5, 30, 30);

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream($"{caminho}", FileMode.Create));
            doc.Open();

            float larguraTotal = 550;

            float largura1 = 0.11f;
            float largura2 = 0.38f;
            float largura3 = 0.08f;
            float largura4 = 0.1f;
            float largura5 = 0.1f;
            float largura6 = 0.12f;
            float largura7 = 0.12f;

            largura1 *= larguraTotal;
            largura2 *= larguraTotal;
            largura3 *= larguraTotal;
            largura4 *= larguraTotal;
            largura5 *= larguraTotal;
            largura6 *= larguraTotal;
            largura7 *= larguraTotal;

            BaseColor CSTitulo = BaseColor.GRAY;
            BaseColor linhaAlternada0 = BaseColor.WHITE;
            BaseColor linhaAlternada1 = BaseColor.LIGHT_GRAY;


            PdfPTable table = new PdfPTable(7);

            table.DefaultCell.Phrase = new Phrase() { Font = texto };
            table.TotalWidth = larguraTotal;
            table.PaddingTop = 0;
            table.LockedWidth = true;
            float[] widths = new float[] { largura1, largura2, largura3, largura4, largura5, largura6, largura7 };
            table.SetWidths(widths);

            if (imagem != "")

            {

                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(dto.FT + codigoP + ".jpg");

                float largura = 200;
                float alturai = 0.0f;
                float alturaNova;
                alturai = pic.Height;
                alturaNova = (largura * alturai) / pic.Width;
                pic.ScaleAbsolute(largura, alturaNova);

                PdfPCell foto = new PdfPCell(pic);

                foto.Colspan = 7;
                foto.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                foto.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(foto);
            }


            PdfPCell cell = new PdfPCell(new Phrase($"{nomePrato} ({codigoP}) ", new iTextSharp.text.Font(Titulo)));

            cell.Colspan = 6;
            cell.Rowspan = 6;


            cell.FixedHeight = 40f;
            cell.HorizontalAlignment = 1; //0=esquerda, 1 = centro, 2=direita
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cell);

            float altura = 15f;

            PdfPCell tctotal = new PdfPCell(new Phrase("CUSTO TOTAL", new iTextSharp.text.Font(subtitulo)));
            tctotal.BackgroundColor = (CSTitulo);

            tctotal.FixedHeight = altura;
            tctotal.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            tctotal.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(tctotal);


            PdfPCell ctotal = new PdfPCell(new Phrase(total.ToString("#0,0.00"), new iTextSharp.text.Font(texto)));

            ctotal.FixedHeight = altura;
            ctotal.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            ctotal.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(ctotal);

            PdfPCell tckg = new PdfPCell(new Phrase("CUSTO/Kg", new iTextSharp.text.Font(subtitulo)));
            tckg.BackgroundColor = (CSTitulo);

            tckg.FixedHeight = altura;
            tckg.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            tckg.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(tckg);

            PdfPCell ckg = new PdfPCell(new Phrase(totalKg.ToString("#0,0.00"), new iTextSharp.text.Font(texto)));
            ckg.FixedHeight = altura;
            ckg.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            ckg.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(ckg);

            PdfPCell tcporcao = new PdfPCell(new Phrase("CUSTO/PORÇÃO", new iTextSharp.text.Font(subtitulo)));
            tcporcao.BackgroundColor = (CSTitulo);

            tcporcao.FixedHeight = altura;
            tcporcao.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            tcporcao.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(tcporcao);

            PdfPCell cporcao = new PdfPCell(new Phrase(totalPorcao.ToString("#0,0.00"), new iTextSharp.text.Font(texto)));

            cporcao.FixedHeight = altura;
            cporcao.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cporcao.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cporcao);

            altura = 20f;

            PdfPCell tsetor = new PdfPCell(new Phrase("SETOR", new iTextSharp.text.Font(subtitulo)));
            tsetor.BackgroundColor = (CSTitulo);

            tsetor.FixedHeight = altura;
            tsetor.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            tsetor.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(tsetor);

            PdfPCell tcategoria = new PdfPCell(new Phrase("CATEGORIZAÇÃO", new iTextSharp.text.Font(subtitulo)));
            tcategoria.BackgroundColor = (CSTitulo);

            tcategoria.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            tcategoria.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            tcategoria.FixedHeight = altura;
            tcategoria.Colspan = 4;
            table.AddCell(tcategoria);

            PdfPCell tpeso = new PdfPCell(new Phrase("PESO", new iTextSharp.text.Font(subtitulo)));
            tpeso.BackgroundColor = (CSTitulo);

            tpeso.FixedHeight = altura;
            tpeso.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            tpeso.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(tpeso);

            PdfPCell trendimento = new PdfPCell(new Phrase("RENDIMENTO", new iTextSharp.text.Font(subtitulo)));
            trendimento.BackgroundColor = (CSTitulo);

            trendimento.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            trendimento.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.FixedHeight = altura;
            table.AddCell(trendimento);


            altura = 15;

            PdfPCell setor = new PdfPCell(new Phrase(nome_setor, texto));
            setor.FixedHeight = altura;
            setor.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            setor.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(setor);

            string categorias = "";

            if (nome_cat != "")
            {
                categorias = nome_cat;
            }
            if (nome_scat != "")
            {
                if (nome_cat == "")
                {
                    categorias += nome_scat;
                }
                else
                {
                    categorias += ", " + nome_scat;
                }
            }

            PdfPCell categoria = new PdfPCell(new Phrase(categorias, texto));
            categoria.FixedHeight = altura;
            categoria.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            categoria.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            categoria.Colspan = 4;
            table.AddCell(categoria);

            PdfPCell pesopdf = new PdfPCell(new Phrase(peso.ToString("#,0.0000"), texto));
            pesopdf.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            pesopdf.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            pesopdf.FixedHeight = altura;
            table.AddCell(pesopdf);

            PdfPCell rendimentoPdf = new PdfPCell(new Phrase(rendimento.ToString("#0,0.00"), texto));
            rendimentoPdf.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            rendimentoPdf.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            rendimentoPdf.FixedHeight = altura;
            table.AddCell(rendimentoPdf);

            altura = 20;

            PdfPCell cod = new PdfPCell(new Phrase("CODIGO", new iTextSharp.text.Font(subtitulo)));
            cod.BackgroundColor = (CSTitulo);

            cod.FixedHeight = altura;
            cod.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cod.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cod);

            PdfPCell item = new PdfPCell(new Phrase("ITEM", new iTextSharp.text.Font(subtitulo)));
            item.BackgroundColor = (CSTitulo);

            item.FixedHeight = altura;
            item.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            item.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            table.AddCell(item);

            PdfPCell fc = new PdfPCell(new Phrase("FC", new iTextSharp.text.Font(subtitulo)));
            fc.BackgroundColor = (CSTitulo);

            fc.FixedHeight = altura;
            fc.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            fc.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            table.AddCell(fc);

            PdfPCell um = new PdfPCell(new Phrase("U.M.", new iTextSharp.text.Font(subtitulo)));
            um.BackgroundColor = (CSTitulo);

            um.FixedHeight = altura;
            um.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            um.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            table.AddCell(um);


            PdfPCell quant = new PdfPCell(new Phrase("QUANT.", new iTextSharp.text.Font(subtitulo)));
            quant.BackgroundColor = (CSTitulo);

            quant.FixedHeight = altura;
            quant.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            quant.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            table.AddCell(quant);

            PdfPCell unit = new PdfPCell(new Phrase("$UNIT", new iTextSharp.text.Font(subtitulo)));
            unit.BackgroundColor = (CSTitulo);

            unit.FixedHeight = altura;
            unit.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            unit.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            table.AddCell(unit);

            PdfPCell totalpdf = new PdfPCell(new Phrase("$TOTAL", new iTextSharp.text.Font(subtitulo)));
            totalpdf.BackgroundColor = (CSTitulo);

            totalpdf.FixedHeight = altura;
            totalpdf.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            totalpdf.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            table.AddCell(totalpdf);

            altura = 15;

            PdfPCell linha = new PdfPCell();
            linha.FixedHeight = altura;
            linha.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            linha.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;


            //Linha por linha busca ingrediente com custo
            BLLPratos bll = new BLLPratos(cx);
            DataTable tabelaIngredientes = bll.ListarIngredientes(codigoP);

            BLLAeB bllaeb = new BLLAeB(cx);
            DataTable tabelaAeb;


            string codIngrediente, nomeingrediente, uniMedida;
            double quantidade, custoUnit, custoTotal, correcao;


            if (tabelaIngredientes.Rows.Count > 0)
            {
                for (int i = 0; i < tabelaIngredientes.Rows.Count; i++)
                {
                    //cod_item, quant_ingrediente

                    tabelaAeb = bllaeb.localizarPorCod(tabelaIngredientes.Rows[i][0].ToString());


                    codIngrediente = tabelaIngredientes.Rows[i][0].ToString();
                    nomeingrediente = tabelaAeb.Rows[0][0].ToString();
                    uniMedida = tabelaAeb.Rows[0][1].ToString();

                    if (string.IsNullOrEmpty(tabelaAeb.Rows[0][2].ToString()))
                    {
                        correcao = 0;
                    }
                    else
                    {
                        correcao = Convert.ToDouble(tabelaAeb.Rows[0][2]);
                    }

                    quantidade = Convert.ToDouble(tabelaIngredientes.Rows[i][1]);

                    custoUnit = CustoIngrediente(codIngrediente, unidade);
                    custoTotal = custoUnit * quantidade;


                    //add linhas

                    if (i % 2 > 0)
                    {
                        linha.BackgroundColor = (linhaAlternada1);
                    }
                    else
                    {
                        linha.BackgroundColor = (linhaAlternada0);

                    }

                    linha.Phrase = new Phrase(codIngrediente, texto);
                    table.AddCell(linha);

                    linha.Phrase = new Phrase(nomeingrediente, texto);
                    table.AddCell(linha);

                    linha.Phrase = new Phrase(correcao.ToString("#,0.00"), texto);
                    table.AddCell(linha);

                    linha.Phrase = new Phrase(uniMedida, texto);
                    table.AddCell(linha);

                    linha.Phrase = new Phrase(quantidade.ToString(), texto);
                    table.AddCell(linha);

                    linha.Phrase = new Phrase(custoUnit.ToString("#,0.00"), texto);
                    table.AddCell(linha);

                    linha.Phrase = new Phrase(custoTotal.ToString("#,0.00"), texto);
                    table.AddCell(linha);
                }
            }                    
                

            PdfPCell tModoPreparo = new PdfPCell(new Phrase("MODO DE PREPARO", new iTextSharp.text.Font(subtitulo)));

            tModoPreparo.BackgroundColor = (CSTitulo);
            tModoPreparo.Colspan = 7;
            tModoPreparo.FixedHeight = 20f;
            tModoPreparo.HorizontalAlignment = 1; //0=esquerda, 1 = centro, 2=direita
            tModoPreparo.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            table.AddCell(tModoPreparo);

            PdfPCell ModoPreparo = new PdfPCell(new Phrase(preparo, texto));
            ModoPreparo.Colspan = 7;

            ModoPreparo.HorizontalAlignment = PdfPCell.ALIGN_JUSTIFIED;

            table.AddCell(ModoPreparo);


            doc.Add(table);

            doc.Close();



        }


    }
}

