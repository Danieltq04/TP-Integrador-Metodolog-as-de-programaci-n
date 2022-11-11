/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 20/09/2019
 * Hora: 10:50 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace TrabajoIntegrador
{
	public interface Iluminable {
		void revisarYCambiarLamparasQuemadas();
	}
	
	abstract public class Componente: Iluminable {
		abstract public void revisarYCambiarLamparasQuemadas();
	}
	public class Compuesto : Componente {
		private List<Componente> hijos;
		public Compuesto() {
			hijos = new List<Componente>();
		}
		public void agregarHijo(Componente componente){
			hijos.Add(componente);
		}
		override public void revisarYCambiarLamparasQuemadas() {
			foreach (Componente d in hijos) {
				d.revisarYCambiarLamparasQuemadas();
			}
		}
	}
}
