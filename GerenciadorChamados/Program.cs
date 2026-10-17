using GerenciadorChamados.Modelos;
using GerenciadorChamados.Servicos;
using GerenciadorChamados.Telas;

RepositorioChamados repositorio = new();

List<Chamado> chamados =
    repositorio.Carregar();

GerenciadorDeChamados gerenciador =
    new GerenciadorDeChamados(chamados);

Menu menu =
    new Menu(gerenciador, repositorio);

menu.Iniciar();