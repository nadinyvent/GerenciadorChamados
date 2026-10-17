# Gerenciador de Chamados

**Aluno:** Nadiny Venturini da Silva

## Descrição

Este projeto consiste em um sistema de gerenciamento de chamados para uma equipe técnica de suporte, O sistema permite abrir, listar, visualizar e concluir chamados por meio do Console, mantendo os dados armazenados em um arquivo JSON.

## Como compilar e executar

Abra o terminal na pasta do projeto e execute:

```bash
dotnet run
```

## Estrutura das classes

### Chamado

Representa um chamado do sistema, contendo:

* Número (Id)
* Descrição
* Status
* Data de abertura
* Data de conclusão

Também possui o método `Concluir()`, responsável por finalizar um chamado.

### StatusChamado

Enum que representa os possíveis estados de um chamado:

* Aberto
* Concluído

### GerenciadorDeChamados

Responsável pelas regras de negócio do sistema.

Principais métodos:

* AbrirChamado()
* ListarTodos()
* ObterPorId()
* ConcluirChamado()

### RepositorioChamados

Responsável pela persistência dos dados em um arquivo `chamados.json`.

Principais métodos:

* Carregar()
* Salvar()

### Menu

Responsável pela interface do usuário no Console, exibindo o menu principal e as telas de criação, listagem e visualização dos chamados.


** :)