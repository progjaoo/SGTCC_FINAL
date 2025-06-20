
CREATE TABLE [Projeto] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[Nome] CHAR(100) NOT NULL,
	[Descricao] CHAR(300) NOT NULL,
	[Justificativa] CHAR(300) NOT NULL,
	[DataInicio] DATETIME NOT NULL,
	[DataFim] DATETIME,
	[Aprovado] BIT NOT NULL,
	[Estado] INT NOT NULL,
	[CriadoEm] DATETIME NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [Usuario] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdCurso] INT NOT NULL,
	[Nome] NVARCHAR(100) NOT NULL,
	[Email] NVARCHAR(100) NOT NULL,
	[Senha] NVARCHAR(255) NOT NULL,
	[Papel] INT NOT NULL,
	[IdImagem] INT,
	[UltimoAcesso] DATETIME,
	[CriadoEm] DATETIME NOT NULL,
	[EditadoEm] DATETIME,
	PRIMARY KEY([Id])
);


CREATE TABLE [Curso] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[Nome] NVARCHAR(100) NOT NULL,
	[Descricao] NVARCHAR(500) NOT NULL,
	[CriadoEm] DATETIME NOT NULL,
	[EditadoEm] DATETIME,
	PRIMARY KEY([Id])
);


CREATE TABLE [ProjetoEntrega] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdProjeto] INT NOT NULL,
	[Titulo] NVARCHAR(100) NOT NULL,
	[DataLimite] DATETIME NOT NULL,
	[DataEnvio] DATETIME,
	[Entregue] BIT NOT NULL,
	[CriadoEm] DATETIME NOT NULL,
	[EditadoEm] DATETIME,
	PRIMARY KEY([Id])
);


CREATE TABLE [ProjetoArquivo] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdProjeto] INT NOT NULL,
	[IdArquivo] INT NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [ProjetoTag] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdProjeto] INT NOT NULL,
	[Nome] NVARCHAR(255) NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [ProjetoAtividade] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdProjeto] INT NOT NULL,
	[Nome] NVARCHAR(50) NOT NULL,
	[Descricao] NVARCHAR(300) NOT NULL,
	[Estado] INT NOT NULL,
	[CriadoEm] DATETIME,
	[EditadoEm] DATETIME,
	PRIMARY KEY([Id])
);


CREATE TABLE [AtividadeProposta] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[Nome] NVARCHAR(50) NOT NULL,
	[Descricao] NVARCHAR(300) NOT NULL,
	[Concluida] BIT NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [Tag] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[Nome] NVARCHAR(50) NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [UsuarioProjeto] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdUsuario] INT NOT NULL,
	[IdProjeto] INT NOT NULL,
	[Funcao] INT NOT NULL,
	[AdicionadoEm] DATETIME NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [ProjetoAvaliacaoPublica] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdUsuario] INT NOT NULL,
	[IdProjeto] INT NOT NULL,
	[Avaliacao] INT NOT NULL,
	[DataAvaliacao] DATETIME NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [CampoDocumentoAvaliacaoAluno] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[Campo] NVARCHAR(100) NOT NULL,
	[IdCateria] INT NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [NotaDocumentoAluno] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdAvaliadorBanca] INT NOT NULL,
	[IdCampo] INT NOT NULL,
	[IdAluno] INT NOT NULL,
	[Nota] INT NOT NULL,
	[Tipo] INT NOT NULL,
	[CriadoEm] DATETIME NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [Banca] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdProjeto] INT NOT NULL,
	[DataSeminario] DATETIME NOT NULL,
	[Parecer] INT,
	[ObservacaoNotaProjeto] NVARCHAR(500),
	[ObservacaoAluno] NVARCHAR(500),
	[Recomendacao] NVARCHAR(500),
	[CriadoEm] DATETIME NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [AvaliadorBanca] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdUsuario] INT NOT NULL,
	[IdBanca] INT NOT NULL,
	[AdicionadoEm] DATETIME NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [NotaFinalAluno] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdAvaliadorBanca] INT NOT NULL,
	[IdAluno] INT NOT NULL,
	[Nota] INT NOT NULL,
	[CriadoEm] DATETIME NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [Cateria] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[Valor] NVARCHAR(100) NOT NULL,
	PRIMARY KEY([Id])
);


