CREATE DATABASE DBOrdem-Servicos;
USE DBOrdem-Servicos;

CREATE TABLE DBProdutos (
  IDProduto INT NOT NULL AUTO_INCREMENT,
  IDProdutoInterno VARCHAR(50),
  IDProdutoFabricante VARCHAR(50),
  Descricao VARCHAR(100),
  IDFornecedor INT,
  IDMarca INT,
  IDModelo INT,
  IDUnidade INT,
  PrecoCompra DECIMAL(10,2),
  PrecoVenda DECIMAL(10,2),
  EstoqueAtual DECIMAL(10,4),
  EstoqueMinimo DECIMAL(10,4),
  DataUltimaCompra DATETIME,
  Garantia VARCHAR(50),
  Imagem LONGBLOB,
  PRIMARY KEY (IDProduto),
  UNIQUE (IDProdutoInterno),
  UNIQUE (IDProdutoFabricante),
  UNIQUE (Descricao)
);

CREATE TABLE DBFornecedores (
  IDFornecedor INT NOT NULL AUTO_INCREMENT,
  TipoPessoa VARCHAR(8),
  Cpf_Cnpj VARCHAR(14),
  Nome_RazaoSocial VARCHAR(100),
  Endereco VARCHAR(50),
  Numero VARCHAR(50),
  Bairro VARCHAR(50),
  Municipio VARCHAR(50),
  UF VARCHAR(2),
  Cep VARCHAR(8),
  Contato VARCHAR(50),
  Fone_1 VARCHAR(11),
  Fone_2 VARCHAR(11),
  Email VARCHAR(100),
  DataCadastro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (IDFornecedor),
  UNIQUE (Cpf_Cnpj)
);

CREATE TABLE DBModelos (
  IDModelo INT NOT NULL AUTO_INCREMENT,
  IDMarca INT NOT NULL,
  Descricao VARCHAR(100),
  PRIMARY KEY (IDModelo),
  UNIQUE (Descricao)
);

CREATE TABLE DBUnidades (
  IDUnidade INT NOT NULL AUTO_INCREMENT,
  Descricao VARCHAR(100),
  PRIMARY KEY (IDUnidade),
  UNIQUE (Descricao)
);

CREATE TABLE DBClientes (
  IDCliente INT NOT NULL AUTO_INCREMENT,
  TipoPessoa VARCHAR(8),
  Cpf_Cnpj VARCHAR(14),
  Nome_RazaoSocial VARCHAR(100),
  Endereco VARCHAR(50),
  Numero VARCHAR(50),
  Bairro VARCHAR(50),
  Municipio VARCHAR(50),
  UF VARCHAR(2),
  Cep VARCHAR(8),
  Contato VARCHAR(50),
  Fone_1 VARCHAR(11),
  Fone_2 VARCHAR(11),
  Email VARCHAR(100),
  DataCadastro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (IDCliente),
  UNIQUE (Cpf_Cnpj)
);

CREATE TABLE DBUsuarios (
  IDUsuario INT NOT NULL AUTO_INCREMENT,
  Nome VARCHAR(100),
  Login VARCHAR(20),
  Senha VARCHAR(500),
  Endereco VARCHAR(50),
  Numero VARCHAR(50),
  Bairro VARCHAR(50),
  Municipio VARCHAR(50),
  UF VARCHAR(2),
  Cep VARCHAR(8),
  Fone_1 VARCHAR(11),
  Fone_2 VARCHAR(11),
  Email VARCHAR(100),
  DataCadastro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  Imagem LONGBLOB,
  PRIMARY KEY (IDUsuario),
  UNIQUE (Nome),
  UNIQUE (Login)
);

CREATE TABLE DBMarcas (
  IDMarca INT NOT NULL AUTO_INCREMENT,
  Descricao VARCHAR(100),
  PRIMARY KEY (IDMarca),
  UNIQUE (Descricao)
);

CREATE TABLE DBCategoriaServicos (
  IDCategoriaServico INT NOT NULL AUTO_INCREMENT,
  Descricao VARCHAR(100),
  PRIMARY KEY (IDCategoriaServico),
  UNIQUE (Descricao)
);

CREATE TABLE DBServicos (
  IDServico INT NOT NULL AUTO_INCREMENT,
  IDCodigoBase VARCHAR(20),
  IDCategoriaServico INT NOT NULL,
  Descricao VARCHAR(100),
  ValorServico DECIMAL(10,2),
  PRIMARY KEY (IDServico),
  UNIQUE (IDCodigoBase),
  UNIQUE (Descricao)
);

CREATE TABLE DBLancamentoServicos (
  IDOrdenServico INT NOT NULL AUTO_INCREMENT,
  DataEmissao DATETIME,
  DataConclusao DATETIME,
  IDCliente INT NOT NULL,
  IDMarca INT NOT NULL,
  IDProduto INT NOT NULL,
  NumeroSerie VARCHAR(100),
  DescricaoDefeito TEXT,
  GarantiaServico VARCHAR(50),
  GarantiaMaterial VARCHAR(50),
  ValorTotalServico DECIMAL(10,2),
  ValorTotalMaterial DECIMAL(10,2),
  Imagem LONGBLOB,
  PRIMARY KEY (IDOrdenServico)
);
