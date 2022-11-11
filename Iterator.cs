/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 10/10/2019
 * Hora: 11:17 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace TrabajoIntegrador
{
	public interface IResponsable {
		
	}
	
	public interface IDenuncia {
		void atender(IResponsable unResponsable);
	}
	public class DenunciaDeIncendio : IDenuncia {
		ILugar lugar;
		public DenunciaDeIncendio(ILugar lugar) {
			this.lugar = lugar;
		}
		public void atender(IResponsable unResponsable) {
			((Manejador)unResponsable).apagarIncendio(lugar);
		}
		public ILugar obtenerILugar() {
			return lugar;
		}
	}
	
	public interface IDenuncias {
		Iterador crearIterador();
		void agregarDenuncia(IDenuncia denuncia);
	}
	
	public class DenunciasPorTablero : IDenuncias, IObservador {
		List<IDenuncia> denuncias;
		
		public DenunciasPorTablero(){
			denuncias = new List<IDenuncia>();
		}
		public void actualizar(ILugar lugar) {
			denuncias.Add(new DenunciaDeIncendio(lugar));
		}
		public void agregarDenuncia(IDenuncia denuncia) {
			actualizar(((DenunciaDeIncendio)denuncia).obtenerILugar());
			//actualizar(denuncia.obtenerILugar());
		}
		public Iterador crearIterador() {
			return new IteradorDeListas(denuncias);
		}
	}
	
	
	//********************************************************************************
	public class DenunciasPorWhatsapp : IDenuncias {
		MensajeWhatsapp siguiente;
		
		public DenunciasPorWhatsapp(){
			siguiente = null;
		}
		public void agregarDenuncia(IDenuncia denuncia){
			siguiente = new MensajeWhatsapp(denuncia, siguiente);
		}
		public Iterador crearIterador(){
			return new IteradorDeListasEnlazadas(siguiente);
		}	
	}
	public class MensajeWhatsapp {
		IDenuncia denuncia;
		MensajeWhatsapp siguiente;
		
		public MensajeWhatsapp(IDenuncia denuncia, MensajeWhatsapp siguiente) {
			this.denuncia = denuncia;
			this.siguiente = siguiente;
		}
		public IDenuncia getDenuncia(){
			return denuncia;
		}
		public MensajeWhatsapp getSiguiente(){
			return siguiente;
		}
	}
	
	//********************************************************************************
	public class DenunciasPorMostrador : IDenuncias {
		IDenuncia denuncia;
		public void agregarDenuncia(IDenuncia denuncia){
			this.denuncia = denuncia;
		}
		public Iterador crearIterador() {
			List<IDenuncia> denuncias = new List<IDenuncia>();
			denuncias.Add(denuncia);
			return new IteradorDeListas(denuncias);
		}
	}
		
	public interface Iterador
	{
		IDenuncia actual();
		void siguiente();
		bool fin();
	}
	public class IteradorDeListas : Iterador {
		List<IDenuncia> denuncias;
		int indice;
		
		public IteradorDeListas(List<IDenuncia> denuncias){
			Console.WriteLine("Denuncias recibidas: "+denuncias.Count);
			Console.ReadKey(true);
			this.denuncias = denuncias;
			indice = 0;
		}
		public IDenuncia actual(){
			return denuncias[indice];
		}
			
		public void siguiente(){
			indice++;
		}
		public bool fin(){
			return indice >= denuncias.Count;
		}
	}
	
	public class IteradorDeListasEnlazadas : Iterador {
		MensajeWhatsapp mensaje;
		
		public IteradorDeListasEnlazadas(MensajeWhatsapp mensaje){
			this.mensaje = mensaje;
		}
		public IDenuncia actual(){
			return mensaje.getDenuncia();
		}
		public void siguiente(){
			mensaje = mensaje.getSiguiente();
		}
		public bool fin(){
			return mensaje == null;
		}
	}
	
	public class BomberoSecretario {
		Bombero bombero;
		public BomberoSecretario(Bombero bombero) {
			this.bombero = bombero;
		}
		public void atenderDenuncias(IDenuncias denuncias) {
			Iterador iterador = denuncias.crearIterador();
			int i = 0;
			while(!iterador.fin()){
				iterador.actual().atender(bombero);
				iterador.siguiente();
				i++;
				Console.WriteLine("Iteracion numero "+i);
				Console.ReadKey(true);
			}
		}

	}
}
