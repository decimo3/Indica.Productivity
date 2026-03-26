CREATE TABLE IF NOT EXISTS processos (
    id_processo INTEGER PRIMARY KEY,
    nome_processo VARCHAR(8) UNIQUE
);

INSERT INTO processos (id_processo, nome_processo) VALUES
(1, 'CORE'),
(2, 'LIDE'),
(3, 'REN'),
(4, 'EMEG');

CREATE TABLE IF NOT EXISTS projetos (
    id_projeto INTEGER PRIMARY KEY,
    nome_projeto VARCHAR(8) UNIQUE,
    usar_dano BOOLEAN DEFAULT FALSE,
    id_processo INTEGER REFERENCES processos(id_processo)
);

INSERT INTO projetos (id_projeto, nome_projeto, usar_dano, id_processo) VALUES
(1, 'CORTE', FALSE, 1),
(2, 'RELIGA', FALSE, 1),
(3, 'LIDE', TRUE, 2),
(4, 'ANEXO', FALSE, 2),
(5, 'AFERICAO', TRUE, 2),
(6, 'INSPECAO', FALSE, 3),
(7, 'COLETIVO', FALSE, 4),
(8, 'MANOBRA', TRUE, 4);

CREATE TABLE IF NOT EXISTS derivacoes (
    id_derivacao INTEGER PRIMARY KEY,
    nome_derivacao VARCHAR(32) UNIQUE
);

INSERT INTO derivacoes ( id_derivacao, nome_derivacao ) VALUES
(1, 'CONVENCIONAL'),
(2, 'PESADO'),
(3, 'INICIATIVA'),
(4, 'MANUTENÇÃO BT'),
(5, 'EXTERNALIZAÇÃO'),
(6, 'MODERNIZAÇÃO'),
(7, 'NORMALIZAÇÃO'),
(8, 'VISTORIADOR'),
(9, 'EMERGÊNCIA'),
(10, 'ESTOQUE DE CORTADOS');

CREATE TABLE IF NOT EXISTS selecao (
    id_selecao INTEGER PRIMARY KEY,
    padrao_selecao VARCHAR(16) UNIQUE,
    id_derivacao INTEGER REFERENCES derivacoes(id_derivacao)
);

INSERT INTO selecao ( id_selecao, padrao_selecao, id_derivacao ) VALUES
(1, 'INICIATIVA', 3),
(2, 'SELMANUTBT', 4),
(3, 'ESTOQCORT',  10),
(4, 'SELEXTMED',  5),
(5, 'SELEXTMDNI', 5),
(6, 'MODYMYMFT',  6),
(7, 'MODMYMFT',   6),
(8, 'PROJTURIA',  7),
(9, 'PROJTUIA',   7),
(10, 'SELMANTUFAT', 4);

CREATE TABLE IF NOT EXISTS atividades (
    id_atividade INTEGER PRIMARY KEY,
    nome_atividade VARCHAR(32) UNIQUE,
    id_projeto INTEGER REFERENCES projetos(id_projeto)
);

INSERT INTO atividades (id_atividade, nome_atividade, id_projeto) VALUES
(1, 'CORTE', 1),
(2, 'CORTE PILOTO', 1),
(3, 'CORTE ESPECIAL', 1),
(4, 'RELIGA', 2),
(5, 'RELIGA POSTO', 2),
(6, 'RELIGA CAMINHÃO', 2),
(7, 'LIDE', 3),
(8, 'LIDE VISTORIADOR', 3),
(9, 'LIDE PESADO', 3),
(10, 'ANEXO IV', 4),
(11, 'ANEXO IV VISTORIADOR', 4),
(12, 'ANEXO IV PESADO', 4),
(13, 'EMERGÊNCIA', 8),
(14, 'PQM', 7),
(15, 'ATENDIMENTO COLETIVO', 7),
(16, 'CONVENCIONAL', 6),
(17, 'EXTERNALIZAÇÃO', 6),
(18, 'LABORATÓRIO', 3),
(19, 'CORTE OSDC', 1),
(20, 'BAIXA RENDA', 1),
(21, 'MANUTENÇÃO BT', 6),
(22, 'MEDIDOR OBSOLETO', 6);

CREATE TABLE IF NOT EXISTS contratos (
    id_contrato INTEGER PRIMARY KEY,
    contrato BIGINT NOT NULL,
    aditivo INTEGER NOT NULL,
    inicio_vigencia DATE NOT NULL,
    final_vigencia DATE DEFAULT '9999-12-31',
    UNIQUE (contrato, aditivo)
);

