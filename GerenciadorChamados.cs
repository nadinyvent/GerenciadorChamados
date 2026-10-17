using GerenciadorChamados.Modelos;

namespace GerenciadorChamados.Servicos;

public class GerenciadorChamados
{
    private readonly List<Chamado> chamados;

    public GerenciadorChamados(List<Chamado> chamados)
    {
        this.chamados = chamados;
    }

    public Chamado AbrirChamado(string descricao)
    {
        int novoId =
            chamados.Count == 0
            ? 1
            : chamados.Max(c => c.Id) + 1;

        Chamado chamado =
            new Chamado(novoId, descricao);

        chamados.Add(chamado);

        return chamado;
    }

    public List<Chamado> ListarTodos()
    {
        return chamados;
    }

    public Chamado? ObterPorId(int id)
    {
        return chamados.FirstOrDefault(c => c.Id == id);
    }

    public void ConcluirChamado(int id)
    {
        Chamado? chamado = ObterPorId(id);

        if (chamado != null)
            chamado.Concluir();
    }
}