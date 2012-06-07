Funcionalidade: Adicao de Evento
    Como usuário
    Quero adicionar novos eventos
    Para manter controle sobre meus compromissos

Cenário: Acessando o formulário de novo evento
	Dado que estou na 'página principal'
    Quando eu clicar em 'Novo evento'
    Então devo ser redirecionado para o formulário de 'Novo evento'
    E o seguinte formulário deve ser exibido
    | Rótulo    |
    | Data      |
    | Hora      |
    | Titulo    |
    | Local     |
    | Descricao |

Cenário: Preenchendo o formulário de novo evento
    Dado que estou no 'formulário de Novo evento'
    Quando preencher os campos da seguinte forma
    | Rótulo | Valor     |
    | Data  | 25/3/2012 |
    | Hora  | 12:00     |
    | Titulo    | Aniversário do Zequinha   |
    | Local     | Barranco                  |
    | Descricao | Não esquecer do presente! |
    E eu clicar em 'Salvar Evento'
    Então o evento deve ser armazenado no sistema



    