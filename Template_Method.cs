/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 20/09/2019
 * Hora: 10:54 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TrabajoIntegrador
{
	public interface IInfartable {
		bool estasConciente();
		bool estasRespirando();
		bool tenesRitmoCardiaco();
	}
	
	public class Transeunte : IInfartable {
		static Random random = new Random();
		private double probConciente, probRespirando, probRitmoCardiaco;
		public Transeunte(double pc, double pr, double prc)
		{
			probConciente = pc; 
			probRespirando = pr;
			probRitmoCardiaco = prc;
		}
		public bool estasConciente() {
			return random.NextDouble() < (probConciente/100);
		}
		public bool estasRespirando() {
			return random.NextDouble() < (probRespirando/100);
		}
		public bool tenesRitmoCardiaco() {
			return random.NextDouble() < (probRitmoCardiaco/100);
		}
	}
	
	abstract public class ProtocoloRCP
	{	
		public void ejecutarProtocoloRCP(IInfartable transeunte){
			int intentos = 0;
			this.eliminarObstruccion();
			if(transeunte.estasConciente()) {
				Console.WriteLine("El transeunte está conciente, termina.");
			}
			else {
				this.llamarAmbulancia();
				this.descubrirElTorax();
				this.acomodarLaCabeza();
				do {
					this.hacerCompresionesToracicas();
					this.hacerInsuflaciones();
					if(!transeunte.tenesRitmoCardiaco()) {
						this.usarDesfibrilador();
					}
					intentos++;
				}
				while(!transeunte.estasRespirando() || ( this.evaluar() && intentos<5 ));
				if(!this.evaluar() && intentos>=5) {
					Console.WriteLine("Pasaron "+intentos+" intentos. El médico desiste de la reanimación.");
				}
				else {
					Console.WriteLine("La víctima respira, termina.");
				}
			}
		}
		abstract protected void eliminarObstruccion();
		abstract protected void llamarAmbulancia();
		abstract protected void descubrirElTorax();
		abstract protected void acomodarLaCabeza();
		abstract protected void hacerCompresionesToracicas();
		abstract protected void hacerInsuflaciones();
		abstract protected void usarDesfibrilador();
		abstract protected bool evaluar();
	}
	
	public class FormaA : ProtocoloRCP {
		override protected void eliminarObstruccion(){ Console.WriteLine("Eliminando obstrucción con la forma A"); }
		override protected void llamarAmbulancia(){ Console.WriteLine("Llamando ambulancia con la forma A"); }
		override protected void descubrirElTorax(){ Console.WriteLine("Descubriendo el tórax con la forma A"); }
		override protected void acomodarLaCabeza(){ Console.WriteLine("Acomodando su cabeza con la forma A"); }
		override protected void hacerCompresionesToracicas(){ Console.WriteLine("Haciendo compresiones toracicas con la forma A"); }
		override protected void hacerInsuflaciones(){ Console.WriteLine("Haciendo insuflaciones con la forma A"); }
		override protected void usarDesfibrilador(){ Console.WriteLine("Usando desfibrilador con la forma A"); }
		override protected bool evaluar(){ return true; }
	}
	public class FormaB : ProtocoloRCP {
		override protected void eliminarObstruccion(){ Console.WriteLine("Eliminando obstrucción con la forma B"); }
		override protected void llamarAmbulancia(){ Console.WriteLine("Llamando ambulancia con la forma B"); }
		override protected void descubrirElTorax(){ Console.WriteLine("Descubriendo el tórax con la forma B"); }
		override protected void acomodarLaCabeza(){ Console.WriteLine("Acomodando su cabeza con la forma B"); }
		override protected void hacerCompresionesToracicas(){ Console.WriteLine("Haciendo compresiones toracicas con la forma B"); }
		override protected void hacerInsuflaciones(){ Console.WriteLine("Haciendo insuflaciones con la forma B"); }
		override protected void usarDesfibrilador(){ Console.WriteLine("Usando desfibrilador con la forma B"); }
		override protected bool evaluar(){ return false; }
	}
}
