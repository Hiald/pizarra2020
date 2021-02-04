
/* v1 = 14 TABLAS */

CREATE TABLE IF NOT EXISTS maestro(
  `idmaestro` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(150) NULL,
  `descripcion` VARCHAR(250) NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
PRIMARY KEY (`idmaestro`));

CREATE TABLE IF NOT EXISTS maestro_parametro(
  `idmaestroparametro` INT NOT NULL AUTO_INCREMENT,
  `idmaestro` INT, 
  `nombre` VARCHAR(150) NULL,
  `descripcion` VARCHAR(250) NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
  FOREIGN KEY (idmaestro) REFERENCES maestro(idmaestro),
PRIMARY KEY (`idmaestroparametro`));

CREATE TABLE IF NOT EXISTS docente(
  `iddocente` INT NOT NULL AUTO_INCREMENT,
  `distrito` INT NULL,
  `ciudad` INT NULL,
  `provincia` INT NULL,
  `tipoprofesor` INT NULL, /* si es docente,guia */
  `nombre` VARCHAR(150) NULL,
  `etapa_escolar` INT NULL,
  `grado` INT NULL,
  `seccion` INT NULL,
  `apellido` VARCHAR(150) NULL,  
  `fechanac` DATETIME NULL,
  `celular1` CHAR(9) NULL,
  `celular2` CHAR(9) NULL,
  `numerofijo` VARCHAR(9) NULL,
  `genero` SMALLINT(1) NULL,
  `registo_estado` TINYINT(1) NULL, /* si se registro con fb o gmail*/
  `facebookest` SMALLINT(1) NULL,
  `gmailest` SMALLINT(1) NULL,
  `tipodoc` INT NULL,
  `documento` VARCHAR(50) NULL,
  `direccion` VARCHAR(100),
  `ruc` VARCHAR(25) NULL,
  `ocupacion` VARCHAR(250) NULL,
  `estadocivil` INT NULL,
  `ultima_conexion_fecha` DATETIME NULL, 
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
PRIMARY KEY (`iddocente`));

CREATE TABLE IF NOT EXISTS padre(
  `idpadre` INT NOT NULL AUTO_INCREMENT,
  `nombrepadre` VARCHAR(50) NULL,
  `apellidopadre` VARCHAR(50) NULL,
  `celularpadre` CHAR(9) NULL,
  `tipodocpadre` INT NULL,
  `dnipadre` VARCHAR(15) NULL,
  `generopadre` INT NULL,  
  `tipodoc` INT NULL,
  `documento` VARCHAR(50) NULL,  
  `ultima_conexion_fecha` DATETIME NULL, 
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
PRIMARY KEY (`idpadre`));

CREATE TABLE IF NOT EXISTS alumno(
  `idalumno` INT NOT NULL AUTO_INCREMENT,
  `idpadre` INT,
  `distrito` INT NULL,
  `ciudad` INT NULL,
  `provincia` INT NULL,
  `nombre` VARCHAR(150) NULL,
  `apellido` VARCHAR(150) NULL,
  `fechanac` DATETIME NULL,
  `email1` VARCHAR(100) NULL,
  `email2` VARCHAR(100) NULL,
  `celular1` CHAR(9) NULL,
  `celular2` CHAR(9) NULL,
  `numerofijo` VARCHAR(9) NULL,
  `genero` SMALLINT(1) NULL,
  `etapa_escolar` INT NULL,
  `grado` INT NULL,
  `seccion` INT NULL,
  `turno_clase` INT NULL,
  `registo_estado` TINYINT(1) NULL,
  `facebookest` SMALLINT(1) NULL,
  `gmailest` SMALLINT(1) NULL,
  `tipodoc` INT NULL,
  `documento` VARCHAR(50) NULL,
  `ubicacion_latitud` VARCHAR(100) NULL,
  `ubicacion_longitud` VARCHAR(100) NULL,
  `suscripcion_estado` SMALLINT(1) NULL,
  `direccion` VARCHAR(100),
  `referencia` VARCHAR(50),
  `cuenta_verificada_estado` SMALLINT(1) NULL,
  `ruc` VARCHAR(25) NULL,
  `ultima_conexion_fecha` DATETIME NULL, 
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
  FOREIGN KEY (idpadre) REFERENCES padre(idpadre),
PRIMARY KEY (`idalumno`));

CREATE TABLE IF NOT EXISTS historialacceso(
  `idhistorial`  INT NOT NULL AUTO_INCREMENT,
  `idalumno` INT,
  `intentos` INT NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
  FOREIGN KEY (idalumno) REFERENCES alumno(idalumno),
PRIMARY KEY (`idhistorial`));

CREATE TABLE IF NOT EXISTS accesoalumno(
  `idacceso` INT NOT NULL AUTO_INCREMENT,
  `idalumno` INT,
  `email` VARCHAR(100) NULL,
  `clave` VARCHAR(500) NULL,
  `tocken` VARCHAR(500) NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
  FOREIGN KEY (idalumno) REFERENCES alumno(idalumno),
PRIMARY KEY (`idacceso`));

CREATE TABLE IF NOT EXISTS etapa_escolar( /* INICIAL, PRIMARIA, SECUNDARIA */ 
  `idetapa` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(100) NULL,
  `descripcion` VARCHAR(150) NULL,  
  `rutaimagen` VARCHAR(150) NULL,
  `comision_nombre` DECIMAL(10,2) NULL,
  `pasarela_pago_nombre` VARCHAR(50) NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
PRIMARY KEY (`idetapa`));

CREATE TABLE IF NOT EXISTS grado( /* QUINTO DE SECUNDARIA, QUINTO DE PRIMARIA, PRIMERO INICIAL, ETC */
  `idgrado` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(150) NULL,
  `idetapa` INT,
  `descripcion` VARCHAR(250) NULL,
  `monto` INT NULL,
  `rutaimagen` VARCHAR(150) NULL,
  `videoenlace` VARCHAR(250) NULL,  
  `valoracion` INT NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
FOREIGN KEY (idetapa) REFERENCES etapa_escolar(idetapa),
PRIMARY KEY (`idgrado`));

CREATE TABLE IF NOT EXISTS curso( /* matematica, quimica, etc */
  `idcurso` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(150) NULL,
  `idgrado` INT,
  `descripcion` VARCHAR(250) NULL,
  `monto` INT NULL,
  `rutaimagen` VARCHAR(150) NULL,
  `videoenlace` VARCHAR(250) NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
FOREIGN KEY (idgrado) REFERENCES grado(idgrado),
PRIMARY KEY (`idcurso`));

CREATE TABLE IF NOT EXISTS video(  /* ESTA EL NOMBRE DEL VIDEO: circunferencias, cojuntos primarios.mp4, ETC */
  `idvideo` INT NOT NULL AUTO_INCREMENT,
  `idcurso` INT,  
  `nombre` VARCHAR(150) NULL,
  `descripcion` VARCHAR(250) NULL,
  `orden` VARCHAR(150) NULL,
  `categorialeccion` INT, /* si es un video normal o especial */
  `rutaenlace` VARCHAR(250) NULL,
  `rutavideo` VARCHAR(150) NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
  `idsemana` INT(11) NULL,
  FOREIGN KEY (idcurso) REFERENCES curso(idcurso),
PRIMARY KEY (`idvideo`));

