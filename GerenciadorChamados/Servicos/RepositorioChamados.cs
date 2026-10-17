using System.Text.Json;
using GerenciadorChamados.Modelos;

namespace GerenciadorChamados.Servicos;

public class RepositorioChamados
{
    private const string Arquivo = "chamados.json";

    public List<Chamado> Carregar()
    {
        if (!File.Exists(Arquivo))
            return new List<Chamado>();

        string json = File.ReadAllText(Arquivo);

        return JsonSerializer.Deserialize<List<Chamado>>(json)
               ?? new List<Chamado>();
    }

    public void Salvar(List<Chamado> chamados)
    {
        string json = JsonSerializer.Serialize(
            chamados,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(Arquivo, json);
    }
}