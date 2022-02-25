using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        #region Variáveis principais
        static int indexArrayGeralEquipamentos = 0;
        static int indexArrayGeralChamados = 0;

        // Variáveis para equipamentos
        static string[] nomeEquipamento = new string[1000];
        static double[] precoEquipamento = new double[1000];
        static string[] numeroSerieEquipamento = new string[1000];
        static DateTime[] dataFabricacaoEquipamento = new DateTime[1000];
        static string[] fabricanteEquipamento = new string[1000];
        static bool[] estaEmUmChamado = new bool[1000];

        // Variáveis para chamados
        static string[] tituloChamado = new string[1000];
        static string[] descricaoChamado = new string[1000];
        static int[] indiceEquipamento = new int[1000];
        static DateTime[] dataAberturaEquipamento = new DateTime[1000];
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Gestão de Equipamentos");
            while (true)
            {
                Console.WriteLine("1 - Criar equipamento\n2 - Listar equipamentos\n3 - Editar equipamento\n4 - Excluir equipamento\n5 - Criar chamado\n6 - Listar chamados\n7 - Editar chamado\n8 - Excluir chamado\n0 - Sair");
                Console.Write("Digite a opção desejada: ");
                int opcao = int.Parse(Console.ReadLine());
                if (opcao == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Fechando o programa...");
                    Console.ResetColor();
                    break;
                }
                else if (opcao == 1)
                {
                    Console.Clear();
                    CriarEquipamento(ref indexArrayGeralEquipamentos);
                    MensagemDeSucesso("\nCriação de Equipamento concluída...");
                }
                else if (opcao == 2)
                {
                    Console.Clear();
                    ListarEquipamentos();
                    MensagemDeSucesso("\nListagem de Equipamento concluída...");
                }
                else if (opcao == 3)
                {
                    Console.Clear();
                    EditarEquipamento();
                    MensagemDeSucesso("\nEdição de Equipamento concluída...");
                }
                else if (opcao == 4)
                {
                    Console.Clear();
                    ExcluirEquipamentos(ref indexArrayGeralEquipamentos);
                    MensagemDeSucesso("\nExclusão de Equipamento concluída...");
                }
                else if (opcao == 5)
                {
                    Console.Clear();
                    CriarChamado(ref indexArrayGeralChamados);
                    MensagemDeSucesso("\nCriação de Chamado concluída...");
                }
                else if (opcao == 6)
                {
                    Console.Clear();
                    ListarChamados();
                    MensagemDeSucesso("\nListagem de Chamado concluída...");
                }
                else if (opcao == 7)
                {
                    Console.Clear();
                    EditarChamado();
                    MensagemDeSucesso("\nEdição de Chamado concluída...");
                }
                else if (opcao == 8)
                {
                    Console.Clear();
                    ExcluirChamado(ref indexArrayGeralChamados);
                    MensagemDeSucesso("\nExclusão de Chamado concluída...");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        #region CRUD Chamados
        static void ExcluirChamado(ref int indexArrayGeral)
        {
            Console.WriteLine("Escolha um índice para realizar a exclusão: ");
            int indiceParaExcluir = ListarElementosReceberIndiceChamados();
            if (indiceParaExcluir != -1)
            {
                string[] novosTitulosChamado = new string[indexArrayGeral - 1];
                string[] novasDescricoesChamado = new string[indexArrayGeral - 1];
                int[] novosIndicesChamado = new int[indexArrayGeral - 1];
                DateTime[] novosDataFabricacaoChamado = new DateTime[indexArrayGeral - 1];
                bool[] novasVerificacoesChamado = new bool[indexArrayGeral - 1];
                int j = 0;
                for (int i = 0; i < indexArrayGeral; i++)
                {
                    if (i == indiceParaExcluir)
                    {

                        tituloChamado[i] = "";
                        descricaoChamado[i] = "";
                        indiceEquipamento[i] = 0;
                        dataFabricacaoEquipamento[i] = new DateTime(01 / 01 / 2001);
                        estaEmUmChamado[i] = false;
                        j++;

                    }
                }
            }
            else
            {
                MensagemDeErro("Sem chamados para excluir...");
            }
        }

        static void EditarChamado()
        {
            Console.WriteLine("Escolha um índice para realizar a edição: ");

            int indiceParaEditar = ListarElementosReceberIndiceChamados();
            if (indiceParaEditar != -1)
            {
                Console.Write("Redigite o título do chamado: ");
                tituloChamado[indiceParaEditar] = Console.ReadLine();

                Console.Write("Redigite a descrição do chamado: ");
                descricaoChamado[indiceParaEditar] = Console.ReadLine();

                Console.Write("Redigite o índice do equipamento para o chamado: "); // Exibir equipamentos
                int indiceParaCriarChamado = ListarElementosReceberIndiceEquipamentos();

                indiceEquipamento[indiceParaEditar] = indiceParaCriarChamado;
                estaEmUmChamado[indiceParaCriarChamado] = true;

                Console.Write("Redigite a data de fabricação do chamado (Dia/Mês/Ano): "); // Colocar o tempo atual na hora de criação
                dataAberturaEquipamento[indiceParaEditar] = DateTime.Parse(Console.ReadLine());
            }
            else
            {
                MensagemDeErro("Sem chamados para editar...");
            }
        }

        static void ListarChamados()
        {
            if (VerificarExistenciaChamados())
            {
                Console.WriteLine("Listando chamados: ");
                DateTime diaAtual = DateTime.Today;
                for (int i = 0; i < indexArrayGeralChamados; i++)
                {
                    if (tituloChamado[i] != "")
                    {
                        Console.WriteLine("Índice: " + i);
                        Console.WriteLine($"Título do chamado: {tituloChamado[i]}");
                        Console.WriteLine($"Equipamento: {nomeEquipamento[indiceEquipamento[i]]}");
                        Console.WriteLine($"Nº de dias que o chamado está aberto: {(diaAtual - dataAberturaEquipamento[i]).TotalDays}");
                    }
                }
            }
            else
            {
                MensagemDeErro("Sem chamados para listar...");
            }
        }

        static void CriarChamado(ref int indexArrayGeralChamados)
        {
            if (VerificarExistenciaEquipamentos())
            {
                int indiceParaCriarChamado = ListarElementosReceberIndiceEquipamentos();
                if (indiceParaCriarChamado != -1)
                {
                    Console.WriteLine("\nCriando chamado:");
                    Console.Write("Digite o título do chamado: ");
                    tituloChamado[indexArrayGeralChamados] = Console.ReadLine();

                    Console.Write("Digite a descrição do chamado: ");
                    descricaoChamado[indexArrayGeralChamados] = Console.ReadLine();

                    // Atribuindo equipamento aos indices necessários
                    indiceEquipamento[indexArrayGeralChamados] = indiceParaCriarChamado;
                    estaEmUmChamado[indiceParaCriarChamado] = true;

                    Console.Write("Digite a data de abertura do chamado (Dia/Mês/Ano): "); // Colocar o tempo atual na hora de criação
                    dataAberturaEquipamento[indexArrayGeralChamados] = DateTime.Parse(Console.ReadLine());

                    indexArrayGeralChamados++;
                }
                else
                {
                    MensagemDeErro("Sem equipamentos para criar um chamado...");
                }
            }
            else
            {
                MensagemDeErro("Sem equipamentos para criar um chamado...");
            }

        }

        #endregion

        #region CRUD Equipamentos

        // Anulando todos os valores do índice desejado
        static void ExcluirEquipamentos(ref int indexArrayGeral)
        {
            Console.WriteLine("Escolha um índice para realizar a exclusão: ");
            int indiceParaExcluir = ListarElementosReceberIndiceEquipamentos();
            if (indiceParaExcluir != -1)
            {
                string[] novosNomesEquipamento = new string[indexArrayGeral - 1];
                double[] novosPrecoEquipamento = new double[indexArrayGeral - 1];
                string[] novosNumeroSerieEquipamento = new string[indexArrayGeral - 1];
                DateTime[] novosDataFabricacaoEquipamento = new DateTime[indexArrayGeral - 1];
                string[] novosFabricanteEquipamento = new string[indexArrayGeral - 1];
                bool[] novasVerificacoesChamado = new bool[indexArrayGeral - 1];
                int j = 0;
                for (int i = 0; i < indexArrayGeral; i++)
                {
                    if (i == indiceParaExcluir)
                    {
                        if (estaEmUmChamado[i] == true)
                        {
                            MensagemDeErro("O equipamento está anexado em um chamado, portanto não pode ser excluído...");
                            break;
                        }
                        else
                        {
                            nomeEquipamento[i] = "";
                            precoEquipamento[i] = 0;
                            numeroSerieEquipamento[i] = "";
                            dataFabricacaoEquipamento[i] = new DateTime(01 / 01 / 2001);
                            fabricanteEquipamento[i] = "";
                            estaEmUmChamado[i] = false;
                            j++;
                        }
                    }
                }
            }
            else
            {
                MensagemDeErro("Sem equipamentos para excluir...");
            }
        }

        static void EditarEquipamento()
        {
            Console.WriteLine("Escolha um índice para realizar a edição: ");

            int indiceParaEditar = ListarElementosReceberIndiceEquipamentos();
            if (indiceParaEditar != -1)
            {
                if(nomeEquipamento[indiceParaEditar] != "")
                {
                    Console.Write("\nRedigite o nome do equipamento: ");
                    nomeEquipamento[indiceParaEditar] = Console.ReadLine();

                    Console.Write("Redigite o preço do equipamento: ");
                    precoEquipamento[indiceParaEditar] = double.Parse(Console.ReadLine());

                    Console.Write("Redigite o número de série do equipamento: ");
                    numeroSerieEquipamento[indiceParaEditar] = Console.ReadLine();

                    Console.Write("Redigite a data de fabricação do equipamento (Dia/Mês/Ano): ");
                    dataFabricacaoEquipamento[indiceParaEditar] = DateTime.Parse(Console.ReadLine());

                    Console.Write("Redigite o nome da fabricante do equipamento: ");
                    fabricanteEquipamento[indiceParaEditar] = Console.ReadLine();
                }
                else
                {
                    MensagemDeErro("Índice impossível de editar...");
                }
            }
            else
            {
                MensagemDeErro("Sem equipamentos para editar...");
            }
        }

        static void ListarEquipamentos()
        {
            if (VerificarExistenciaEquipamentos())
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                for (int i = 0; i < indexArrayGeralEquipamentos; i++)
                {
                    if (nomeEquipamento[i] != "")
                    {
                        Console.WriteLine("Índice: " + i);
                        Console.WriteLine($"Nome do Equipamento: {nomeEquipamento[i]}");
                        Console.WriteLine($"Número de série do Equipamento: {numeroSerieEquipamento[i]}");
                        Console.WriteLine($"Fabricante do Equipamento: {fabricanteEquipamento[i]}\n");
                    }
                }
                Console.ResetColor();
            }
            else
            {
                MensagemDeErro("Sem equipamentos para listar...");
            }
        }

        static void CriarEquipamento(ref int indexArrayGeral)
        {
            Console.WriteLine("Criando um equipamento: ");
            while (true)
            {
                Console.Write("Digite o nome do equipamento: ");
                nomeEquipamento[indexArrayGeral] = Console.ReadLine();
                if (nomeEquipamento[indexArrayGeral].Length < 6)
                {
                    Console.WriteLine("Não é possível inserir um nome com menos que 6 caracteres, insira novamente...\n");
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.Write("Digite o preço do equipamento: ");
            precoEquipamento[indexArrayGeral] = double.Parse(Console.ReadLine());

            Console.Write("Digite o número de série do equipamento: ");
            numeroSerieEquipamento[indexArrayGeral] = Console.ReadLine();

            Console.Write("Digite a data de fabricação do equipamento (Dia/Mês/Ano): ");
            dataFabricacaoEquipamento[indexArrayGeral] = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o nome da fabricante do equipamento: ");
            fabricanteEquipamento[indexArrayGeral] = Console.ReadLine();

            estaEmUmChamado[indexArrayGeral] = false;

            indexArrayGeral++;
        }

        #endregion

        #region Verificacoes extras

        static void MensagemDeSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        static void MensagemDeErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        static int ListarElementosReceberIndiceEquipamentos()
        {
            int contadorEquipamentos = 0;
            if (VerificarExistenciaEquipamentos())
            {
                for (int i = 0; i < indexArrayGeralEquipamentos; i++)
                {
                    if (nomeEquipamento[i] != "")
                    {
                        contadorEquipamentos++;
                        Console.WriteLine($"Indice {i}: {nomeEquipamento[i]}");
                    }
                }
                if(contadorEquipamentos > 0)
                {
                    Console.Write("\nDigite o índice desejado: ");
                    int indice = int.Parse(Console.ReadLine());

                    return indice;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        static int ListarElementosReceberIndiceChamados()
        {
            if (VerificarExistenciaChamados())
            {
                for (int i = 0; i < indexArrayGeralChamados; i++)
                {
                    Console.WriteLine($"Índice {i}: {tituloChamado[i]}");
                }
                Console.WriteLine("\nDigite o índice desejado: ");
                int indice = int.Parse(Console.ReadLine());

                return indice;
            }
            else
            {
                return -1;
            }
        }

        static bool VerificarExistenciaChamados()
        {
            if (indexArrayGeralChamados > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool VerificarExistenciaEquipamentos()
        {
            if (indexArrayGeralEquipamentos > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