CREATE TABLE IF NOT EXISTS progreso_alumno(
  `idprogreso` INT NOT NULL AUTO_INCREMENT,
  `idvideo` INT,
  `idalumno` INT,
  `nombre` VARCHAR(150) NULL,
  `puntosacumulados` INT NULL,
  `fechareg` DATETIME NULL,
  `activo` BIT(1) NULL,
  FOREIGN KEY (idvideo) REFERENCES video(idvideo),
  FOREIGN KEY (idalumno) REFERENCES alumno(idalumno),
PRIMARY KEY (`idprogreso`));

CREATE TABLE IF NOT EXISTS pago(
  `idpago` INT NOT NULL AUTO_INCREMENT,
  `idalumno` INT,
  `idetapa` INT,
  `nombre` VARCHAR(100) NULL,
  `tipopago` INT NULL,
  `dia` INT NULL,
  `mes` INT NULL,
  `anio` VARCHAR(4) NULL,
  `monto` DECIMAL(10,2) NULL,
  `igv` DECIMAL(10,2) NULL,
  `comision_nombre` DECIMAL(10,2) NULL,
  `pasarela_pago_nombre` VARCHAR(50) NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
  `fechafin` DATETIME NULL,
  FOREIGN KEY (idalumno) REFERENCES alumno(idalumno),
  FOREIGN KEY (idetapa) REFERENCES etapa_escolar(idetapa),
PRIMARY KEY (`idpago`));

CREATE TABLE IF NOT EXISTS historial_acceso_alumno(
  `idhistorialalumno` INT NOT NULL AUTO_INCREMENT,
  `idalumno` INT,
  `tipoconexion` INT NULL, /* si es login o es cerrar sesion */
  `direccionip` VARCHAR(150) NULL,
  `direccionmac` VARCHAR(150) NULL,
  `fechafin` DATETIME NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
  FOREIGN KEY (idalumno) REFERENCES alumno(idalumno),
PRIMARY KEY (`idhistorialalumno`));

/* v1 = 14 TABLAS */
/* ----------------------------------------------------------------------- */

CREATE TABLE IF NOT EXISTS accesodocente(
  `idaccesodocente` INT NOT NULL AUTO_INCREMENT,
  `iddocente` INT,
  `email` VARCHAR(100) NULL,
  `clave` VARCHAR(500) NULL,
  `tocken` VARCHAR(500) NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
  FOREIGN KEY (iddocente) REFERENCES docente(iddocente),
PRIMARY KEY (`idaccesodocente`));


CREATE TABLE IF NOT EXISTS historial_acceso_docente(
  `idhistorialdocente` INT NOT NULL AUTO_INCREMENT,
  `iddocente` INT,
  `tipoconexion` INT NULL, /* si es login o es cerrar sesion */
  `direccionip` VARCHAR(150) NULL,
  `direccionmac` VARCHAR(150) NULL,
  `fechafin` DATETIME NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
  FOREIGN KEY (iddocente) REFERENCES docente(iddocente),
PRIMARY KEY (`idhistorialdocente`));

CREATE TABLE IF NOT EXISTS archivo_video(
  `idarchivo` INT NOT NULL AUTO_INCREMENT,
  `iddocente` INT,
  `idvideo` INT,
  `tipodearchivo` INT NULL, /* si es pdf, word, excel, o si es video en vivo etc */
  `url` VARCHAR(500) NULL,
  `activo` BIT(1) NULL,
  `modificado` BIT(1) NULL,
  `fechareg` DATETIME NULL,
  `fechamod` DATETIME NULL,
  FOREIGN KEY (iddocente) REFERENCES docente(iddocente),
  FOREIGN KEY (idvideo) REFERENCES video(idvideo),
PRIMARY KEY (`idarchivo`));


/* v2 = 16 TABLAS */
/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spalumno_configuracion`;*/
DELIMITER $$
CREATE PROCEDURE `spalumno_configuracion` (IN _correo VARCHAR(150), IN _idetapa INT, IN _nombre VARCHAR(50))
BEGIN

SELECT
a.idalumno
,IFNULL((SELECT p2.idpago FROM PAGO p2 WHERE p2.idalumno = a.idalumno AND p2.activo = 1),0) as 'idpago'
,0 as 'idetapa'
,CONCAT_WS(' ', a.nombre, a.apellido) as 'nombrealumno'
,aa.email
,IFNULL(
(SELECT c.nombre FROM etapa_escolar c WHERE c.idetapa = (SELECT p2.idetapa FROM pago p2 WHERE p2.idalumno = a.idalumno AND p2.activo = 1))
,'Sin categoría') as 'etapa_escolar'
,IFNULL((SELECT DATE_FORMAT(p2.fechareg, '%d-%m-%Y') FROM PAGO p2 WHERE p2.idalumno = a.idalumno AND p2.activo = 1),'-') as 'fechareg'
,IFNULL((SELECT DATE_FORMAT(p2.fechafin, '%d-%m-%Y') FROM PAGO p2 WHERE p2.idalumno = a.idalumno AND p2.activo = 1),'-') as 'fechafin'
,IFNULL((SELECT DATEDIFF(p2.fechafin, p2.fechareg) FROM PAGO p2 WHERE p2.idalumno = a.idalumno AND p2.activo = 1),0) as 'diasrestantes'
FROM alumno a
  INNER JOIN accesoalumno aa ON a.idalumno = aa.idalumno
    WHERE (aa.email like concat('%', _correo, '%') OR (_correo = ''))
    AND ((a.nombre like concat('%', _nombre, '%')) OR (a.apellido like concat('%', _nombre, '%')) OR (_nombre = ''));
    

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spalumno_crear`;*/

DELIMITER $$
CREATE PROCEDURE `spalumno_crear` (
IN _nombre VARCHAR(150)
,IN _apellido VARCHAR(150)
,IN _email VARCHAR(100)
,IN _etapa INT
,IN _grado INT
,IN _seccion INT
,IN _nombrepadre VARCHAR(50)
,IN _clave VARCHAR(500))
BEGIN

IF EXISTS(SELECT activo FROM accesoalumno WHERE `email` =  _email) THEN
BEGIN
        SELECT 0 as '_result';       
END;
ELSE
BEGIN
INSERT INTO padre(nombrepadre,fechareg,activo)
    VALUES(_nombrepadre, NOW(), 1);

  INSERT INTO alumno(idpadre,nombre,apellido,etapa_escolar,grado,seccion,fechareg,activo)
    VALUES((SELECT LAST_INSERT_ID()),_nombre,_apellido,_etapa,_grado,_seccion,NOW(),1);
        
  INSERT INTO accesoalumno(idalumno,clave,email,fechareg,activo) 
    VALUES ((SELECT LAST_INSERT_ID()),_clave,_email, NOW(), 1);

  SELECT LAST_INSERT_ID() as '_result';
END;
END IF;

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spalumno_creardomeses`;*/
DELIMITER $$
CREATE PROCEDURE `spalumno_creardomeses` (IN _idalumno INT, IN _idetapa INT, IN _tipopago INT)
BEGIN

UPDATE PAGO SET activo = 0 WHERE idalumno = _idalumno;

INSERT INTO pago(
  idalumno
  ,nombre
  ,tipopago
  ,dia
  ,mes
  ,anio
  ,monto
  ,fechareg
  ,fechafin
  ,activo
)VALUES(
  _idalumno
    ,'Pago por plataforma web'
    ,_tipopago
    ,DAY(NOW())
    ,MONTH(NOW())
    ,YEAR(NOW())
    ,200
    ,NOW()
    ,DATE_ADD(NOW(),INTERVAL 60 DAY)
    ,1
);

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spalumno_crearMes`;*/
/* NUEVO, agregar al backend */
DELIMITER $$
CREATE PROCEDURE `spalumno_crearMes` (IN _idalumno INT, IN _idetapa INT, IN _tipopago INT)
BEGIN

