/*
 Teste técnico - Processo Seletivo | Maxiprod
 Nome: Samuel Parra Vieira 
 */

using System;
using System.Security.Cryptography;

namespace testeTecnicoCommandLine
{
    internal class Program
    {
        //arrays que vão guardar as informações das pessoas
        static string[] nomes = new string[10];
        static int[] idades = new int[10];
        static int[] ids = new int[10];
        static int totalPessoas = 0;

        //arrays que vão guardar as informações das transações com quantidades maiores, pois, podem várias transações por pessoa cadastrada
        static string[] descricoes = new string[100];
        static string[] tipos = new string[100];
        static double[] valores = new double[100];
        static int[] idsTransacoes = new int[100];
        static string[] pessoaCorrespondente = new string[100];
        static int[] idsPessoaCorrespondente = new int[100];
        static int totalTransacoes = 0;
        static double totalGeralDespesas = 0;
        static double totalGeralReceitas = 0;
        static double saldoLiquidoTotal = 0;

        static void Main(string[] args)
        {
            //pessoas teste
            nomes[0] = "Samuel";
            idades[0] = 23;
            ids[0] = 0;
            totalPessoas++;

            nomes[1] = "Melissa";
            idades[1] = 22;
            ids[1] = 1;
            totalPessoas++;

            //transações teste
            tipos[0] = "Receita";
            valores[0] = 1000;
            descricoes[0] = "Salário";
            idsTransacoes[0] = 0;
            pessoaCorrespondente[0] = "Samuel";
            idsPessoaCorrespondente[0] = 0;
            totalTransacoes++;

            tipos[1] = "Despesa";
            valores[1] = 100;
            descricoes[1] = "Contas";
            idsTransacoes[1] = 1;
            pessoaCorrespondente[1] = "Samuel";
            idsPessoaCorrespondente[1] = 0;
            totalTransacoes++;

            tipos[2] = "Receita";
            valores[2] = 2000;
            descricoes[2] = "Salário";
            idsTransacoes[2] = 2;
            pessoaCorrespondente[2] = "Melissa";
            idsPessoaCorrespondente[2] = 1;
            totalTransacoes++;

            tipos[3] = "Despesa";
            valores[3] = 200;
            descricoes[3] = "Contas";
            idsTransacoes[3] = 3;
            pessoaCorrespondente[3] = "Melissa";
            idsPessoaCorrespondente[3] = 1;
            totalTransacoes++;

            /*for (int i = 0; i < totalTransacoes; i++)
            {
                if (tipos[i] == "Receita")
                {
                    totalGeralReceitas += valores[i];
                }

                if (tipos[i] == "Despesa")
                {
                    totalGeralDespesas += valores[i];
                }
            }
            saldoLiquidoTotal = totalGeralReceitas - totalGeralDespesas;*/

            ////////////////////////////////

            string op;

            //loop que repete até que o usuário digite uma opção válida
            while (true)
            {
                limpaTela();

                Console.WriteLine("\n\t --- Bem vindo! --- \n\n");

                Console.WriteLine(" 1 - Pessoas");
                Console.WriteLine(" 2 - Transações");
                Console.WriteLine(" 3 - Consulta de totais");
                Console.WriteLine("\n 0 - Sair");

                Console.Write("\n - Opção: ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        limpaTela();
                        menuPessoas();
                        break;

                    case "2":
                        limpaTela();
                        menuTransacoes();
                        break;

                    case "3":
                        limpaTela();
                        consultaTotais();
                        break;

                    case "0":
                        limpaTela();
                        Console.WriteLine("\n\n\tPrograma encerrado");
                        return;

                    default:
                        Console.WriteLine("\nOpção inválida!\nPressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void menuPessoas()
        {
            string op;

            while (true)
            {
                limpaTela();

                Console.WriteLine("\n\t --- Pessoas --- \n\n");

                Console.WriteLine(" 1 - Cadastrar");
                Console.WriteLine(" 2 - Listar");
                Console.WriteLine(" 3 - Deletar");
                Console.WriteLine("\n 0 - Voltar");

                Console.Write("\n - Opção: ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        limpaTela();
                        cadPessoa();
                        break;

                    case "2":
                        limpaTela();
                        listaPessoa();
                        break;

                    case "3":
                        limpaTela();
                        delPessoa();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("\nOpção inválida!\nPressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void cadPessoa()
        {
            //verifica se a quantidade total de pessoas cadastradas já foi atingida
            if (totalPessoas >= 10)
            {
                Console.WriteLine(" \t\t Limite de pessoas atingido!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\n\t --- Cadastrar Pessoa --- \n\n");

            //adiciona os valores digitados aos seus respectivos arrays e incrementa o contador de pessoas cadastradas
            Console.Write("\t Nome completo: ");
            nomes[totalPessoas] = Console.ReadLine();

            Console.Write("\t         Idade: ");
            idades[totalPessoas] = int.Parse(Console.ReadLine());

            if (ids[ids.Length - 1] == totalPessoas)
            {
                ids[totalPessoas] = totalPessoas + 1;
            }
            else
            {
                ids[totalPessoas] = totalPessoas;
            }

            totalPessoas++;

            Console.WriteLine("\n\nPessoa cadastrada com sucesso!\n\nPressione qualquer tecla para voltar...");
            Console.WriteLine("length = " + ids.Length + " - totalpessoas = " + totalPessoas);
            Console.ReadKey();
            limpaTela();
        }

        static void listaPessoa()
        {
            //verifica se existem pessoas cadastradas
            if (totalPessoas == 0)
            {
                Console.WriteLine("\nNenhuma pessoa cadastrada!\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\n\t\t --- Clientes Cadastrados --- \n\n");

            //percorre os arrays para mostrar as pessoas cadastradas
            for (int i = 0; i < totalPessoas; i++)
            {
                Console.WriteLine("\t\t\t   ID: " + ids[i]);
                Console.WriteLine("\t\t\t Nome: " + nomes[i]);
                Console.WriteLine("\t\t\tIdade: " + idades[i]);
                Console.WriteLine("\t\t-------------------------------");
            }
            Console.WriteLine("\nFim da lista.\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void delPessoa()
        {
            //variável para a pessoa que será excluída
            int idExc;

            //verifica se existem pessoas cadastradas
            if (totalPessoas == 0)
            {
                Console.WriteLine("\nNenhuma pessoa cadastrada!\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            //mostra as pessoas cadastradas para melhor visualização antes de deletar
            Console.WriteLine("\n\n\t\t --- Exclusão de Pessoas ---");

            for (int i = 0; i < totalPessoas; i++)
            {
                Console.WriteLine("\t\t\t   ID: " + ids[i]);
                Console.WriteLine("\t\t\t Nome: " + nomes[i]);
                Console.WriteLine("\t\t-------------------------------");
            }

            //solicita o id da pessoa desejada            
            Console.Write("\nDigite o ID da pessoa que deseja excluir: ");

            //salva o valor na variável decrementando o id, pois, antes estava incrementado em 1 para melhor visualização
            idExc = int.Parse(Console.ReadLine());

            //verifica se o id digitado é válido
            if (idExc < 0 || idExc > totalPessoas)
            {
                Console.WriteLine("\nPessoa não existente.");
                Console.WriteLine("\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                limpaTela();
                return;
            }

            //percorre os arrays de pessoas e passa os elementos para uma posição anterior a partir da pessoa excluída
            for (int i = idExc; i < totalPessoas; i++)
            {
                ids[i] = ids[i + 1];
                nomes[i] = nomes[i + 1];
                idades[i] = idades[i + 1];

                delTransacao(idExc);
            }

            //diminui a quantidade de pessoas cadastradas
            totalPessoas--;

            Console.WriteLine("\n\nPessoa excluída com sucesso!\nPressione qualquer tecla para voltar...");
            Console.WriteLine("length = " + ids.Length + " - totalpessoas = " + totalPessoas);

            Console.ReadKey();
        }

        static void delTransacao(int idExc)
        {
            int novoTotalTransacoes = 0;

            for (int i = 0; i < totalTransacoes; i++)
            {
                if (idsPessoaCorrespondente[i] == idExc)
                {
                    if (tipos[i] == "Despesa")
                    {
                        totalGeralDespesas -= valores[idExc];
                    }

                    else if (tipos[i] == "Receita")
                    {
                        totalGeralReceitas -= valores[idExc];
                    }

                    descricoes[novoTotalTransacoes] = descricoes[i];
                    tipos[novoTotalTransacoes] = tipos[i];
                    valores[novoTotalTransacoes] = valores[i];
                    idsTransacoes[novoTotalTransacoes] = idsTransacoes[i];
                    pessoaCorrespondente[novoTotalTransacoes] = pessoaCorrespondente[i];
                    idsPessoaCorrespondente[novoTotalTransacoes] = idsPessoaCorrespondente[i];

                    novoTotalTransacoes++;
                }
            }
        }

        static void menuTransacoes()
        {
            string op;

            //loop que repete até que o usuário digite uma opção válida
            while (true)
            {
                limpaTela();

                //menu transações
                Console.WriteLine("\n\t --- Transações --- \n\n");

                Console.WriteLine(" 1 - Cadastrar");
                Console.WriteLine(" 2 - Listar");
                Console.WriteLine("\n 0 - Voltar");

                Console.Write("\n - Opção: ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        limpaTela();
                        cadTransacao();
                        break;

                    case "2":
                        limpaTela();
                        listaTransacao();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("\nOpção inválida!\nPressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void cadTransacao()
        {
            int id;

            Console.WriteLine("\n\t --- Cadastrar Transação --- \n\n");

            //verifica se existem pessoas cadastradas para criar uma transação
            if (totalPessoas <= 0)
            {
                Console.WriteLine("Nenhuma pessoa no sistema para cadastrar uma transação.\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            //mostra as pessoas cadastradas para facilitar a visualização
            for (int i = 0; i < totalPessoas; i++)
            {
                Console.WriteLine("\t\t   ID: " + ids[i]);
                Console.WriteLine("\t\t Nome: " + nomes[i]);
                Console.WriteLine("\t-------------------------------");
            }
            Console.Write("\nDigite o ID da pessoa que deseja cadastrar uma transação: ");
            //diminui em 1, pois, antes estava aumentado para melhor visualização
            id = int.Parse(Console.ReadLine());

            limpaTela();
            Console.WriteLine("\n\t --- Cadastrar Transação --- \n\n");
            Console.WriteLine("\n Pessoa selecionada: " + nomes[id]);

            //copia o nome e id da pessoa para os arrays de correspondencia
            pessoaCorrespondente[totalTransacoes] = nomes[id];
            idsPessoaCorrespondente[totalTransacoes] = ids[id];

            idsTransacoes[totalTransacoes] = totalTransacoes;

            if (idades[id] >= 18)
            {
                maior18();
            }
            else
            {
                menor18();
            }

        }

        //deixa a pessoa escolher se vai cadastrar uma receita ou despesa
        static void maior18()
        {
            string tipo;

            Console.WriteLine("\n Tipo da transação:");
            Console.WriteLine("\n  1 - Despesa\n  2 - Receita");
            Console.Write("\n\t - Opção: ");
            tipo = Console.ReadLine();

            Console.Write("\n Valor da transação: ");
            valores[totalTransacoes] = double.Parse(Console.ReadLine());

            //adiciona os valores às variáveis de totais gerais para serem exibidos na tela de consulta totais
            if (tipo == "1")
            {
                tipos[totalTransacoes] = "Despesa";
                totalGeralDespesas += valores[totalTransacoes];
            }
            if (tipo == "2")
            {
                tipos[totalTransacoes] = "Receita";
                totalGeralReceitas += valores[totalTransacoes];
            }

            Console.Write("\n Descrição da transação: ");
            descricoes[totalTransacoes] = Console.ReadLine();

            totalTransacoes++;

            Console.WriteLine("\nTransação cadastrada com sucesso!\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
            limpaTela();
        }

        //cadastra apenas despesas
        static void menor18()
        {
            tipos[totalTransacoes] = "Despesa";

            Console.Write("\n Valor da transação: ");
            valores[totalTransacoes] = double.Parse(Console.ReadLine());

            totalGeralDespesas += valores[totalTransacoes];

            Console.Write("\n Descrição da transação: ");
            descricoes[totalTransacoes] = Console.ReadLine();

            totalTransacoes++;

            Console.WriteLine("\nTransação cadastrada com sucesso!\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
            limpaTela();
        }

        static void listaTransacao()
        {
            bool pessoaExiste = false;

            Console.WriteLine("\n\t\t --- Transações Cadastradas --- \n\n");
            //verifica se existem transações cadastradas
            if (totalTransacoes == 0)
            {
                Console.WriteLine("\nNenhuma transação cadastrada!\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < totalTransacoes; i++)
            {
                // Verifica se a pessoa ainda existe
                pessoaExiste = false;

                for (int j = 0; j < totalPessoas; j++)
                {
                    if (idsPessoaCorrespondente[i] == ids[j])
                    {
                        pessoaExiste = true;
                        break;
                    }
                }

                // Se a pessoa foi excluída, não exibe a transação
                if (!pessoaExiste)
                {
                    continue;
                }

                Console.WriteLine("\t\t   ID da transação: " + idsTransacoes[i]);
                Console.WriteLine("\t\t ID do responsável: " + idsPessoaCorrespondente[i]);
                Console.WriteLine("\t\t       Responsável: " + pessoaCorrespondente[i]);
                Console.WriteLine("\t\t              Tipo: " + tipos[i]);
                Console.WriteLine("\t\t             Valor: R$ " + valores[i]);
                Console.WriteLine("\t\t         Descrição: " + descricoes[i]);
                Console.WriteLine("\t\t-------------------------------");
            }
            Console.WriteLine("\nFim da lista.\nPressione qualquer tecla para voltar...");
            Console.ReadKey();

        }

        static void consultaTotais()
        {
            bool temTransacoes = false;

            double totalReceitas = 0;
            double totalDespesas = 0;
            int qtdTransacoes = 0;
            int qtdReceitas = 0;
            int qtdDespesas = 0;

            totalGeralReceitas = 0;
            totalGeralDespesas = 0;
            saldoLiquidoTotal = 0;

            //loop externo para percorrer todas as pessoas cadastradas
            for (int i = 0; i < totalPessoas; i++)
            {
                temTransacoes = false;

                //verifica se a pessoa tem transações associadas
                for (int j = 0; j < totalTransacoes; j++)
                {
                    if (idsPessoaCorrespondente[j] == ids[i])
                    {
                        temTransacoes = true;
                        break;
                    }
                }

                if (!temTransacoes)
                {
                    continue;
                }

                //as variáveis zeram toda vez que o loop passa por outra pessoa
                totalReceitas = 0;
                totalDespesas = 0;
                qtdTransacoes = 0;
                qtdReceitas = 0;
                qtdDespesas = 0;

                //loop interno para percorrer todas as transações de cada pessoa
                for (int j = 0; j < totalTransacoes; j++)
                {
                    if (idsPessoaCorrespondente[j] == ids[i])
                    {
                        if (tipos[j] == "Receita")
                        {
                            totalReceitas += valores[j];
                            qtdTransacoes++;
                            qtdReceitas++;
                        }
                        if (tipos[j] == "Despesa")
                        {
                            totalDespesas += valores[j];
                            qtdTransacoes++;
                            qtdDespesas++;
                        }
                    }
                }
                //calcula o saldo líquido de cada pessoa
                double saldoLiquido = totalReceitas - totalDespesas;

                totalGeralReceitas += totalReceitas;
                totalGeralDespesas += totalDespesas;
                saldoLiquidoTotal += saldoLiquido;

                //mostra os dados antes que as variáveis sejam zeradas para calcular os totais de outra pessoa
                Console.WriteLine("             Pessoa: " + nomes[i]);
                Console.WriteLine("                 ID: " + ids[i]);
                Console.WriteLine("         Transações: " + qtdTransacoes);
                Console.WriteLine("           Receitas: " + qtdReceitas);
                Console.WriteLine("           Despesas: " + qtdDespesas);
                Console.WriteLine(" Total das Receitas: R$ " + totalReceitas);
                Console.WriteLine(" Total das Despesas: R$ " + totalDespesas);
                Console.WriteLine("      Saldo Líquido: R$ " + saldoLiquido);
                Console.WriteLine("--------------------------------------------------");


            }



            Console.WriteLine("\n\n\t --- Total Geral --- \n");
            Console.WriteLine("   Total das receitas: R$ " + totalGeralReceitas);
            Console.WriteLine("   Total das despesas: R$ " + totalGeralDespesas);
            Console.WriteLine("  Saldo líquido total: R$ " + saldoLiquidoTotal);

            Console.WriteLine("\n\nFim da lista. \nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void limpaTela()
        {
            Console.Clear();
        }
    }
}
