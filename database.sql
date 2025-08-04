-- Criação do banco de dados
CREATE DATABASE IF NOT EXISTS produtivity;

-- Conectar ao banco de dados
\c produtivity;

CREATE TABLE IF NOT EXISTS processos (
    id_processo INTEGER PRIMARY KEY,
    nome_processo VARCHAR(8) NOT NULL,
);

INSERT INTO processos (id_processo, nome_processo) VALUES
(1, 'CORE'),
(2, 'LIDE'),
(3, 'REN'),
(4, 'EMEG');

CREATE TABLE IF NOT EXISTS projetos (
    id_projeto INTEGER PRIMARY KEY,
    nome_projeto VARCHAR(16) NOT NULL,
    id_processo INTEGER REFERENCES processos(id_processo)
);

INSERT INTO projetos (id_projeto, nome_projeto, id_processo) VALUES
(1, 'CORTE', 1),
(2, 'RELIGA', 1),
(3, 'LIDE', 2),
(4, 'ANEXO', 2),
(5, 'AFERICAO', 2),
(6, 'INSPECAO', 3),
(7, 'EXTERNALIZACAO', 3),
(8, 'MODERNIZACAO', 3),
(9, 'MANUTENCAO', 3),
(10, 'PQM', 4),
(11, 'EMERGENCIA', 4),
(12, 'MANOBRA', 4);

CREATE TABLE IF NOT EXISTS atividades (
    id_atividade INTEGER PRIMARY KEY,
    nome_atividade VARCHAR(32) NOT NULL,
    eh_caminhao BOOLEAN DEFAULT FALSE,
    eh_metade BOOLEAN DEFAULT FALSE,
    eh_especial BOOLEAN DEFAULT FALSE,
    id_projeto INTEGER REFERENCES projetos(id_projeto)
);

INSERT INTO atividades (id_atividade, nome_atividade, eh_caminhao, eh_metade, eh_especial, id_projeto) VALUES
(1, 'CORTE', FALSE, FALSE, FALSE, 1),
(2, 'CORTE PILOTO', FALSE, FALSE, FALSE, 1),
(3, 'CORTE ESPECIAL', FALSE, FALSE, FALSE, 1),
(4, 'RELIGA', FALSE, FALSE, FALSE, 2),
(5, 'RELIGA POSTO', FALSE, FALSE, FALSE, 2),
(6, 'RELIGA CAMINHÃO', TRUE, FALSE, FALSE, 2),
(7, 'LIDE', FALSE, FALSE, FALSE, 3),
(8, 'LIDE VISTORIADOR', FALSE, TRUE, FALSE, 3),
(9, 'LIDE PESADO', TRUE, FALSE, TRUE, 3),
(10, 'ANEXO IV', FALSE, FALSE, FALSE, 4),
(11, 'ANEXO IV VISTORIADOR', FALSE, TRUE, TRUE, 4),
(12, 'ANEXO IV PESADO', TRUE, FALSE, FALSE, 4),
(13, 'EMERGÊNCIA', FALSE, FALSE, TRUE, 11),
(14, 'PQM', FALSE, FALSE,  FALSE, 10),
(15, 'ATENDIMENTO COLETIVO', FALSE, FALSE, FALSE, 11),
(16, 'CONVENCIONAL', FALSE, FALSE, FALSE, 6),
(17, 'EXTERNALIZAÇÃO', FALSE, FALSE, FALSE, 7),
(18, 'LABORATÓRIO', FALSE, TRUE, FALSE, 3),
(19, 'CORTE OSDC', FALSE, FALSE, FALSE, 1),
(20, 'BAIXA RENDA', FALSE, FALSE, FALSE, 1),
(21, 'MANUTENÇÃO BT', FALSE, FALSE, FALSE, 9),
(22, 'MEDIDOR OBSOLETO', FALSE, FALSE, FALSE, 8);

CREATE TABLE IF NOT EXISTS contratos (
    id_contrato INTEGER PRIMARY KEY,
    contrato INTEGER NOT NULL,
    aditivo INTEGER NOT NULL,
    inicio_vigencia DATE NOT NULL,
    final_vigencia DATE DEFAULT '9999-12-31'
);

CREATE TABLE IF NOT EXISTS contrato_atividade (
    id_contrato_atividade INTEGER PRIMARY KEY,
    id_contrato INTEGER REFERENCES contratos(id_contrato),
    id_atividade INTEGER REFERENCES atividades(id_atividade),
    inicio_vigencia DATE NOT NULL,
    final_vigencia DATE DEFAULT '9999-12-31'
);

