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
	
	public interface IPatrullable {
		bool hayAlgoFueraDeLoNormal();
		void setNumero(int n);
		int getNumero();
	}
	
	public interface IOrden {
		void ejecutar();
	}
	
	public class DarVozDeAlto : IOrden {
		public void ejecutar(){
			Console.WriteLine("Deteniendo delincuente");
		}
	}
	public class PerseguirDelincuente : IOrden {
		public void ejecutar(){
			Console.WriteLine("*Persiguiendo delincuente*");
		}
	}
	public class PedirRefuerzos : IOrden {
		public void ejecutar(){
			Console.WriteLine("Pidiendo refuerzos");
		}
	}
}
