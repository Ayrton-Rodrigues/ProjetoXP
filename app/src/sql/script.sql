USE master;
CREATE DATABASE CadastroCliente;

CREATE TABLE Clientes
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    DataCadastro DATETIME NOT NULL,
    DataAtualizacao DATETIME

);
CREATE UNIQUE NONCLUSTERED INDEX IDX_Cliente_Id ON Clientes (Id);

CREATE TABLE Enderecos
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    ClienteId UNIQUEIDENTIFIER,
    Numero NVARCHAR(50) NOT NULL,
    Bairro NVARCHAR(100) NOT NULL,
    Cidade NVARCHAR(100) NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    Cep NVARCHAR(10) NOT NULL
    CONSTRAINT FK_Cliente_Endereco FOREIGN KEY (ClienteId) REFERENCES Clientes (Id)
);
CREATE UNIQUE NONCLUSTERED INDEX IDX_Endereco_Id ON Enderecos (Id);

INSERT INTO Clientes (Id, Nome, Email, DataCadastro)
VALUES
  (NEWID(), 'João Silva', 'joao.silva@email.com', GETDATE()),
  (NEWID(), 'Maria Santos', 'maria.santos@email.com', GETDATE()),
  (NEWID(), 'Pedro Oliveira', 'pedro.oliveira@email.com', GETDATE()),
  (NEWID(), 'Ana Lima', 'ana.lima@email.com', GETDATE()),
  (NEWID(), 'Lucas Pereira', 'lucas.pereira@email.com', GETDATE());

INSERT INTO Enderecos (Id, ClienteId, Numero, Bairro, Cidade, Estado, Cep)
VALUES
  (NEWID(), (SELECT Id FROM Clientes WHERE Nome = 'João Silva'), '123', 'Centro', 'São Paulo', 'SP', '01000-000'),
  (NEWID(), (SELECT Id FROM Clientes WHERE Nome = 'Maria Santos'), '456', 'Jardim', 'Rio de Janeiro', 'RJ', '20000-000'),
  (NEWID(), (SELECT Id FROM Clientes WHERE Nome = 'Pedro Oliveira'), '789', 'Vila Nova', 'Belo Horizonte', 'MG', '30000-000'),
  (NEWID(), (SELECT Id FROM Clientes WHERE Nome = 'Ana Lima'), '101', 'Lapa', 'Curitiba', 'PR', '80000-000'),
  (NEWID(), (SELECT Id FROM Clientes WHERE Nome = 'Lucas Pereira'), '202', 'Itaim', 'São Paulo', 'SP', '02000-000');