CREATE TABLE IF NOT EXISTS objetivos (
    id_objetivo INTEGER PRIMARY KEY,
    eh_caminhao BOOLEAN DEFAULT FALSE,
    eh_metade BOOLEAN DEFAULT FALSE,
    mensal_valor_meta NUMERIC DEFAULT 0,
    mensal_divisor_fixo NUMERIC DEFAULT 0,
    meta_apresentacao_util INTEGER DEFAULT 0,
    meta_apresentacao_feriado INTEGER DEFAULT 0,
    meta_execucoes_diaria INTEGER DEFAULT 0,
    id_contrato INTEGER REFERENCES contratos(id_contrato),
    id_projeto INTEGER REFERENCES projetos(id_projeto)
);

CREATE TABLE IF NOT EXISTS funcionario_situacoes (
    id_funcionario_situacao INTEGER PRIMARY KEY,
    nome_funcionario_situacao VARCHAR(16) NOT NULL
);

INSERT INTO funcionario_situacoes (id_funcionario_situacao, nome_funcionario_situacao) VALUES
(1, 'ativo'),
(2, 'inss'),
(3, 'ferias'),
(4, 'suspenso'),
(5, 'desligado');

CREATE TABLE IF NOT EXISTS funcionario_funcoes (
    id_funcionario_funcao INTEGER PRIMARY KEY,
    nome_funcionario_funcao VARCHAR(16) NOT NULL
);

INSERT INTO funcionario_funcoes (id_funcionario_funcao, nome_funcionario_funcao) VALUES
(1, 'eletricista'),
(2, 'supervisor'),
(3, 'administrativo'),
(4, 'supervisor lider'),
(5, 'coordenador');

CREATE TABLE IF NOT EXISTS funcionarios (
    id_funcionario INTEGER PRIMARY KEY,
    matricula_indica INTEGER NOT NULL,
    matricula_cliente INTEGER NOT NULL,
    nome_funcionario VARCHAR(128) NOT NULL,
    data_admissao DATE NOT NULL,
    data_demissao DATE DEFAULT NULL,
    id_funcionario_situacao INTEGER REFERENCES funcionario_situacoes(id_funcionario_situacao),
    id_funcionario_funcao INTEGER REFERENCES funcionario_funcoes(id_funcionario_funcao)
);

CREATE TABLE IF NOT EXISTS composicao_regionais (
    id_composicao_regional INTEGER PRIMARY KEY,
    nome_composicao_regional VARCHAR(16) NOT NULL
);

INSERT INTO composicao_regionais (id_composicao_regional, nome_composicao_regional) VALUES
(1, 'oeste'), (2, 'baixada');

CREATE TABLE IF NOT EXISTS composicao_funcoes (
    id_composicao_funcao INTEGER PRIMARY KEY,
    nome_composicao_funcao VARCHAR(16) NOT NULL
);

INSERT INTO composicao_funcoes (id_composicao_funcao, nome_composicao_funcao) VALUES
(1, 'supervisor'),
(2, 'executor1'),
(3, 'executor2'),
(4, 'executor3');

CREATE TABLE IF NOT EXISTS composicoes (
    id_composicao INTEGER PRIMARY KEY,
    dia DATE NOT NULL,
    ordem INTEGER NOT NULL,
    placa VARCHAR(8) NOT NULL,
    recurso VARCHAR(32) NOT NULL,
    telefone INTEGER NOT NULL,
    eh_considerado BOOLEAN DEFAULT TRUE,
    eh_especial BOOLEAN DEFAULT FALSE,
    id_atividade INTEGER REFERENCES atividades(id_atividade),
    id_regional INTEGER REFERENCES regionais(id_regional)
);

CREATE TABLE IF NOT EXISTS equipes (
    id_equipe INTEGER PRIMARY KEY,
    id_composicao INTEGER REFERENCES composicao(id_composicao),
    id_funcionario INTEGER REFERENCES funcionario(id_funcionario),
    id_composicao_funcao INTEGER REFERENCES composicao_funcao(id_composicao_funcao)
);

