using GerenciadorChamados.Modelos;
using GerenciadorChamados.Servicos;

namespace GerenciadorChamados.Telas;

public class Menu
{
    private readonly GerenciadorDeChamados gerenciador;
    private readonly RepositorioChamados repositorio;

    public Menu(GerenciadorDeChamados gerenciador,
                RepositorioChamados repositorio)
    {
        this.gerenciador = gerenciador;
        this.repositorio = repositorio;
    }

    public void Iniciar()
    {
        bool executando = true;

        while (executando)
        {
            Console.Clear();

            Console.WriteLine("=== MENU PRINCIPAL ===");
            Console.WriteLine("1 - Abrir chamado");
            Console.WriteLine("2 - Listar chamados");
            Console.WriteLine("3 - Visualizar chamado");
            Console.WriteLine("4 - Sair");

            Console.Write("\nOpção: ");

            string? opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AbrirChamado();
                    break;

                case "2":
                    ListarChamados();
                    break;

                case "3":
                    VisualizarChamado();
                    break;

                case "4":
                    executando = false;
                    break;

                default:
                    Console.WriteLine("\nOpção inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void AbrirChamado()
    {
        Console.Clear();

        Console.WriteLine("=== NOVO CHAMADO ===");

        Console.Write("\nDescrição: ");

        string? descricao = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(descricao))
        {
            Console.WriteLine("\nDescrição inválida.");
            Console.ReadKey();
            return;
        }

        gerenciador.AbrirChamado(descricao);

        repositorio.Salvar(gerenciador.ListarTodos());

        Console.WriteLine("\nChamado criado com sucesso!");
        Console.ReadKey();
    }

    private void ListarChamados()
    {
        Console.Clear();

        Console.WriteLine("=== CHAMADOS ===\n");

        foreach (Chamado chamado in gerenciador.ListarTodos())
        {
            Console.WriteLine($"número: {chamado.Id}");
            Console.WriteLine($"Status: {chamado.Status}");
            Console.WriteLine($"Descrição: {chamado.Descricao}");
            Console.WriteLine("----------------------------");
        }

        Console.ReadKey();
    }

    private void VisualizarChamado()
    {
        Console.Clear();

        Console.Write("Informe o número do chamado: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("número inválido.");
            Console.ReadKey();
            return;
        }

        Chamado? chamado = gerenciador.ObterPorId(id);

        if (chamado == null)
        {
            Console.WriteLine("Chamado não encontrado.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"\nID: {chamado.Id}");
        Console.WriteLine($"Descrição: {chamado.Descricao}");
        Console.WriteLine($"Status: {chamado.Status}");
        Console.WriteLine($"Data abertura: {chamado.DataAbertura}");

        if (chamado.DataConclusao != null)
            Console.WriteLine($"Data conclusão: {chamado.DataConclusao}");

        if (chamado.Status == StatusChamado.Aberto)
        {
            Console.Write("\nConcluir chamado? (S/N): ");

            string? resposta = Console.ReadLine();

            if (resposta?.ToUpper() == "S")
            {
                gerenciador.ConcluirChamado(id);

                repositorio.Salvar(gerenciador.ListarTodos());

                Console.WriteLine("\nChamado concluído.");
            }
        }

        Console.ReadKey();
    }
}