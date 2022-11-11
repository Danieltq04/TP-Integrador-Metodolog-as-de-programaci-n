/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 17/10/2019
 * Hora: 08:48 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TrabajoIntegrador
{
	abstract public class EstadoDelVehiculo
	{
		protected IVehiculo vehiculo;
		
		public EstadoDelVehiculo(IVehiculo vehiculo){
			this.vehiculo = vehiculo;
		}
		virtual public void acelerar(){
			Console.WriteLine("Sin efecto");
		}
		virtual public void desacelerar(){
			Console.WriteLine("Sin efecto");
		}
		virtual public void frenar(){
			Console.WriteLine("Sin efecto");
		}
		virtual public void encender(){
			Console.WriteLine("Sin efecto");
		}
		virtual public void apagar(){
			Console.WriteLine("Sin efecto");
		}
		virtual public void arreglar(){
			Console.WriteLine("Sin efecto");
		}
		abstract public bool seRompio();
	}
	
	public class Apagado : EstadoDelVehiculo {
		public Apagado(IVehiculo v) : base (v){ }
		
		override public void encender(){
			Console.WriteLine("Encendiendo motor");
			vehiculo.setEstado(new PuntoMuerto(vehiculo));
		}
		override public bool seRompio() {
			return false;
		}
	}
	
	public class PuntoMuerto : EstadoDelVehiculo {
		public PuntoMuerto(IVehiculo v) : base (v){ }
		
		override public void acelerar(){
			Console.WriteLine("acelerando a marcha lenta");
			vehiculo.setEstado(new MarchaLenta(vehiculo));
		}
		override public void apagar(){
			Console.WriteLine("apagando el vehiculo");
			vehiculo.setEstado(new Apagado(vehiculo));
		}
		override public bool seRompio() {
			return false;
		}
	}
	
	public class MarchaLenta : EstadoDelVehiculo {
		public MarchaLenta(IVehiculo v) : base (v){ }
		
		override public void acelerar(){
			Console.WriteLine("acelerando a media marcha");
			vehiculo.setEstado(new MediaMarcha(vehiculo));
		}
		override public void desacelerar(){
			Console.WriteLine("desacelerando a punto muerto");
			vehiculo.setEstado(new PuntoMuerto(vehiculo));
		}
		override public void frenar(){
			Console.WriteLine("frenando");
			vehiculo.setEstado(new PuntoMuerto(vehiculo));
		}
		override public void apagar(){
			Console.WriteLine("rompiendo el motor");
			vehiculo.setEstado(new Roto(vehiculo));
		}
		override public bool seRompio() {
			return false;
		}
	}
	
	public class MediaMarcha : EstadoDelVehiculo {
		public MediaMarcha(IVehiculo v) : base (v){ }
		
		override public void acelerar(){
			Console.WriteLine("acelerando a toda marcha");
			vehiculo.setEstado(new ATodaVelocidad(vehiculo));
		}
		override public void desacelerar(){
			Console.WriteLine("desacelerando a marcha lenta");
			vehiculo.setEstado(new MarchaLenta(vehiculo));
		}
		override public void frenar(){
			Console.WriteLine("frenando");
			vehiculo.setEstado(new PuntoMuerto(vehiculo));
		}
		override public void apagar(){
			Console.WriteLine("rompiendo el motor");
			vehiculo.setEstado(new Roto(vehiculo));
		}
		override public bool seRompio() {
			return false;
		}
	}
	
	public class ATodaVelocidad : EstadoDelVehiculo {
		public ATodaVelocidad(IVehiculo v) : base (v){ }
		
		override public void acelerar(){
			Console.WriteLine("rompiendo el motor");
			vehiculo.setEstado(new Roto(vehiculo));
		}
		override public void desacelerar(){
			Console.WriteLine("desacelerando a media marcha");
			vehiculo.setEstado(new MediaMarcha(vehiculo));
		}
		override public void frenar(){
			Console.WriteLine("frenando");
			vehiculo.setEstado(new PuntoMuerto(vehiculo));
		}
		override public void apagar(){
			Console.WriteLine("rompiendo el motor");
			vehiculo.setEstado(new Roto(vehiculo));
		}
		override public bool seRompio() {
			return false;
		}
	}
	
	public class Roto : EstadoDelVehiculo{
		public Roto(IVehiculo v) : base (v){ }
		
		override public void arreglar(){
			Console.WriteLine("arreglando");
			vehiculo.setEstado(new Apagado(vehiculo));
		}
		override public bool seRompio() {
			return true;
		}
	}
}
