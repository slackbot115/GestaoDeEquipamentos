using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        #region Variáveis principais
        static int indexArrayGeralEquipamentos = 0;
        static int indexArrayGeralChamados = 0;
        static int indexArrayGeralSolicitantes = 0;

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
        static bool[] temUmSolicitante = new bool[1000];
        static int[] indiceSolicitante = new int[1000];
        static bool[] estaAberto = new bool[1000];

        // Variáveis para solicitantes
        static string[] nomeSolicitante = new string[1000];
        static string[] emailSolicitante = new string[1000];
        static string[] telefoneSolicitante = new string[1000];
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Gestão de Equipamentos");
            while (true)
            {
                Console.WriteLine("1 - Menu de Equipamentos\n2 - Menu de Chamados\n3 - Menu de Solicitantes\n0 - Sair");
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
                    Console.WriteLine("1 - Criar equipamento\n2 - Listar equipamentos\n3 - Editar equipamento\n4 - Excluir equipamento\n0 - Voltar");
                    Console.Write("Opção: ");
                    int menuOpcao = int.Parse(Console.ReadLine());
                    switch (menuOpcao)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Voltando...");
                            Console.ResetColor();
                            break;
                        case 1:
                            Console.Clear();
                            CriarEquipamento(ref indexArrayGeralEquipamentos);
                            MensagemDeSucesso("\nCriação de Equipamento concluída...");
                            break;
                        case 2:
                            Console.Clear();
                            ListarEquipamentos();
                            MensagemDeSucesso("\nListagem de Equipamentos concluída...");
                            break;
                        case 3:
                            Console.Clear();
                            EditarEquipamento();
                            MensagemDeSucesso("\nEdição de Equipamento concluída...");
                            break;
                        case 4:
                            Console.Clear();
                            ExcluirEquipamentos(ref indexArrayGeralEquipamentos);
                            MensagemDeSucesso("\nExclusão de Equipamento concluída...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida...");
                            break;
                    }
                }
                else if (opcao == 2)
                {
                    Console.WriteLine("1 - Criar chamado\n2 - Listar chamados\n3 - Editar chamado\n4 - Excluir chamado\n5 - Editar equipamento em um chamado\n0 - Voltar");
                    Console.Write("Opção: ");
                    int menuOpcao = int.Parse(Console.ReadLine());

                    switch (menuOpcao)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Voltando...");
                            Console.ResetColor();
                            break;
                        case 1:
                            Console.Clear();
                            CriarChamado(ref indexArrayGeralChamados);
                            MensagemDeSucesso("\nCriação de Chamado concluída...");
                            break;
                        case 2:
                            Console.Clear();
                            ListarChamados();
                            MensagemDeSucesso("\nListagem de Chamados concluída...");
                            break;
                        case 3:
                            Console.Clear();
                            EditarChamado();
                            MensagemDeSucesso("\nEdição de Chamado concluída...");
                            break;
                        case 4:
                            Console.Clear();
                            ExcluirChamado(ref indexArrayGeralChamados);
                            MensagemDeSucesso("\nExclusão de Chamado concluída...");
                            break;
                        case 5:
                            Console.Clear();
                            EditarEquipamentoEmChamado();
                            MensagemDeSucesso("\nEquipamento editado com sucesso...");
                            break;
                        case 6:
                            Console.Clear();
                            AlterarStatusChamado();
                            MensagemDeSucesso("\nStatus do Chamado editado com sucesso...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida...");
                            break;
                    }
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("1 - Criar solicitante\n2 - Listar solicitantes\n3 - Editar solicitante\n4 - Excluir solicitante\n5 - Adicionar solicitante em um chamado\n6 - Editar solicitante em um chamado\n0 - Voltar");
                    Console.Write("Opção: ");
                    int menuOpcao = int.Parse(Console.ReadLine());

                    switch (menuOpcao)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Voltando...");
                            Console.ResetColor();
                            break;
                        case 1:
                            Console.Clear();
                            CriarSolicitante(ref indexArrayGeralSolicitantes);
                            MensagemDeSucesso("\nCriação de Solicitante concluída...");
                            break;
                        case 2:
                            Console.Clear();
                            ListarSolicitante();
                            MensagemDeSucesso("\nListagem de Solicitantes concluída...");
                            break;
                        case 3:
                            Console.Clear();
                            EditarSolicitante();
                            MensagemDeSucesso("\nEdição de Solicitante concluída...");
                            break;
                        case 4:
                            Console.Clear();
                            ExcluirSolicitante(ref indexArrayGeralSolicitantes);
                            MensagemDeSucesso("\nExclusão de Solicitante concluída...");
                            break;
                        case 5:
                            Console.Clear();
                            AdicionarSolicitanteEmChamado();
                            MensagemDeSucesso("\nSolicitante adicionado com sucesso...");
                            break;
                        case 6:
                            Console.Clear();
                            EditarSolicitanteEmChamado();
                            MensagemDeSucesso("\nSolicitante editado com sucesso...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida...");
                            break;
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        #region CRUD Solicitantes

        static void ExcluirSolicitante(ref int indexArrayGeral)
        {
            Console.WriteLine("Escolha um índice para realizar a exclusão: ");
            int indiceParaExcluir = ListarElementosReceberIndiceSolicitantes();
            if (indiceParaExcluir != -1)
            {
                for (int i = 0; i < indexArrayGeral; i++)
                {
                    if (i == indiceParaExcluir)
                    {
                        nomeSolicitante[i] = "";
                        emailSolicitante[i] = "";
                        telefoneSolicitante[i] = "";
                    }
                }
            }
            else
            {
                MensagemDeErro("Sem solicitantes para excluir...");
            }
        }

        static void EditarSolicitante()
        {
            Console.WriteLine("Escolha um índice para realizar a edição: ");

            int indiceParaEditar = ListarElementosReceberIndiceSolicitantes();
            if (indiceParaEditar != -1)
            {
                if (nomeSolicitante[indiceParaEditar] != "")
                {
                    Console.Write("\nRedigite o nome do solicitante: ");
                    nomeSolicitante[indiceParaEditar] = Console.ReadLine();

                    Console.Write("Redigite o email do equipamento: ");
                    emailSolicitante[indiceParaEditar] = Console.ReadLine();

                    Console.Write("Redigite o telefone do solicitante: ");
                    telefoneSolicitante[indiceParaEditar] = Console.ReadLine();

                }
                else
                {
                    MensagemDeErro("Índice impossível de editar...");
                }
            }
            else
            {
                MensagemDeErro("Sem solicitantes para editar...");
            }
        }

        static void ListarSolicitante()
        {
            if (VerificarExistenciaSolicitantes())
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                for (int i = 0; i < indexArrayGeralSolicitantes; i++)
                {
                    if (nomeSolicitante[i] != "")
                    {
                        Console.WriteLine("ID: " + i);
                        Console.WriteLine($"Nome do Solicitante: {nomeSolicitante[i]}");
                        Console.WriteLine($"Email: {emailSolicitante[i]}");
                        Console.WriteLine($"Telefone: {telefoneSolicitante[i]}\n");
                    }
                }
                Console.ResetColor();
            }
            else
            {
                MensagemDeErro("Sem solicitantes para listar...");
            }
        }

        static void CriarSolicitante(ref int indexArrayGeral)
        {
            Console.WriteLine("Criando um solicitante: ");
            while (true)
            {
                Console.Write("Digite o nome do solicitante: ");
                nomeSolicitante[indexArrayGeral] = Console.ReadLine();
                if (nomeSolicitante[indexArrayGeral].Length < 6)
                {
                    Console.WriteLine("Não é possível inserir um nome com menos que 6 caracteres, insira novamente...\n");
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.Write("Digite o email do solicitante: ");
            emailSolicitante[indexArrayGeral] = Console.ReadLine();

            Console.Write("Digite o número de telefone do solicitante: ");
            telefoneSolicitante[indexArrayGeral] = Console.ReadLine();

            indexArrayGeral++;
        }

        #endregion

        #region CRUD Chamados

        static void AlterarStatusChamado()
        {
            if (VerificarExistenciaChamados())
            {
                int indiceParaEditarChamado = ListarElementosReceberIndiceChamados();
                if (indiceParaEditarChamado != -1)
                {
                    // Atribuindo solicitante aos indices necessários
                    if (estaAberto[indiceParaEditarChamado] == true)
                    {
                        estaAberto[indiceParaEditarChamado] = false;
                    }
                    else
                    {
                        estaAberto[indiceParaEditarChamado] = true;
                    }
                }
                else
                {
                    MensagemDeErro("Sem chamados para alterar um equipamento...");
                }
            }
        }

        static void EditarEquipamentoEmChamado()
        {
            if (VerificarExistenciaChamados())
            {
                int indiceParaEditarChamado = ListarElementosReceberIndiceChamados();
                if (indiceParaEditarChamado != -1)
                {
                    Console.WriteLine("\nAlterando equipamento do chamado...");
                    int indiceParaReceberEquipamento = ListarElementosReceberIndiceEquipamentos();
                    if (indiceParaReceberEquipamento != -1)
                    {
                        // Atribuindo solicitante aos indices necessários
                        indiceEquipamento[indiceParaEditarChamado] = indiceParaReceberEquipamento;
                    }
                    else
                    {
                        MensagemDeErro("Sem chamados para alterar um solicitante...");
                    }
                }
                else
                {
                    MensagemDeErro("Sem chamados para alterar um equipamento...");
                }
            }
            else
            {
                MensagemDeErro("Sem chamados para alterar um equipamento...");
            }
        }

        static void EditarSolicitanteEmChamado()
        {
            if (VerificarExistenciaChamados())
            {
                int indiceParaEditarChamado = ListarElementosReceberIndiceChamados();
                if (indiceParaEditarChamado != -1)
                {
                    Console.WriteLine("\nAlterando solicitante do chamado...");
                    int indiceParaReceberSolicitante = ListarElementosReceberIndiceSolicitantes();
                    if (indiceParaReceberSolicitante != -1)
                    {
                        // Atribuindo solicitante aos indices necessários
                        indiceSolicitante[indiceParaEditarChamado] = indiceParaReceberSolicitante;
                    }
                    else
                    {
                        MensagemDeErro("Sem solicitantes para adicionar em um chamado...");
                    }
                }
                else
                {
                    MensagemDeErro("Sem chamados para adicionar um solicitante...");
                }
            }
            else
            {
                MensagemDeErro("Sem chamados para adicionar um solicitante...");
            }
        }

        static void AdicionarSolicitanteEmChamado()
        {
            if (VerificarExistenciaChamados())
            {
                int indiceParaEditarChamado = ListarElementosReceberIndiceChamados();
                if (indiceParaEditarChamado != -1)
                {
                    if (temUmSolicitante[indiceParaEditarChamado] == false)
                    {
                        Console.WriteLine("\nAdicionando solicitante ao chamado...");
                        int indiceParaReceberSolicitante = ListarElementosReceberIndiceSolicitantes();
                        if (indiceParaReceberSolicitante != -1)
                        {
                            // Atribuindo solicitante aos indices necessários
                            indiceSolicitante[indiceParaEditarChamado] = indiceParaReceberSolicitante;
                            temUmSolicitante[indiceParaEditarChamado] = true;
                        }
                        else
                        {
                            MensagemDeErro("Sem solicitantes para adicionar em um chamado...");
                        }
                    }
                    else
                    {
                        MensagemDeErro("Este chamado já possui um solicitante...");
                    }
                }
                else
                {
                    MensagemDeErro("Sem solicitantes para adicionar em um chamado...");
                }
            }
            else
            {
                MensagemDeErro("Sem chamados para adicionar um solicitante...");
            }
        }

        static void ExcluirChamado(ref int indexArrayGeral)
        {
            Console.WriteLine("Escolha um índice para realizar a exclusão: ");
            int indiceParaExcluir = ListarElementosReceberIndiceChamados();
            if (indiceParaExcluir != -1)
            {
                if (estaAberto[indiceParaExcluir] == false)
                {
                    for (int i = 0; i < indexArrayGeral; i++)
                    {
                        if (i == indiceParaExcluir)
                        {

                            tituloChamado[i] = "";
                            descricaoChamado[i] = "";
                            indiceEquipamento[i] = 0;
                            dataFabricacaoEquipamento[i] = new DateTime(01 / 01 / 2001);
                            estaEmUmChamado[i] = false;
                        }
                    }
                }
                else
                {
                    MensagemDeErro("O chamado não pode ser excluído pois ainda está aberto...");
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

                Console.Write("Redigite a data de fabricação do chamado (Dia/Mês/Ano): ");
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

                Console.Write("\nChamados abertos estão em ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("verde");
                Console.ResetColor();
                Console.WriteLine();

                Console.Write("\nChamados fechados estão em ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("vermelho");
                Console.ResetColor();
                Console.WriteLine("\n");

                for (int i = 0; i < indexArrayGeralChamados; i++)
                {
                    if (tituloChamado[i] != "" && estaAberto[i] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (temUmSolicitante[i] != false)
                        {
                            Console.WriteLine("Índice: " + i);
                            Console.WriteLine($"Título do chamado: {tituloChamado[i]}");
                            Console.WriteLine($"Equipamento: {nomeEquipamento[indiceEquipamento[i]]}");
                            Console.WriteLine($"Nº de dias que o chamado está aberto: {(diaAtual - dataAberturaEquipamento[i]).TotalDays}");
                            Console.WriteLine($"Solicitante: {nomeSolicitante[indiceSolicitante[i]]}");
                        }
                        else
                        {
                            Console.WriteLine("Índice: " + i);
                            Console.WriteLine($"Título do chamado: {tituloChamado[i]}");
                            Console.WriteLine($"Equipamento: {nomeEquipamento[indiceEquipamento[i]]}");
                            Console.WriteLine($"Nº de dias que o chamado está aberto: {(diaAtual - dataAberturaEquipamento[i]).TotalDays}");
                        }
                        Console.ResetColor();
                    }
                    else if (tituloChamado[i] != "" && estaAberto[i] == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (temUmSolicitante[i] != false)
                        {
                            Console.WriteLine("Índice: " + i);
                            Console.WriteLine($"Título do chamado: {tituloChamado[i]}");
                            Console.WriteLine($"Equipamento: {nomeEquipamento[indiceEquipamento[i]]}");
                            Console.WriteLine($"Nº de dias que o chamado está aberto: {(diaAtual - dataAberturaEquipamento[i]).TotalDays}");
                            Console.WriteLine($"Solicitante: {nomeSolicitante[indiceSolicitante[i]]}");
                        }
                        else
                        {
                            Console.WriteLine("Índice: " + i);
                            Console.WriteLine($"Título do chamado: {tituloChamado[i]}");
                            Console.WriteLine($"Equipamento: {nomeEquipamento[indiceEquipamento[i]]}");
                            Console.WriteLine($"Nº de dias que o chamado está aberto: {(diaAtual - dataAberturaEquipamento[i]).TotalDays}");
                        }
                        Console.ResetColor();
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
                int indiceParaInserirEquipamento = ListarElementosReceberIndiceEquipamentos();
                if (indiceParaInserirEquipamento != -1)
                {
                    Console.WriteLine("\nCriando chamado:");
                    Console.Write("Digite o título do chamado: ");
                    tituloChamado[indexArrayGeralChamados] = Console.ReadLine();

                    Console.Write("Digite a descrição do chamado: ");
                    descricaoChamado[indexArrayGeralChamados] = Console.ReadLine();

                    // Atribuindo equipamento aos indices necessários
                    indiceEquipamento[indexArrayGeralChamados] = indiceParaInserirEquipamento;
                    estaEmUmChamado[indiceParaInserirEquipamento] = true;

                    Console.Write("Digite a data de abertura do chamado (Dia/Mês/Ano): ");
                    dataAberturaEquipamento[indexArrayGeralChamados] = DateTime.Parse(Console.ReadLine());

                    estaAberto[indexArrayGeralChamados] = true;

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
                if (nomeEquipamento[indiceParaEditar] != "")
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

        static int ListarElementosReceberIndiceSolicitantes()
        {
            int contadorSolicitantes = 0;
            if (VerificarExistenciaSolicitantes())
            {
                for (int i = 0; i < indexArrayGeralSolicitantes; i++)
                {
                    if (nomeSolicitante[i] != "")
                    {
                        contadorSolicitantes++;
                        Console.WriteLine($"Indice {i}: {nomeSolicitante[i]}");
                    }
                }
                if (contadorSolicitantes > 0)
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
                if (contadorEquipamentos > 0)
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

        static bool VerificarExistenciaSolicitantes()
        {
            if (indexArrayGeralSolicitantes > 0)
            {
                return true;
            }
            else
            {
                return false;
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
