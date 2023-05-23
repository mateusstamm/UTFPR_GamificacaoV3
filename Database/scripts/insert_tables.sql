CREATE TABLE IF NOT EXISTS Mesas (
    MesaID INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Numero INTEGER NULL,
    Ocupada TEXT NULL,
    HoraAbertura TEXT NULL
);

CREATE TABLE Garcons (
    GarconID INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Nome TEXT NULL,
    Sobrenome TEXT NULL,
    NumIdentificao INTEGER NULL,
    Telefone TEXT NULL
);

CREATE TABLE Categorias (
    CategoriaID INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Nome TEXT NULL,
    Descricao TEXT NULL
);

CREATE TABLE Atendimentos (
    AtendimentoID INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT,
    MesaID INTEGER NULL,
    GarconID INTEGER NULL,
    HorarioAtendimento TEXT NULL,
    PrecoTotal REAL NULL,
    CONSTRAINT FK_Atendimentos_Garcons_GarconID FOREIGN KEY (GarconID) REFERENCES Garcons (GarconID),
    CONSTRAINT FK_Atendimentos_Mesas_MesaID FOREIGN KEY (MesaID) REFERENCES Mesas (MesaID)
);

CREATE TABLE Produtos (
    ProdutoID INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Nome TEXT NULL,
    Descricao TEXT NULL,
    Preco REAL NULL,
    CategoriaID INTEGER NULL,
    CONSTRAINT FK_Produtos_Categorias_CategoriaID FOREIGN KEY (CategoriaID) REFERENCES Categorias (CategoriaID)
);

CREATE TABLE AtendimentoProduto (
    ProdutoID INTEGER NOT NULL,
    AtendimentoID INTEGER NOT NULL,
    Quantidade INTEGER NULL,
    CONSTRAINT PK_AtendimentoProduto PRIMARY KEY (AtendimentoID, ProdutoID),
    CONSTRAINT FK_AtendimentoProduto_Atendimentos_AtendimentoID FOREIGN KEY (AtendimentoID) REFERENCES Atendimentos (AtendimentoID) ON DELETE CASCADE,
    CONSTRAINT FK_AtendimentoProduto_Produtos_ProdutoID FOREIGN KEY (ProdutoID) REFERENCES Produtos (ProdutoID) ON DELETE CASCADE
);