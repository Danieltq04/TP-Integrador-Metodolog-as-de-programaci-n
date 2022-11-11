/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 07/10/2019
 * Hora: 01:18 a.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TrabajoIntegrador
{
	public abstract class FabricadeISectores
	{
		public static ISector crearSector(string queDecorado, ISector sector,int caudalLluvia, int temperatura, int velocidadViento, int gente_asustada){
			FabricadeISectores fabrica = null;
			switch(queDecorado){
				case "Pasto Seco": 
			        fabrica = new FabricaDePastoSeco(sector);
			        break;
				case "Arboles Grandes":
			        fabrica = new FabricaDeArbolesGrandes(sector);
			        break;
			    case "Dia De Mucho Calor":
			        fabrica = new FabricaDeDiaDeMuchoCalor(temperatura,sector);
			        break;
			    case "Dia Ventoso":
			        fabrica = new FabricaDeDiaVentoso(velocidadViento, sector);
			        break;
			    case "Gente Asustada":
			        fabrica = new FabricaDeGenteAsustada(gente_asustada,sector);
			        break;
			    case "Dia LLuvioso":
			        fabrica = new FabricaDeDiaLLuvioso(caudalLluvia, sector);
			        break;
			}
			return fabrica.crearSector();
		}
		//Sobrecargar
		public abstract ISector crearSector();
	}
		
	
	public class FabricaDePastoSeco : FabricadeISectores{
		ISector sector;
		public FabricaDePastoSeco(ISector sec) {
			sector = sec;
		}
		override public ISector crearSector(){
			return new PastoSeco(sector);
		}
	}
	public class FabricaDeArbolesGrandes : FabricadeISectores{
		ISector sector;
		public FabricaDeArbolesGrandes(ISector sec) {
			sector = sec;
		}
		override public ISector crearSector(){
			return new ArbolesGrandes(sector);
		}
	}
	public class FabricaDeDiaDeMuchoCalor : FabricadeISectores{
		ISector sector;
		int temperatura;
		public FabricaDeDiaDeMuchoCalor(int temp, ISector sec) {
			sector = sec;
			temperatura = temp;
		}
		override public ISector crearSector(){
			return new DiaDeMuchoCalor(temperatura, sector);
		}
	}
	public class FabricaDeDiaVentoso : FabricadeISectores{
		ISector sector;
		int velocidadViento;
		public FabricaDeDiaVentoso(int velocidad , ISector sec) {
			sector = sec;
			velocidadViento = velocidad;
		}
		override public ISector crearSector(){
			return new DiaVentoso(velocidadViento, sector);
		}
	}
	public class FabricaDeGenteAsustada : FabricadeISectores{
		ISector sector;
		int cantidad_personas;
		public FabricaDeGenteAsustada(int cant_personas, ISector sec) {
			sector = sec;
			cantidad_personas = cant_personas;
		}
		override public ISector crearSector(){
			return new GenteAsustada(cantidad_personas, sector);
		}
	}
	public class FabricaDeDiaLLuvioso : FabricadeISectores{
		ISector sector;
		int caudalLluvia;
		public FabricaDeDiaLLuvioso(int caudal,ISector sec) {
			sector = sec;
			caudalLluvia = caudal;
		}
		override public ISector crearSector(){
			return new DiaLLuvioso(caudalLluvia,sector);
		}
	}
}
