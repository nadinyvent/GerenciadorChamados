namespace GerenciadorChamados.Modelos;

public class Chamado
{
    public int Id { get; set; }

    public string Descricao { get; set; }

    public StatusChamado Status { get; set; }

    public DateTime DataAbertura { get; set; }

    public DateTime? DataConclusao { get; set; }

    public Chamado()
    {
    }

    public Chamado(int id, string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("Descrição inválida.");

        Id = id;
        Descricao = descricao;
        Status = StatusChamado.Aberto;
        DataAbertura = DateTime.Now;
        DataConclusao = null;
    }

    public void Concluir()
    {
        if (Status == StatusChamado.Concluido)
            return;

        Status = StatusChamado.Concluido;
        DataConclusao = DateTime.Now;
    }
}