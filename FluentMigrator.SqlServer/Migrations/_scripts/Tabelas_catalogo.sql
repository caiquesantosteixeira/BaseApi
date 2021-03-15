CREATE TABLE [dbo].[categorias_cliente] (
  [id] int identity(1,1) NOT NULL,
  [nome] varchar(50) NOT NULL,
  [imagem] varchar(50) NOT NULL,
  PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
CREATE NONCLUSTERED INDEX [idx_categorias_clientes_id]
ON [dbo].[categorias_cliente] (
  [id]
)
GO

CREATE TABLE [dbo].[categorias_produto] (
  [id] int identity(1,1) NOT NULL,
  [nome] varchar(60) NOT NULL,
  [id_externo] varchar(20) NULL,
  [id_cliente] int NOT NULL,
  [ativa] bit DEFAULT 1 NULL,
  [imagem] varchar(20),
  [data_cadastro] datetime NOT NULL,
  [data_alteracao] datetime null,
  PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
CREATE NONCLUSTERED INDEX [idx_categorias_id]
ON [dbo].[categorias_produto] (
  [id]
)
GO
CREATE NONCLUSTERED INDEX [idx_categorias_id_cliente]
ON [dbo].[categorias_produto] (
  [id_cliente]
)
GO

CREATE TABLE [dbo].[clientes] (
  [id] int identity(1,1) NOT NULL,
  [id_externo] varchar(30) NOT NULL,
  [razao_social] varchar(120) NOT NULL,
  [fantasia] varchar(120) NOT NULL,
  [endereco] varchar(120) NOT NULL,
  [bairro] varchar(60) NOT NULL,
  [cidade] varchar(50) NULL,
  [ibge] int NOT NULL,
  [estado] varchar(2) NOT NULL,
  [cep] varchar(255) NULL,
  [telefone] varchar(40) NULL,
  [cpf_cnpj] varchar(14) NOT NULL,
  [rg_ie] varchar(13) NULL,
  [email] varchar(80) NOT NULL,
  [data_cadastro] datetime NOT NULL,
  [data_alteracao] datetime NULL,
  [id_categoria_clientes] int,
  [imagem] varchar(50) NULL,
  [ativo] bit DEFAULT 0 NULL,
  [tenant] varchar(80) NULL,
  [whatsApp] varchar(255) NULL,
  [instagram] varchar(150) NULL,
  PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
CREATE NONCLUSTERED INDEX [idx_clientes_id]
ON [dbo].[clientes] (
  [id]
)
GO
CREATE NONCLUSTERED INDEX [idx_categorias_cliente]
ON [dbo].[clientes] (
  [id_categoria_clientes]
)
GO

CREATE TABLE [dbo].[clientes_usuarios] (
  [id] int identity(1,1) NOT NULL,
  [id_cliente] int NULL,
  [id_usuario] nvarchar(450) NULL,
  PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [dbo].[produtos] (
  [id] int identity(1,1) NOT NULL,
  [produto] varchar(120) NOT NULL,
  [preco_atual] decimal(18,2) NOT NULL,
  [preco_anterior] decimal(18,2) NULL,
  [id_cliente] int NOT NULL,
  [data_cadastro] datetime NOT NULL,
  [data_alteracao] datetime NULL,
  [id_categoria_produto] int NULL,
  [ativo] bit DEFAULT 1 NULL,
  [id_externo] varchar(30) NOT NULL,
  [imagem] varchar(20),
  PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
CREATE NONCLUSTERED INDEX [idx_produtos_id]
ON [dbo].[produtos] (
  [id]
)
GO
CREATE NONCLUSTERED INDEX [idx_produtos_id_categoria_produto]
ON [dbo].[produtos] (
  [id_categoria_produto]
)
GO
DROP INDEX [idx_categorias_clientes_id] ON [dbo].[categorias_cliente]
GO
CREATE NONCLUSTERED INDEX [idx_categorias_clientes_id]
ON [dbo].[categorias_cliente] (
  [id]
)
GO
DROP INDEX [idx_categorias_id] ON [dbo].[categorias_produto]
GO
DROP INDEX [idx_categorias_id_cliente] ON [dbo].[categorias_produto]
GO
ALTER TABLE [dbo].[categorias_produto] ADD CONSTRAINT [fk_categorias_id_cliente] FOREIGN KEY ([id_cliente]) REFERENCES [dbo].[clientes] ([id])
GO
CREATE NONCLUSTERED INDEX [idx_categorias_id]
ON [dbo].[categorias_produto] (
  [id]
)
GO
CREATE NONCLUSTERED INDEX [idx_categorias_id_cliente]
ON [dbo].[categorias_produto] (
  [id_cliente]
)
GO
DROP INDEX [idx_clientes_id] ON [dbo].[clientes]
GO
DROP INDEX [idx_categorias_cliente] ON [dbo].[clientes]
GO
ALTER TABLE [dbo].[clientes] ADD CONSTRAINT [fk_clientes_id_categorias_cliente] FOREIGN KEY ([id_categoria_clientes]) REFERENCES [dbo].[categorias_cliente] ([id])
GO
CREATE NONCLUSTERED INDEX [idx_clientes_id]
ON [dbo].[clientes] (
  [id]
)
GO
CREATE NONCLUSTERED INDEX [idx_categorias_cliente]
ON [dbo].[clientes] (
  [id_categoria_clientes]
)
GO

ALTER TABLE [dbo].[clientes_usuarios] ADD CONSTRAINT [fk_clientes_usuarios_id_cliente] FOREIGN KEY ([id_cliente]) REFERENCES [dbo].[clientes] ([id])
GO

ALTER TABLE [dbo].[clientes_usuarios] ADD CONSTRAINT [fk_clientes_usuarios_id_usuario] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[usuarios] ([id])
GO

DROP INDEX [idx_produtos_id] ON [dbo].[produtos]
GO

DROP INDEX [idx_produtos_id_categoria_produto] ON [dbo].[produtos]
GO

ALTER TABLE [dbo].[produtos] ADD CONSTRAINT [fk_produtos_id_categoria_produto] FOREIGN KEY ([id_categoria_produto]) REFERENCES [dbo].[categorias_produto] ([id])
GO

ALTER TABLE [dbo].[produtos] ADD CONSTRAINT [fk_produtos_id_cliente] FOREIGN KEY ([id_cliente]) REFERENCES [dbo].[clientes] ([id])
GO

CREATE NONCLUSTERED INDEX [idx_produtos_id]
ON [dbo].[produtos] (
  [id]
)
GO

CREATE NONCLUSTERED INDEX [idx_produtos_id_categoria_produto]
ON [dbo].[produtos] (
  [id_categoria_produto]
)
GO

