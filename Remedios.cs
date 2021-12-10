using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeuJoao
{
    class Remedios
    {
        private string _nome, _hora;

        public string Nome { get => _nome; set => _nome = value; }
        public string Hora { get => _hora; set => _hora = value; }

        public bool gravarRemedio()
        {
            Banco bd = new Banco();
            SqlConnection cn = bd.abrirConexao();
            SqlTransaction tran = cn.BeginTransaction();
            SqlCommand command = new SqlCommand();

            command.Connection = cn;
            command.Transaction = tran;
            command.CommandType = CommandType.Text;

            command.CommandText = "insert into remedio values (@nome, @horario)";
            command.Parameters.Add("@nome", SqlDbType.VarChar);
            command.Parameters.Add("@horario", SqlDbType.VarChar);

            command.Parameters[0].Value = _nome;
            command.Parameters[1].Value = _hora;

            try
            {
                command.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("" + ex);
                return false;
            }
        }


    }
}
