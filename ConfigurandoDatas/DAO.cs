using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ConfigurandoDatas
{
    class DAO
    {
        public string dados;
        public string resultado;
        private MySqlConnection conexao;
        public int[] codigo;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public int i;
        public int contador;
        public string msg;
        public DateTime[] dat;
        public DAO()
        {
            //conexaoDataSet = new DataSet();
            conexao = new MySqlConnection("server=localhost;DataBase=BancoDeDadosTI13N;Uid=root;Password=;");
            try
            {
                conexao.Open();//Tentando abrir a conexão com o BD
            }
            catch (Exception excecao)
            {
                Console.WriteLine("Algo deu errado\n\n" + excecao);
                Console.ReadLine();//Manter o Promp Aberto
                conexao.Close();
            }//fim da tentativa de conexão com o BD     
        }//fim do construtor

        public void Inserir(string nome, string telefone, string endereco, DateTime dat)
        {
            try
            {
                //Guardando na variável dados, todos os dados da parte Value do Insert
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
                parameter.Value = dat.Year + "-" + dat.Month + "-" + dat.Day;
                dados = "'','" + nome + "','" + telefone + "','" + endereco + "','" + parameter.Value + "'";
                resultado = "Insert into Pessoa(codigo, nome, telefone, endereco, dataAtual) values(" + dados + ")";
                //Executando o insert no BD
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                //Mostrar em tela o resultado da operação

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }//fim do método Inserir



    }//fim da classe
}//fim do projeto
