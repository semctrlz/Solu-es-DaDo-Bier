using GUI.Code.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms.Comuns
{
    public partial class Config : Form
    {
        TableLayoutRowStyleCollection rowStyles, rowGraficos, rowAtalhos, rowInicial;

        string selecionado = "";
        int idUsuario = 0;
        string opcao = "0";
        string imagem;

        public Config(int id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        private void Atalhos_Click(object sender, EventArgs e)
        {
            if (selecionado == "atalhos")
            {
                selecionado = "";
                RecolheSubs(selecionado);
            }
            else
            {
                selecionado = "atalhos";
            }

            RecolheSubs(selecionado);
        }

        private void Config_Load(object sender, EventArgs e)
        {
            rowStyles = tbPrincipal.RowStyles;
            rowGraficos = tbGraficos.RowStyles;
            rowAtalhos = tbAtalhos.RowStyles;
            rowInicial = tbInicial.RowStyles;
            DefaultState();


            RecolheSubs("");
        }

        private void DefaultState()
        {
            pnAparencia.Visible = false;
            selecionado = "";
            opcao = "0";

            DTOCaminhos dt = new DTOCaminhos();

            if (File.Exists(dt.Wallpaper + idUsuario.ToString() + ".jpg"))
            {
                pbWallpaper.Load(dt.Wallpaper + idUsuario.ToString() + ".jpg");
                btDeletaFoto.Enabled = true;
            }
            else
            {
                try
                {
                    pbWallpaper.Load(dt.Wallpaper + "default.jpg");
                }
                catch
                {

                }
                btDeletaFoto.Enabled = false;
            }




        }

        private Color On()
        {
            return Color.LightGray;
        }

        private Color Out()
        {
            return Color.WhiteSmoke;
        }
        
        private void lbPaginaInicial_Click(object sender, EventArgs e)
        {
            if (selecionado == "inicial")
            {
                selecionado = "";
                RecolheSubs(selecionado);
            }
            else
            {
                selecionado = "inicial";
            }

            RecolheSubs(selecionado);
        }

        private void SelecionaOpcao()
        {
            
            if(opcao == "1.1")
            {
                lbAparencia.BackColor = On();
                pnAparencia.Visible = true;
            }
        }

        private void lbAparencia_MouseEnter(object sender, EventArgs e)
        {            
            lbAparencia.BackColor = On();                    
        }

        private void lbAparencia_MouseLeave(object sender, EventArgs e)
        {
            if (opcao != "1.1")
            {
                lbAparencia.BackColor = Out();
            }
        }

        private void MouseOn(Label lb)
        {
            lb.BackColor = Color.LightGray;
        }

        private void lbAparencia_Click(object sender, EventArgs e)
        {
            opcao = "1.1";
            SelecionaOpcao();
        }

        private void MouseOut(Label lb)
        {
            lb.BackColor = Color.WhiteSmoke;
        }

        private void btCarregaFoto_Click(object sender, EventArgs e)
        {
            // Mostra uma caixa de diálogo para salvar a imagem


            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg";
            saveFileDialog1.Title = "Salvar uma imagem.";
            saveFileDialog1.ShowDialog();

            imagem = saveFileDialog1.FileName;

            try
            {
                if (imagem != "")
                {
                    pbWallpaper.Load(imagem);
                    IncluiFoto(idUsuario.ToString(), imagem);

                }
            }
            catch
            {
                MessageBox.Show("Erro ao salvar imagem. Verifique se a extenção é .jpg.");
            }


            // If the file name is not an empty string open it for saving.
            btDeletaFoto.Enabled = true;
        }

        private void btDeletaFoto_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Deseja reverter o papel de parede da página inicial ao seu padrão? Atenção, a imagem de papel de parede atual será excluída. Continuar?", "Aviso", MessageBoxButtons.YesNo);
            if (d.ToString() == "Yes")
            {
                IncluiFoto(idUsuario.ToString(), "del");
                btDeletaFoto.Enabled = false;
            }
            else
            {

            }
        }

        private void RecolheSubs(string option)
        {
            rowStyles[0].Height = 30;
            rowStyles[1].Height = 0;
            rowStyles[2].Height = 30;
            rowStyles[3].Height = 0;
            rowStyles[4].Height = 30;
            rowStyles[5].Height = 0;

            for (int i = 0; i < tbGraficos.RowCount; i++)
            {
                rowGraficos[i].Height = 0;
            }
            for (int i = 0; i < tbAtalhos.RowCount; i++)
            {
                rowAtalhos[i].Height = 0;
            }
            for (int i = 0; i < tbInicial.RowCount; i++)
            {
                rowInicial[i].Height = 0;
            }

            if (option == "graficos")
            {
                int tamanho = tbGraficos.RowCount * 20;
                rowStyles[1].Height = tamanho;

                for (int i = 0; i < tbGraficos.RowCount; i++)
                {
                    rowGraficos[i].Height = 20;
                }
                

            }
            else if (option == "atalhos")
            {
                int tamanho = tbAtalhos.RowCount * 20;
                rowStyles[3].Height = tamanho;

                for (int i = 0; i < tbAtalhos.RowCount; i++)
                {
                    rowAtalhos[i].Height = 20;
                }
            }
            else if (option == "inicial")
            {
                int tamanho = tbInicial.RowCount * 20;
                rowStyles[5].Height = tamanho;

                for (int i = 0; i < tbInicial.RowCount; i++)
                {
                    rowInicial[i].Height = 20;
                }
            }

        }

        private void lb_Click(object sender, EventArgs e)
        {
            if (selecionado == "graficos")
            {
                selecionado = "";
                RecolheSubs(selecionado);
            }
            else
            {
                selecionado = "graficos";
            }

            RecolheSubs(selecionado);
        }


    public void IncluiFoto(String id, string foto)
    {
        DTOCaminhos mc = new DTOCaminhos();

            if (foto != "")
            {
                if (foto == "del")
                {
                    if (File.Exists(mc.Wallpaper + id + ".jpg"))
                    {
                        pbWallpaper.Load(mc.Wallpaper + "default.jpg");
                        
                        File.Delete(mc.Wallpaper + id + ".jpg");
                    }
                }
                else
                {
                    try
                    {
                        var path = Path.Combine(mc.Wallpaper, Path.GetFileName(foto));

                        if (!Directory.Exists(mc.Wallpaper))

                        {
                            Directory.CreateDirectory(mc.Wallpaper);

                            File.Copy(foto, mc.Wallpaper + id + Path.GetExtension(foto));
                        }
                        else
                        {
                            if (File.Exists(mc.Wallpaper + id + Path.GetExtension(foto)))
                            {
                                File.Delete(mc.Wallpaper + id + Path.GetExtension(foto));
                            }

                            File.Copy(foto, mc.Wallpaper + id + Path.GetExtension(foto));
                        }
                    }
                    catch { }

                }
            }

        }
    }

}
