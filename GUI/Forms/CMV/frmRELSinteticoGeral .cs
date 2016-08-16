using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms.CMV
{
    public partial class frmRELSinteticoGeral : Form
    {
        int unidade, idUsuario;
        bool liberado = false;
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        DateTime DiaI, DiaF, DiaA;

        public frmRELSinteticoGeral(int id)
        {
            idUsuario = Convert.ToInt32(id);
            InitializeComponent();
        }

        private void frmRELSinteticoGeral_Load(object sender, EventArgs e)
        {
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";
            DafaultValues();
            
        }

        public class Language
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string Data { get; set; }
            public string Value1 { get; set; }
            public string Name2 { get; set; }
            public string Value2 { get; set; }
            public string Name3 { get; set; }
            public string Value3 { get; set; }
            public string Name4 { get; set; }
            public string Value4 { get; set; }
            public string Name5 { get; set; }
            public string Value5 { get; set; }
        }

        public class CMV
        {
            public string Data { get; set; }
            public string Pax { get; set; }
            public string Custo1 { get; set; }
            public string Percent1 { get; set; }
            public string Custo2 { get; set; }
            public string Percent2 { get; set; }
            public string Custo3 { get; set; }
            public string Percent3 { get; set; }
            public string Custo4 { get; set; }
            public string Percent4 { get; set; }
            public string Custo5 { get; set; }
            public string Percent5 { get; set; }
        }

        private void DafaultValues()
        {
            pn01.Visible = false;
            liberado = false;

            CarregaMes();
            DateTime data = DateTime.Today;

            numAno.Value = data.Year;
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(con);
            BLLUsuario bllu = new BLLUsuario(con);
            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            cbUnidade.DataSource = bllun.ListarUnidades();
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
            cbUnidade.Text = modelou.IdUnidade.ToString();

            if (modelou.PermissaoUsuario < 4)
            {
                cbUnidade.Enabled = false;
            }

            unidade = Convert.ToInt32(cbUnidade.SelectedValue);


            CarregaDgvs();

            liberado = true;
            pn01.Visible = true;

        }

        private void CarregaMes()
        {

            DateTime data = DateTime.Today;
            int mesAtual = data.Month;

            var dataSource = new List<Language>();
            dataSource.Add(new Language() { Name = "Janeiro", Value = "1" });
            dataSource.Add(new Language() { Name = "Fevereiro", Value = "2" });
            dataSource.Add(new Language() { Name = "Março", Value = "3" });
            dataSource.Add(new Language() { Name = "Abril", Value = "4" });
            dataSource.Add(new Language() { Name = "Maio", Value = "5" });
            dataSource.Add(new Language() { Name = "Junho", Value = "6" });
            dataSource.Add(new Language() { Name = "Julho", Value = "7" });
            dataSource.Add(new Language() { Name = "Agosto", Value = "8" });
            dataSource.Add(new Language() { Name = "Setembro", Value = "9" });
            dataSource.Add(new Language() { Name = "Outubro", Value = "10" });
            dataSource.Add(new Language() { Name = "Novembro", Value = "11" });
            dataSource.Add(new Language() { Name = "Dezembro", Value = "12" });

            //Adicionar ao ComboBox
            this.cbMes.DataSource = dataSource;
            this.cbMes.DisplayMember = "Name";
            this.cbMes.ValueMember = "Value";
            this.cbMes.SelectedIndex = mesAtual - 1;

        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                CarregaDgvs();
            }
        }

        private void CarregaDgvs()
        {
            pn01.Visible = false;

            CarregaDatas();
            CarregaGrupo01();
            pn01.Visible = true;

        }

        private void CarregaDatas()
        {






            DataGridView dgv = new DataGridView();
            dgv = dgvData;
            dgv.Rows.Clear();

            DiaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DiaF = DiaI.AddDays(-(DiaI.Day - 1)).AddMonths(1).AddDays(-1);
            DiaA = DiaI;
            string data;

            var dataSource = new List<CMV>();
            for (int i = 0; i < 31; i++)
            {

                data = Dia(DiaA);
                dataSource.Add(new CMV() { Data = data, Pax = "1" });
                               
                DiaA = DiaA.AddDays(1);
            }
            dataSource.Add(new CMV() { Data = "", Pax = "0" });

            dgv.DataSource = dataSource;
           

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgv.Font, FontStyle.Bold);

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgv.Font, FontStyle.Bold);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {

                try
                {
                    if (dgv.Rows[i].Cells[1].Value.ToString() == "-1")
                    {

                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgv.Rows[i].Height = 3;
                    }


                    if (dgv.Rows[i].Cells[1].Value.ToString() == "0")
                    {
                        dgv.Rows[i].DefaultCellStyle = style2;
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dgv.Rows[i].Height = 25;
                    }
                    
                    


                }
                catch { }
            }
        }

        private void CarregaGrupo01()
        {
            

        }



        private string Dia(DateTime dia)
        {
            string diaDaSemana = dia.Day.ToString("00") + "/" +cbMes.Text.Substring(0,3)+" - ";

            switch ((int)dia.DayOfWeek)
            {
                case 0:
                    diaDaSemana += "Dom";
                    break;
                case 1:
                    diaDaSemana += "Seg";
                    break;
                case 2:
                    diaDaSemana += "Ter";
                    break;
                case 3:
                    diaDaSemana += "Qua";
                    break;
                case 4:
                    diaDaSemana += "Qui";
                    break;
                case 5:
                    diaDaSemana += "Sex";
                    break;
                case 6:
                    diaDaSemana += "Sáb";
                    break;
            }

            return diaDaSemana;
        }

        private void numAno_ValueChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                CarregaDgvs();
            }
        }

        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                CarregaDgvs();
            }
        }




    }
}