CREATE TABLE IF NOT EXISTS mestres (
    id_mestre INTEGER PRIMARY KEY,
    mestre INTEGER NOT NULL,
    descricao VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS pagamentos (
    id_pagamento INTEGER PRIMARY KEY,
    eh_caminhao BOOLEAN DEFAULT FALSE,
    eh_especial BOOLEAN DEFAULT FALSE,
    id_contrato INTEGER REFERENCES contrato(id_contrato),
    id_projeto INTEGER REFERENCES projetos(id_projeto),
    id_mestre INTEGER REFERENCES mestres(id_mestre),
    valoracao DECIMAL(6,2) NOT NULL
);

CREATE TABLE IF NOT EXISTS finalizacao_categorias (
    id_finalizacao_categoria INTEGER PRIMARY KEY,
    nome_finalizacao_categoria VARCHAR(16) NOT NULL,
    eh_executado BOOLEAN DEFAULT TRUE
);

INSERT INTO finalizacao_categorias (id_finalizacao_categoria, nome_finalizacao_categoria, eh_executado) VALUES
(1, 'EXEC', TRUE),
(2, 'CAPEX', TRUE),
(3, 'OPEX', TRUE),
(4, 'PGMQ', TRUE),
(5, 'VIST', TRUE),
(6, 'TOI', TRUE),
(7, 'NORM', TRUE),
(7, 'NA', TRUE),
(8, 'NI', FALSE),
(10, 'ELIG', FALSE),
(11, 'NEXE', FALSE),
(12, 'S_MD', TRUE),
(13, 'S_RM', TRUE),
(14, 'PROD', TRUE),
(15, 'IMPR', FALSE),
(99, 'ERRO', FALSE);

CREATE TABLE IF NOT EXISTS finalizacoes (
    id_finalizacao INTEGER PRIMARY KEY,
    agrupamento_medidas VARCHAR(128) NOT NULL,
    id_categoria INTEGER REFERENCES categorias(id_categoria)
);

CREATE TABLE IF NOT EXISTS finalizacoes_pagamento (
    id_finalizacao_pagamento INTEGER PRIMARY KEY,
    id_finalizacao INTEGER REFERENCES finalizacoes(id_finalizacao),
    id_mestre INTEGER REFERENCES mestres(id_mestre)
);

CREATE TABLE IF NOT EXISTS dano_projeto (
    id_dano_projeto INTEGER PRIMARY KEY,
    nome_dano_projeto VARCHAR(4) NOT NULL,
    texto_breve_para_dano VARCHAR(64) NOT NULL,
    id_projeto INTEGER REFERENCES projetos(id_projeto)
);

INSERT INTO dano_projeto (id_dano_projeto, nome_dano_projeto, texto_breve_para_dano, id_projeto) VALUES
(1, '0001', 'Início de turno', 0),
(2, '0002', 'Intervalo para almoço', 0),
(3, '0003', 'Indisponibilidade', 0),
(4, '0004', 'Retorno para base', 0);


CREATE TABLE IF NOT EXISTS codigo_filtragem (
    id_codigo_filtragem INTEGER PRIMARY KEY,
    nome_codigo_filtragem VARCHAR(4) NOT NULL,
    id_projeto INTEGER REFERENCES projetos(id_projeto)
);

CREATE TABLE IF NOT EXISTS servico_situacao (
    id_servico_situacao INTEGER PRIMARY KEY,
    nome_servico_situacao VARCHAR(16) NOT NULL
);

INSERT INTO servico_situacao (id_servico_situacao, nome_servico_situacao) VALUES
(1, 'pendente'), (2, 'em rota'), (3, 'iniciado'),
(4, 'concluído'), (5, 'não concluído'), (6, 'cancelado');

CREATE TABLE IF NOT EXISTS servico_fases (
    id_servico_fase INTEGER PRIMARY KEY,
    nome_servico_fase VARCHAR(16) NOT NULL
);

INSERT INTO servico_fases (id_servico_fase, nome_servico_fase) VALUES
(1, 'Monofásico'), (2, 'Bifásico'), (3, 'Trifásico');

CREATE TABLE IF NOT EXISTS coordenadas_exatidao (
    id_coordenadas_exatidao INTEGER PRIMARY KEY,
    nome_coordenadas_exatidao VARCHAR(8) NOT NULL
);

INSERT INTO coordenadas_exatidao (id_coordenadas_exatidao, nome_coordenadas_exatidao) VALUES
(1, 'Alto'), (2, 'Médio'), (3, 'Baixo');

CREATE TABLE IF NOT EXISTS servico_cliente (
    id_servico_cliente INTEGER PRIMARY KEY,
    instalacao BIGINT NOT NULL,
    nome VARCHAR(128) NOT NULL,
    logradouro VARCHAR(64) NOT NULL,
    numero VARCHAR(32),
    complemento VARCHAR(32)
    localidade INTEGER NOT NULL,
    sub_bairro VARCHAR(32) NOT NULL,
    cidade VARCHAR(32) NOT NULL,
    estado VARCHAR(32) NOT NULL,
    codigo_postal INTEGER DEFAULT 0,
    telefone INTEGER DEFAULT 0,
    celular INTEGER DEFAULT 0,
    email VARCHAR(64) DEFAULT NULL,
    fases INTEGER REFERENCES servico_fases(id_servico_fase),
    eh_encontrada_coordenadas BOOLEAN DEFAULT TRUE,
    coordenada_x DOUBLE DEFAULT 0,
    coordenada_y DOUBLE DEFAULT 0,
    id_coordenadas_exatidao INTEGER REFERENCES coordenadas_exatidao(id_coordenadas_exatidao)
);

CREATE TABLE IF NOT EXISTS servicos_base (
    id_servico_base INTEGER PRIMARY KEY,
    recurso VARCHAR(32) NOT NULL,
    dia DATE NOT NULL,
    id_atividade INTEGER NOT NULL,
    tempo_inicio TIME NOT NULL,
    tempo_final TIME NOT NULL,
    tempo_duracao INTERVAL,
    tempo_desloca INTERVAL,
    id_dano CHAR(4) NOT NULL,
    tempo_de_reserva TIMESTAMP,
    estimado_desloca INTERVAL,
    estimado_duracao INTERVAL,
    nome_arquivo VARCHAR(64) NOT NULL,
    id_composicao VARCHAR(32) NOT NULL,
    eh_finalizado BOOLEAN DEFAULT TRUE,
    id_situacao INTEGER REFERENCES servico_situacao(id_servico_situacao),
    id_composicao INTEGER REFERENCES composicoes(id_composicao),
    id_dano_projeto INTEGER REFERENCES dano_projeto(id_composicao)
);

CREATE TABLE IF NOT EXISTS servico_intervalo (
    id_servico_intervalo INTEGER PRIMARY KEY,
    motivo_indisponibilidade_ou_descricao_intervalo VARCHAR(32) NOT NULL
);

CREATE TABLE IF NOT EXISTS servico_turnoinfo (
    id_servico_turnoinfo INTEGER PRIMARY KEY,
    inicio_do_turno DATE NOT NULL,
    label_do_veiculo CHAR(13) NOT NULL,
    id_matricula_lider INTEGER NOT NULL,
    id_matricula_auxiliares INTEGER DEFAULT 0,
    id_matricula_tecnico INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS servico_servico (
    id_servico_servico INTEGER PRIMARY KEY,
    nota BIGINT NOT NULL,
    inicio_do_sla DATETIME DEFAULT '0001-01-01',
    final_do_sla DATETIME DEFAULT '9999-12-31',
    eh_lg_ctrl_tipo_fechamento_ok BOOLEAN DEFAULT TRUE,
    codigos_fechamento_preenchido BOOLEAN DEFAULT FALSE,
    codigos_fechamentos VARCHAR(128) NOT NULL,
    observacao VARCHAR(1024) DEFAULT NULL,
    descricao VARCHAR(64) DEFAULT NULL,
    eh_lg_flag_preech_fechamento BOOLEAN DEFAULT FALSE,
    codigos_de_fechamento_da_atividade_pai VARCHAR(32),
    eh_lg_ctrl_reprovado_flag BOOLEAN DEFAULT FALSE,
    tipo_da_nota CHAR(2) NOT NULL,
    balde_origem VARCHAR(32)
    cliente_debitos DECIMAL(6,2) DEFAULT 0,
    eh_cliente_assinou_toi BOOLEAN DEFAULT NULL,
    eh_cliente_recusa_assinar_toi BOOLEAN DEFAULT NULL,
    eh_cliente_autorizou_levantar_carga BOOLEAN DEFAULT NULL,
    abrangencia VARCHAR(32) DEFAULT NULL,
    chi INTEGER DEFAULT NULL,
    tempo_interrompido INTEGER DEFAULT NULL,
    valor_compensação_financeira INTEGER DEFAULT NULL,
    instalacao BIGINT REFERENCES servico_cliente(instalacao)
    eh_finalizado BOOLEAN DEFAULT TRUE,
    id_finalizacao INTEGER REFERENCES finalizacoes(id_finalizacao)
);

CREATE TABLE IF NOT EXISTS credenciais (
    id_credencial INTEGER PRIMARY KEY,
    id_funcionario INTEGER REFERENCES funcionario(id_funcionario),
    passwordhash VARCHAR(32) NOT NULL
);