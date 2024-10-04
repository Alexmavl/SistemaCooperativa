CREATE TABLE Estatus (
    id_estatus      NUMBER PRIMARY KEY,
    descripcion     VARCHAR2(30) NOT NULL
);

CREATE TABLE TipoPersona (
    id_tipo_persona NUMBER PRIMARY KEY,
    descripcion     VARCHAR2(30) NOT NULL
);

CREATE TABLE CategoriaProducto (
    id_categoria_producto NUMBER PRIMARY KEY,
    descripcion           VARCHAR2(50) NOT NULL
);

CREATE TABLE TipoPrestamo (
    id_tipo_prestamo NUMBER PRIMARY KEY,
    descripcion      VARCHAR2(30) NOT NULL
);

CREATE TABLE TipoCuenta (
    id_tipo_cuenta NUMBER PRIMARY KEY,
    descripcion    VARCHAR2(30) NOT NULL
);

CREATE TABLE Cede (
    id_cede         NUMBER PRIMARY KEY,
    ubicacion       VARCHAR2(100) NOT NULL,
    nombre          VARCHAR2(50) NOT NULL
);

-- Crear secuencias para las tablas con ID autoincrementable
CREATE SEQUENCE sec_persona START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE sec_producto START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE sec_prestamo START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE sec_detalle_prestamo START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE sec_cuenta START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE sec_saldo START WITH 1 INCREMENT BY 1;

-- Crear tablas con dependencias
CREATE TABLE Producto (
    id_producto      NUMBER PRIMARY KEY,
    nombre           VARCHAR2(50) NOT NULL,
    precio           NUMBER(10, 2),
    id_categoria_producto NUMBER,
    CONSTRAINT fk_categoria_producto FOREIGN KEY (id_categoria_producto) REFERENCES CategoriaProducto(id_categoria_producto)
);

CREATE TRIGGER trg_producto_id
BEFORE INSERT ON Producto
FOR EACH ROW
BEGIN
    SELECT sec_producto.NEXTVAL INTO :NEW.id_producto FROM dual;
END;

CREATE TABLE Persona (
    id_persona      NUMBER PRIMARY KEY,
    nombre          VARCHAR2(50) NOT NULL,
    apellido        VARCHAR2(50) NOT NULL,
    direccion       VARCHAR2(100),
    telefono        VARCHAR2(15),
    email           VARCHAR2(50),
    id_tipo_persona NUMBER,
    id_estatus      NUMBER,
    CONSTRAINT fk_tipo_persona FOREIGN KEY (id_tipo_persona) REFERENCES TipoPersona(id_tipo_persona),
    CONSTRAINT fk_estatus FOREIGN KEY (id_estatus) REFERENCES Estatus(id_estatus)
);

CREATE TRIGGER trg_persona_id
BEFORE INSERT ON Persona
FOR EACH ROW
BEGIN
    SELECT sec_persona.NEXTVAL INTO :NEW.id_persona FROM dual;
END;

CREATE TABLE Prestamo (
    id_prestamo     NUMBER PRIMARY KEY,
    monto           NUMBER(10, 2) NOT NULL,
    fecha           DATE NOT NULL,
    id_persona      NUMBER,
    id_tipo_prestamo NUMBER,
    CONSTRAINT fk_persona FOREIGN KEY (id_persona) REFERENCES Persona(id_persona),
    CONSTRAINT fk_tipo_prestamo FOREIGN KEY (id_tipo_prestamo) REFERENCES TipoPrestamo(id_tipo_prestamo)
);

CREATE TRIGGER trg_prestamo_id
BEFORE INSERT ON Prestamo
FOR EACH ROW
BEGIN
    SELECT sec_prestamo.NEXTVAL INTO :NEW.id_prestamo FROM dual;
END;

CREATE TABLE DetallePrestamo (
    id_detalle_prestamo NUMBER PRIMARY KEY,
    id_prestamo         NUMBER,
    id_producto         NUMBER,
    cantidad            NUMBER,
    CONSTRAINT fk_prestamo FOREIGN KEY (id_prestamo) REFERENCES Prestamo(id_prestamo),
    CONSTRAINT fk_producto FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);

CREATE TRIGGER trg_detalle_prestamo_id
BEFORE INSERT ON DetallePrestamo
FOR EACH ROW
BEGIN
    SELECT sec_detalle_prestamo.NEXTVAL INTO :NEW.id_detalle_prestamo FROM dual;
END;

CREATE TABLE Cuenta (
    id_cuenta       NUMBER PRIMARY KEY,
    id_persona      NUMBER,
    id_tipo_cuenta  NUMBER,
    fecha_apertura  DATE,
    CONSTRAINT fk_persona_cuenta FOREIGN KEY (id_persona) REFERENCES Persona(id_persona),
    CONSTRAINT fk_tipo_cuenta FOREIGN KEY (id_tipo_cuenta) REFERENCES TipoCuenta(id_tipo_cuenta)
);

CREATE TRIGGER trg_cuenta_id
BEFORE INSERT ON Cuenta
FOR EACH ROW
BEGIN
    SELECT sec_cuenta.NEXTVAL INTO :NEW.id_cuenta FROM dual;
END;

CREATE TABLE Saldo (
    id_saldo        NUMBER PRIMARY KEY,
    id_cuenta       NUMBER,
    monto           NUMBER(10, 2) NOT NULL,
    fecha_actualizacion DATE,
    CONSTRAINT fk_cuenta FOREIGN KEY (id_cuenta) REFERENCES Cuenta(id_cuenta)
);

CREATE TRIGGER trg_saldo_id
BEFORE INSERT ON Saldo
FOR EACH ROW
 BEGIN
    SELECT sec_saldo.NEXTVAL INTO :NEW.id_saldo FROM dual;
END;