CREATE TABLE IF NOT EXISTS regionais (
    id_regional INTEGER PRIMARY KEY,
    nome_regional VARCHAR(16) UNIQUE
);

INSERT INTO regionais (id_regional, nome_regional) VALUES
(1, 'CAMPO GRANDE'), (2, 'BAIXADA');

CREATE TABLE IF NOT EXISTS contrato_projeto (
    id_contrato_projeto INTEGER PRIMARY KEY,
    id_contrato INTEGER REFERENCES contratos(id_contrato),
    id_projeto INTEGER REFERENCES projetos(id_projeto),
    id_derivacao INTEGER REFERENCES derivacoes(id_derivacao),
    id_regional INTEGER REFERENCES regionais(id_regional),
    UNIQUE (id_contrato, id_projeto, id_regional, id_derivacao)
);

CREATE TABLE IF NOT EXISTS objetivos (
    id_objetivo INTEGER PRIMARY KEY,
    mensal_valor_meta NUMERIC DEFAULT 0,
    mensal_divisor_fixo NUMERIC DEFAULT 0,
    meta_apresentacao_util INTEGER DEFAULT 0,
    meta_apresentacao_feriado INTEGER DEFAULT 0,
    meta_execucoes_diaria INTEGER DEFAULT 0,
    id_contrato_projeto INTEGER REFERENCES contrato_projeto(id_contrato_projeto),
    UNIQUE (id_contrato_projeto)
);

CREATE TABLE IF NOT EXISTS funcionario_situacoes (
    id_funcionario_situacao INTEGER PRIMARY KEY,
    nome_funcionario_situacao VARCHAR(16) UNIQUE
);

INSERT INTO funcionario_situacoes (id_funcionario_situacao, nome_funcionario_situacao) VALUES
(1, 'ativo'),
(2, 'inss'),
(3, 'ferias'),
(4, 'suspenso'),
(5, 'desligado');

CREATE TABLE IF NOT EXISTS funcionario_funcoes (
    id_funcionario_funcao INTEGER PRIMARY KEY,
    nome_funcionario_funcao VARCHAR(16) UNIQUE
);

INSERT INTO funcionario_funcoes (id_funcionario_funcao, nome_funcionario_funcao) VALUES
(1, 'eletricista'),
(2, 'supervisor'),
(3, 'controlador'),
(4, 'administrador'),
(5, 'proprietario');

CREATE TABLE IF NOT EXISTS funcionarios (
    id_funcionario INTEGER PRIMARY KEY,
    matricula_indica INTEGER UNIQUE,
    matricula_cliente INTEGER UNIQUE,
    nome_funcionario VARCHAR(128) UNIQUE,
    data_admissao DATE NOT NULL,
    data_demissao DATE DEFAULT NULL,
    id_funcionario_situacao INTEGER REFERENCES funcionario_situacoes(id_funcionario_situacao),
    id_funcionario_funcao INTEGER REFERENCES funcionario_funcoes(id_funcionario_funcao)
);

CREATE TABLE IF NOT EXISTS composicao_funcoes (
    id_composicao_funcao INTEGER PRIMARY KEY,
    nome_composicao_funcao VARCHAR(16) UNIQUE
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
    id_atividade INTEGER REFERENCES atividades(id_atividade),
    id_regional INTEGER REFERENCES regionais(id_regional),
    UNIQUE (dia, recurso)
);

CREATE TABLE IF NOT EXISTS equipes (
    id_equipe INTEGER PRIMARY KEY,
    id_composicao INTEGER REFERENCES composicoes(id_composicao),
    id_funcionario INTEGER REFERENCES funcionarios(id_funcionario),
    id_composicao_funcao INTEGER REFERENCES composicao_funcoes(id_composicao_funcao),
    UNIQUE (id_composicao, id_funcionario)
);

