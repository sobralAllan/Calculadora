using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurandoDatas
{
    class Control
    {
        DAO acesso;
        public int opcao;
        public int codigo;
        public void MostrarMenu()
        {
            try
            {
                acesso = new DAO();
                Console.WriteLine("--------- MENU -----------\n" +
                                 "Escolha uma das opções abaixo: " +
                                 "\n1. Inserir" +
                                 "\n2. Consultar Tudo" +
                                 "\n3. Consultar Nome" +
                                 "\n8. Sair");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!" + e);
            }
        }//fim do método

        public void Operacao()
        {

            do
            {
                MostrarMenu();

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("-------- Cadastrar ----------");
                        Console.WriteLine("Informe o seu nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Informe o seu telefone: ");
                        string telefone = Console.ReadLine();
                        Console.WriteLine("Informe o seu endereço: ");
                        string endereco = Console.ReadLine();
                        Console.WriteLine("Informe a data atual: ");
                        
                        DateTime dataAtual = DateTime.Parse(Console.ReadLine());
                        //passar para método
                        acesso.Inserir(nome, telefone, endereco, dataAtual);
                        break;
                   
 
                    default:
                        Console.WriteLine("Código informado não existe!");
                        break;
                }//fim do switch
            } while (opcao != 8);
        }//fim do operacao
    }//fim da classe
}//fim do projeto
