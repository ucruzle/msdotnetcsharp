
CREATE TABLE ge_sessao_usuario (
       Usuario         Char(15) NOT NULL,
       IdSession       Char(18) NOT NULL,
       DateTimeSession DateTime NOT NULL,
       MachineName     Char(50) NOT NULL,
       MachineIP       Char(50) NOT NULL,
       LogonNumber     Int NOT NULL
)
go


ALTER TABLE ge_sessao_usuario
       ADD PRIMARY KEY (Usuario)
go