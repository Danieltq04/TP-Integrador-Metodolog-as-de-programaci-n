/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 17/10/2019
 * Hora: 06:46 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TrabajoIntegrador
{
	public class BomberoProxy : Manejador, IResponsable
	{
		private IResponsable bomberoReal = null;
		IFabricaDeHeroes fabrica = new FabricaDeBomberos();
		public BomberoProxy() {
		}
		public BomberoProxy(Manejador m) : base (m) {
		}
		override public void apagarIncendio(ILugar lugar) {
			if(bomberoReal == null){
				Console.WriteLine("Pide apagar incendio, se crea un Bombero real.");
				Console.ReadKey(true);
				bomberoReal = fabrica.crearHeroe();
				((Bombero)bomberoReal).setHerramienta(fabrica.crearHerramienta());
				((Bombero)bomberoReal).setVehiculo(fabrica.crearVehiculo());
				
				FormaDeApagado estrategia;
				Console.WriteLine("Ingrese la estrategia del Bombero: ");
				Console.WriteLine("1- Secuencial: ");
				Console.WriteLine("2- Escalera: ");
				Console.WriteLine("3- Espiral: ");
				//int opcion = int.Parse(Console.ReadLine());
				switch (int.Parse(Console.ReadLine())){
					case 2: estrategia = new Escalera(); break;
					case 3: estrategia = new Espiral(); break;
					default: estrategia = new Secuencial(); break;
				}
				((Bombero)bomberoReal).cambiarForma(estrategia);
			}
			((Bombero)bomberoReal).apagarIncendio(lugar);
		}
	}
	
	public class MedicoProxy : Manejador
	{
		private IResponsable medicoReal = null;
		IFabricaDeHeroes fabrica = new FabricaDeMedicos();
		public MedicoProxy() {
		}
		public MedicoProxy(Manejador m) : base (m) {
		}
		override public void AtenderInfarto(IInfartable transeunte ) {
			if(medicoReal == null){
				Console.WriteLine("Pide atender infarto, se crea un Médico real.");
				Console.ReadKey(true);
				medicoReal = fabrica.crearHeroe();
				((Medico)medicoReal).setHerramienta(fabrica.crearHerramienta());
				((Medico)medicoReal).setVehiculo(fabrica.crearVehiculo());
			}
			((Medico)medicoReal).AtenderInfarto(transeunte);
		}
	}
	
	public class PoliciaProxy : Manejador
	{
		private IResponsable policiaReal = null;
		IFabricaDeHeroes fabrica = new FabricaDePolicias();
		public PoliciaProxy() { }
		public PoliciaProxy(Manejador m) : base (m) { }
		
		override public void patrullarCalles(IPatrullable patrullable) {
			if(policiaReal == null){
				Console.WriteLine("Pide patrullar calles, se crea un Policia real.");
				Console.ReadKey(true);
				policiaReal = fabrica.crearHeroe();
				((Policia)policiaReal).setHerramienta(fabrica.crearHerramienta());
				((Policia)policiaReal).setVehiculo(fabrica.crearVehiculo());
			}
			((Policia)policiaReal).patrullarCalles(patrullable);
		}
	}
	public class ElectricistaProxy : Manejador
	{
		private IResponsable electricistaReal = null;
		IFabricaDeHeroes fabrica = new FabricaDeElectricistas();
		public ElectricistaProxy() { }
		public ElectricistaProxy(Manejador m) : base (m) { }
		
		override public void revisar(Iluminable iluminable) {
			if(electricistaReal == null){
				Console.WriteLine("Pide revisar, se crea un Electricista real.");
				Console.ReadKey(true);
				electricistaReal = fabrica.crearHeroe();
				((Electricista)electricistaReal).setHerramienta(fabrica.crearHerramienta());
				((Electricista)electricistaReal).setVehiculo(fabrica.crearVehiculo());
			}
			((Electricista)electricistaReal).revisar(iluminable);
		}
	}
}
