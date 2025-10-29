CREATE DATABASE DBOrdem-Servicos;
GO

USE DBOrdem-Servicos;
GO

CREATE TABLE DBProdutos (
  IDProduto INT NOT NULL IDENTITY(1,1),
  IDProdutoInterno VARCHAR(50) NULL,
  IDProdutoFabricante VARCHAR(50) NULL,
  Descricao VARCHAR(100) NULL,
  IDFornecedor INT NULL,
  IDMarca INT NULL,
  IDModelo INT NULL,
  IDUnidade INT NULL,
  PrecoCompra DECIMAL(10,2) NULL,
  PrecoVenda DECIMAL(10,2) NULL,
  EstoqueAtual DECIMAL(10,4) NULL,
  EstoqueMinimo DECIMAL(10,4) NULL,
  DataUltimaCompra DATETIME NULL,
  Garantia VARCHAR(50) NULL,
  Imagem VARBINARY(MAX) NULL,
  PRIMARY KEY (IDProduto),
  UNIQUE (IDProdutoInterno),
  UNIQUE (IDProdutoFabricante),
  UNIQUE (Descricao)
);
GO

CREATE TABLE DBFornecedores (
  IDFornecedor INT NOT NULL IDENTITY(1,1),
  TipoPessoa VARCHAR(8) NULL,
  Cpf_Cnpj VARCHAR(14) NULL,
  Nome_RazaoSocial VARCHAR(100) NULL,
  Endereco VARCHAR(50) NULL,
  Numero VARCHAR(50) NULL,
  Bairro VARCHAR(50) NULL,
  Municipio VARCHAR(50) NULL,
  UF VARCHAR(2) NULL,
  Cep VARCHAR(8) NULL,
  Contato VARCHAR(50) NULL,
  Fone_1 VARCHAR(11) NULL,
  Fone_2 VARCHAR(11) NULL,
  Email VARCHAR(100) NULL,
  DataCadastro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (IDFornecedor),
  UNIQUE (Cpf_Cnpj)
);
GO

CREATE TABLE DBModelos (
  IDModelo INT NOT NULL IDENTITY(1,1),
  IDMarca INT NOT NULL,
  Descricao VARCHAR(100) NULL,
  PRIMARY KEY (IDModelo),
  UNIQUE (Descricao)
);
GO

CREATE TABLE DBUnidades (
  IDUnidade INT NOT NULL IDENTITY(1,1),
  Descricao VARCHAR(100) NULL,
  PRIMARY KEY (IDUnidade),
  UNIQUE (Descricao)
);
GO

CREATE TABLE DBClientes (
  IDCliente INT NOT NULL IDENTITY(1,1),
  TipoPessoa VARCHAR(8) NULL,
  Cpf_Cnpj VARCHAR(14) NULL,
  Nome_RazaoSocial VARCHAR(100) NULL,
  Endereco VARCHAR(50) NULL,
  Numero VARCHAR(50) NULL,
  Bairro VARCHAR(50) NULL,
  Municipio VARCHAR(50) NULL,
  UF VARCHAR(2) NULL,
  Cep VARCHAR(8) NULL,
  Contato VARCHAR(50) NULL,
  Fone_1 VARCHAR(11) NULL,
  Fone_2 VARCHAR(11) NULL,
  Email VARCHAR(100) NULL,
  DataCadastro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (IDCliente),
  UNIQUE (Cpf_Cnpj)
);
GO

CREATE TABLE DBUsuarios (
  IDUsuario INT NOT NULL IDENTITY(1,1),
  Nome VARCHAR(100) NULL,
  Login VARCHAR(20) NULL,
  Senha VARCHAR(500) NULL,
  Endereco VARCHAR(50) NULL,
  Numero VARCHAR(50) NULL,
  Bairro VARCHAR(50) NULL,
  Municipio VARCHAR(50) NULL,
  UF VARCHAR(2) NULL,
  Cep VARCHAR(8) NULL,
  Fone_1 VARCHAR(11) NULL,
  Fone_2 VARCHAR(11) NULL,
  Email VARCHAR(100) NULL,
  DataCadastro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  Imagem VARBINARY(MAX) NULL,
  PRIMARY KEY (IDUsuario),
  UNIQUE (Nome),
  UNIQUE (Login)
);
GO

CREATE TABLE DBMarcas (
  IDMarca INT NOT NULL IDENTITY(1,1),
  Descricao VARCHAR(100) NULL,
  PRIMARY KEY (IDMarca),
  UNIQUE (Descricao)
);
GO

CREATE TABLE DBCategoriaServicos (
  IDCategoriaServico INT NOT NULL IDENTITY(1,1),
  Descricao VARCHAR(100) NULL,
  PRIMARY KEY (IDCategoriaServico),
  UNIQUE (Descricao)
);
GO

CREATE TABLE DBServicos (
	IDServico INT NOT NULL IDENTITY(1,1),
	IDCodigoBase VARCHAR(20) NULL,
	IDCategoriaServico INT NOT NULL,
	Descricao VARCHAR(100) NULL,
	ValorServico DECIMAL(10,2) NULL,
	PRIMARY KEY (IDServico),
	UNIQUE (IDCodigoBase),
	UNIQUE (Descricao)
);
GO

CREATE TABLE DBLancamentoServicos (
	IDOrdenServico INT NOT NULL IDENTITY(1,1),
	DataEmissao DATETIME NULL,
	DataConclusao DATETIME NULL,
	IDCliente INT NOT NULL,
	IDMarca INT NOT NULL,
	IDProduto INT NOT NULL,
	NumeroSerie VARCHAR(100) NULL,
	DescricaoDefeito TEXT NULL,
	GarantiaServico VARCHAR(50) NULL,
	GarantiaMaterial VARCHAR(50) NULL,
	ValorTotalServico DECIMAL(10,2) NULL,
	ValorTotalMaterial DECIMAL(10,2) NULL,
	Imagem VARBINARY(MAX) NULL,
	PRIMARY KEY (IDOrdenServico)
);
GO