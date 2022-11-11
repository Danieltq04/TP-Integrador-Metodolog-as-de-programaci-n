/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 20/09/2019
 * Hora: 11:01 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace TrabajoIntegrador
{
	public class Bombero : Manejador, IObservador, IResponsable {
		IHerramienta herramienta;
		IVehiculo vehiculo;
		FormaDeApagado formaApagado;
		
		public void actualizar(ILugar lugar){
			apagarIncendio(lugar);
		}
		
		public Bombero() {
			formaApagado = new Secuencial();
			
			herramienta = new Manguera();
			vehiculo = new Autobomba();
		}
		public Bombero(Manejador m) : base (m) {
			formaApagado = new Secuencial();
			
			herramienta = new Manguera();
			vehiculo = new Autobomba();
		}
		
		public IHerramienta getHerramienta() {
			return herramienta;
		}
		public void setHerramienta(IHerramienta herramienta) {
			this.herramienta = herramienta;
		}
		public IVehiculo getVehiculo() {
			return vehiculo;
		}
		public void setVehiculo(IVehiculo vehiculo) {
			this.vehiculo = vehiculo;
		}
		
		public void bajarGatitoDeArbol() {
			Console.WriteLine("Bajando gato.");
		}
		
		public void cambiarForma(FormaDeApagado forma_apagado) {
			formaApagado = forma_apagado;
		}
		override public void apagarIncendio(ILugar lugar) {
			vehiculo.encenderSirena();
			vehiculo.conducir();
			if(vehiculo.estaRoto()) {
				Console.WriteLine("El bombero no puede realizar su tarea porque su vehiculo se rompió");
			}
			else {
				herramienta.usar();
				formaApagado.apagar(lugar, lugar.getCalle());
				herramienta.guardar();
			}
		}
	}
	
	public class Medico : Manejador, IResponsable {
		ProtocoloRCP protocolo;
		IHerramienta herramienta;
		IVehiculo vehiculo;
		
		public Medico()  {
			protocolo = new FormaA();
			
			herramienta = new Desfibrilador();
			vehiculo = new Ambulancia();
		}
		public Medico(Manejador m) : base (m)  {
			protocolo = new FormaA();
			
			herramienta = new Desfibrilador();
			vehiculo = new Ambulancia();
		}
		
		public IHerramienta getHerramienta() {
			return herramienta;
		}
		public void setHerramienta(IHerramienta herramienta) {
			this.herramienta = herramienta;
		}
		public IVehiculo getVehiculo() {
			return vehiculo;
		}
		public void setVehiculo(IVehiculo vehiculo) {
			this.vehiculo = vehiculo;
		}
		
		public void setProtocolo(ProtocoloRCP p) {
			protocolo = p;
		}
		override public void AtenderInfarto(IInfartable transeunte ) {
			vehiculo.encenderSirena();
			vehiculo.conducir();
			if(vehiculo.estaRoto()) {
				Console.WriteLine("El Médico no puede realizar su tarea porque su vehiculo se rompió");
			}
			else {
				herramienta.usar();
				protocolo.ejecutarProtocoloRCP(transeunte);
				herramienta.guardar();
			}
		}
		public void atenderDesmayo() {
			Console.WriteLine("Termina de atender");
		}
	}
	
	public class Policia : Manejador, IResponsable {
		IOrden ordenPop;
		IHerramienta herramienta;
		IVehiculo vehiculo;
		
		public Policia() {
			ordenPop = new DarVozDeAlto();
			
			herramienta = new Pistola();
			vehiculo = new Patrullero();
		}
		public Policia(Manejador m) : base (m) {
			ordenPop = new PedirRefuerzos();
			
			herramienta = new Pistola();
			vehiculo = new Patrullero();
		}
		
		public IHerramienta getHerramienta() {
			return herramienta;
		}
		public void setHerramienta(IHerramienta herramienta) {
			this.herramienta = herramienta;
		}
		public IVehiculo getVehiculo() {
			return vehiculo;
		}
		public void setVehiculo(IVehiculo vehiculo) {
			this.vehiculo = vehiculo;
		}
		override public void patrullarCalles(IPatrullable patrullable) {
			vehiculo.encenderSirena();
			vehiculo.conducir();
			if(vehiculo.estaRoto()) {
				Console.WriteLine("El Policia no puede realizar su tarea porque su vehiculo se rompió");
			}
			else {
				herramienta.usar();
				ordenPop.ejecutar();
				herramienta.guardar();
			}
		}
		public void setOrdenPop(IOrden oPop) {
			ordenPop = oPop;
		}
		public void detenerDelincuente() {
			Console.WriteLine("Deteniendo delincuente.");
		}
	}
	
	
	public class Electricista : Manejador, IResponsable {
		IHerramienta herramienta;
		IVehiculo vehiculo;
		
		public Electricista() {
			herramienta = new Buscapolo();
			vehiculo = new Camioneta();
		}
		public Electricista(Manejador m) : base (m) {
			herramienta = new Buscapolo();
			vehiculo = new Camioneta();
		}
		
		public IHerramienta getHerramienta() {
			return herramienta;
		}
		public void setHerramienta(IHerramienta herramienta) {
			this.herramienta = herramienta;
		}
		public IVehiculo getVehiculo() {
			return vehiculo;
		}
		public void setVehiculo(IVehiculo vehiculo) {
			this.vehiculo = vehiculo;
		}
		override public void revisar(Iluminable iluminable) {
			vehiculo.encenderSirena();
			vehiculo.conducir();
			if(vehiculo.estaRoto()) {
				Console.WriteLine("El Electricista no puede realizar su tarea porque su vehiculo se rompió");
			}
			else {
				herramienta.usar();
				Console.WriteLine("Revisando....");
				cambiarLamparasQuemadas(iluminable);
				herramienta.guardar();
			}
		}
		public void cambiarLamparasQuemadas(Iluminable iluminable) {
			//iluminable.revisarYCambiarLamparasQuemadas()
			iluminable.revisarYCambiarLamparasQuemadas();
		}
	}
	
	public class Mecanico {
		public void arreglarMotor() {
			Console.WriteLine("Arreglando motor.");
		}
		public void remolcarAuto() {
			Console.WriteLine("Remolcando auto.");
		}
	}
}
