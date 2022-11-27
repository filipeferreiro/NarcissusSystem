using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace NarcissusSystem.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void InsertUsuario(Usuario usuario)
        {
            connection.Open();
            command.CommandText = "CALL spInsertUsuario(@Nome, @login, @Senha);";
            command.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = usuario.Nome;
            command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = usuario.Login;
            command.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = usuario.Senha;
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public string SelectLogin(string vLogin)
        {
            connection.Open();
            command.CommandText = "CALL spSelectLogin(@Login);";
            command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = vLogin;
            command.Connection = connection;
            string Login = (string)command.ExecuteScalar(); // ExecuteScalar: RETORNAR APENAS 1 VALOR
            connection.Close();

            if (Login == null)
                Login = "";
            return Login;
        }

        public Usuario SelectUsuario(string vLogin)
        {
            connection.Open();
            command.CommandText = "CALL spSelectUsuario(@Login);";
            command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = vLogin;
            command.Connection = connection;
            var readUsuario = command.ExecuteReader();
            var tempUsuario = new Usuario();

            if (readUsuario.Read())
            {
                tempUsuario.Id = int.Parse(readUsuario["UsuarioID"].ToString());
                tempUsuario.Nome = readUsuario["UsuNome"].ToString();
                tempUsuario.Login = readUsuario["Login"].ToString();
                tempUsuario.Senha = readUsuario["Senha"].ToString();
            };

            readUsuario.Close();
            connection.Close();

            return tempUsuario;
        }

        public void UpdateSenha(Usuario usuario)
        {
            connection.Open();
            command.CommandText = "CALL spUpdateSenha(@Login, @Senha);";
            command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = usuario.Login;
            command.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = usuario.Senha;
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}