using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeuJoao
{
    public partial class btnGravar : Form
    {
      
        public btnGravar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Remedios r = new Remedios();
            r.Nome = txbRemedio.Text;
            r.Hora = txbHorario.Text;
            r.gravarRemedio();

            Banco bd = new Banco();
            string sql = "select * from remedio";
            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);

            dataGridView1.DataSource = dt;

            //Banco bd = new Banco();

            //try
            //{
            //    SqlConnection cn = bd.abrirConexao();
            //    SqlCommand command = new SqlCommand("Select * from remedio", cn);

            //    SqlDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        string t = reader.GetString(2);
            //        string[] corta = t.Split(':');
            //        MessageBox.Show(corta[0] + ":" + corta[1]);


            //    }



            //}
            //catch (Exception ex)
            //{

            //    return;
            //}
            //finally
            //{
            //    bd.fecharConexao();
            //}



        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            string sql = "select * from remedio";
            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);

            dataGridView1.DataSource = dt;
         
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            int hora = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            try
            {
                SqlConnection cn = bd.abrirConexao();
                SqlCommand command = new SqlCommand("Select * from remedio", cn);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string [] t = reader.GetString(2).Split(':');
                    double h = int.Parse(t[0]);
                    double m = int.Parse(t[1]);
                    
                    if (h == hora && m ==min)
                    {
                        MessageBox.Show("Hora do remedio: " + reader.GetString(1));
                     
                    }

                }
               


            }
            catch (Exception ex)
            {

                return;
            }
            finally
            {
                bd.fecharConexao();
            }
        }
    }
}
