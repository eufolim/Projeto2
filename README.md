Integração - Documento de Requisitos

1. Propósito do Sistema
O objetivo do sistema é gerenciar condomínios de forma eficiente, permitindo o controle centralizado de informações relacionadas às residências, moradores e taxas de condomínio. O sistema será desenvolvido com arquitetura de microsserviços para garantir modularidade e escalabilidade. Ele permitirá o cadastro e consulta de informações essenciais e manterá as interações entre os microsserviços para sincronizar dados em tempo real.

2. Quais são os Usuários?
O sistema atenderá aos seguintes tipos de usuários:

  Administradores do Condomínio:
   - Usuários responsáveis por gerenciar o cadastro de residências, moradores e taxas de condomínio.
   - Realizam consultas, atualizações e validações dos dados.

   Síndicos:
   - Usuários que acompanham o status de residências e dívidas associadas aos moradores para facilitar a administração do condomínio.

3. Requisitos Funcionais

Microsserviço de Residências:

 Permitir o cadastro, consulta, atualização e exclusão de residências.

 Cada residência deverá ter os seguintes atributos:
   - ID único.
   - Endereço.
   - Status (ativa/inativa).
   - ID do morador associado.

Microsserviço de Moradores:

  Permitir o cadastro, consulta, atualização e exclusão de moradores.

  Cada morador deverá ter os seguintes atributos:
   - ID único.
   - Nome completo.
   - CPF.
   - ID da residência associada.
   - Saldo de dívida atualizado.

Microsserviço de Taxa de Condomínio:

 Permitir o cadastro, consulta, atualização e exclusão de taxas de condomínio.

 Cada taxa deverá ter os seguintes atributos:
   - ID único.
   - Valor da taxa.
   - ID da residência associada.
   - Data de vencimento.

 Ao cadastrar uma nova taxa, verificar se a residência está ativa (integração com o Microsserviço de Residências).

 Atualizar o saldo de dívida do morador ao cadastrar uma nova taxa (integração com o Microsserviço de Moradores).

Integrações Entre os Microsserviços:

 Consulta de Dados Simples:
   - Ao buscar uma residência, exibir os dados do morador associado (integração entre Microsserviço de Residências e Microsserviço de Moradores).
   - Ao cadastrar uma taxa, validar se a residência associada está ativa (integração entre Microsserviço de Taxa de Condomínio e Microsserviço de Residências).

 Alteração de Dados:
   - Ao cadastrar uma taxa de condomínio, o valor correspondente será adicionado ao saldo de dívida do morador associado (integração entre Microsserviço de Taxa de Condomínio e Microsserviço de Moradores).
