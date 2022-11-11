/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 12/10/2019
 * Hora: 04:37 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace TrabajoIntegrador
{
	public interface IVehiculo {
		void encenderSirena();
		void conducir();
		
		void setEstado(EstadoDelVehiculo e);
		bool estaRoto();
	}
	//************************************ VEHICULOS ***************
	public class Autobomba : IVehiculo {
		EstadoDelVehiculo estado;
		bool roto;
		public Autobomba() {
			this.estado = new Apagado(this);
			roto = false;
		}
		public void encenderSirena() {
			Console.WriteLine("Sirena de autobomba");
		}
		public void conducir() {
			estado.encender();
			Console.WriteLine("Conducir autobomba");
			Random random = new Random();
			int valor = random.Next(5);
			Console.WriteLine("Va a acelerar "+valor+" veces");
			for(int i=0;i<valor;i++) {
				estado.acelerar();
			}
			if(estado.seRompio()) {
				roto = true;
			}
			estado.frenar();
			estado.apagar();
		}
		public void setEstado(EstadoDelVehiculo e){
			estado = e;
		}
		public bool estaRoto() {
			return roto;
		}
	}
	
	
	public class Ambulancia : IVehiculo {
		private EstadoDelVehiculo estado;
		bool roto;
		public Ambulancia()
		{
			estado = new Apagado(this);
		}
		public void setEstado(EstadoDelVehiculo e){
			estado = e;
		}
		public void encenderSirena() {
			Console.WriteLine("Sirena de Ambulancia");
		}
		public void conducir() {
			estado.encender();
			Console.WriteLine("Conducir Ambulancia");
			Random random = new Random();
			int valor = random.Next(5);
			Console.WriteLine("Va a acelerar "+valor+" veces");
			for(int i=0;i<valor;i++) {
				estado.acelerar();
			}
			if(estado.seRompio()) {
				roto = true;
			}
			estado.frenar();
			estado.apagar();
		}
		public bool estaRoto() {
			return roto;
		}
	}
	public class Patrullero : IVehiculo {
		private EstadoDelVehiculo estado;
		bool roto;
		public Patrullero()
		{
			estado = new Apagado(this);
		}
		
		public void setEstado(EstadoDelVehiculo e){
			estado = e;
		}
		public void encenderSirena() {
			Console.WriteLine("Sirena de Patrullero");
		}
		public void conducir() {
			estado.encender();
			Console.WriteLine("Conducir Patrullero");
			Random random = new Random();
			int valor = random.Next(5);
			Console.WriteLine("Va a acelerar "+valor+" veces");
			for(int i=0;i<valor;i++) {
				estado.acelerar();
			}
			if(estado.seRompio()) {
				roto = true;
			}
			estado.frenar();
			estado.apagar();
		}
		public bool estaRoto() {
			return roto;
		}
	}
	
	public class Camioneta : IVehiculo {
		//Del singleton
		private EstadoDelVehiculo estado;
		bool roto;
		public Camioneta()
		{
			estado = new Apagado(this);
		}
		
		public void setEstado(EstadoDelVehiculo e){
			estado = e;
		}
		public void encenderSirena() {
			Console.WriteLine("Sirena de Camioneta");
		}
		public void conducir() {
			estado.encender();
			Console.WriteLine("Conducir Camioneta");
			Random random = new Random();
			int valor = random.Next(5);
			Console.WriteLine("Va a acelerar "+valor+" veces");
			for(int i=0;i<valor;i++) {
				estado.acelerar();
			}
			if(estado.seRompio()) {
				roto = true;
			}
			estado.frenar();
			estado.apagar();
		}
		public bool estaRoto() {
			return roto;
		}
	}
	
	//************************************ HERRAMIENTAS ***************
	public interface IHerramienta {
		void usar();
		void guardar();
	}
	public class Manguera : IHerramienta {
		public void usar() {
			Console.WriteLine("Usando manguera");
		}
		public void guardar() {
			Console.WriteLine("Guardando manguera");
		}
	}
	public class Desfibrilador : IHerramienta {
		public void usar() {
			Console.WriteLine("Usando Desfibrilador");
		}
		public void guardar() {
			Console.WriteLine("Guardando Desfibrilador");
		}
	}
	public class Pistola : IHerramienta {
		public void usar() {
			Console.WriteLine("Usando Pistola");
		}
		public void guardar() {
			Console.WriteLine("Guardando Pistola");
		}
	}
	public class Buscapolo : IHerramienta {
		public void usar() {
			Console.WriteLine("Usando Buscapolo");
		}
		public void guardar() {
			Console.WriteLine("Guardando Buscapolo");
		}
	}
	
	//******************************************* CUARTELES ************
	public interface ICuartel {
		void agregarVehiculo(IVehiculo vehiculo);
		void agregarPersonal(IResponsable responsable);
		void agregarHerramienta(IHerramienta herramienta);
		IResponsable getPersonal();
	}
	
	public class CuartelDeBomberos : ICuartel {
		List<IVehiculo> vehiculos;
		List<IResponsable> responsables;
		List<IHerramienta> herramientas;		
		
		private static CuartelDeBomberos unicoCuartel = null;
	
		private CuartelDeBomberos(){
			vehiculos = new List<IVehiculo>();
			herramientas = new List<IHerramienta>();
			responsables = new List<IResponsable>();
		}
		public static ICuartel getInstance(){
			if(unicoCuartel == null)
				unicoCuartel = new CuartelDeBomberos();
			return unicoCuartel;
		}
		public void agregarVehiculo(IVehiculo vehiculo) {
			vehiculos.Add(vehiculo);
		}
		public void agregarPersonal(IResponsable responsable) {
			responsables.Add(responsable);
		}
		public void agregarHerramienta(IHerramienta herramienta) {
			herramientas.Add(herramienta);
		}
		public IResponsable getPersonal() {
			if(responsables[0]!= null) {
				((Bombero)responsables[0]).setHerramienta(herramientas[0]);
				((Bombero)responsables[0]).setVehiculo(vehiculos[0]);
				IResponsable copia = responsables[0];
				responsables.RemoveAt(0);
				return copia;
				//return responsables[0];
			}
			else {
				Console.WriteLine("No hay IResponsable");
				return null;
			}
		}
	}
	
	public class Hospital : ICuartel {
		List<IVehiculo> vehiculos;
		List<IResponsable> responsables;
		List<IHerramienta> herramientas;
		
		private static Hospital unicoHospital = null;
	
		private Hospital(){
			vehiculos = new List<IVehiculo>();
			herramientas = new List<IHerramienta>();
			responsables = new List<IResponsable>();
		}
		public static ICuartel getInstance(){
			if(unicoHospital == null)
				unicoHospital = new Hospital();
			return unicoHospital;
		}
		public void agregarVehiculo(IVehiculo vehiculo) {
			vehiculos.Add(vehiculo);
		}
		public void agregarPersonal(IResponsable responsable) {
			responsables.Add(responsable);
		}
		public void agregarHerramienta(IHerramienta herramienta) {
			herramientas.Add(herramienta);
		}
		public IResponsable getPersonal() {
			if(responsables[0]!= null) {
				((Medico)responsables[0]).setHerramienta(herramientas[0]);
				((Medico)responsables[0]).setVehiculo(vehiculos[0]);
				
				IResponsable copia = responsables[0];
				responsables.RemoveAt(0);
				return copia;
			}
			else {
				Console.WriteLine("No hay IResponsable");
				return null;
			}
		}
	}
	public class Comisaria : ICuartel {
		List<IVehiculo> vehiculos;
		List<IResponsable> responsables;
		List<IHerramienta> herramientas;
		
		private static Comisaria unicaComisaria = null;
		private Comisaria(){
			vehiculos = new List<IVehiculo>();
			herramientas = new List<IHerramienta>();
			responsables = new List<IResponsable>();
		}
		public static ICuartel getInstance(){
			if(unicaComisaria == null)
				unicaComisaria = new Comisaria();
			return unicaComisaria;
		}
		public void agregarVehiculo(IVehiculo vehiculo) {
			vehiculos.Add(vehiculo);
		}
		public void agregarPersonal(IResponsable responsable) {
			responsables.Add(responsable);
		}
		public void agregarHerramienta(IHerramienta herramienta) {
			herramientas.Add(herramienta);
		}
		public IResponsable getPersonal() {
			if(responsables[0]!= null) {
				((Policia)responsables[0]).setHerramienta(herramientas[0]);
				((Policia)responsables[0]).setVehiculo(vehiculos[0]);
				IResponsable copia = responsables[0];
				responsables.RemoveAt(0);
				return copia;
				//return responsables[0];
			}
			else {
				Console.WriteLine("No hay IResponsable");
				return null;
			}
		}
	}
	public class CentralElectrica : ICuartel {
		List<IVehiculo> vehiculos;
		List<IResponsable> responsables;
		List<IHerramienta> herramientas;
		
		private static CentralElectrica unicaCentralElectrica = null;
		private CentralElectrica(){
			vehiculos = new List<IVehiculo>();
			herramientas = new List<IHerramienta>();
			responsables = new List<IResponsable>();
		}
		public static ICuartel getInstance(){
			if(unicaCentralElectrica == null)
				unicaCentralElectrica = new CentralElectrica();
			return unicaCentralElectrica;
		}
		public void agregarVehiculo(IVehiculo vehiculo) {
			vehiculos.Add(vehiculo);
		}
		public void agregarPersonal(IResponsable responsable) {
			responsables.Add(responsable);
		}
		public void agregarHerramienta(IHerramienta herramienta) {
			herramientas.Add(herramienta);
		}
		public IResponsable getPersonal() {
			if(responsables[0]!= null) {
				((Electricista)responsables[0]).setHerramienta(herramientas[0]);
				((Electricista)responsables[0]).setVehiculo(vehiculos[0]);
				
				IResponsable copia = responsables[0];
				responsables.RemoveAt(0);
				return copia;
			}
			else {
				Console.WriteLine("No hay IResponsable");
				return null;
			}
		}
	}
	//******************************** FÁBRICA DE HÉROES ******
	public interface IFabricaDeHeroes {
		IResponsable crearHeroe();
		IVehiculo crearVehiculo();
		IHerramienta crearHerramienta();
		ICuartel crearCuartel();
	}
	public class FabricaDeBomberos : IFabricaDeHeroes {
		public IResponsable crearHeroe() {
			return new Bombero();
		}
		public IVehiculo crearVehiculo() {
			return new Autobomba();
		}
		public IHerramienta crearHerramienta() {
			return new Manguera();
		}
		public ICuartel crearCuartel() {
			return CuartelDeBomberos.getInstance();
		}
	}
	public class FabricaDeMedicos : IFabricaDeHeroes {
		public IResponsable crearHeroe() {
			return new Medico();
		}
		public IVehiculo crearVehiculo() {
			return new Ambulancia();
		}
		public IHerramienta crearHerramienta() {
			return new Desfibrilador();
		}
		public ICuartel crearCuartel() {
			return Hospital.getInstance();
		}
	}
	public class FabricaDePolicias : IFabricaDeHeroes {
		public IResponsable crearHeroe() {
			return new Policia();
		}
		public IVehiculo crearVehiculo() {
			return new Patrullero();
		}
		public IHerramienta crearHerramienta() {
			return new Pistola();
		}
		public ICuartel crearCuartel() {
			return Comisaria.getInstance();
		}
	}
	public class FabricaDeElectricistas : IFabricaDeHeroes {
		public IResponsable crearHeroe() {
			return new Electricista();
		}
		public IVehiculo crearVehiculo() {
			return new Camioneta();
		}
		public IHerramienta crearHerramienta() {
			return new Buscapolo();
		}
		public ICuartel crearCuartel() {
			return CentralElectrica.getInstance();
		}
	}
	
}