/**
PERGUNTA: Enum direto no usuario
*/
/*
CREATE TABLE [Papel] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[Nome] NVARCHAR(255) NOT NULL,
	[Ativo] BIT NOT NULL,
	PRIMARY KEY([Id])
);

*/

CREATE TABLE [Arquivo] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[NomeOriginal] NVARCHAR(255) NOT NULL,
	[Diretorio] NVARCHAR(255) NOT NULL,
	[CriadoEm] DATETIME NOT NULL,
	[EditadoEm] DATETIME,
	[Tamanho] INT NOT NULL,
	PRIMARY KEY([Id])
);


CREATE TABLE [ProjetoComentario] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdUsuario] INT NOT NULL,
	[IdProjeto] INT NOT NULL,
	[Comentario] NVARCHAR(300) NOT NULL,
	[CriadoEm] DATETIME NOT NULL,
	[EditadoEm] DATETIME,
	PRIMARY KEY([Id])
);


CREATE TABLE [AtividadeComentario] (
	[Id] INT NOT NULL IDENTITY UNIQUE,
	[IdUsuario] INT NOT NULL,
	[IdAtividade] INT NOT NULL,
	[Comentario] NVARCHAR(300) NOT NULL,
	[CriadoEm] DATETIME NOT NULL,
	[EditadoEm] DATETIME,
	PRIMARY KEY([Id])
);


ALTER TABLE [ProjetoEntrega]
ADD FOREIGN KEY([IdProjeto]) REFERENCES [Projeto]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [ProjetoTag]
ADD FOREIGN KEY([IdProjeto]) REFERENCES [Projeto]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [ProjetoAtividade]
ADD FOREIGN KEY([IdProjeto]) REFERENCES [Projeto]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [UsuarioProjeto]
ADD FOREIGN KEY([IdUsuario]) REFERENCES [Usuario]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [UsuarioProjeto]
ADD FOREIGN KEY([IdProjeto]) REFERENCES [Projeto]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [ProjetoArquivo]
ADD FOREIGN KEY([IdProjeto]) REFERENCES [Projeto]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [ProjetoAvaliacaoPublica]
ADD FOREIGN KEY([IdUsuario]) REFERENCES [Usuario]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [ProjetoAvaliacaoPublica]
ADD FOREIGN KEY([IdProjeto]) REFERENCES [Projeto]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [AvaliadorBanca]
ADD FOREIGN KEY([IdUsuario]) REFERENCES [Usuario]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [AvaliadorBanca]
ADD FOREIGN KEY([IdBanca]) REFERENCES [Banca]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [NotaDocumentoAluno]
ADD FOREIGN KEY([IdAluno]) REFERENCES [Usuario]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [NotaFinalAluno]
ADD FOREIGN KEY([IdAluno]) REFERENCES [Usuario]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [Banca]
ADD FOREIGN KEY([IdProjeto]) REFERENCES [Projeto]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [Usuario]
ADD FOREIGN KEY([IdImagem]) REFERENCES [Arquivo]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [ProjetoArquivo]
ADD FOREIGN KEY([IdArquivo]) REFERENCES [Arquivo]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [CampoDocumentoAvaliacaoAluno]
ADD FOREIGN KEY([IdCateria]) REFERENCES [Cateria]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [NotaDocumentoAluno]
ADD FOREIGN KEY([IdAvaliadorBanca]) REFERENCES [AvaliadorBanca]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [NotaDocumentoAluno]
ADD FOREIGN KEY([IdCampo]) REFERENCES [CampoDocumentoAvaliacaoAluno]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [NotaFinalAluno]
ADD FOREIGN KEY([IdAvaliadorBanca]) REFERENCES [AvaliadorBanca]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [Usuario]
ADD FOREIGN KEY([IdCurso]) REFERENCES [Curso]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [ProjetoComentario]
ADD FOREIGN KEY([IdUsuario]) REFERENCES [Usuario]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [ProjetoComentario]
ADD FOREIGN KEY([IdProjeto]) REFERENCES [Projeto]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [AtividadeComentario]
ADD FOREIGN KEY([IdAtividade]) REFERENCES [ProjetoAtividade]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE [AtividadeComentario]
ADD FOREIGN KEY([IdUsuario]) REFERENCES [Usuario]([Id])
ON UPDATE NO ACTION ON DELETE NO ACTION;
