Back-end Todo-List
##################

Api Rest para gerenciamento de tarefas em Asp.net Core e SQL Server.
Utiliza Entity-framework para abstração de dados. No arquivo
"program.cs" deve-se estabelecer a connection string com o
banco de dados Sql Server. Segue o script de criação do banco de dados

#################################################################################

USE [todo_list]
GO

/****** Object:  Table [dbo].[Tarefas]    Script Date: 06/11/2023 11:30:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tarefas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
	[Progresso] [char](1) NOT NULL,
	[DtPrazo] [datetime] NULL,
 CONSTRAINT [PK_Tarefas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

###########################################################################################################################################################################

Abrir o .sln no Visual Studio 22 e rodar ou fazer o deploy no IIS.