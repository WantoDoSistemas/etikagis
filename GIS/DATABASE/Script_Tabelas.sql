-- 1 - Tabela de Status OK
create table t_sgs_status(
	cd_status int identity primary key,
	dc_status varchar(50),
	no_userid_cadastro varchar(20),
	dt_cadastro datetime,
	no_userid_alteracao varchar(20),
	dt_ultima_alteracao datetime 
)
--select * from t_sgs_status


-- 2 - Tabela de Empresa OK
create table t_sgs_empresa(
	cd_empresa int identity primary key,
	dc_razao_social varchar(200),
	dc_nome_fantasia varchar(200),
	nm_cnpj varchar(18),
	nm_inscricao_estadual varchar(12),
	nm_inscricao_municipal varchar(11),
	dc_email varchar(200),
	nm_cep_cobranca varchar(9),
	dc_endereco_cobranca varchar(200),
	dc_cidade_cobranca varchar(100),
	dc_uf_cobranca char(2),
	nm_telefone varchar(20),
	cd_status int,
	no_userid_cadastro varchar(20),
	dt_cadastro datetime,
	no_userid_alteracao varchar(20),
	dt_ultima_alteracao datetime,
	foreign key(cd_status) references t_sgs_status(cd_status)
)
--select * from t_sgs_empresa



-- 3 - Tabela de Perfil(representante)
create table t_sgs_perfil_representante(
	cd_perfil int identity primary key,
	dc_perfil varchar(80),
	cd_status int,
	no_userid_cadastro varchar(20),
	dt_cadastro datetime,
	no_userid_alteracao varchar(20),
	dt_ultima_alteracao datetime,
	foreign key(cd_status) references t_sgs_status(cd_status)
)
--select * from t_sgs_perfil_representante


-- 4 - Tabela de Representante
create table t_sgs_representante(
	cd_representante int identity primary key,
	cd_empresa int,
	cd_perfil int,
	no_representante varchar(80),
	dc_usuario varchar(20),
	dc_senha varchar(20),
	dc_cargo varchar(50),
	dc_area varchar(30),
	nm_telefone varchar(20),
	dc_email varchar(200),
	xx_ponto_focal bit,
	cd_status int,
	no_userid_cadastro varchar(20),
	dt_cadastro datetime,
	no_userid_alteracao varchar(20),
	dt_ultima_alteracao datetime,
	foreign key(cd_empresa) references t_sgs_empresa(cd_empresa),
	foreign key(cd_perfil) references t_sgs_perfil_representante(cd_perfil),
	foreign key(cd_status) references t_sgs_status(cd_status)
)
--select * from t_sgs_representante



-- 5 - Tabela de Indicador
create table t_sgs_indicador(
	cd_indicador int identity primary key,
	nm_indicador int,
	dc_indicador varchar(3000),
	cd_forma_gestao int,
	cd_status int,
	no_userid_cadastro varchar(20),
	dt_cadastro datetime,
	no_userid_alteracao varchar(20),
	dt_ultima_alteracao datetime,
	foreign key(cd_status) references t_sgs_status(cd_status)
)
--select * from t_sgs_indicador



-- 6 - Tabela de categoria 
create table t_sgs_categoria(
	cd_categoria int identity primary key,
	dc_categoria varchar(200),
	cd_status int,
	no_userid_cadastro varchar(20),
	dt_cadastro datetime,
	no_userid_alteracao varchar(20),
	dt_ultima_alteracao datetime,
	foreign key(cd_status) references t_sgs_status(cd_status)
)
--select * from t_sgs_categoria




-- 6.1 - Tabela de Forma Gestão 
create table t_sgs_forma_gestao(
	cd_forma_gestao int identity primary key,
	dc_forma_gestao varchar(200),
	cd_categoria int,
	cd_status int,
	no_userid_cadastro varchar(20),
	dt_cadastro datetime,
	no_userid_alteracao varchar(20),
	dt_ultima_alteracao datetime,
	foreign key(cd_categoria) references t_sgs_categoria(cd_categoria),
	foreign key(cd_status) references t_sgs_status(cd_status)
)
--select * from t_sgs_forma_gestao



-- 7 - Tabela de Questão
create table t_sgs_questao(
	cd_questao int identity primary key,
	cd_indicador int,
	--cd_categoria int,
	dc_questao varchar(3000),
	cd_status int,
	no_userid_cadastro varchar(20),
	dt_cadastro datetime,
	no_userid_alteracao varchar(20),
	dt_ultima_alteracao datetime,
	foreign key(cd_indicador) references t_sgs_indicador(cd_indicador),
	--foreign key(cd_categoria) references t_sgs_categoria(cd_categoria),
	foreign key(cd_status) references t_sgs_status(cd_status)
)
--select * from t_sgs_questao



-- 8 - Tabele de Representante/Questão
create table t_sgs_representante_questao(
	cd_representante_questao int identity primary key,
	cd_representante int,
	cd_questao int,
	cd_status int,
	no_userid_cadastro varchar(20),
	dt_cadastro datetime,
	no_userid_alteracao varchar(20),
	dt_ultima_alteracao datetime,
	foreign key(cd_representante) references t_sgs_representante(cd_representante),
	foreign key(cd_questao) references t_sgs_questao(cd_questao),
	foreign key(cd_status) references t_sgs_status(cd_status),
)
--select * from t_sgs_representante_questao



-- 9 - Tabela de Resposta
create table t_sgs_resposta(
	cd_resposta int identity primary key,
	cd_representante_questao int,
	dc_resposta varchar(5000),
	cd_status int,
	dt_resposta datetime,
	no_userid varchar(20),
	dt_ultima_alteracao datetime,
	foreign key(cd_representante_questao) references t_sgs_representante_questao(cd_representante_questao),
	foreign key(cd_status) references t_sgs_status(cd_status)
)
--select * from t_sgs_resposta