UPDATE PAGO SET activo = 0 WHERE idalumno = _idalumno AND idetapa = _idetapa;

INSERT INTO pago(
  idalumno
  ,idetapa
  ,nombre
  ,tipopago
  ,dia
  ,mes
  ,anio
  ,monto
  ,fechareg
  ,fechafin
  ,activo
)VALUES(
  _idalumno
    ,_idetapa
    ,'Pago por plataforma web'
    ,_tipopago
    ,DAY(NOW())
    ,MONTH(NOW())
    ,YEAR(NOW())
    ,200
    ,NOW()
    ,DATE_ADD(NOW(),INTERVAL 30 DAY)
    ,1
);

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spalumno_crearsietemeses`;*/
DELIMITER $$
CREATE PROCEDURE `spalumno_crearsietemeses` (IN _idalumno INT, IN _idetapa INT, IN _tipopago INT)
BEGIN

UPDATE PAGO SET activo = 0 WHERE idalumno = _idalumno;

INSERT INTO pago(
  idalumno
  ,nombre
  ,tipopago
  ,dia
  ,mes
  ,anio
  ,monto
  ,fechareg
  ,fechafin
  ,activo
)VALUES(
  _idalumno
    ,'Pago por plataforma web'
    ,_tipopago
    ,DAY(NOW())
    ,MONTH(NOW())
    ,YEAR(NOW())
    ,390
    ,NOW()
    ,DATE_ADD(NOW(),INTERVAL 210 DAY)
    ,1
);

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spalumno_generarclave`;*/
DELIMITER $$
CREATE PROCEDURE `spalumno_generarclave` (IN _idalumno VARCHAR(150), IN _nuevaclave VARCHAR(50))
BEGIN

UPDATE accesoalumno SET clave = _nuevaclave WHERE idalumno = _idalumno;
INSERT INTO historialacceso(idalumno,intentos,fechareg,activo) VALUES(_idalumno,1,NOW(),1);

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spalumno_listar`;*/

DELIMITER $$
CREATE PROCEDURE `spalumno_listar` (IN _idalumno INT)
BEGIN

SELECT 
   a.idalumno
  ,a.distrito
    ,a.ciudad
    ,a.provincia
    ,CONCAT_WS(' ',a.nombre, a.apellido) as nombre
    ,DATE_FORMAT(a.fechanac, '%d %m %Y') as fechanac
    ,(SELECT a2.email FROM accesoalumno a2 where a2.idalumno = _idalumno) as 'email'
  ,a.etapa_escolar
  ,a.grado
  ,a.seccion    
    ,a.tipodoc
    ,a.documento
    ,a.suscripcion_estado
    ,a.activo
    ,a.ultima_conexion_fecha
    ,0 as 'matriculado'
FROM alumno as a where a.idalumno = _idalumno;

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spalumno_login`;*/

DELIMITER $$
CREATE PROCEDURE `spalumno_login` (IN _correo VARCHAR(100), IN _clave VARCHAR(500))
BEGIN

IF EXISTS(SELECT idalumno FROM accesoalumno WHERE `email` =  _correo) THEN
BEGIN
  DECLARE _result INT DEFAULT 0;   
    SET _result = (SELECT IFNULL((SELECT idalumno FROM accesoalumno WHERE `email` =  _correo AND `clave` = _clave),-1) as '_result');
    SELECT _result;
END;
ELSE
BEGIN 
  SELECT 0 as '_result';
END;
END IF;

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spalumno_registro`;*/

DELIMITER $$
CREATE PROCEDURE `spalumno_registro` (IN _idalumno INT,IN _direccionip VARCHAR(150), IN _direccionmac VARCHAR(150), IN _tipoconexion INT)
BEGIN

INSERT INTO historial_acceso_alumno(idalumno,fechareg,direccionip,direccionmac,tipoconexion,activo)
VALUES (_idalumno,NOW(),_direccionip,_direccionmac,_tipoconexion ,1);

SELECT LAST_INSERT_ID() as '_result';

END$$
DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spalumno_validarcorreo`;*/
DELIMITER $$
CREATE PROCEDURE `spalumno_validarcorreo` (IN _correo VARCHAR(100))
BEGIN

IF EXISTS(SELECT idalumno FROM accesoalumno WHERE `email` =  _correo) THEN
BEGIN
  SELECT 1 as '_result';
END;
ELSE
BEGIN
  SELECT 0 as '_result';
END;
END IF;

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spalumno_validarcuenta`;*/

DELIMITER $$
CREATE PROCEDURE `spalumno_validarcuenta` (IN _correo VARCHAR(100))
BEGIN

IF ((SELECT activo FROM accesoalumno WHERE `email` =  _correo) = 0) THEN
BEGIN
  SELECT 1 as '_result';
    
END;
ELSE
BEGIN
  
  SELECT 0 as '_result';
END;
END IF;

END$$

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spetapa_listar`;*/
/* si ya se vencio, muestra un dialogo para realizar el pago, si no, deberia redirigir al siguiente paso : antiguo spcategoria_listar */
DELIMITER $$
CREATE PROCEDURE `spetapa_listar` (IN _idalumno INT)
BEGIN

SELECT 
  idetapa
    ,nombre
    ,descripcion
    ,activo
    ,'' as 'monto'
    ,rutaimagen
    ,0 as 'resultado'
    ,pasarela_pago_nombre
FROM etapa_escolar where activo = 1 ORDER BY idetapa ASC;

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spgrado_listar`;*/
/* antiguo: spcurso_listar */
-- este SP tambien se utiliza para listar los cursos desde modo admin con el usuario 1, corregir este sp
-- ya estan los cambios solo falta subir a la bd y probar esta por defecto con el usuario 0 , corregir en el frontendcv en el metodo
DELIMITER $$
CREATE PROCEDURE `spgrado_listar` (IN _idetapa INT, IN _idalumno INT)
BEGIN

IF EXISTS(SELECT idpago FROM pago where (idalumno = _idalumno || _idalumno = 0) AND idetapa = _idetapa AND activo = 1 AND DATE(fechafin) >= CURDATE()) THEN
BEGIN

SELECT
  idgrado
    ,idetapa
    ,nombre
    ,descripcion
    ,monto
    ,promocionfechainicio
    ,promocionfechafin
    ,rutaimagen
    ,videoenlace
    ,valoracion
  ,0 as '_result'
FROM grado WHERE idetapa = _idetapa AND activo = 1 ORDER BY idgrado ASC;

END;
ELSE
BEGIN

SELECT 
     0 as 'idgrado'
    ,0 as 'idetapa'
    ,'-' as 'nombre'
    ,'-' as 'descripcion'
    ,0 as 'monto'
    ,'-' as 'promocionfechainicio'
    ,'-' as 'promocionfechafin'
    ,'-' as 'rutaimagen'
    ,'' as 'videoenlace'
    ,0 as 'valoracion'
    ,1 as '_result';

END;
END IF;


END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */
/* AGREGAR COLUMNA idetapa a curso */
ALTER TABLE `db_a47a2c_bdcv001`.`curso` 
ADD COLUMN `idetapa` INT(11) NOT NULL AFTER `idgrado`;


/*DROP procedure IF EXISTS `spcurso_listar`;*/
/* nuevo, agregar */
DELIMITER $$
CREATE PROCEDURE `spcurso_listar` (IN _idgrado INT,IN _idetapa INT, IN _idalumno INT)
BEGIN

IF ((SELECT DATE(fechafin) FROM pago WHERE idalumno = _idalumno AND activo = 1 LIMIT 1) >= CURDATE()) THEN
BEGIN

SELECT
     idcurso
    ,idgrado
    ,idetapa
    ,nombre
    ,descripcion
    ,rutaimagen
    ,videoenlace
    ,0 as 'valoracion'
  ,0 as '_result'
FROM curso WHERE idgrado = _idgrado AND idetapa = _idetapa AND activo = 1 ORDER BY idcurso ASC;

END;
ELSE
BEGIN

SELECT 
     0 as 'idcurso'
    ,0 as 'idgrado'
    ,0 as 'idetapa'
    ,'-' as 'nombre'
    ,'-' as 'descripcion'
    ,'-' as 'rutaimagen'
    ,'' as 'videoenlace'
    ,0 as 'valoracion'
    ,1 as '_result';

END;
END IF;


END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spvideo_listar`;*/
DELIMITER $$
CREATE PROCEDURE `spvideo_listar` (IN _idcurso INT, IN _idalumno INT, IN _idsemana INT)
BEGIN
-- FORMATO = 25/04/2020
IF ((SELECT DATE(fechafin) FROM pago WHERE idalumno = _idalumno AND activo = 1 LIMIT 1) >= CURDATE()) THEN
BEGIN

    SELECT
    idvideo
    ,idsemana
    ,idcurso
    ,nombre
    ,descripcion
    ,orden
    ,rutavideo
    ,rutaenlace
    ,0 as '_result'
  from video where activo = 1 AND idcurso = _idcurso AND idsemana = _idsemana ORDER BY idvideo ASC;

