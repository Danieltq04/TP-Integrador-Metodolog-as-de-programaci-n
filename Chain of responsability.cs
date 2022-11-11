/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 11/10/2019
 * Hora: 11:34 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TrabajoIntegrador
{
	public abstract class Manejador : IResponsable
	{
		Manejador sucesor = null;
		public Manejador(Manejador s) {
			sucesor = s;
		}
		public Manejador() {
		}
		virtual public void apagarIncendio(ILugar lugar) {
			if(sucesor != null) {
				Console.WriteLine("Se la pasa a el que sigue. ->");
				sucesor.apagarIncendio(lugar);
			}
		}
		virtual public void AtenderInfarto(IInfartable transeunte ) {
			if(sucesor != null) {
				Console.WriteLine("Se la pasa a el que sigue. ->");
				sucesor.AtenderInfarto(transeunte);
			}
		}
		virtual public void patrullarCalles(IPatrullable patrullable) {
			if(sucesor != null) {
				Console.WriteLine("Se la pasa a el que sigue. ->");
				sucesor.patrullarCalles(patrullable);
			}
		}
		virtual public void revisar(Iluminable iluminable) {
			if(sucesor != null) {
				Console.WriteLine("Se la pasa a el que sigue. ->");
				sucesor.revisar(iluminable);
			}
		}
	}
	
	public class DenunciaDeInfarto : IDenuncia {
		IInfartable infartable;
		public DenunciaDeInfarto(IInfartable infartable) {
			this.infartable = infartable;
		}
		public void atender(IResponsable unResponsable) {
			((Manejador)unResponsable).AtenderInfarto(infartable);
		}
		public void setInfartable(IInfartable infartable) {
			this.infartable = infartable;
		}
		public IInfartable getInfartable() {
			return infartable;
		}
	}
	public class DenunciaDeRobo : IDenuncia {
		IPatrullable patrullable;
		public DenunciaDeRobo(IPatrullable patrullable) {
			this.patrullable = patrullable;
		}
		public void atender(IResponsable unResponsable) {
			((Manejador)unResponsable).patrullarCalles(patrullable);
		}
		public void setPatrullable(IPatrullable patrullable) {
			this.patrullable = patrullable;
		}
		public IPatrullable getPatrulable() {
			return patrullable;
		}
	}
	public class DenunciaDeLamparaQuemada : IDenuncia {
		Iluminable iluminable;
		public DenunciaDeLamparaQuemada(Iluminable iluminable) {
			this.iluminable = iluminable;
		}
		public void atender(IResponsable unResponsable) {
			((Manejador)unResponsable).revisar(iluminable);
		}
		public void setIluminable(Iluminable iluminable) {
			this.iluminable = iluminable;
		}
		public Iluminable getPatrulable() {
			return iluminable;
		}
	}
	public class Operador911 {
		Manejador manejador;
		
		public Operador911(Manejador manejador) {
			this.manejador = manejador;
		}
		public void setManejador(Manejador manejador) {
			this.manejador = manejador;
		}
		public void atenderDenuncias(IDenuncias denuncias) {
			Iterador iterador = denuncias.crearIterador();
			
			int i = 1;
			while(!iterador.fin()){
				iterador.actual().atender(manejador);
				iterador.siguiente();
				
				Console.WriteLine("Fin de la Iteracion numero "+i+" de la lista de denuncias.");
				i++;
				Console.ReadKey(true);
				Console.Clear();
			}
		}
	}
}

