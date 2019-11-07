using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace PCW.Models
{
    public class PessoasDAL : IPessoasDAL
    {
        string connectionString = @"Data Source=DESKTOP-PIKVREV\SQLEXPRESS;Initial Catalog=PCW;Integrated Security=True;";
        public IEnumerable<Pessoas> GetAllPessoas()
        {
            List<Pessoas> lstpessoa = new List<Pessoas>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT SEQPESSOA, NOME,CPF, DTNASCIMENTO,USUARIO, SENHA, TIPO, TELEFONE, ENDERECO, NUMERO,ESTADO,CEP,CIDADE from PESSOAS", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Pessoas pessoas = new Pessoas();
                    pessoas.SEQPESSOA = Convert.ToInt32(rdr["SEQPESSOA"]);
                    pessoas.NOME = rdr["NOME"].ToString();
                    pessoas.CIDADE = rdr["CIDADE"].ToString();
                    pessoas.CPF = rdr["CPF"].ToString();
                    pessoas.DTNASCIMENTO = rdr["DTNASCIMENTO"].ToString();
                    pessoas.USUARIO = rdr["USUARIO"].ToString();
                    pessoas.SENHA = rdr["SENHA"].ToString();
                    pessoas.TIPO = rdr["TIPO"].ToString();
                    pessoas.TELEFONE = rdr["TELEFONE"].ToString();
                    pessoas.ENDERECO = rdr["ENDERECO"].ToString();
                    pessoas.NUMERO = rdr["NUMERO"].ToString();
                    pessoas.ESTADO = rdr["ESTADO"].ToString();
                    pessoas.CEP = rdr["CEP"].ToString();
                    pessoas.CIDADE = rdr["CIDADE"].ToString();

                    lstpessoa.Add(pessoas);
                }
                con.Close();
            }
            return lstpessoa;
        }
        public void AddPessoas(Pessoas pessoas)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Insert into PESSOAS ( NOME,CPF, DTNASCIMENTO,USUARIO, SENHA, TIPO, TELEFONE, ENDERECO, NUMERO,ESTADO,CEP,CIDADE, CNH) Values(@NOME,@CPF, @DTNASCIMENTO,@USUARIO, @SENHA, @TIPO, @TELEFONE, @ENDERECO, @NUMERO,@ESTADO,@CEP,@CIDADE, @CNH)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NOME", pessoas.NOME);
                cmd.Parameters.AddWithValue("@CPF", pessoas.CPF);
                cmd.Parameters.AddWithValue("@DTNASCIMENTO", pessoas.DTNASCIMENTO);
                cmd.Parameters.AddWithValue("@USUARIO", pessoas.USUARIO);
                cmd.Parameters.AddWithValue("@SENHA", pessoas.SENHA);
                cmd.Parameters.AddWithValue("@TIPO", pessoas.TIPO);
                cmd.Parameters.AddWithValue("@TELEFONE", pessoas.TELEFONE);
                cmd.Parameters.AddWithValue("@ENDERECO", pessoas.ENDERECO);
                cmd.Parameters.AddWithValue("@NUMERO", pessoas.NUMERO);
                cmd.Parameters.AddWithValue("@ESTADO", pessoas.ESTADO);
                cmd.Parameters.AddWithValue("@CEP", pessoas.CEP);
                cmd.Parameters.AddWithValue("@CIDADE", pessoas.CIDADE);
                cmd.Parameters.AddWithValue("@CNH", pessoas.CNH);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdatePessoas(Pessoas pessoas)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Update PESSOAS set NOME = @NOME, DTNASCIMENTO = @DTNASCIMENTO, USUARIO=@USUARIO, SENHA=@SENHA, TIPO=@TIPO, TELEFONE=@TELEFONE, ENDERECO=@ENDERECO, NUMERO=@NUMERO, ESTADO=@ESTADO, CIDADE=@CIDADE, CNH=@CNH where SEQPESSOA = @SEQPESSOA";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SEQPESSOA", pessoas.SEQPESSOA);
                cmd.Parameters.AddWithValue("@NOME", pessoas.NOME);
                cmd.Parameters.AddWithValue("@CPF", pessoas.CPF);
                cmd.Parameters.AddWithValue("@DTNASCIMENTO", pessoas.DTNASCIMENTO);
                cmd.Parameters.AddWithValue("@USUARIO", pessoas.USUARIO);
                cmd.Parameters.AddWithValue("@SENHA", pessoas.SENHA);
                cmd.Parameters.AddWithValue("@TIPO", pessoas.TIPO);
                cmd.Parameters.AddWithValue("@TELEFONE", pessoas.TELEFONE);
                cmd.Parameters.AddWithValue("@ENDERECO", pessoas.ENDERECO);
                cmd.Parameters.AddWithValue("@NUMERO", pessoas.NUMERO);
                cmd.Parameters.AddWithValue("@ESTADO", pessoas.ESTADO);
                cmd.Parameters.AddWithValue("@CIDADE", pessoas.CIDADE);
                cmd.Parameters.AddWithValue("@CNH", pessoas.CNH);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Pessoas GetPessoas(int? id)
        {
            Pessoas pessoas = new Pessoas();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM PESSOAS WHERE SEQPESSOA= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    pessoas.SEQPESSOA = Convert.ToInt32(rdr["SEQPESSOA"]);
                    pessoas.NOME = rdr["NOME"].ToString();
                    pessoas.CIDADE = rdr["CIDADE"].ToString();
                    pessoas.CPF = rdr["CPF"].ToString();
                    pessoas.DTNASCIMENTO = rdr["DTNASCIMENTO"].ToString();
                    pessoas.USUARIO = rdr["USUARIO"].ToString();
                    pessoas.SENHA = rdr["SENHA"].ToString();
                    pessoas.TIPO = rdr["TIPO"].ToString();
                    pessoas.TELEFONE = rdr["TELEFONE"].ToString();
                    pessoas.ENDERECO = rdr["ENDERECO"].ToString();
                    pessoas.NUMERO = rdr["NUMERO"].ToString();
                    pessoas.ESTADO = rdr["ESTADO"].ToString();
                    pessoas.CEP = rdr["CEP"].ToString();
                    pessoas.CIDADE = rdr["CIDADE"].ToString();
                }
            }
            return pessoas;
        }

        public Pessoas GetUsu(string senha)
        {
            Pessoas pessoas = new Pessoas();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM PESSOAS WHERE SENHA= " + senha;
                //string sqlQuery = "SELECT * FROM PESSOAS WHERE SENHA= " + senha + " AND USUARIO = " + usuario;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    pessoas.SEQPESSOA = Convert.ToInt32(rdr["SEQPESSOA"]);
                    pessoas.NOME = rdr["NOME"].ToString();
                    pessoas.CIDADE = rdr["CIDADE"].ToString();
                    pessoas.CPF = rdr["CPF"].ToString();
                    pessoas.DTNASCIMENTO = rdr["DTNASCIMENTO"].ToString();
                    pessoas.USUARIO = rdr["USUARIO"].ToString();
                    pessoas.SENHA = rdr["SENHA"].ToString();
                    pessoas.TIPO = rdr["TIPO"].ToString();
                    pessoas.TELEFONE = rdr["TELEFONE"].ToString();
                    pessoas.ENDERECO = rdr["ENDERECO"].ToString();
                    pessoas.NUMERO = rdr["NUMERO"].ToString();
                    pessoas.ESTADO = rdr["ESTADO"].ToString();
                    pessoas.CEP = rdr["CEP"].ToString();
                    pessoas.CIDADE = rdr["CIDADE"].ToString();

                }
            }
            return pessoas;
        }
        public void DeletePessoas(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from PESSOAS where SEQPESSOA = @SEQPESSOA";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SEQPESSOA", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //public IEnumerable<Pessoas> GetAllPessoas()
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddPessoa(Pessoas pessoas)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdatePessoas(Pessoas pessoas)
        //{
        //    throw new NotImplementedException();
        //}

        //public Pessoas GetPessoas(int? id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeletePessoas(int? id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}