END;
ELSE
BEGIN

 SELECT 
    0 as 'idvideo'
    ,0 as 'idsemana'
    ,0 as 'idcurso'
    ,'-' as 'nombre'
    ,'-' as 'descripcion'
    ,9 as 'orden'
    ,0 as 'rutavideo'
    ,'-' as 'rutaenlace'
    ,1 as '_result';  

END;
END IF;

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `sppago_notificar`;*/

DELIMITER $$
CREATE PROCEDURE `sppago_notificar` (IN _idalumno INT, IN _idetapa INT)
BEGIN

SELECT
  DATEDIFF(DATE(fechafin), CURDATE()) as fecha
FROM pago where idalumno = _idalumno AND idetapa = _idetapa AND activo = 1;

END$$

DELIMITER ;

/* 16 procedimientos v1 */
/* ----------------------------------------------------------------------- */


/*DROP procedure IF EXISTS `spdocente_validarcorreo`;*/
DELIMITER $$
CREATE PROCEDURE `spdocente_validarcorreo` (IN _correo VARCHAR(100))
BEGIN

IF EXISTS(SELECT iddocente FROM accesodocente WHERE `email` =  _correo) THEN
BEGIN
  SELECT 1 as '_result';
END;
ELSE
BEGIN
  SELECT 0 as '_result';
END;
END IF;

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spdocente_crear`;*/
DELIMITER $$
CREATE PROCEDURE `spdocente_crear` (
IN _nombre VARCHAR(150)
,IN _apellido VARCHAR(150)
,IN _email VARCHAR(100)
,IN _clave VARCHAR(500))
BEGIN

IF EXISTS(SELECT activo FROM accesodocente WHERE `email` =  _email) THEN
BEGIN
        SELECT 0 as '_result';       
END;
ELSE
BEGIN
  INSERT INTO docente(nombre,apellido,fechareg,activo)
    VALUES(_nombre,_apellido,NOW(),1);

  INSERT INTO accesodocente(iddocente,clave,email,fechareg,activo) 
    VALUES ((SELECT LAST_INSERT_ID()),_clave,_email, NOW(), 1);

  SELECT LAST_INSERT_ID() as '_result';
END;
END IF;

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spdocente_listar`;*/

DELIMITER $$
CREATE PROCEDURE `spdocente_listar` (IN _iddocente INT)
BEGIN

SELECT 
   d.iddocente
  ,d.distrito
  ,d.ciudad
  ,d.provincia
  ,CONCAT_WS(' ',d.nombre, d.apellido) as nombre  
  ,(SELECT d2.email FROM accesodocente d2 where d2.iddocente = _iddocente) as 'email'
  ,d.tipodoc
  ,d.documento  
  ,d.activo
FROM docente as d where d.iddocente = _iddocente;

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spcurso_buscar`;*/
/* nuevo, agregar */
DELIMITER $$
CREATE PROCEDURE `spcurso_buscar` (IN _idgrado INT,IN _idetapa INT, IN _nombre VARCHAR(50))
BEGIN

SELECT
    idcurso
    ,idgrado
    ,idetapa
    ,nombre   
FROM curso WHERE idgrado = _idgrado AND idetapa = _idetapa AND nombre like CONCAT('%', _nombre ,'%') AND activo = 1 ORDER BY idcurso ASC;

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */
   
/*DROP procedure IF EXISTS `spcurso_crear`;*/
DELIMITER $$
CREATE PROCEDURE `spcurso_crear` (
IN _idcurso INT
,IN _idsemana INT
,IN _nombre VARCHAR(50)
,IN _descripcion VARCHAR(150)
,IN _rutavideo VARCHAR(250)
)
BEGIN

INSERT INTO video 
    (idcurso
    ,nombre
    ,idsemana
    ,descripcion
    ,orden
    ,rutavideo
    ,fechareg
    ,activo)
VALUES(
    _idcurso
    ,_nombre
    ,_idsemana
    ,_nombre
    ,1
    ,_rutavideo
    ,str_to_date(_descripcion, '%d/%m/%Y')
    ,1);

  SELECT LAST_INSERT_ID() as '_result';

END$$

DELIMITER ;
-- 24/09/2020
/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spdocente_login`;*/

DELIMITER $$
CREATE PROCEDURE `spdocente_login` (IN _correo VARCHAR(100), IN _clave VARCHAR(500))
BEGIN

IF EXISTS(SELECT iddocente FROM accesodocente WHERE `email` =  _correo) THEN
BEGIN
  DECLARE _result INT DEFAULT 0;   
    SET _result = (SELECT IFNULL((SELECT iddocente FROM accesodocente WHERE `email` =  _correo AND `clave` = _clave),-1) as '_result');
    SELECT _result;
END;
ELSE
BEGIN 
  SELECT 0 as '_result';
END;
END IF;

END$$

DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `spdocente_registro`;*/

DELIMITER $$
CREATE PROCEDURE `spdocente_registro` (IN _iddocente INT,IN _direccionip VARCHAR(150), IN _direccionmac VARCHAR(150), IN _tipoconexion INT)
BEGIN

INSERT INTO historial_acceso_docente(iddocente,fechareg,direccionip,direccionmac,tipoconexion,activo)
VALUES (_iddocente,NOW(),_direccionip,_direccionmac,_tipoconexion ,1);

SELECT LAST_INSERT_ID() as '_result';

END$$
DELIMITER ;

/* 23 procedimientos v2 */
/* ----------------------------------------------------------------------- */


/*DROP procedure IF EXISTS `sparchivo_registro`;*/