CREATE TABLE IF NOT EXISTS mestres (
    id_mestre INTEGER PRIMARY KEY,
    mestre INTEGER UNIQUE,
    descricao VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS pagamentos (
    id_pagamento INTEGER PRIMARY KEY,
    id_contrato_projeto INTEGER REFERENCES contrato_projeto(id_contrato_projeto),
    id_mestre INTEGER REFERENCES mestres(id_mestre),
    valoracao DECIMAL(6,2) NOT NULL,
    UNIQUE (id_contrato_projeto, id_mestre)
);

CREATE TABLE IF NOT EXISTS finalizacao_categorias (
    id_finalizacao_categoria INTEGER PRIMARY KEY,
    nome_finalizacao_categoria VARCHAR(16) UNIQUE,
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
(8, 'NA', TRUE),
(9, 'NI', FALSE),
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
    eh_alternativo BOOLEAN DEFAULT FALSE,
    id_categoria INTEGER REFERENCES finalizacao_categorias(id_finalizacao_categoria),
    UNIQUE (agrupamento_medidas, eh_alternativo)
);

CREATE TABLE IF NOT EXISTS finalizacoes_pagamento (
    id_finalizacao_pagamento INTEGER PRIMARY KEY,
    id_finalizacao INTEGER REFERENCES finalizacoes(id_finalizacao),
    id_mestre INTEGER REFERENCES mestres(id_mestre),
    UNIQUE (id_finalizacao, id_mestre)
);

CREATE TABLE IF NOT EXISTS dano_projeto (
    id_dano_projeto INTEGER PRIMARY KEY,
    nome_dano_projeto VARCHAR(4) UNIQUE,
    texto_breve_para_dano VARCHAR(64) NOT NULL,
    id_projeto INTEGER REFERENCES projetos(id_projeto)
);

INSERT INTO dano_projeto (id_dano_projeto, nome_dano_projeto, texto_breve_para_dano, id_projeto) VALUES
(1, '0001', 'Início de turno', NULL),
(2, '0002', 'Intervalo para almoço', NULL),
(3, '0003', 'INDISPONIBILIDADE', NULL),
(4, '0004', 'Retorno para base', NULL);


CREATE TABLE IF NOT EXISTS codigo_filtragem (
    id_codigo_filtragem INTEGER PRIMARY KEY,
    nome_codigo_filtragem VARCHAR(4) NOT NULL,
    id_projeto INTEGER REFERENCES projetos(id_projeto),
    UNIQUE (nome_codigo_filtragem, id_projeto)
);

CREATE TABLE IF NOT EXISTS servico_situacao (
    id_servico_situacao INTEGER PRIMARY KEY,
    nome_servico_situacao VARCHAR(16) UNIQUE,
    eh_servico_finalizado BOOLEAN NOT NULL
);

INSERT INTO servico_situacao (id_servico_situacao, nome_servico_situacao, eh_servico_finalizado) VALUES
(1, 'pendente', FALSE), (2, 'em rota', FALSE), (3, 'iniciado', FALSE),
(4, 'concluído', TRUE), (5, 'não concluído', TRUE), (6, 'cancelado', TRUE);

CREATE TABLE IF NOT EXISTS servico_fases (
    id_servico_fase INTEGER PRIMARY KEY,
    nome_servico_fase VARCHAR(16) UNIQUE
);

INSERT INTO servico_fases (id_servico_fase, nome_servico_fase) VALUES
(1, 'Monofásico'), (2, 'Bifásico'), (3, 'Trifásico');

CREATE TABLE IF NOT EXISTS coordenadas_exatidao (
    id_coordenadas_exatidao INTEGER PRIMARY KEY,
    nome_coordenadas_exatidao VARCHAR(8) UNIQUE
);

INSERT INTO coordenadas_exatidao (id_coordenadas_exatidao, nome_coordenadas_exatidao) VALUES
(1, 'Alto'), (2, 'Médio'), (3, 'Baixo');

CREATE TABLE IF NOT EXISTS servico_localidade (
    id_servico_localidade INTEGER PRIMARY KEY,
    num_servico_localidade INTEGER UNIQUE,
    nome_servico_localidade VARCHAR(16) UNIQUE,
    id_regional INTEGER REFERENCES regionais(id_regional)
);

INSERT INTO servico_localidade ( id_servico_localidade, nome_servico_localidade, num_servico_localidade, id_regional ) VALUES
(1, '(CS/CE) - 500 - COPACABANA', 500, NULL),
(2, '(CS/BA) - 502 - SAO CONRADO', 502, NULL),
(3, '(CS/CE) - 505 - BOTAFOGO', 505, NULL),
(4, '(CS/CE) - 510 - CENTRO', 510, NULL),
(5, '(CS/CE) - 516 - URCA', 516, NULL),
(6, '(CS/CE) - 520 - TIJUCA', 520, NULL),
(7, '(CS/BA) - 525 - BARRA DA TIJUCA', 525, NULL),
(8, '(LE/ME) - 535 - MEIER', 535, NULL),
(9, '(LE/ME) - 538 - PILARES', 538, NULL),
(10, '(OE/JP) - 539 - JACAREPAGUA', 539, 1),
(11, '(LE/PE) - 540 - MADUREIRA', 540, NULL),
(12, '(LE/PE) - 544 - GUADALUPE', 544, NULL),
(13, '(LE/PE) - 545 - IRAJA', 545, NULL),
(14, '(LE/PE) - 550 - OLARIA', 550, NULL),
(15, '(LE/ME) - 551 - MARE', 551, NULL),
(16, '(LE/ME) - 552 - RAMOS', 552, NULL),
(17, '(LE/PE) - 555 - PENHA', 555, NULL),
(18, '(LE/ME) - 565 - ILHA GOVERNADOR', 565, NULL),
(19, '(LE/ME) - 566 - PAQUETA', 566, NULL),
(20, '(CS/CE) - 570 - SAO CRISTOVAO', 570, NULL),
(21, '(OE/JP) - 580 - REALENGO', 580, 1),
(22, '(OE/JP) - 585 - BANGU', 585, 1),
(23, '(OE/CG) - 590 - CAMPO GRANDE', 590, 1),
(24, '(OE/CG) - 593 - SANTA CRUZ', 593, 1),
(25, '(OE/CG) - 595 - ITAGUAI', 595, 1),
(26, '(OE/CG) - 596 - SEROPEDICA', 596, 1),
(27, '(OE/CG) - 597 - SERRA DO MATOSO', 597, 1),
(28, '(OE/CG) - 598 - MATOSO', 598, 1),
(29, '(BX/NI) - 610 - NOVA IGUACU', 610, 2),
(30, '(BX/NI) - 611 - MESQUITA', 611, 2),
(31, '(BX/NI) - 612 - ESPLANADA', 612, 2),
(32, '(BX/NI) - 613 - AUSTIN', 613, 2),
(33, '(BX/NI) - 614 - RANCHO NOVO', 614, 2),
(34, '(BX/NI) - 615 - VILA DE CAVA', 615, 2),
(35, '(BX/NI) - 616 - TINGUA', 616, 2),
(36, '(BX/NI) - 617 - NOVA AURORA', 617, 2),
(37, '(BX/NI) - 620 - BELFORD ROXO', 620, 2),
(38, '(BX/NI) - 622 - QUEIMADOS', 622, 2),
(39, '(BX/NI) - 623 - CABUCU', 623, 2),
(40, '(BX/NI) - 624 - MATO GROSSO', 624, 2),
(41, '(BX/CX) - 625 - NILOPOLIS', 625, 2),
(42, '(BX/CX) - 630 - DUQUE DE CAXIAS', 630, 2),
(43, '(BX/CX) - 632 - CAPIVARI', 632, 2),
(44, '(BX/CX) - 635 - SAO JOAO MERITI', 635, 2),
(45, '(BX/CX) - 636 - COELHO DA ROCHA', 636, 2),
(46, '(BX/CX) - 637 - VILAR DOS TELES', 637, 2),
(47, '(BX/NI) - 643 - ENG PEDREIRA', 643, 2),
(48, '(BX/NI) - 644 - JAPERI', 644, 2),
(49, '(BX/NI) - 645 - PARACAMBI', 645, 2),
(50, '(BX/NI) - 646 - PAES LEME', 646, 2),
(51, '(VP/TR) - 700 - VASSOURAS', 700, NULL),
(52, '(VP/TR) - 705 - POCINHO', 705, NULL),
(53, '(VP/TR) - 707 - CACHOEIRA', 707, NULL),
(54, '(VP/TR) - 710 - PATY DO ALFERES', 710, NULL),
(55, '(VP/TR) - 711 - AVELAR', 711, NULL),
(56, '(VP/TR) - 715 - IPIRANGA', 715, NULL),
(57, '(VP/TR) - 716 - ITAKAMOSI', 716, NULL),
(58, '(VP/TR) - 717 - DEMETRIO RIBEIRO', 717, NULL),
(59, '(VP/TR) - 720 - ANDRADE COSTA', 720, NULL),
(60, '(VP/TR) - 721 - ANDRADE PINTO', 721, NULL),
(61, '(VP/TR) - 722 - BARAO DE JUPARANA', 722, NULL),
(62, '(VP/TR) - 723 - VALENCA', 723, NULL),
(63, '(VP/TR) - 731 - MENDES', 731, NULL),
(64, '(VP/VR) - 735 - RIO CLARO', 735, NULL),
(65, '(VP/TR) - 740 - MIGUEL PEREIRA', 740, NULL),
(66, '(VP/VR) - 742 - PASSA TRES', 742, NULL),
(67, '(VP/TR) - 745 - SANATORIO SERRA', 745, NULL),
(68, '(VP/VR) - 747 - PIRAI', 747, NULL),
(69, '(VP/TR) - 749 - SANTANESIA', 749, NULL),
(70, '(VP/VR) - 750 - PINHEIRAL', 750, NULL),
(71, '(VP/VR) - 752 - GETULANDIA', 752, NULL),
(72, '(VP/TR) - 753 - ABARRACAMENTO', 753, NULL),
(73, '(VP/TR) - 754 - RIO DAS FLORES', 754, NULL),
(74, '(VP/TR) - 758 - CARMO', 758, NULL),
(75, '(VP/TR) - 760 - SAPUCAIA', 760, NULL),
(76, '(VP/TR) - 761 - SAO JOSE DO VALE DO RIO PRETO', 761, NULL),
(77, '(VP/TR) - 762 - ENG PAULO FRONTIN', 762, NULL),
(78, '(VP/TR) - 763 - MORRO AZUL', 763, NULL),
(79, '(VP/TR) - 770 - BARRA DO PIRAI', 770, NULL),
(80, '(VP/VR) - 772 - CALIFORNIA', 772, NULL),
(81, '(VP/VR) - 776 - VOLTA REDONDA', 776, NULL),
(82, '(VP/VR) - 777 - PONTE ALTA', 777, NULL),
(83, '(VP/VR) - 778 - AMPARO', 778, NULL),
(84, '(VP/VR) - 779 - BARRA MANSA', 779, NULL),
(85, '(VP/VR) - 782 - QUATIS', 782, NULL),
(86, '(VP/TR) - 786 - TRES RIOS', 786, NULL),
(87, '(VP/TR) - 788 - CDOR L GASPARIAN', 788, NULL),
(88, '(VP/TR) - 793 - PARAIBA DO SUL', 793, NULL),
(89, '(VP/TR) - 810 - CHIADOR', 810, NULL),
(90, '(VP/TR) - 825 - SIMAO PEREIRA', 825, NULL),
(91, '(VP/TR) - 830 - RIO PRETO', 830, NULL),
(92, '(VP/TR) - 840 - PORTO DAS FLORES', 840, 0);

CREATE TABLE IF NOT EXISTS servico_cliente (
    id_servico INTEGER PRIMARY KEY,
    instalacao BIGINT UNIQUE,
    nome VARCHAR(128) NOT NULL,
    logradouro VARCHAR(64) NOT NULL,
    numero VARCHAR(32) DEFAULT NULL,
    complemento VARCHAR(32) DEFAULT NULL,
    id_localidade INTEGER REFERENCES servico_localidade(id_servico_localidade),
    sub_bairro VARCHAR(32) NOT NULL,
    cidade VARCHAR(32) NOT NULL,
    estado VARCHAR(32) NOT NULL,
    codigo_postal INTEGER DEFAULT NULL,
    telefone INTEGER DEFAULT NULL,
    celular INTEGER DEFAULT NULL,
    email VARCHAR(64) DEFAULT NULL,
    fases INTEGER REFERENCES servico_fases(id_servico_fase),
    eh_encontrada_coordenadas BOOLEAN DEFAULT TRUE,
    coordenada_x DOUBLE PRECISION DEFAULT 0,
    coordenada_y DOUBLE PRECISION DEFAULT 0,
    id_coordenadas_exatidao INTEGER REFERENCES coordenadas_exatidao(id_coordenadas_exatidao)
);

CREATE TABLE IF NOT EXISTS servico_base (
    id_servico INTEGER PRIMARY KEY,
    recurso VARCHAR(32) NOT NULL,
    dia DATE NOT NULL,
    id_atividade INTEGER UNIQUE,
    tempo_inicio TIME NOT NULL,
    tempo_final TIME NOT NULL,
    tempo_duracao INTERVAL NOT NULL,
    tempo_desloca INTERVAL NOT NULL,
    tempo_de_reserva TIMESTAMP NOT NULL,
    estimado_desloca INTERVAL NOT NULL,
    estimado_duracao INTERVAL NOT NULL,
    tempo_total_decimal REAL DEFAULT 0,
    id_situacao INTEGER REFERENCES servico_situacao(id_servico_situacao),
    id_composicao INTEGER REFERENCES composicoes(id_composicao),
    id_dano_projeto INTEGER REFERENCES dano_projeto(id_dano_projeto)
);

CREATE TABLE IF NOT EXISTS servico_turnoinfo (
    id_servico INTEGER PRIMARY KEY,
    inicio_do_turno DATE,
    label_do_veiculo CHAR(13),
    id_matricula_lider INTEGER,
    id_matricula_auxiliares INTEGER,
    id_matricula_tecnico INTEGER,
    motivo_indisponibilidade_ou_descricao_intervalo VARCHAR(32)
);

CREATE TABLE IF NOT EXISTS servico_servico (
    id_servico INTEGER PRIMARY KEY,
    nota_de_servico BIGINT NOT NULL,
    inicio_do_sla TIMESTAMP DEFAULT '0001-01-01 00:00:00',
    final_do_sla TIMESTAMP DEFAULT '9999-12-31 23:59:59',
    habilidades_trabalho VARCHAR(64) NOT NULL,
    eh_lg_ctrl_tipo_fechamento_ok BOOLEAN DEFAULT TRUE,
    codigos_fechamento_preenchido BOOLEAN DEFAULT FALSE,
    codigos_fechamentos VARCHAR(128) NOT NULL,
    observacao VARCHAR(1024) DEFAULT NULL,
    descricao VARCHAR(64) DEFAULT NULL,
    eh_lg_flag_preech_fechamento BOOLEAN DEFAULT FALSE,
    codigos_de_fechamento_da_atividade_pai VARCHAR(32) DEFAULT NULL,
    eh_lg_ctrl_reprovado_flag BOOLEAN DEFAULT FALSE,
    tipo_da_nota VARCHAR(2) NOT NULL,
    balde_origem VARCHAR(32) NOT NULL,
    cliente_debitos REAL DEFAULT 0,
    eh_cliente_assinou_toi BOOLEAN DEFAULT NULL,
    eh_cliente_recusa_assinar_toi BOOLEAN DEFAULT NULL,
    eh_cliente_recusa_receber_toi BOOLEAN DEFAULT NULL,
    eh_cliente_autorizou_levantar_carga BOOLEAN DEFAULT NULL,
    abrangencia VARCHAR(32) DEFAULT NULL,
    chi INTEGER DEFAULT NULL,
    tempo_interrompido INTEGER DEFAULT NULL,
    valor_compensação_financeira INTEGER DEFAULT NULL,
    id_cliente INTEGER REFERENCES servico_cliente(id_servico),
    id_derivacao INTEGER REFERENCES derivacoes (id_derivacao),
    id_finalizacao INTEGER REFERENCES finalizacoes(id_finalizacao)
);

CREATE TABLE IF NOT EXISTS credenciais (
    id_credencial INTEGER PRIMARY KEY,
    id_funcionario INTEGER REFERENCES funcionarios(id_funcionario),
    passwordhash VARCHAR(32) NOT NULL,
    UNIQUE (id_funcionario)
);

CREATE VIEW relatorio_contrato_projeto AS SELECT
    cp.id_contrato_projeto,
    cp.id_projeto,
    cp.id_derivacao,
    cp.id_regional,
    ct.id_contrato,
    ct.contrato,
    ct.aditivo,
    ct.inicio_vigencia,
    ct.final_vigencia
FROM contrato_projeto AS cp
INNER JOIN contratos AS ct
    ON cp.id_contrato = ct.id_contrato;

CREATE VIEW relatorio_composicoes AS SELECT
-- composicao table fields
    c.id_composicao,
    c.dia,
    c.ordem,
    c.placa,
    c.recurso,
    c.telefone,
    c.eh_considerado,
-- atividade table fields
    a.nome_atividade,
-- projeto table fields
    p.nome_projeto,
-- processo table fields
    pr.nome_processo,
-- regional table fields
    r.nome_regional,
-- contrato table fields
    ctt.contrato,
    ctt.aditivo,
    ctt.inicio_vigencia,
    ctt.final_vigencia
FROM composicoes AS c
LEFT JOIN atividades AS a
    ON a.id_atividade = c.id_atividade
LEFT JOIN projetos AS p
    ON p.id_projeto = a.id_projeto
LEFT JOIN processos AS pr
    ON pr.id_processo = p.id_processo
LEFT JOIN regionais AS r
    ON r.id_regional = c.id_regional
LEFT JOIN relatorio_contrato_projeto AS ctt
    ON p.id_projeto = ctt.id_projeto
    AND ctt.id_derivacao = 1
    AND c.id_regional = ctt.id_regional
    AND c.dia
        BETWEEN ctt.inicio_vigencia
            AND ctt.final_vigencia;

CREATE VIEW relatorio_servicos AS SELECT
-- servico_base table fields
    sb.recurso,
    sb.dia,
    sb.id_atividade,
    sb.tempo_inicio,
    sb.tempo_final,
    sb.tempo_duracao,
    sb.tempo_desloca,
    sb.tempo_de_reserva,
    sb.estimado_desloca,
    sb.estimado_duracao,
    sb.id_composicao,
    sb.id_dano_projeto,
-- servico_servico table fields
    sv.nota_de_servico,
    sv.inicio_do_sla,
    sv.final_do_sla,
    sv.tipo_da_nota,
    sv.habilidades_trabalho,
    sv.codigos_fechamentos,
    sv.observacao,
    sv.descricao,
--  sv.tempo_total_decimal,
-- servico_cliente table fields
    cl.instalacao,
-- servico_localidade table fields
    sl.num_servico_localidade,
    sl.nome_servico_localidade,
-- servico_regional table fields
    r.nome_regional,
-- servico_situacao table fields
    ss.nome_servico_situacao,
    ss.eh_servico_finalizado,
-- dano_projeto table fields
    dm.nome_dano_projeto,
    dm.texto_breve_para_dano,
-- projeto table fields
    pj.nome_projeto,
--  pj.eh_especial,
-- processos table fields
    pc.nome_processo,
-- finalizacoes table fields
    f.id_finalizacao,
    f.agrupamento_medidas,
-- finalizacao_categorias table fields
    fc.nome_finalizacao_categoria,
    fc.eh_executado,
-- pagamentos table fields
    pg.id_pagamento,
    pg.id_contrato_projeto,
    pg.id_mestre,
    m.mestre,
    pg.valoracao
--  SUM(pg.valoracao) AS 'pg.valoracao'
FROM servico_servico AS sv
LEFT JOIN servico_base AS sb
    ON sv.id_servico = sb.id_servico
LEFT JOIN servico_cliente AS cl
    ON sv.id_cliente = cl.id_servico
LEFT JOIN servico_localidade AS sl
    ON cl.id_localidade = sl.id_servico_localidade
LEFT JOIN regionais AS r
    ON sl.id_regional = r.id_regional
LEFT JOIN servico_situacao AS ss
    ON sb.id_situacao = ss.id_servico_situacao
LEFT JOIN dano_projeto AS dm
    ON sb.id_dano_projeto = dm.id_dano_projeto
LEFT JOIN projetos AS pj
    ON dm.id_projeto = pj.id_projeto
LEFT JOIN processos AS pc
    ON pj.id_processo = pc.id_processo
LEFT JOIN relatorio_contrato_projeto AS ctt
    ON ctt.id_regional = r.id_regional
    AND ctt.id_projeto = pj.id_projeto
    AND ctt.id_derivacao = sv.id_derivacao
    AND sb.dia BETWEEN ctt.inicio_vigencia
    AND ctt.final_vigencia
LEFT JOIN finalizacoes AS f
    ON sv.id_finalizacao = f.id_finalizacao
LEFT JOIN finalizacao_categorias AS fc
    ON f.id_categoria = fc.id_finalizacao_categoria
LEFT JOIN finalizacoes_pagamento AS fp
    ON f.id_finalizacao = fp.id_finalizacao
LEFT JOIN pagamentos AS pg
    ON fp.id_mestre = pg.id_mestre
    AND ctt.id_contrato_projeto = pg.id_contrato_projeto
LEFT JOIN mestres AS m
    ON m.id_mestre = pg.id_mestre;
