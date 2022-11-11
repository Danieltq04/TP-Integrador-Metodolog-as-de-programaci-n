/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 08/10/2019
 * Hora: 11:21 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TrabajoIntegrador
{
	abstract public class ConstructorDeEscenariosAbstracto
	{
		public abstract ISector construirEscenario(int porcentaje_afeccion, int caudalLluvia, int temperatura, int velocidadViento, int gente_asustada);
	}
	
	public class ConstructorSimple : ConstructorDeEscenariosAbstracto {
		public override ISector construirEscenario(int porcentaje_afeccion, int caudalLluvia, int temperatura, int velocidadViento, int gente_asustada) {
			ISector sector = new Sector(porcentaje_afeccion);
			return sector;
		}
	}
	
	public class ConstructorFavorable : ConstructorDeEscenariosAbstracto {
		public override ISector construirEscenario(int porcentaje_afeccion, int caudalLluvia, int temperatura, int velocidadViento, int gente_asustada) {
			ISector sector = new Sector(porcentaje_afeccion);
			sector = FabricadeISectores.crearSector("Dia LLuvioso",sector,caudalLluvia,temperatura,velocidadViento,gente_asustada);
			return sector;
		}
	}
	
	public class ConstructorDesfavorable : ConstructorDeEscenariosAbstracto {
		public override ISector construirEscenario(int porcentaje_afeccion, int caudalLluvia, int temperatura, int velocidadViento, int gente_asustada) {
			ISector sector = new Sector(porcentaje_afeccion);
			sector = FabricadeISectores.crearSector("Pasto Seco",sector,caudalLluvia,temperatura,velocidadViento,gente_asustada);
			sector = FabricadeISectores.crearSector("Arboles Grandes",sector,caudalLluvia,temperatura,velocidadViento,gente_asustada);
			sector = FabricadeISectores.crearSector("Gente Asustada",sector,caudalLluvia,temperatura,velocidadViento,gente_asustada);
			sector = FabricadeISectores.crearSector("Dia De Mucho Calor",sector,caudalLluvia,temperatura,velocidadViento,gente_asustada);
			sector = FabricadeISectores.crearSector("Dia Ventoso",sector,caudalLluvia,temperatura,velocidadViento,gente_asustada);
			return sector;
		}
	}
	public class ConstructorMixto : ConstructorDeEscenariosAbstracto {
		public override ISector construirEscenario(int porcentaje_afeccion, int caudalLluvia, int temperatura, int velocidadViento, int gente_asustada) {
			ISector sector = new Sector(porcentaje_afeccion);
			sector = FabricadeISectores.crearSector("Pasto Seco",sector,caudalLluvia,temperatura,velocidadViento,gente_asustada);
			sector = FabricadeISectores.crearSector("Arboles Grandes",sector,caudalLluvia,temperatura,velocidadViento,gente_asustada);
			sector = FabricadeISectores.crearSector("Gente Asustada",sector,caudalLluvia,temperatura,velocidadViento,gente_asustada);
			sector = FabricadeISectores.crearSector("Dia De Mucho Calor",sector,caudalLluvia,temperatura,velocidadViento,gente_asustada);
			sector = FabricadeISectores.crearSector("Dia Ventoso",sector,caudalLluvia,temperatura,velocidadViento,gente_asustada);
			sector = FabricadeISectores.crearSector("Dia LLuvioso",sector,caudalLluvia,temperatura,velocidadViento,gente_asustada);
			return sector;
		}
	}
	
	public class DirectorDeSectores {
		public static ISector[,] construirMatrizDeSectores(ConstructorDeEscenariosAbstracto constructor,int fila_col, int temperatura, int lluvia, int viento, int gente_asustada)
		{
			ISector[,] sector;
			Random r = new Random();
			int porcentaje_afeccion = r.Next(101);
			sector = new ISector[fila_col, fila_col];
			for(int i = 0; i < fila_col; i++) {
				for(int j = 0; j < fila_col; j++) {
					porcentaje_afeccion = r.Next(101);
					sector[i,j] = constructor.construirEscenario(porcentaje_afeccion,lluvia,temperatura,viento,gente_asustada);
				}
			}
			return sector;
		}
	}
}