DELIMITER $$
CREATE PROCEDURE `sparchivo_registro` (
IN _iddocente INT,
IN _idvideo INT,
IN _tipodearchivo INT,
IN _url VARCHAR(500))
BEGIN

INSERT INTO archivo_video(
  iddocente,
  idvideo,
  tipodearchivo,
  url,
  activo,
  fechareg)
VALUES(
  _iddocente,
  _idvideo,
  _tipodearchivo,
  _url,
  1,
  NOW());

SELECT LAST_INSERT_ID() as '_result';

END$$
DELIMITER ;

/* ----------------------------------------------------------------------- */

/*DROP procedure IF EXISTS `sparchivo_buscar`;*/
/* nuevo, agregar */
DELIMITER $$
CREATE PROCEDURE `sparchivo_buscar` (IN _idvideo INT, IN _tipodearchivo INT)
BEGIN

SELECT
  idarchivo,
  iddocente,
  tipodearchivo,
  idvideo,
  url
FROM archivo_video WHERE (idvideo = _idvideo OR _idvideo = 0) 
   AND (tipodearchivo = _tipodearchivo OR _tipodearchivo = 0)
   AND activo = 1;

END$$

DELIMITER ;

/* ------------------------------------------------------------------------ */

/*DROP procedure IF EXISTS `sparchivo_eliminar`;*/
DELIMITER $$
CREATE PROCEDURE `sparchivo_eliminar` (IN _idarchivo INT)
BEGIN

UPDATE archivo_video SET activo = 0 WHERE idarchivo = _idarchivo;

END$$

DELIMITER ;

/* ------------------------------------------------------------------------ */


/*DROP procedure IF EXISTS `spvideo_listado`;*/
DELIMITER $$
CREATE PROCEDURE `spvideo_listado` ()
BEGIN

    SELECT
    v.idvideo
    ,c.idetapa as 'idcurso'
    ,v.idsemana
    ,v.nombre
    ,c.nombre as 'descripcion'
    ,c.idgrado as 'orden'
    ,v.rutavideo
    ,v.rutaenlace
  from video v 
    INNER JOIN curso c ON v.idcurso = c.idcurso
  where v.activo = 1 ORDER BY v.idvideo ASC;

END$$

DELIMITER ;

/* ------------------------------------------------------------------------ */

/*DROP procedure IF EXISTS `spvideo_listar`;*/
DELIMITER $$
CREATE PROCEDURE `spvideo_eliminar` (IN _idvideo INT)
BEGIN

  UPDATE video SET activo = 0 WHERE idvideo = _idvideo;

END$$

DELIMITER ;

-- --------------------------------------------------------------------------------------------------------










CREATE TABLE t_actividad (
  `id_actividad` int(11) NOT NULL AUTO_INCREMENT,
  `i_tipo_examen` INT NOT NULL,
  `v_nombre` VARCHAR(50) NOT NULL,
  `v_descripcion` VARCHAR(150) DEFAULT NULL,
  `i_puntaje_minimo` INT NOT NULL,
  `i_puntaje_maximo` INT NOT NULL,
  `i_tiempo` INT NOT NULL,
  `i_intentos` INT NOT NULL,
  `t_hora_examen` TIME NOT NULL,
  `d_fecha_examen` DATE NOT NULL,
  `i_total_puntaje` INT NOT NULL,
  `b_estado` BIT(1) NOT NULL,
  `dt_fecharegistro` DATETIME NOT NULL,
  PRIMARY KEY (`id_actividad`)
);

CREATE TABLE t_actividad_detalle (
  `id_actividad_detalle` INT NOT NULL AUTO_INCREMENT,
  `id_actividad` INT NOT NULL,
  `v_pregunta` VARCHAR(500) NOT NULL,
  `v_alternativa_A` VARCHAR(50) NOT NULL,
  `v_alternativa_B` VARCHAR(50) NOT NULL,
  `v_alternativa_C` VARCHAR(50) NOT NULL,
  `v_alternativa_D` VARCHAR(50) NOT NULL,
  `v_alternativa_E` VARCHAR(50) NOT NULL,
  `b_respuesta_A` BIT(1) NOT NULL,
  `b_respuesta_B` BIT(1) NOT NULL,
  `b_respuesta_C` BIT(1) NOT NULL,
  `b_respuesta_D` BIT(1) NOT NULL,
  `b_respuesta_E` BIT(1) NOT NULL,
  `b_respuesta_F` BIT(1) NOT NULL,
  `b_respuesta_G` BIT(1) NOT NULL,
  `b_respuesta_H` BIT(1) NOT NULL,
  `b_respuesta_I` BIT(1) NOT NULL,
  `i_tipo_pregunta` INT NOT NULL,
  `i_puntaje_pregunta` INT NOT NULL,
  `b_estado` BIT(1) NOT NULL,
  FOREIGN KEY (`id_actividad`) REFERENCES t_actividad(`id_actividad`),
  PRIMARY KEY (`id_actividad_detalle`)
);

CREATE TABLE t_actividad_alumno (
  `id_actividad_alumno` INT NOT NULL AUTO_INCREMENT,
  `id_actividad` INT NOT NULL,
  `v_nombres` VARCHAR(150) DEFAULT NULL,
  `v_apellidos` VARCHAR(150) DEFAULT NULL,
  `v_lugarnacimiento` VARCHAR(150) DEFAULT NULL,
  `i_grado` INT DEFAULT NULL,
  `i_edad` INT DEFAULT NULL,
  `i_sexo` INT DEFAULT NULL,
  `v_colegio` VARCHAR(100) DEFAULT NULL,
  `v_celular` VARCHAR(100) DEFAULT NULL,
  `v_correo`  VARCHAR(100) DEFAULT NULL,
  `v_clave`  VARCHAR(100) DEFAULT NULL,
  `v_distrito` VARCHAR(100) DEFAULT NULL,
  `v_ugel` VARCHAR(100) DEFAULT NULL,
  `i_carrera1` VARCHAR(50) DEFAULT NULL,
  `i_carrera2` VARCHAR(50) DEFAULT NULL,
  `i_carrera3` VARCHAR(50) DEFAULT NULL,
  `i_carrera4` VARCHAR(50) DEFAULT NULL,
  `i_carrera5` VARCHAR(50) DEFAULT NULL,
  `i_puntaje` INT DEFAULT NULL,
  `v_comentario` VARCHAR(500) DEFAULT NULL,
  `b_estado` BIT(1) NOT NULL,
  `dt_fecharegistro` DATETIME NOT NULL,
  `dt_fechafin` DATETIME NOT NULL,
  PRIMARY KEY (`id_actividad_alumno`)
);

