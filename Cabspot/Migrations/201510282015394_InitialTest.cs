namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "cabspotdb.bases",
                c => new
                    {
                        idBase = c.Int(nullable: false, identity: true),
                        nombreBase = c.String(nullable: false, maxLength: 50, unicode: false),
                        idDireccion = c.Int(),
                        idContacto = c.Int(),
                    })
                .PrimaryKey(t => t.idBase)
                .ForeignKey("cabspotdb.contactos", t => t.idContacto)
                .ForeignKey("cabspotdb.direcciones", t => t.idDireccion)
                .Index(t => t.idDireccion)
                .Index(t => t.idContacto);
            
            CreateTable(
                "cabspotdb.contactos",
                c => new
                    {
                        idContacto = c.Int(nullable: false, identity: true),
                        telefonoMovil = c.String(maxLength: 10, unicode: false),
                        telefonoResidencial = c.String(maxLength: 10, unicode: false),
                        telefonoTrabajo = c.String(maxLength: 10, unicode: false),
                        fax = c.String(maxLength: 10, unicode: false),
                        email = c.String(unicode: false, storeType: "text"),
                        emailAlternativo = c.String(unicode: false, storeType: "text"),
                        paginaWeb = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.idContacto);
            
            CreateTable(
                "cabspotdb.personas",
                c => new
                    {
                        idPersona = c.Int(nullable: false, identity: true),
                        identificacion = c.String(nullable: false, maxLength: 15, unicode: false),
                        nombres = c.String(nullable: false, maxLength: 30, unicode: false),
                        apellidos = c.String(nullable: false, maxLength: 50, unicode: false),
                        fechaNacimiento = c.DateTime(nullable: false, storeType: "date"),
                        sexo = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        foto = c.String(nullable: false, maxLength: 255, unicode: false),
                        nacionalidad = c.String(nullable: false, maxLength: 50, unicode: false),
                        idDireccion = c.Int(),
                        idContacto = c.Int(),
                    })
                .PrimaryKey(t => t.idPersona)
                .ForeignKey("cabspotdb.contactos", t => t.idContacto)
                .ForeignKey("cabspotdb.direcciones", t => t.idDireccion)
                .Index(t => t.idDireccion)
                .Index(t => t.idContacto);
            
            CreateTable(
                "cabspotdb.clientes",
                c => new
                    {
                        idCliente = c.Int(nullable: false, identity: true),
                        idPersona = c.Int(),
                        nombreUsuario = c.String(maxLength: 15, unicode: false),
                        fechaRegistro = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.idCliente)
                .ForeignKey("cabspotdb.personas", t => t.idPersona)
                .Index(t => t.idPersona);
            
            CreateTable(
                "cabspotdb.solicitudes",
                c => new
                    {
                        idSolicitud = c.Int(nullable: false, identity: true),
                        solicitadoPor = c.Int(),
                        fechaSolicitud = c.DateTime(nullable: false, storeType: "date"),
                        longitudOrigen = c.String(nullable: false, maxLength: 30, unicode: false),
                        latitudOrigen = c.String(nullable: false, maxLength: 30, unicode: false),
                        longitudDestino = c.String(nullable: false, maxLength: 30, unicode: false),
                        latitudDestino = c.String(nullable: false, maxLength: 30, unicode: false),
                        idViaSolicitud = c.Int(),
                        idMetodoPago = c.Int(),
                        idEstadoSolicitud = c.Int(),
                    })
                .PrimaryKey(t => t.idSolicitud)
                .ForeignKey("cabspotdb.estadosolicitud", t => t.idEstadoSolicitud)
                .ForeignKey("cabspotdb.metodopago", t => t.idMetodoPago)
                .ForeignKey("cabspotdb.viasolicitud", t => t.idViaSolicitud)
                .ForeignKey("cabspotdb.clientes", t => t.solicitadoPor)
                .Index(t => t.solicitadoPor)
                .Index(t => t.idViaSolicitud)
                .Index(t => t.idMetodoPago)
                .Index(t => t.idEstadoSolicitud);
            
            CreateTable(
                "cabspotdb.carreras",
                c => new
                    {
                        idCarrera = c.Int(nullable: false, identity: true),
                        idSolicitud = c.Int(),
                        idTaxista = c.Int(),
                        idEstado = c.Int(),
                        fechaInicioCarrera = c.DateTime(nullable: false, precision: 0),
                        fechaFinCarrera = c.DateTime(precision: 0),
                        tiempoCarrera = c.Time(precision: 0),//, fixedLength: true),
                    })
                .PrimaryKey(t => t.idCarrera)
                .ForeignKey("cabspotdb.estadocarreras", t => t.idEstado)
                .ForeignKey("cabspotdb.solicitudes", t => t.idSolicitud)
                .ForeignKey("cabspotdb.taxistas", t => t.idTaxista)
                .Index(t => t.idSolicitud)
                .Index(t => t.idTaxista)
                .Index(t => t.idEstado);
            
            CreateTable(
                "cabspotdb.comentarios",
                c => new
                    {
                        idComentario = c.Int(nullable: false, identity: true),
                        idCarrera = c.Int(),
                        fechaComentario = c.DateTime(nullable: false, storeType: "date"),
                        comentario = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.idComentario)
                .ForeignKey("cabspotdb.carreras", t => t.idCarrera)
                .Index(t => t.idCarrera);
            
            CreateTable(
                "cabspotdb.encuestas",
                c => new
                    {
                        idEncuesta = c.Int(nullable: false, identity: true),
                        idCarrera = c.Int(),
                        fechaEncuesta = c.DateTime(nullable: false, storeType: "date"),
                        idEstadoEncuesta = c.Int(),
                    })
                .PrimaryKey(t => t.idEncuesta)
                .ForeignKey("cabspotdb.carreras", t => t.idCarrera)
                .ForeignKey("cabspotdb.estadoencuestas", t => t.idEstadoEncuesta)
                .Index(t => t.idCarrera)
                .Index(t => t.idEstadoEncuesta);
            
            CreateTable(
                "cabspotdb.encuestaspreguntas",
                c => new
                    {
                        respuesta = c.Single(nullable: false),
                        idEncuesta = c.Int(),
                        idPregunta = c.Int(),
                    })
                .PrimaryKey(t => t.respuesta)
                .ForeignKey("cabspotdb.encuestas", t => t.idEncuesta)
                .ForeignKey("cabspotdb.preguntas", t => t.idPregunta)
                .Index(t => t.idEncuesta)
                .Index(t => t.idPregunta);
            
            CreateTable(
                "cabspotdb.preguntas",
                c => new
                    {
                        idPregunta = c.Int(nullable: false, identity: true),
                        pregunta = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.idPregunta);
            
            CreateTable(
                "cabspotdb.estadoencuestas",
                c => new
                    {
                        idEstadoEncuesta = c.Int(nullable: false, identity: true),
                        estadoEncuesta = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.idEstadoEncuesta);
            
            CreateTable(
                "cabspotdb.estadocarreras",
                c => new
                    {
                        idEstado = c.Int(nullable: false, identity: true),
                        estadoCarrera = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.idEstado);
            
            CreateTable(
                "cabspotdb.taxistas",
                c => new
                    {
                        idTaxista = c.Int(nullable: false, identity: true),
                        idPersona = c.Int(),
                        codigoTaxita = c.String(nullable: false, maxLength: 10, unicode: false),
                        idEstadoDisponibilidad = c.Int(),
                        idBase = c.Int(),
                        fechaRegistro = c.DateTime(nullable: false, storeType: "date"),
                        registradoPor = c.Int(),
                    })
                .PrimaryKey(t => t.idTaxista);
            
            CreateTable(
                "cabspotdb.vehiculos",
                c => new
                    {
                        idVehiculo = c.Int(nullable: false, identity: true),
                        idTaxista = c.Int(),
                        chasis = c.String(nullable: false, maxLength: 50, unicode: false),
                        placa = c.String(nullable: false, maxLength: 10, unicode: false),
                        marca = c.String(nullable: false, maxLength: 20, unicode: false),
                        modelo = c.String(nullable: false, maxLength: 20, unicode: false),
                        serie = c.String(maxLength: 5, unicode: false),
                        anio = c.String(nullable: false, maxLength: 5, unicode: false),
                        color = c.String(nullable: false, maxLength: 10, unicode: false),
                        unidad = c.String(nullable: false, maxLength: 5, unicode: false),
                        idTipoVehiculo = c.Int(),
                        idEstadoVehiculo = c.Int(),
                        idCondicionVehiculo = c.Int(),
                        cantidadAsientos = c.Int(nullable: false),
                        fechaRegistro = c.DateTime(nullable: false, storeType: "date"),
                        registradoPor = c.Int(),
                        fechaUltimaModificacion = c.DateTime(storeType: "date"),
                        modificadoPor = c.Int(),
                    })
                .PrimaryKey(t => t.idVehiculo)
                .ForeignKey("cabspotdb.condicionvehiculos", t => t.idCondicionVehiculo)
                .ForeignKey("cabspotdb.empleados", t => t.registradoPor)
                .ForeignKey("cabspotdb.empleados", t => t.modificadoPor)
                .ForeignKey("cabspotdb.estadovehiculos", t => t.idEstadoVehiculo)
                .ForeignKey("cabspotdb.taxistas", t => t.idTaxista)
                .ForeignKey("cabspotdb.tipovehiculos", t => t.idTipoVehiculo)
                .Index(t => t.idTaxista)
                .Index(t => t.idTipoVehiculo)
                .Index(t => t.idEstadoVehiculo)
                .Index(t => t.idCondicionVehiculo)
                .Index(t => t.registradoPor)
                .Index(t => t.modificadoPor);
            
            CreateTable(
                "cabspotdb.condicionvehiculos",
                c => new
                    {
                        idCondicionVehiculo = c.Int(nullable: false, identity: true),
                        condicionVehiculo = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.idCondicionVehiculo);
            
            CreateTable(
                "cabspotdb.empleados",
                c => new
                    {
                        idEmpleado = c.Int(nullable: false, identity: true),
                        fechaRegistro = c.DateTime(nullable: false, storeType: "date"),
                        registradoPor = c.Int(),
                        idEstadoEmpleado = c.Int(),
                        idBase = c.Int(),
                        idRol = c.Int(),
                        usuario = c.String(nullable: false, maxLength: 25, unicode: false),
                        contrasena = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.idEmpleado)
                .ForeignKey("cabspotdb.bases", t => t.idBase)
                .ForeignKey("cabspotdb.empleados", t => t.registradoPor)
                .ForeignKey("cabspotdb.estadoempleados", t => t.idEstadoEmpleado)
                .ForeignKey("cabspotdb.roles", t => t.idRol)
                .Index(t => t.registradoPor)
                .Index(t => t.idEstadoEmpleado)
                .Index(t => t.idBase)
                .Index(t => t.idRol);
            
            CreateTable(
                "cabspotdb.estadoempleados",
                c => new
                    {
                        idEstadoEmpleado = c.Int(nullable: false, identity: true),
                        estadoEmpleado = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.idEstadoEmpleado);
            
            CreateTable(
                "cabspotdb.roles",
                c => new
                    {
                        idRol = c.Int(nullable: false, identity: true),
                        rol = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.idRol);
            
            CreateTable(
                "cabspotdb.estadovehiculos",
                c => new
                    {
                        idEstadoVehiculo = c.Int(nullable: false, identity: true),
                        estadoVehiculo = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.idEstadoVehiculo);
            
            CreateTable(
                "cabspotdb.tipovehiculos",
                c => new
                    {
                        idTipoVehiculo = c.Int(nullable: false, identity: true),
                        tipoVehiculo = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.idTipoVehiculo);
            
            CreateTable(
                "cabspotdb.estadosolicitud",
                c => new
                    {
                        idEstadoSolicitud = c.Int(nullable: false, identity: true),
                        estadoSolicitud = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.idEstadoSolicitud);
            
            CreateTable(
                "cabspotdb.metodopago",
                c => new
                    {
                        idMEtodoPago = c.Int(nullable: false, identity: true),
                        metodoPago = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.idMEtodoPago);
            
            CreateTable(
                "cabspotdb.viasolicitud",
                c => new
                    {
                        idViaSolicitud = c.Int(nullable: false, identity: true),
                        viaSolicitud = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.idViaSolicitud);
            
            CreateTable(
                "cabspotdb.sugerencias",
                c => new
                    {
                        idSugerencia = c.Int(nullable: false, identity: true),
                        idCliente = c.Int(),
                        sugerencia = c.String(nullable: false, maxLength: 255, unicode: false),
                        fechaSugerencia = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.idSugerencia)
                .ForeignKey("cabspotdb.clientes", t => t.idCliente)
                .Index(t => t.idCliente);
            
            CreateTable(
                "cabspotdb.direcciones",
                c => new
                    {
                        idDireccion = c.Int(nullable: false, identity: true),
                        numeroPuerta = c.String(nullable: false, maxLength: 5, unicode: false),
                        numeroEdificio = c.String(maxLength: 5, unicode: false),
                        nombreEdificio = c.String(maxLength: 100, unicode: false),
                        calle = c.String(nullable: false, maxLength: 255, unicode: false),
                        ciudad = c.String(nullable: false, maxLength: 100, unicode: false),
                        idMunicipio = c.Int(),
                    })
                .PrimaryKey(t => t.idDireccion)
                .ForeignKey("cabspotdb.municipios", t => t.idMunicipio)
                .Index(t => t.idMunicipio);
            
            CreateTable(
                "cabspotdb.municipios",
                c => new
                    {
                        idMunicipio = c.Int(nullable: false, identity: true),
                        nombreMunicipio = c.String(nullable: false, maxLength: 255, unicode: false),
                        idProvincia = c.Int(),
                    })
                .PrimaryKey(t => t.idMunicipio)
                .ForeignKey("cabspotdb.provincias", t => t.idProvincia)
                .Index(t => t.idProvincia);
            
            CreateTable(
                "cabspotdb.provincias",
                c => new
                    {
                        idProvincia = c.Int(nullable: false, identity: true),
                        nombreProvincia = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.idProvincia);
            
            CreateTable(
                "cabspotdb.estadodisponibilidad",
                c => new
                    {
                        idEstadoDisponibilidad = c.Int(nullable: false, identity: true),
                        estadoDisponibilidad = c.String(nullable: false, maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => t.idEstadoDisponibilidad);
            
        }
        
        public override void Down()
        {
            DropForeignKey("cabspotdb.personas", "idDireccion", "cabspotdb.direcciones");
            DropForeignKey("cabspotdb.municipios", "idProvincia", "cabspotdb.provincias");
            DropForeignKey("cabspotdb.direcciones", "idMunicipio", "cabspotdb.municipios");
            DropForeignKey("cabspotdb.bases", "idDireccion", "cabspotdb.direcciones");
            DropForeignKey("cabspotdb.personas", "idContacto", "cabspotdb.contactos");
            DropForeignKey("cabspotdb.sugerencias", "idCliente", "cabspotdb.clientes");
            DropForeignKey("cabspotdb.solicitudes", "solicitadoPor", "cabspotdb.clientes");
            DropForeignKey("cabspotdb.solicitudes", "idViaSolicitud", "cabspotdb.viasolicitud");
            DropForeignKey("cabspotdb.solicitudes", "idMetodoPago", "cabspotdb.metodopago");
            DropForeignKey("cabspotdb.solicitudes", "idEstadoSolicitud", "cabspotdb.estadosolicitud");
            DropForeignKey("cabspotdb.vehiculos", "idTipoVehiculo", "cabspotdb.tipovehiculos");
            DropForeignKey("cabspotdb.vehiculos", "idTaxista", "cabspotdb.taxistas");
            DropForeignKey("cabspotdb.vehiculos", "idEstadoVehiculo", "cabspotdb.estadovehiculos");
            DropForeignKey("cabspotdb.vehiculos", "modificadoPor", "cabspotdb.empleados");
            DropForeignKey("cabspotdb.vehiculos", "registradoPor", "cabspotdb.empleados");
            DropForeignKey("cabspotdb.empleados", "idRol", "cabspotdb.roles");
            DropForeignKey("cabspotdb.empleados", "idEstadoEmpleado", "cabspotdb.estadoempleados");
            DropForeignKey("cabspotdb.empleados", "registradoPor", "cabspotdb.empleados");
            DropForeignKey("cabspotdb.empleados", "idBase", "cabspotdb.bases");
            DropForeignKey("cabspotdb.vehiculos", "idCondicionVehiculo", "cabspotdb.condicionvehiculos");
            DropForeignKey("cabspotdb.carreras", "idTaxista", "cabspotdb.taxistas");
            DropForeignKey("cabspotdb.carreras", "idSolicitud", "cabspotdb.solicitudes");
            DropForeignKey("cabspotdb.carreras", "idEstado", "cabspotdb.estadocarreras");
            DropForeignKey("cabspotdb.encuestas", "idEstadoEncuesta", "cabspotdb.estadoencuestas");
            DropForeignKey("cabspotdb.encuestaspreguntas", "idPregunta", "cabspotdb.preguntas");
            DropForeignKey("cabspotdb.encuestaspreguntas", "idEncuesta", "cabspotdb.encuestas");
            DropForeignKey("cabspotdb.encuestas", "idCarrera", "cabspotdb.carreras");
            DropForeignKey("cabspotdb.comentarios", "idCarrera", "cabspotdb.carreras");
            DropForeignKey("cabspotdb.clientes", "idPersona", "cabspotdb.personas");
            DropForeignKey("cabspotdb.bases", "idContacto", "cabspotdb.contactos");
            DropIndex("cabspotdb.municipios", new[] { "idProvincia" });
            DropIndex("cabspotdb.direcciones", new[] { "idMunicipio" });
            DropIndex("cabspotdb.sugerencias", new[] { "idCliente" });
            DropIndex("cabspotdb.empleados", new[] { "idRol" });
            DropIndex("cabspotdb.empleados", new[] { "idBase" });
            DropIndex("cabspotdb.empleados", new[] { "idEstadoEmpleado" });
            DropIndex("cabspotdb.empleados", new[] { "registradoPor" });
            DropIndex("cabspotdb.vehiculos", new[] { "modificadoPor" });
            DropIndex("cabspotdb.vehiculos", new[] { "registradoPor" });
            DropIndex("cabspotdb.vehiculos", new[] { "idCondicionVehiculo" });
            DropIndex("cabspotdb.vehiculos", new[] { "idEstadoVehiculo" });
            DropIndex("cabspotdb.vehiculos", new[] { "idTipoVehiculo" });
            DropIndex("cabspotdb.vehiculos", new[] { "idTaxista" });
            DropIndex("cabspotdb.encuestaspreguntas", new[] { "idPregunta" });
            DropIndex("cabspotdb.encuestaspreguntas", new[] { "idEncuesta" });
            DropIndex("cabspotdb.encuestas", new[] { "idEstadoEncuesta" });
            DropIndex("cabspotdb.encuestas", new[] { "idCarrera" });
            DropIndex("cabspotdb.comentarios", new[] { "idCarrera" });
            DropIndex("cabspotdb.carreras", new[] { "idEstado" });
            DropIndex("cabspotdb.carreras", new[] { "idTaxista" });
            DropIndex("cabspotdb.carreras", new[] { "idSolicitud" });
            DropIndex("cabspotdb.solicitudes", new[] { "idEstadoSolicitud" });
            DropIndex("cabspotdb.solicitudes", new[] { "idMetodoPago" });
            DropIndex("cabspotdb.solicitudes", new[] { "idViaSolicitud" });
            DropIndex("cabspotdb.solicitudes", new[] { "solicitadoPor" });
            DropIndex("cabspotdb.clientes", new[] { "idPersona" });
            DropIndex("cabspotdb.personas", new[] { "idContacto" });
            DropIndex("cabspotdb.personas", new[] { "idDireccion" });
            DropIndex("cabspotdb.bases", new[] { "idContacto" });
            DropIndex("cabspotdb.bases", new[] { "idDireccion" });
            DropTable("cabspotdb.estadodisponibilidad");
            DropTable("cabspotdb.provincias");
            DropTable("cabspotdb.municipios");
            DropTable("cabspotdb.direcciones");
            DropTable("cabspotdb.sugerencias");
            DropTable("cabspotdb.viasolicitud");
            DropTable("cabspotdb.metodopago");
            DropTable("cabspotdb.estadosolicitud");
            DropTable("cabspotdb.tipovehiculos");
            DropTable("cabspotdb.estadovehiculos");
            DropTable("cabspotdb.roles");
            DropTable("cabspotdb.estadoempleados");
            DropTable("cabspotdb.empleados");
            DropTable("cabspotdb.condicionvehiculos");
            DropTable("cabspotdb.vehiculos");
            DropTable("cabspotdb.taxistas");
            DropTable("cabspotdb.estadocarreras");
            DropTable("cabspotdb.estadoencuestas");
            DropTable("cabspotdb.preguntas");
            DropTable("cabspotdb.encuestaspreguntas");
            DropTable("cabspotdb.encuestas");
            DropTable("cabspotdb.comentarios");
            DropTable("cabspotdb.carreras");
            DropTable("cabspotdb.solicitudes");
            DropTable("cabspotdb.clientes");
            DropTable("cabspotdb.personas");
            DropTable("cabspotdb.contactos");
            DropTable("cabspotdb.bases");
        }
    }
}
