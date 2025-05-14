-- Criação do banco de dados
CREATE DATABASE IF NOT EXISTS development;

-- Conectar ao banco de dados
\c development; 


CREATE TABLE IF NOT EXISTS contratos (
    id_contrato NUMERIC(11, 1) PRIMARY KEY,
    contrato BIGINT NOT NULL,
    aditivo INT NOT NULL,
    inicio_vigencia DATE NOT NULL,
    final_vigencia DATE NOT NULL,
);

CREATE TABLE IF NOT EXISTS processos (
    id_processo INT PRIMARY KEY,
    nome_processo BIGINT NOT NULL,
    descricao VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS objetivos (
    id_contrato NUMERIC(11, 1) NOT NULL,
    id_processo INT NOT NULL,
    is_viatura BOOLEAN NOT NULL,
    is_metade BOOLEAN NOT NULL,
    meta_mensal DECIMAL NOT NULL,
    divisor FLOAT NOT NULL,
    meta_equipe_dia_util INT NOT NULL,
    meta_equipe_feriado INT NOT NULL,
    meta_quantidade_exec INT NOT NULL,
    PRIMARY KEY (id_contrato, id_processo, is_viatura, is_metade),
    FOREIGN KEY (id_contrato) REFERENCES contratos(id_contrato),
    FOREIGN KEY (id_processo) REFERENCES processos(id_processo)
);

-- Criação da tabela finalizacoes
CREATE TABLE IF NOT EXISTS finalizacoes (
    agrupamento_de_medidas VARCHAR(128) PRIMARY KEY,
    descricao VARCHAR(32) NOT NULL
);

-- Criação da tabela pagamentos
CREATE TABLE IF NOT EXISTS pagamentos (
    id_contrato NUMERIC(11, 1) NOT NULL,
    id_processo INT NOT NULL,
    id_mestre INT NOT NULL,
    descricao VARCHAR(256) NOT NULL,
    valor DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (id_contrato, id_processo, id_mestre)
);

-- Criação da tabela finalizacao_pagamento
CREATE TABLE IF NOT EXISTS finalizacao_pagamento (
    agrupamento_de_medidas VARCHAR(128) NOT NULL,
    id_contrato NUMERIC(11, 1) NOT NULL,
    id_processo INT NOT NULL,
    id_mestre INT NOT NULL,
    PRIMARY KEY (agrupamento_de_medidas, id_contrato, id_processo, id_mestre),
    FOREIGN KEY (agrupamento_de_medidas) REFERENCES finalizacoes(agrupamento_de_medidas),
    FOREIGN KEY (id_contrato, id_processo, id_mestre) REFERENCES pagamentos(id_contrato, id_processo, id_mestre)
);

-- Criação da tabela de filtros de código
CREATE TABLE IF NOT EXISTS filtros_de_codigo (
    id_codigo_filtro VARCHAR(5) PRIMARY KEY,
    id_processo INT NOT NULL,
    codigo VARCHAR(4) NOT NULL,
    FOREIGN KEY (id_processo) REFERENCES processos(id_processo)
);

CREATE TABLE IF NOT EXISTS dano_processo (
    dano VARCHAR(4) PRIMARY KEY,
    descricao VARCHAR(128) NOT NULL,
    id_processo INT NOT NULL,
    FOREIGN KEY (id_processo) REFERENCES processos(id_processo)
);

CREATE TABLE IF NOT EXISTS clientes (
    id_instalacao BIGINT PRIMARY KEY,
    nome VARCHAR(128),
    logradouro VARCHAR(128),
    numero_rua VARCHAR(32),
    complemento VARCHAR(32),
    sub_bairro VARCHAR(32),
    cidade VARCHAR(32),
    estado VARCHAR(2),
    cod_postal INT,
    telefone BIGINT,
    celular BIGINT,
    email VARCHAR(128),
);

CREATE TABLE IF NOT EXISTS status_servicos (
    id_status_servico INT PRIMARY KEY,
    nome_status_servico VARCHAR(32) NOT NULL,
);

-- TODO - Criação da tabela de servicos
CREATE TABLE IF NOT EXISTS servicos (
    recurso VARCHAR(32) NOT NULL,
    data_servico DATE NOT NULL,
    id_atividade BIGINT PRIMARY KEY,
    id_status_servico INT NOT NULL,
    StartTime TIME NOT NULL,
    FinalTime TIME NOT NULL,
    StartFinal VARCHAR(),
    StartOfSLA TIMESTAMP,
    FinalOfSLA TIMESTAMP,
    DurationTime INTERVAL,
    TravellingTime INTERVAL,
    TypeOfActivity VARCHAR,
    TypeOfActivity_1 VARCHAR,
    WorkOrderNumber BIGINT,
    AccountNumber BIGINT,
    WorkAbility VARCHAR,
    WorkArea INT,
    FirstManualOperation VARCHAR,
    FirstManualOperationPerformedByUserLogin VARCHAR,
    FirstManualOperationPerformedByUserName VARCHAR,
    EnRouteTimetable VARCHAR,
    ShiftStartDate TIMESTAMP,
    RODate VARCHAR,
    AutoRoutedToMoment DATE,
    AutoRoutedToResource INT,
    AutoRoutedToResourceName VARCHAR,
    IdResource INT,
    FirstManualOperationPerformedByUser INT,
    UserConclusion VARCHAR,
    CoordinateX DOUBLE PRECISION,
    CoordinateY DOUBLE PRECISION,
    CoordinateAccuracy VARCHAR,
    CoordinateStatus VARCHAR,
    ClosingCodes VARCHAR,
    LgCtrlTypeClosingOk VARCHAR,
    ClosedCodesFilledIn VARCHAR,
    ClosingCodes_1 VARCHAR,
    VehicleLabel VARCHAR,
    IdLeaderRegistration INT,
    IdAuxiliaryRegistration INT,
    IdTechnicalRegistration INT,
    Observation VARCHAR,
    BriefDescriptionOfTheContentOfTheNote VARCHAR,
    LgFlagPrefillimentoClosing VARCHAR,
    ParentActivityClosingCodesV03 VARCHAR,
    LgCtrlReprovedFlag VARCHAR,
    id_instalacao BIGINT,
    TimeInterval VARCHAR,
    ReasonForRejection VARCHAR,
    TypeOfServiceNote VARCHAR,
    ActivityBookingTime TIMESTAMP,
    TotalCustomerDebts DOUBLE PRECISION,
    BucketOrigin VARCHAR,
    ConnectionType VARCHAR,
    HasCustomerSignedToi BOOLEAN,
    HasRefusedToSignToi BOOLEAN,
    HasRefusedToReceiveToi BOOLEAN,
    CustomerAuthorizedloadAnalysis VARCHAR,
    EstimatedTravellingTime INTERVAL,
    EstimatedDurationTime INTERVAL,
    ScopeOfService VARCHAR,
    ReasonForUnavailability VARCHAR,
    CHI INT,
    InterruptedTime INT,
    FinancialCompensationAmount INT,
    nome_arquivo VARCHAR(64) NOT NULL,
    id_composicao VARCHAR(32) NOT NULL,
    datahora TIMESTAMP NOT NULL,
    agrupamento_de_medidas VARCHAR(128),
    FOREIGN KEY (id_composicao) REFERENCES composicoes(id_composicao),
    FOREIGN KEY (agrupamento_de_medidas) REFERENCES finalizacoes(agrupamento_de_medidas),
    FOREIGN KEY (id_instalacao) REFERENCES clientes(id_instalacao),
    FOREIGN KEY (id_status_servico) REFERENCES status_servicos(id_status_servico)
);

CREATE TABLE IF NOT EXISTS funcoes (
    id_funcao INT PRIMARY KEY,
    nome_funcao VARCHAR(32) NOT NULL,
    descricao VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS situacoes (
    id_situacao INT PRIMARY KEY,
    nome_situacao VARCHAR(32) NOT NULL,
    descricao VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS funcionarios (
    matricula INT PRIMARY KEY,
    nome VARCHAR(128) NOT NULL,
    admissao DATE NOT NULL,
    demissao DATE,
    id_funcao INT NOT NULL,
    id_situacao INT NOT NULL,
    FOREIGN KEY (id_funcao) REFERENCES funcoes(id_funcao),
    FOREIGN KEY (id_situacao) REFERENCES situacoes(id_situacao)
);

CREATE TABLE IF NOT EXISTS habilidades (
    id_habilidade INT PRIMARY KEY,
    nome_habilidade VARCHAR(32) NOT NULL,
    descricao VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS equipes (
    id_equipe INT PRIMARY KEY,
    id_composicao VARCHAR(32) NOT NULL,
    matricula INT NOT NULL,
    id_funcao INT NOT NULL,
    FOREIGN KEY (id_composicao) REFERENCES composicoes(id_composicao),
    FOREIGN KEY (matricula) REFERENCES funcionarios(matricula),
    FOREIGN KEY (id_funcao) REFERENCES funcoes(id_funcao)
);

CREATE TABLE IF NOT EXISTS funcionario_habilidades (
    matricula INT NOT NULL,
    id_habilidade INT NOT NULL,
    PRIMARY KEY (matricula, id_habilidade),
    FOREIGN KEY (matricula) REFERENCES funcionarios(matricula),
    FOREIGN KEY (id_habilidade) REFERENCES habilidades(id_habilidade)
);

CREATE TABLE IF NOT EXISTS credenciais (
    matricula INT PRIMARY KEY,
    passhash VARCHAR(128) NOT NULL,
    FOREIGN KEY (matricula) REFERENCES funcionarios(matricula)
);

CREATE TABLE IF NOT EXISTS regionais (
    id_regional INT PRIMARY KEY,
    nome_regional VARCHAR(32) NOT NULL,
    descricao VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS viaturas (
    adesivo INT PRIMARY KEY,
    placa VARCHAR(8) NOT NULL,
);

CREATE TABLE IF NOT EXISTS atividades (
    id_atividade INT PRIMARY KEY,
    nome_atividade VARCHAR(32) NOT NULL,
    descricao VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS supervisor_contratos (
    id_supervisor_contrato INT PRIMARY KEY,
    id_supervisor INT NOT NULL,
    id_contrato NUMERIC(11, 1) NOT NULL,
    FOREIGN KEY (id_supervisor) REFERENCES funcionarios(matricula),
    FOREIGN KEY (id_contrato) REFERENCES contratos(id_contrato)
);

CREATE TABLE IF NOT EXISTS composicoes (
    id_composicao VARCHAR(32) PRIMARY KEY,
    adesivo INT NOT NULL,
    id_atividade INT NOT NULL,
    id_equipe INT NOT NULL,
    id_regional INT NOT NULL,
    FOREIGN KEY (id_viatura) REFERENCES viaturas(id_viatura),
    FOREIGN KEY (id_atividade) REFERENCES atividades(id_atividade),
    FOREIGN KEY (id_equipe) REFERENCES equipes(id_equipe),
    FOREIGN KEY (id_regional) REFERENCES regionais(id_regional)
);