CREATE TABLE t_actividad_alumno_detalle (
  `id_actividad_alumno_detalle` INT NOT NULL AUTO_INCREMENT,
  `id_actividad_alumno` INT NOT NULL,
  `id_actividad_detalle` INT NOT NULL,
  `i_fase` INT NULL,
  `v_pregunta_1` VARCHAR(50) NULL,
  `v_pregunta_2` VARCHAR(50) NULL,
  `v_pregunta_3` VARCHAR(50) NULL,
  `v_pregunta_4` VARCHAR(50) NULL,
  `v_pregunta_5` VARCHAR(50) NULL,
  `v_pregunta_6` VARCHAR(50) NULL,
  `v_pregunta_7` VARCHAR(50) NULL,
  `v_pregunta_8` VARCHAR(50) NULL,
  `v_pregunta_9` VARCHAR(50) NULL,
  `v_pregunta_10` VARCHAR(50) NULL,
  `v_pregunta_11` VARCHAR(50) NULL,
  `v_pregunta_12` VARCHAR(50) NULL,
  `v_pregunta_13` VARCHAR(50) NULL,
  `v_pregunta_14` VARCHAR(50) NULL,
  `v_pregunta_15` VARCHAR(50) NULL,
  `v_pregunta_16` VARCHAR(50) NULL,
  `v_pregunta_17` VARCHAR(50) NULL,
  `v_pregunta_18` VARCHAR(50) NULL,
  `v_pregunta_19` VARCHAR(50) NULL,
  `v_pregunta_20` VARCHAR(50) NULL,
  `v_pregunta_21` VARCHAR(50) NULL,
  `v_pregunta_22` VARCHAR(50) NULL,
  `v_pregunta_23` VARCHAR(50) NULL,
  `v_pregunta_24` VARCHAR(50) NULL,
  `v_pregunta_25` VARCHAR(50) NULL,
  `v_pregunta_26` VARCHAR(50) NULL,
  `v_pregunta_27` VARCHAR(50) NULL,
  `v_pregunta_28` VARCHAR(50) NULL,
  `v_pregunta_29` VARCHAR(50) NULL,
  `v_pregunta_30` VARCHAR(50) NULL,
  `v_pregunta_31` VARCHAR(50) NULL,
  `v_pregunta_32` VARCHAR(50) NULL,
  `v_pregunta_33` VARCHAR(50) NULL,
  `v_pregunta_34` VARCHAR(50) NULL,
  `v_pregunta_35` VARCHAR(50) NULL,
  `v_pregunta_36` VARCHAR(50) NULL,
  `v_pregunta_37` VARCHAR(50) NULL,
  `v_pregunta_38` VARCHAR(50) NULL,
  `v_pregunta_39` VARCHAR(50) NULL,
  `v_pregunta_40` VARCHAR(50) NULL,
  `v_pregunta_41` VARCHAR(50) NULL,
  `v_pregunta_42` VARCHAR(50) NULL,
  `v_pregunta_43` VARCHAR(50) NULL,
  `v_pregunta_44` VARCHAR(50) NULL,
  `v_pregunta_45` VARCHAR(50) NULL,
  `v_pregunta_46` VARCHAR(50) NULL,
  `v_pregunta_47` VARCHAR(50) NULL,
  `v_pregunta_48` VARCHAR(50) NULL,
  `v_pregunta_49` VARCHAR(50) NULL,
  `v_pregunta_50` VARCHAR(50) NULL,
  `v_pregunta_51` VARCHAR(50) NULL,
  `v_pregunta_52` VARCHAR(50) NULL,
  `v_pregunta_53` VARCHAR(50) NULL,
  `v_pregunta_54` VARCHAR(50) NULL,
  `v_pregunta_55` VARCHAR(50) NULL,
  `v_pregunta_56` VARCHAR(50) NULL,
  `v_pregunta_57` VARCHAR(50) NULL,
  `v_pregunta_58` VARCHAR(50) NULL,
  `v_pregunta_59` VARCHAR(50) NULL,
  `v_pregunta_60` VARCHAR(50) NULL,
  `i_puntaje` INT NULL,
  `v_descripcion` VARCHAR(500) NULL,
  `i_tipo_pregunta` INT NOT NULL,
  `b_estado` BIT(1) NOT NULL,
  `dt_fecharegistro` DATETIME NULL,
  FOREIGN KEY (`id_actividad_alumno`) REFERENCES t_actividad_alumno(`id_actividad_alumno`),
  FOREIGN KEY (`id_actividad_detalle`) REFERENCES t_actividad_detalle(`id_actividad_detalle`),
  PRIMARY KEY (`id_actividad_alumno_detalle`)
);

-- -------------------------------------------------
-- OBTIENE LA INFORMACION DEL ALUMNO INSCRITO
DELIMITER $$
CREATE PROCEDURE `sp_obtener_actividadA`(IN _v_correo VARCHAR(100))
BEGIN
  select 
   aa.id_actividad_alumno
  ,aa.id_actividad
  ,aa.v_nombres
  ,aa.v_apellidos
  ,aa.v_lugarnacimiento
  ,aa.i_edad
  ,aa.v_celular
  ,aa.v_correo
  ,aa.v_colegio
  ,aa.v_distrito
  ,aa.v_ugel
  ,aa.i_carrera1
  ,aa.i_carrera2
  ,aa.i_carrera3
  ,aa.i_carrera4
  ,aa.i_carrera5
  ,aa.v_comentario
  ,aa.dt_fecharegistro
  ,aa.dt_fechafin
  from t_actividad_alumno aa
    where aa.b_estado = 1 AND (aa.v_correo = _v_correo OR _v_correo = '');
END$$
DELIMITER ;

-- -------------------------------------------------
-- OBTIENE LAS PREGUNTAS DE CADA FASE
DELIMITER $$
CREATE PROCEDURE `sp_obtener_actividadA_det`(IN _idactividad INT,IN _ifase INT)
BEGIN
  select 
     ad.id_actividad_alumno_detalle
    ,ad.id_actividad_alumno
    ,ad.id_actividad_detalle
    ,ad.i_fase
    ,ad.v_pregunta_1
    ,ad.v_pregunta_2
    ,ad.v_pregunta_3
    ,ad.v_pregunta_4
    ,ad.v_pregunta_5
    ,ad.v_pregunta_6
    ,ad.v_pregunta_7
    ,ad.v_pregunta_8
    ,ad.v_pregunta_9
    ,ad.v_pregunta_10
    ,ad.v_pregunta_11
    ,ad.v_pregunta_12
    ,ad.v_pregunta_13
    ,ad.v_pregunta_14
    ,ad.v_pregunta_15
    ,ad.v_pregunta_16
    ,ad.v_pregunta_17
    ,ad.v_pregunta_18
    ,ad.v_pregunta_19
    ,ad.v_pregunta_20
    ,ad.v_pregunta_21
    ,ad.v_pregunta_22
    ,ad.v_pregunta_23
    ,ad.v_pregunta_24
    ,ad.v_pregunta_25
    ,ad.v_pregunta_26
    ,ad.v_pregunta_27
    ,ad.v_pregunta_28
    ,ad.v_pregunta_29
    ,ad.v_pregunta_30
    ,ad.v_pregunta_31
    ,ad.v_pregunta_32
    ,ad.v_pregunta_33
    ,ad.v_pregunta_34
    ,ad.v_pregunta_35
    ,ad.v_pregunta_36
    ,ad.v_pregunta_37
    ,ad.v_pregunta_38
    ,ad.v_pregunta_39
    ,ad.v_pregunta_40
    ,ad.v_pregunta_41
    ,ad.v_pregunta_42
    ,ad.v_pregunta_43
    ,ad.v_pregunta_44
    ,ad.v_pregunta_45
    ,ad.v_pregunta_46
    ,ad.v_pregunta_47
    ,ad.v_pregunta_48
    ,ad.v_pregunta_49
    ,ad.v_pregunta_50
    ,ad.v_pregunta_51
    ,ad.v_pregunta_52
    ,ad.v_pregunta_53
    ,ad.v_pregunta_54
    ,ad.v_pregunta_55
    ,ad.v_pregunta_56
    ,ad.v_pregunta_57
    ,ad.v_pregunta_58
    ,ad.v_pregunta_59
    ,ad.v_pregunta_60
    ,ad.i_puntaje
    ,ad.v_descripcion
    ,ad.i_tipo_pregunta
    ,ad.b_estado
    ,DATE_FORMAT(ad.dt_fecharegistro, '%d %m %Y') as 'dt_fecharegistro'
  from t_actividad_alumno_detalle ad
    where ad.id_actividad_alumno = _idactividad AND ad.b_estado = 1 AND ad.i_fase = _ifase;
