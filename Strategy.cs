/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 20/09/2019
 * Hora: 10:23 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TrabajoIntegrador
{
	public interface FormaDeApagado {
		void apagar(ILugar lugar, Calle calle);
	}
	
	public class Secuencial : FormaDeApagado {
		public void apagar(ILugar lugar, Calle calle) {
			Console.WriteLine("\nApagando en forma secuencial:");
			for(int i = 0; i< lugar.getSectores().GetLength(0);i++) {
				for(int j=0 ; j< lugar.getSectores().GetLength(1);j++) {
					Console.Write("("+i+","+j+") ");
					HeroesDeCiudad.apagarIterando(lugar,calle,i,j);
				}
			}
			if(lugar.getString()!="") {
				Console.WriteLine("\n¡¡¡¡¡¡¡ El fuego de la plaza ''"+lugar.getString()+"'' fue extinguido en su totalidad !!!!!!");
			}
			else {
				Console.WriteLine("\n¡¡¡¡¡¡¡ El fuego de la Casa fue extinguido en su totalidad !!!!!!");
			}
		}
	}
	public class Escalera : FormaDeApagado {
		public void apagar(ILugar lugar, Calle calle) {
			Console.WriteLine("\nApagando en forma de escalera:");
			for(int i = 0; i< lugar.getSectores().GetLength(0);i++) {
				if((i % 2) == 0) {
					for(int j=0 ; j< lugar.getSectores().GetLength(1);j++) {
						Console.Write("("+i+","+j+") ");
						while(!lugar.getSectores()[i,j].estaApagado()) {
							Console.Write("-> " + lugar.getSectores()[i,j].getPorcentaje() + " ");
							lugar.getSectores()[i,j].mojar(calle.getCaudal());
						}
						Console.WriteLine("-> " + lugar.getSectores()[i,j].getPorcentaje()+".");
					}
				}
				else {
					for(int j=lugar.getSectores().GetLength(1)-1 ; j>=0;j--) {
						Console.Write("("+i+","+j+") ");
						while(!lugar.getSectores()[i,j].estaApagado()) {
							Console.Write("-> " + lugar.getSectores()[i,j].getPorcentaje() + " ");
							lugar.getSectores()[i,j].mojar(calle.getCaudal());
						}
						Console.WriteLine("-> " + lugar.getSectores()[i,j].getPorcentaje()+".");
					}
				}
			}
			if(lugar.getString()!="") {
				Console.WriteLine("\n¡¡¡¡¡¡¡ El fuego de la plaza ''"+lugar.getString()+"'' fue extinguido en su totalidad !!!!!!");
			}
			else {
				Console.WriteLine("\n¡¡¡¡¡¡¡ El fuego de la Casa fue extinguido en su totalidad !!!!!!");
			}
		}
	}
	public class Espiral : FormaDeApagado {
		public void apagar(ILugar lugar, Calle calle) {
			Console.WriteLine("\nApagando en forma de espiral:\n");
			int n = 0, sentido = 0, x = 0, y = 0;
		    while (n < lugar.getSectores().GetLength(0)*lugar.getSectores().GetLength(0)) {
				switch (sentido){
					case 0: { // -> izquierda a derecha
						for (int i = x; i < lugar.getSectores().GetLength(0) - y; i++) {
								Console.Write("("+x+","+i+") ");
								HeroesDeCiudad.apagarIterando(lugar,calle,x,i);
							n++;
		            	}
						sentido++;
			            break;
					}
					case 1: { //Arriba a abajo
						for (int i = x + 1; i < lugar.getSectores().GetLength(0) - x; i++) {
								Console.Write("("+i+","+(lugar.getSectores().GetLength(0) - 1 - y)+") ");
								HeroesDeCiudad.apagarIterando(lugar,calle,i,lugar.getSectores().GetLength(0) - 1 - y);;
							n++;
						}
			            sentido++;
			            break;
					}
					case 2: { //Derecha a izquierda
			            for (int i = lugar.getSectores().GetLength(0) - 2 - y; i >= y; i--) {
								Console.Write("("+(lugar.getSectores().GetLength(0) - 1 -x)+","+i+") ");
								HeroesDeCiudad.apagarIterando(lugar,calle,lugar.getSectores().GetLength(0) - 1 - x,i);
			               n++;
			            }
			            sentido++;
			            break;
					}
					case 3:{ //Abajo a arriba
			            for (int i = lugar.getSectores().GetLength(0) - 2 - x; i >= x + 1; i--) {
								Console.Write("("+i+","+y+") ");
								HeroesDeCiudad.apagarIterando(lugar,calle,i,y);
			            	n++;
			            }
			            sentido = 0;
			            //Se aumentan las filas y las columnas para un subnivel en el espiral
			            x++;
			            y++;
			            break;
					}
				}
			}
			if(lugar.getString()!="") {
				Console.WriteLine("\n¡¡¡¡¡¡¡ El fuego de la plaza ''"+lugar.getString()+"'' fue extinguido en su totalidad !!!!!!");
			}
			else {
				Console.WriteLine("\n¡¡¡¡¡¡¡ El fuego de la Casa fue extinguido en su totalidad !!!!!!");
			}
		}
	}
}
