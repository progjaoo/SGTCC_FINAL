USE SGTCC
GO

INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Sistema de Informação', 'Curso que abrange teoria e prática em programação, algoritmos e sistemas computacionais.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Administração', 'Estudo das práticas de gestão e organização de empresas e negócios.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Psicologia', 'Estudo do comportamento humano e processos mentais.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Direito', 'Estudo das leis e do sistema jurídico, preparando profissionais para a advocacia.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Engenharia Mecânica', 'Curso que aborda a concepção e desenvolvimento de sistemas mecânicos e térmicos.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Comunicação', 'Formação em comunicação e produção de conteúdo informativo para diversos meios.', GETDATE());
GO

INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm, EmailVerificado)
VALUES (1, 'Admin', 'admin@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 3, NULL, NULL, GETDATE(), 1);
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm, EmailVerificado) 
VALUES (1, 'Gilberto Luis', 'gilberto.luis@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, NULL, NULL, GETDATE(), 1);
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm, EmailVerificado) 
VALUES (1, 'João Marcos', 'joao.marcos@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, NULL, NULL, GETDATE(), 1);
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm, EmailVerificado) 
VALUES (1, 'João Evangelista', 'joao.evangelista@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, NULL, NULL, GETDATE(), 1);
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm, EmailVerificado) 
VALUES (2, 'Pedro', 'pedro@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, NULL, NULL, GETDATE(), 1);
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm, EmailVerificado, Permissao) 
VALUES (2, 'Teste Professor', 'teste.professor@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 2, NULL, NULL, GETDATE(), 1, 0);
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm, EmailVerificado, Permissao) 
VALUES (2, 'Teste Coordenador', 'teste.coordenador@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 4, NULL, NULL, GETDATE(), 1, 0);
GO

INSERT INTO [Projeto] (Nome, Descricao, Justificativa, DataInicio, DataFim, Aprovado, Estado, CriadoEm) 
VALUES ('Pesquisa em Inteligência Artificial', 'Estudo sobre novas abordagens em IA.', 'Explorar avanços na tecnologia e suas aplicações.', '2024-02-01', NULL, 1, 3, GETDATE());
GO
INSERT INTO [Projeto] (Nome, Descricao, Justificativa, DataInicio, DataFim, Aprovado, Estado, CriadoEm) 
VALUES ('Automação de Processos', 'Implementação de robótica em processos administrativos.', 'Aumentar a eficiência operacional da empresa.', '2024-01-10', '2024-04-10', 1, 3, GETDATE());
GO
INSERT INTO [Projeto] (Nome, Descricao, Justificativa, DataInicio, DataFim, Aprovado, Estado, CriadoEm) 
VALUES ('Sistema de Monitoramento Ambiental', 'Desenvolvimento de um sistema para monitorar a qualidade do ar.', 'Contribuir para a sustentabilidade e saúde pública.', '2024-03-15', NULL, 1, 3, GETDATE());
GO

INSERT INTO [UsuarioProjeto] (IdUsuario, IdProjeto, Funcao, AdicionadoEm) 
VALUES (2, 1, 1, GETDATE());
GO
INSERT INTO [UsuarioProjeto] (IdUsuario, IdProjeto, Funcao, AdicionadoEm) 
VALUES (3, 1, 1, GETDATE());
GO
INSERT INTO [UsuarioProjeto] (IdUsuario, IdProjeto, Funcao, AdicionadoEm) 
VALUES (4, 1, 1, GETDATE());
GO

INSERT INTO [UsuarioProjeto] (IdUsuario, IdProjeto, Funcao, AdicionadoEm) 
VALUES (2, 2, 1, GETDATE());
GO
INSERT INTO [UsuarioProjeto] (IdUsuario, IdProjeto, Funcao, AdicionadoEm) 
VALUES (3, 2, 1, GETDATE());
GO
INSERT INTO [UsuarioProjeto] (IdUsuario, IdProjeto, Funcao, AdicionadoEm) 
VALUES (4, 2, 1, GETDATE());
GO

INSERT INTO [UsuarioProjeto] (IdUsuario, IdProjeto, Funcao, AdicionadoEm) 
VALUES (5, 3, 1, GETDATE());
GO