END$$
DELIMITER ;

-- -------------------------------------------------
-- REGISTRA A LOS ALUMNOS
DELIMITER $$
CREATE PROCEDURE `sp_insertar_actividadAlumno`(
   IN _id_actividad INT
  ,IN _v_nombres VARCHAR(150)
  ,IN _v_apellidos VARCHAR(150)
  ,IN _v_lugarnacimiento VARCHAR(150)
  ,IN _i_grado INT
  ,IN _i_edad INT
  ,IN _i_sexo INT
  ,IN _v_celular VARCHAR(100)
  ,IN _v_correo  VARCHAR(100)
  ,IN _v_clave VARCHAR(100)
  ,IN _v_colegio VARCHAR(100)
  ,IN _v_distrito VARCHAR(100)
  ,IN _v_ugel VARCHAR(100)
  ,IN _b_estado BIT(1)
  ,IN _dt_fecharegistro DATETIME)
BEGIN

IF EXISTS(SELECT aa.id_actividad FROM t_actividad_alumno aa WHERE aa.v_correo = _v_correo) THEN
BEGIN

    SELECT 0 as '_result';

END;
ELSE
BEGIN

INSERT INTO t_actividad_alumno(
      id_actividad
      ,v_nombres
      ,v_apellidos
      ,v_lugarnacimiento
      ,i_grado
      ,i_edad
      ,i_sexo
      ,v_celular
      ,v_correo
      ,v_clave
      ,v_colegio
      ,v_distrito
      ,v_ugel
      ,b_estado
      ,dt_fecharegistro)
    VALUES (
      _id_actividad
      ,_v_nombres
      ,_v_apellidos
      ,_v_lugarnacimiento
      ,_i_grado
      ,_i_edad
      ,_i_sexo
      ,_v_celular
      ,_v_correo
      ,_v_clave
      ,_v_colegio
      ,_v_distrito
      ,_v_ugel
      ,_b_estado
      ,_dt_fecharegistro);

    SELECT LAST_INSERT_ID() as '_result';

END;
END IF;

END$$
DELIMITER ;

-- -------------------------------------------------
-- REGISTRA LAS PREGUNTAS DE CADA FASE
DELIMITER $$
CREATE PROCEDURE `sp_insertar_actividadAlumnoDetalle`(
   _id_actividad_alumno INT
  ,_id_actividad_detalle INT
  ,_i_fase INT
  ,_v_pregunta_1 VARCHAR(50)
  ,_v_pregunta_2 VARCHAR(50)
  ,_v_pregunta_3 VARCHAR(50)
  ,_v_pregunta_4 VARCHAR(50)
  ,_v_pregunta_5 VARCHAR(50)
  ,_v_pregunta_6 VARCHAR(50)
  ,_v_pregunta_7 VARCHAR(50)
  ,_v_pregunta_8 VARCHAR(50)
  ,_v_pregunta_9 VARCHAR(50)
  ,_v_pregunta_10 VARCHAR(50)
  ,_v_pregunta_11 VARCHAR(50)
  ,_v_pregunta_12 VARCHAR(50)
  ,_v_pregunta_13 VARCHAR(50)
  ,_v_pregunta_14 VARCHAR(50)
  ,_v_pregunta_15 VARCHAR(50)
  ,_v_pregunta_16 VARCHAR(50)
  ,_v_pregunta_17 VARCHAR(50)
  ,_v_pregunta_18 VARCHAR(50)
  ,_v_pregunta_19 VARCHAR(50)
  ,_v_pregunta_20 VARCHAR(50)
  ,_v_pregunta_21 VARCHAR(50)
  ,_v_pregunta_22 VARCHAR(50)
  ,_v_pregunta_23 VARCHAR(50)
  ,_v_pregunta_24 VARCHAR(50)
  ,_v_pregunta_25 VARCHAR(50)
  ,_v_pregunta_26 VARCHAR(50)
  ,_v_pregunta_27 VARCHAR(50)
  ,_v_pregunta_28 VARCHAR(50)
  ,_v_pregunta_29 VARCHAR(50)
  ,_v_pregunta_30 VARCHAR(50)
  ,_v_pregunta_31 VARCHAR(50)
  ,_v_pregunta_32 VARCHAR(50)
  ,_v_pregunta_33 VARCHAR(50)
  ,_v_pregunta_34 VARCHAR(50)
  ,_v_pregunta_35 VARCHAR(50)
  ,_v_pregunta_36 VARCHAR(50)
  ,_v_pregunta_37 VARCHAR(50)
  ,_v_pregunta_38 VARCHAR(50)
  ,_v_pregunta_39 VARCHAR(50)
  ,_v_pregunta_40 VARCHAR(50)
  ,_v_pregunta_41 VARCHAR(50)
  ,_v_pregunta_42 VARCHAR(50)
  ,_v_pregunta_43 VARCHAR(50)
  ,_v_pregunta_44 VARCHAR(50)
  ,_v_pregunta_45 VARCHAR(50)
  ,_v_pregunta_46 VARCHAR(50)
  ,_v_pregunta_47 VARCHAR(50)
  ,_v_pregunta_48 VARCHAR(50)
  ,_v_pregunta_49 VARCHAR(50)
  ,_v_pregunta_50 VARCHAR(50)
  ,_v_pregunta_51 VARCHAR(50)
  ,_v_pregunta_52 VARCHAR(50)
  ,_v_pregunta_53 VARCHAR(50)
  ,_v_pregunta_54 VARCHAR(50)
  ,_v_pregunta_55 VARCHAR(50)
  ,_v_pregunta_56 VARCHAR(50)
  ,_v_pregunta_57 VARCHAR(50)
  ,_v_pregunta_58 VARCHAR(50)
  ,_v_pregunta_59 VARCHAR(50)
  ,_v_pregunta_60 VARCHAR(50)
  ,_i_puntaje INT
  ,_v_descripcion VARCHAR(500)
  ,_i_tipo_pregunta INT
  ,_b_estado BIT(1)
  ,_dt_fecharegistro VARCHAR(25))
