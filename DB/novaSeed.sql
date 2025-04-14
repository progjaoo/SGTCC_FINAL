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
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Biomedicina', 'Curso voltado ao estudo das doenças humanas, microbiologia e análises clínicas.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Farmácia', 'Formação focada em medicamentos, análises clínicas e atenção farmacêutica.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Fisioterapia', 'Curso voltado à reabilitação física e promoção da saúde motora.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Engenharia de Software', 'Curso que aborda o desenvolvimento e gestão de softwares.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Dual Administração', 'Curso integrado com foco prático em gestão e negócios.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Marketing Digital', 'Curso voltado às estratégias digitais e comportamento do consumidor online.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Produção Multimídia', 'Curso que une design, vídeo, som e animação para meios digitais.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Educação Física', 'Formação focada no movimento humano e práticas esportivas.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Enfermagem', 'Curso voltado ao cuidado com a saúde e atenção ao paciente.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Engenharia de Produção', 'Curso que une engenharia e gestão para melhorar processos produtivos.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Ciências Contábeis', 'Formação em contabilidade, tributos e finanças empresariais.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Logística', 'Curso focado no gerenciamento de cadeias de suprimento e distribuição.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Letras', 'Curso voltado ao estudo da linguagem, literatura e linguística.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Pedagogia', 'Formação para atuação na educação infantil e nos anos iniciais.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Engenharia Civil', 'Curso voltado ao projeto e execução de obras e estruturas.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Engenharia Elétrica/Eletrônica', 'Curso focado em sistemas elétricos, automação e eletrônica.', GETDATE());
GO
INSERT INTO [Curso] (Nome, Descricao, CriadoEm) VALUES ('Gestão de RH', 'Curso sobre gestão de pessoas, recrutamento e clima organizacional.', GETDATE());
GO

INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm)
VALUES (1, 'Admin', 'admin@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 3, NULL, NULL, GETDATE());
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm) 
VALUES (1, 'Gilberto Luis', 'gilberto.luis@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, NULL, NULL, GETDATE());
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm) 
VALUES (1, 'João Marcos', 'joao.marcos@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, NULL, NULL, GETDATE());
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm) 
VALUES (1, 'João Evangelista', 'joao.evangelista@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, NULL, NULL, GETDATE());
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm) 
VALUES (2, 'Pedro', 'pedro@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, NULL, NULL, GETDATE());
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm)
VALUES (7, 'Lucas Silva', 'lucas.silva@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, NULL, NULL, GETDATE());
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm)
VALUES (11, 'Mariana Torres', 'mariana.torres@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, NULL, NULL, GETDATE());
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm)
VALUES (6, 'Carlos Mendes', 'carlos.mendes@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, NULL, NULL, GETDATE());
GO
INSERT INTO [Usuario] (IdCurso, Nome, Email, Senha, Papel, IdImagem, UltimoAcesso, CriadoEm)
VALUES (1, 'Rafael Chiareli', 'rafael.chiareli@aedb.br', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 2, NULL, NULL, GETDATE());
GO


INSERT INTO [Projeto] (Nome, Descricao, Justificativa, DataInicio, DataFim, Aprovado, Estado, CriadoEm) 
VALUES ('Pesquisa em Inteligência Artificial', 'Estudo sobre novas abordagens em IA.', 'Explorar avanços na tecnologia e suas aplicações.', '2025-02-01', '2025-03-10', 2, 3, GETDATE());
GO
INSERT INTO [Projeto] (Nome, Descricao, Justificativa, DataInicio, DataFim, Aprovado, Estado, CriadoEm) 
VALUES ('Automação de Processos', 'Implementação de robótica em processos administrativos.', 'Aumentar a eficiência operacional da empresa.', '2025-01-10', '2025-04-10', 2, 3, GETDATE());
GO
INSERT INTO [Projeto] (Nome, Descricao, Justificativa, DataInicio, DataFim, Aprovado, Estado, CriadoEm) 
VALUES ('Sistema de Monitoramento Ambiental', 'Desenvolvimento de um sistema para monitorar a qualidade do ar.', 'Contribuir para a sustentabilidade e saúde pública.', '2025-03-15', NULL, 2, 3, GETDATE());
GO
INSERT INTO [Projeto] (Nome, Descricao, Justificativa, DataInicio, DataFim, Aprovado, Estado, CriadoEm)
VALUES ('Plataforma de Gestão Acadêmica', 'Desenvolvimento de sistema para gerenciamento de cursos e alunos.', 'Modernizar a gestão universitária.', '2025-02-01',  '2025-04-10', 2, 3, GETDATE());
GO
INSERT INTO [Projeto] (Nome, Descricao, Justificativa, DataInicio, DataFim, Aprovado, Estado, CriadoEm)
VALUES ('Campanha de Marketing para Saúde Mental', 'Criação de conteúdo digital para redes sociais.', 'Sensibilizar jovens sobre o cuidado com a saúde mental.', '2025-04-01', '2025-04-02', 2, 3, GETDATE());
GO
INSERT INTO [Projeto] (Nome, Descricao, Justificativa, DataInicio, DataFim, Aprovado, Estado, CriadoEm)
VALUES ('Análise de Patógenos em Águas Urbanas', 'Projeto de análise microbiológica de águas.', 'Contribuir para políticas públicas de saúde.', '2025-03-20',  '2025-03-25', 2, 3, GETDATE());
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

INSERT INTO [UsuarioProjeto] (IdUsuario, IdProjeto, Funcao, AdicionadoEm) 
VALUES (6, 4, 1, GETDATE());
GO
INSERT INTO [UsuarioProjeto] (IdUsuario, IdProjeto, Funcao, AdicionadoEm) 
VALUES (7, 5, 1, GETDATE());
GO
INSERT INTO [UsuarioProjeto] (IdUsuario, IdProjeto, Funcao, AdicionadoEm) 
VALUES (8, 6, 1, GETDATE());
GO

-- Projeto 1: Pesquisa em Inteligência Artificial
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (1, 'Inteligência Artificial');
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (1, 'Pesquisa');
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (1, 'Tecnologia');

-- Projeto 2: Automação de Processos
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (2, 'Automação');
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (2, 'Robótica');
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (2, 'Processos');

-- Projeto 3: Sistema de Monitoramento Ambiental
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (3, 'Sustentabilidade');
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (3, 'Meio Ambiente');
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (3, 'Tecnologia Verde');

-- Projeto 4: Plataforma de Gestão Acadêmica
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (4, 'Educação');
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (4, 'Gestão');
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (4, 'Software');

-- Projeto 5: Campanha de Marketing para Saúde Mental
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (5, 'Saúde Mental');
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (5, 'Marketing Digital');
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (5, 'Comunicação');

-- Projeto 6: Análise de Patógenos em Águas Urbanas
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (6, 'Biomedicina');
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (6, 'Saúde Pública');
INSERT INTO [ProjetoTag] (IdProjeto, Nome) VALUES (6, 'Análise Microbiológica');