/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 20/09/2019
 * Hora: 10:45 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TrabajoIntegrador
{
	public interface IObservador {
		void actualizar(ILugar lugar);
	}
	public interface IObservado {
		void agregarObservador(IObservador o);
		void quitarObservador(IObservador o);
		void notificar();
	}
}
