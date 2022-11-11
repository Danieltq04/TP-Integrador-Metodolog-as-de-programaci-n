/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 20/09/2019
 * Hora: 10:55 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TrabajoIntegrador    	
{
	public class InfartableAdapter : IInfartable {
    	IPasserby passerby;

    	public InfartableAdapter(IPasserby p){
			passerby = p;
    	}
    	public bool estasConciente() {
    		return passerby.isConscious();
    	}
    	public bool estasRespirando() {
    		return passerby.isBreathing();
    	}
    	public bool tenesRitmoCardiaco() {
    		return passerby.haveHeartRate();
    	}
	}

	public interface IPasserby {
		bool isConscious();
		bool isBreathing();
		bool haveHeartRate();
	}
	
	public class Passerby : IPasserby
	{
		static Random random = new Random();
		
		private double probConscius, probBrathing, probHeartRate;
		
		public Passerby(double pc, double pb, double phr)
		{
			probConscius = pc; 
			probBrathing = pb;
			probHeartRate = phr;
		}
		public bool isConscious(){
			return random.NextDouble() < (probConscius/100);
		}
		
		public bool isBreathing(){
			return random.NextDouble() < (probBrathing/100);
		}
		
		public bool haveHeartRate(){
			return random.NextDouble() < (probHeartRate/100);
		}
	}
	
}