BEGIN
  INSERT INTO t_actividad_alumno_detalle(
       id_actividad_alumno
      ,id_actividad_detalle
      ,i_fase
      ,v_pregunta_1
      ,v_pregunta_2
      ,v_pregunta_3
      ,v_pregunta_4
      ,v_pregunta_5
      ,v_pregunta_6
      ,v_pregunta_7
      ,v_pregunta_8
      ,v_pregunta_9
      ,v_pregunta_10
      ,v_pregunta_11
      ,v_pregunta_12
      ,v_pregunta_13
      ,v_pregunta_14
      ,v_pregunta_15
      ,v_pregunta_16
      ,v_pregunta_17
      ,v_pregunta_18
      ,v_pregunta_19
      ,v_pregunta_20
      ,v_pregunta_21
      ,v_pregunta_22
      ,v_pregunta_23
      ,v_pregunta_24
      ,v_pregunta_25
      ,v_pregunta_26
      ,v_pregunta_27
      ,v_pregunta_28
      ,v_pregunta_29
      ,v_pregunta_30
      ,v_pregunta_31
      ,v_pregunta_32
      ,v_pregunta_33
      ,v_pregunta_34
      ,v_pregunta_35
      ,v_pregunta_36
      ,v_pregunta_37
      ,v_pregunta_38
      ,v_pregunta_39
      ,v_pregunta_40
      ,v_pregunta_41
      ,v_pregunta_42
      ,v_pregunta_43
      ,v_pregunta_44
      ,v_pregunta_45
      ,v_pregunta_46
      ,v_pregunta_47
      ,v_pregunta_48
      ,v_pregunta_49
      ,v_pregunta_50
      ,v_pregunta_51
      ,v_pregunta_52
      ,v_pregunta_53
      ,v_pregunta_54
      ,v_pregunta_55
      ,v_pregunta_56
      ,v_pregunta_57
      ,v_pregunta_58
      ,v_pregunta_59
      ,v_pregunta_60
      ,i_puntaje
      ,v_descripcion
      ,i_tipo_pregunta
      ,b_estado)
    VALUES (
      _id_actividad_alumno
      ,_id_actividad_detalle
      ,_i_fase
      ,_v_pregunta_1
      ,_v_pregunta_2
      ,_v_pregunta_3
      ,_v_pregunta_4
      ,_v_pregunta_5
      ,_v_pregunta_6
      ,_v_pregunta_7
      ,_v_pregunta_8
      ,_v_pregunta_9
      ,_v_pregunta_10
      ,_v_pregunta_11
      ,_v_pregunta_12
      ,_v_pregunta_13
      ,_v_pregunta_14
      ,_v_pregunta_15
      ,_v_pregunta_16
      ,_v_pregunta_17
      ,_v_pregunta_18
      ,_v_pregunta_19
      ,_v_pregunta_20
      ,_v_pregunta_21
      ,_v_pregunta_22
      ,_v_pregunta_23
      ,_v_pregunta_24
      ,_v_pregunta_25
      ,_v_pregunta_26
      ,_v_pregunta_27
      ,_v_pregunta_28
      ,_v_pregunta_29
      ,_v_pregunta_30
      ,_v_pregunta_31
      ,_v_pregunta_32
      ,_v_pregunta_33
      ,_v_pregunta_34
      ,_v_pregunta_35
      ,_v_pregunta_36
      ,_v_pregunta_37
      ,_v_pregunta_38
      ,_v_pregunta_39
      ,_v_pregunta_40
      ,_v_pregunta_41
      ,_v_pregunta_42
      ,_v_pregunta_43
      ,_v_pregunta_44
      ,_v_pregunta_45
      ,_v_pregunta_46
      ,_v_pregunta_47
      ,_v_pregunta_48
      ,_v_pregunta_49
      ,_v_pregunta_50
      ,_v_pregunta_51
      ,_v_pregunta_52
      ,_v_pregunta_53
      ,_v_pregunta_54
      ,_v_pregunta_55
      ,_v_pregunta_56
      ,_v_pregunta_57
      ,_v_pregunta_58
      ,_v_pregunta_59
      ,_v_pregunta_60
      ,_i_puntaje
      ,_v_descripcion
      ,_i_tipo_pregunta
      ,_b_estado
      ,STR_TO_DATE(_dt_fecharegistro,'%Y-%m-%d'));

    SELECT LAST_INSERT_ID() as '_result';

END$$
DELIMITER ;

-- -------------------------------------------------

-- CREA LAS CARRERAS PARA EL ALUMNO
DELIMITER $$
CREATE PROCEDURE `sp_actualizar_actividadAlumno`(
  IN id_actividad_alumno INT
  ,IN _i_carrera1 VARCHAR(50)
  ,IN _i_carrera2 VARCHAR(50)
  ,IN _i_carrera3 VARCHAR(50)
  ,IN _i_carrera4 VARCHAR(50)
  ,IN _i_carrera5 VARCHAR(50)
  ,IN _i_puntaje INT
  ,IN _v_comentario VARCHAR(500))
BEGIN
  UPDATE t_actividad_alumno
  SET  
  i_carrera1 = _i_carrera1,
  i_carrera2 = _i_carrera2,
  i_carrera3 = _i_carrera3,
  i_carrera4 = _i_carrera4,
  i_carrera5 = _i_carrera5,
  i_puntaje = i_puntaje,
  v_comentario = v_comentario
  WHERE id_actividad_alumno = id_actividad_alumno;
END$$
DELIMITER ;

-- --------------------------------------------------

-- CREA EL RESULTADO FINAL DE CADA FASE
DELIMITER $$
CREATE PROCEDURE `sp_actualizar_actividadAlumnoDetalle`(
   IN _id_actividad_alumno INT
  ,IN _ifase INT
  ,IN _v_descripcion VARCHAR(500)
  ,IN _i_tipo_pregunta INT
  ,IN _i_puntaje INT)
BEGIN
  UPDATE t_actividad_alumno_detalle
  SET  
  i_puntaje = _i_puntaje
  ,v_descripcion = _v_descripcion
  ,i_tipo_pregunta = _i_tipo_pregunta
  WHERE id_actividad_alumno = _id_actividad_alumno AND i_fase = _ifase;
END$$
DELIMITER ;

-- --------------------------------------------------
-- TRAE LA SESSION DEL ALUMNO PARA EL LOGIN
DELIMITER $$
CREATE PROCEDURE `sp_listar_actividadAlumno`(
  IN _v_correo  VARCHAR(100)
  ,IN _v_clave  VARCHAR(100))
BEGIN
 SELECT
      aa.id_actividad
      ,aa.v_nombres
      ,aa.v_apellidos
      ,aa.v_lugarnacimiento
      ,aa.v_correo
      ,aa.v_clave
      ,aa.v_colegio

  FROM t_actividad_alumno aa WHERE aa.v_correo = _v_correo AND aa.v_clave = _v_clave;

END$$
DELIMITER ;


-- --------------------------------------------------
-- TRAE LAS FASES DE LOS ALUMNOS DEPENDIENDO DEL ID DE USUARIO
DELIMITER $$
CREATE PROCEDURE `sp_listar_actividadFases`(
  IN _id_actividad INT)
BEGIN
 SELECT DISTINCT
  aad.i_fase

  FROM t_actividad_alumno_detalle aad WHERE aad.id_actividad_alumno = _id_actividad;

END$$
DELIMITER ;

-- --------------------------------------------------------

-- TRAE A LOS USUARIOS EN GENERAL
DELIMITER $$
CREATE PROCEDURE `sp_listar_alumnosActividad`(
   IN _nombres VARCHAR(50)
  ,IN _apellidos VARCHAR(50))
BEGIN
 SELECT
   aad.id_actividad_alumno
  ,aad.id_actividad
  ,aad.v_nombres
  ,aad.v_apellidos
  ,aad.i_grado
  ,aad.i_edad
  ,aad.i_sexo
  ,aad.v_colegio
  ,aad.v_celular
  ,aad.v_correo
  ,aad.v_clave
  ,aad.i_carrera1
  ,aad.i_carrera2
  ,aad.i_carrera3
  ,aad.i_carrera4
  ,aad.i_carrera5
  ,aad.i_puntaje
  ,aad.v_comentario

  FROM t_actividad_alumno_detalle aad 
    WHERE aad.v_nombres LIKE CONCAT('%', _nombres, '%') OR (_nombres = '') 
      AND aad.v_apellidos LIKE CONCAT('%', _apellidos, '%') OR (_apellidos = '');

END$$
DELIMITER ;

-- ----------------------------------------------------
