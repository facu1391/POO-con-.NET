namespace AppTurno
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Plan plan1 = new Plan(1, "ORO");
            Plan plan2 = new Plan(2, "PLATA");
            Plan plan3 = new Plan(3, "COBRE");

            Financiador financiador1 = new Financiador(1, "OSDE");
            financiador1.planes.Add(plan1);
            financiador1.planes.Add(plan2);

            financiador1.InformarDatos();
            financiador1.ListarPlanes();

            Financiador financiador2 = new Financiador(2, "PAMI");
            financiador2.planes.Add(plan3);

            financiador2.InformarDatos();
            financiador2.ListarPlanes();

            Turno turno1 = new Turno(1001, "01/10/2022", "08:00", 30);
            Turno turno2 = new Turno(1001, "01/10/2022", "08:30", 30);
            Turno turno3 = new Turno(1001, "01/10/2022", "09:00", 30);
            Turno turno4 = new Turno(1001, "01/10/2022", "09:30", 30);
            Turno turno5 = new Turno(1001, "01/10/2022", "10:00", 30);

            Paciente paciente1 = new Paciente(10, "Gonzalez", "Laura");
            paciente1.financiador = financiador2;
            paciente1.numeroAfiliado = "1254";
            paciente1.plan = financiador2.planes[0];
            paciente1.turnos.Add(turno1);
            paciente1.InformarDatos();

            Paciente paciente2 = new Paciente(12, "Perez", "Juan");
            paciente2.financiador = financiador1;
            paciente2.numeroAfiliado = "9637";
            paciente2.plan = financiador1.planes[0];
            paciente2.turnos.Add(turno2);
            paciente2.turnos.Add(turno3);
            paciente2.turnos.Add(turno4);
            paciente1.InformarDatos();
            

        }
    }

    abstract class Persona
    {
        public string apellido { get; set; }
        public string nombre { get; set; }
        public TipoDocumento tipoDocumento { get; set; }
        public int numeroDocumento { get; set; }
        public Domicilio domicilio { get; set; }
        public Contacto contacto { get; set; }
        public Sexo sexo { get; set; }

        public void InformarDatos()
        {
            Console.WriteLine($"Apellido:{apellido}, Nombre:{nombre}");
        }

    }

    class Usuario
    {
        public Usuario(int id, string usuario, string email, DateTime fechaHoraRegistro, DateTime ultimoIngreso, bool bloqueado, bool activo)
        {
            this.id = id;
            this.usuario = usuario;
            this.email = email;
            this.fechaHoraRegistro = fechaHoraRegistro;
            this.ultimoIngreso = ultimoIngreso;
            this.bloqueado = bloqueado;
            this.activo = activo;
        }

        public int id { get; set; }
        public string usuario { get; set; }
        public string email { get; set; }
        public DateTime fechaHoraRegistro { get; set; }
        public DateTime ultimoIngreso { get; set; }
        public bool bloqueado { get; set; }
        public bool activo { get; set; }

        public void InformarDatos()
        {
            Console.WriteLine($"Paciente Id:{id} - Nombre:{usuario}, Registro:{fechaHoraRegistro}");
            InformarDatos();
        }
    }

    class Paciente : Persona
    {
        public Paciente(int id, string apellido, string nombre)
        {
            this.id = id;
            this.apellido = apellido;
            this.nombre = nombre;
            turnos = new List<Turno>();
        }
        public int id { get; set; }
        public Financiador financiador { get; set; }
        public Plan plan;
        public string numeroAfiliado { get; set; }
        public List<Turno> turnos { get; set; }

        public void InformarDatos()
        {
            Console.WriteLine($"Paciente Id:{id} - Apellido:{apellido}, Nombre:{nombre}");
            ListarTurnos();
        }
        private void ListarTurnos()
        {
            foreach (var turno in turnos)
            {
                Console.WriteLine($"     Turno Id:{turno.id} - Fecha:{turno.fecha} - Hora:{turno.hora}");
            }
        }

    }

    class Secretaria
    {
        int id;
        string nombre;
        string apellido;
        int legajo;
    }

    class Profesional : Persona
    {
        int id;
       string titulo;
       string matriculaNacional;
       string matriculaProvincial;
       List<Especialidad> Especialidades;
    }

    class Especialidad
    {
        int id;
        string nombre;
    }


    class Turno
    {
        public Turno(int id, string fecha, string hora, int duracion)
        {
            this.id = id;
            this.fecha = fecha;
            this.hora = hora;
            this.duracion = duracion;
        }

        public int id { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public int duracion { get; set; }
        
    }

    class Financiador
    {
        public Financiador()
        {
           this.planes = new List<Plan>();
        }
        public Financiador(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            this.planes = new List<Plan>();
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public List<Plan> planes { get; set; }

        public void InformarDatos()
        {
            Console.WriteLine($"Financiador Id:{id} - Nombre:{nombre}");
        }

        public void ListarPlanes()
        {
            foreach(var plan in planes)
            {
                Console.WriteLine($"     Plan Id:{plan.id} - Nombre:{plan.nombre}");
            }
        }

    }

    class Plan
    {
        public Plan() { }
        public Plan(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public int id { get; set; }
        public string nombre { get; set; }
    }

    class TipoDocumento
        {
            int id;
            string abreviatura;
            string nombre;
        }

    class Domicilio
        {
            string calle;
            int altura;
            string barrio;
            string departamento;
            int piso;
            string codigoPostal;
            Localidad localidad;
            Provincia provincia;
            Pais pais;
        }

    class Localidad
        {
            int id;
            string nombre;
            Provincia provincia;
        }

    class Provincia
        {
            int id;
            string nombre;
            Pais pais;
        }

    class Pais
        {
            int id;
            string nombre;
        }

    class Contacto
        {
            public string celular { get; set; }
            public string telefono { get; set; }
            public string email { get; set; }
        }

    class Sexo
        {
          int id;
          string nombre;
        }

    class Servicios
    {
        int id;
        string nombre;
        List<Profesional> profesionales;
    }

    class EstadoTurno
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

}