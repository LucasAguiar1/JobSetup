use JobSetupPREPROD

ALTER TABLE TB_TIPORESPOSTA DROP COLUMN id;
ALTER TABLE TB_TIPORESPOSTA ADD id int;

INSERT INTO TB_TIPORESPOSTA (id, tipoResposta) VALUES (1,'Alternativas');
INSERT INTO TB_TIPORESPOSTA (id, tipoResposta) VALUES (2,'Condi��o');
INSERT INTO TB_TIPORESPOSTA (id, tipoResposta) VALUES (3,'Texto');
INSERT INTO TB_TIPORESPOSTA (id, tipoResposta) VALUES (4,'N�mero');


