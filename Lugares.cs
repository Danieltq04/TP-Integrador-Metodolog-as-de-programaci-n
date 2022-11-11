/*
 * Creado por SharpDevelop.
 * Usuario: Win
 * Fecha: 20/09/2019
 * Hora: 11:02 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace TrabajoIntegrador
{
	public interface ILugar : IObservado {
		ISector[,] getSectores();
		void chispa();
		Calle getCalle();
		string getString();
	}
	
	public class Casa : ILugar, IObservado, IPatrullable {
		int puertas;
		int superficie;
		int habitantes;
		ISector[,] sector;
		Calle calle_asociada;
		DirectorDeSectores director;
		
		int numero = 1;
		public bool hayAlgoFueraDeLoNormal() {
			Random r = new Random();
			if(r.NextDouble() > 0.5) {
				return true;
			}
			return false;
		}
		public void setNumero(int n){
			numero = n;
		}
		public int getNumero(){
			return numero;
		}
		
		public Casa(DirectorDeSectores director, int puertas_, int superficie_, int habitantes_, Calle cal){//Constructor
			puertas = puertas_;
			superficie = superficie_;
			habitantes = habitantes_;
			calle_asociada = cal;
			//calculosDeSectores();
			this.director = director;
			crearISectores();
		}
		public Casa(int puertas_, int superficie_, int habitantes_, Calle cal){//Constructor
			puertas = puertas_;
			superficie = superficie_;
			habitantes = habitantes_;
			calle_asociada = cal;
			//calculosDeSectores();
			this.director = null;
			crearISectores();
		}
		public Calle getCalle() {
			return calle_asociada;
		}
		
		List<IObservador> observadores = new List<IObservador>();
		public void agregarObservador(IObservador o){
			Console.WriteLine("Agregando observador");
			observadores.Add(o);
		}
		public void quitarObservador(IObservador o){
			Console.WriteLine("Quitando observador");
			observadores.Remove(o);
		}
		public void notificar(){
			foreach(IObservador i in observadores) {
				i.actualizar(this);
			}
		}
		public void chispa() {
			this.notificar();
		}
		public ISector[,] getSectores() {
			return sector;
		}
		
		void crearISectores(){
			double raiz_sup = Math.Sqrt(superficie);
			double redondeado = Math.Round(raiz_sup);
			int fila_col = (int)redondeado;
			
			Random random = new Random();
			int temperatura = (30 + random.Next(16));
			int viento = (80 + random.Next(171));
			int lluvia = (1 + random.Next(500));
			int gente_asustada = random.Next(6);
			Console.WriteLine("Temperatura: {0}, Lluvia: {1}, Viento: {2}, Gente Asustada: {3}.",temperatura, lluvia, viento, gente_asustada);
			/*
			Console.WriteLine("Ingrese la temperatura: ");
			int temperatura = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese la lluvia: ");
			int lluvia = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el viento: ");
			int viento = int.Parse(Console.ReadLine());
			Console.WriteLine("Datos: {0}, {1}, {2}",temperatura, lluvia, viento);*/
			
			//Para obtener el constructor
			ConstructorDeEscenariosAbstracto constructor;
			Console.WriteLine("Ingrese constructor: ");
			Console.WriteLine("1- Constructor Simple: ");
			Console.WriteLine("2- Constructor Favorable: ");
			Console.WriteLine("3- Constructor Desfavorable: ");
			Console.WriteLine("4- Constructor Mixto: ");
			int opcion = int.Parse(Console.ReadLine());
			
			switch (opcion){
				case 1: constructor = new ConstructorSimple(); break;
				case 2: constructor = new ConstructorFavorable(); break;
				case 3: constructor = new ConstructorDesfavorable(); break;
				case 4: constructor = new ConstructorMixto(); break;
				default: constructor = new ConstructorSimple(); break;
			}
			
			sector = DirectorDeSectores.construirMatrizDeSectores(constructor,fila_col, temperatura, lluvia, viento, gente_asustada);
		}
		
		
		
		/*
		private void calculosDeSectores() {
			
			double raiz_sup = Math.Sqrt(superficie);
			double redondeado = Math.Round(raiz_sup);
			int fila_col = (int)redondeado;
			
			
			Random random = new Random();
			int temperatura = (30 + random.Next(16));
			int viento = (80 + random.Next(171));
			int lluvia = (1 + random.Next(500));
			Console.WriteLine("Temperatura: {0}, Lluvia: {1}, Viento: {2}.",temperatura, lluvia, viento);
			
			//Console.WriteLine("Ingrese la temperatura: ");
			//int temperatura = int.Parse(Console.ReadLine());
			//Console.WriteLine("Ingrese la lluvia: ");
			//int lluvia = int.Parse(Console.ReadLine());
			//Console.WriteLine("Ingrese el viento: ");
			//int viento = int.Parse(Console.ReadLine());
			
			Random r = new Random();
			int v = r.Next(101);
			sector = new ISector[fila_col, fila_col];
			for(int i = 0; i < fila_col; i++) {
				for(int j = 0; j < fila_col; j++) {
					v = r.Next(101);
					sector[i,j] = crearISector(v,lluvia,temperatura,viento);
				}
			}
		}
		
		public ISector decorarISector(ISector sector, int caudalLluvia, int temperatura, int velocidadViento) {
			double probabilidad_de_decorar = 1;
			Random random = new Random();
			if(random.NextDouble() < probabilidad_de_decorar)
				sector = FabricadeISectores.crearSector("Pasto Seco",sector,caudalLluvia,temperatura,velocidadViento);
			if(random.NextDouble() < probabilidad_de_decorar)
				sector = FabricadeISectores.crearSector("Arboles Grandes",sector,caudalLluvia,temperatura,velocidadViento);
			if(random.NextDouble() < probabilidad_de_decorar)
				sector = FabricadeISectores.crearSector("Gente Asustada",sector,caudalLluvia,temperatura,velocidadViento);
			if(temperatura > 30)
				sector = FabricadeISectores.crearSector("Dia De Mucho Calor",sector,caudalLluvia,temperatura,velocidadViento);
			if(velocidadViento > 80)
				sector = FabricadeISectores.crearSector("Dia Ventoso",sector,caudalLluvia,temperatura,velocidadViento);
			if(caudalLluvia > 0)
				sector = FabricadeISectores.crearSector("Dia LLuvioso",sector,caudalLluvia,temperatura,velocidadViento);
			return sector;
		}
		ISector crearISector(double porcentaje_afeccion, int caudalLluvia, int temperatura, int velocidadViento){
			ISector sector = new Sector(porcentaje_afeccion);
			return decorarISector(sector, caudalLluvia, temperatura, velocidadViento);
		}*/
		
		
		public void mostrarDimension() {
			double raiz_sup = Math.Sqrt(superficie);
			double redondeado = Math.Round(raiz_sup);
			int fila_col = (int)redondeado;
			Console.WriteLine("La matriz va a ser de "+fila_col+"*"+fila_col);
		}
		
		public void mostrarSectores() {
			for(int i = 0; i < sector.GetLength(0); i++) {
				for(int j = 0; j < sector.GetLength(1); j++) {
					Console.Write(sector[i,j].getPorcentaje()+" ");
				}
				Console.WriteLine();
			}
		}
		/*ISector decorarISector(ISector sector, int caudalLluvia, int temperatura, int velocidadViento) {
			double probabilidad_de_decorar = 1;
			Random random = new Random();
			if(random.NextDouble() < probabilidad_de_decorar)
				sector = new PastoSeco(sector);
			if(random.NextDouble() < probabilidad_de_decorar)
				sector =new ArbolesGrandes(sector);
			if(random.NextDouble() < probabilidad_de_decorar)
				sector = new GenteAsustada(5,sector);
			if(temperatura > 30)
				sector = new DiaDeMuchoCalor(temperatura,sector);
			if(velocidadViento > 80)
				sector = new DiaVentoso(velocidadViento, sector);
			if(caudalLluvia > 0)
				sector = new DiaLLuvioso(caudalLluvia, sector);
			return sector;
		}*/
		
		public string getString() {
			return "";
		}
		//**********  GET Y SET DE PUERTAS  **************
		public int getPuertas() {
			return puertas;
		}
		public void setPuertas(int p) {
			puertas = p;
		}
			
		//**********  GET Y SET DE SUPERFICIES  **************
		public int getSuperficie() {
			return superficie;
		}
		public void setSuperficie(int sup) {
			superficie = sup;
		}
			
		//**********  GET Y SET DE HABITANTES  **************
		public int getHabitantes() {
			return habitantes;
		}
		public void setHabitantes(int hab) {
			habitantes = hab;
		}
			
	}
	
	public class Esquina : Componente, Iluminable, IPatrullable {
		int semaforos;
			
		int numero = 1;
		public bool hayAlgoFueraDeLoNormal() {
			Random r = new Random();
			if(r.NextDouble() > 0.5) {
				return true;
			}
			return false;
		}
		public void setNumero(int n){
			numero = n;
		}
		
		public int getNumero(){
			return numero;
		}
		
		
		override public void revisarYCambiarLamparasQuemadas() {
			Console.WriteLine("Cambiando lampara de la Esquina");
		}
		
		
		public Esquina(int semaforo) {
			semaforos = semaforo;
		}
		
		//**********  GET Y SET DE SEMAFOROS  **************
		public int getSemaforos() {
			return semaforos;
		}
		public void setSemaforos(int sem) {
			semaforos = sem;
		}
	}
	public class Plaza : Componente, Iluminable, ILugar, IPatrullable {
		string nombre;
		int superficie;
		int arboles;
		int farolas;
		ISector[,] sector;
		Calle calle_asociada;
		DirectorDeSectores director;
		
		int numero = 1;
		public bool hayAlgoFueraDeLoNormal() {
			Random r = new Random();
			if(r.NextDouble() > 0.5) {
				return true;
			}
			return false;
		}
		public void setNumero(int n){
			numero = n;
		}
		
		public int getNumero(){
			return numero;
		}
		override public void revisarYCambiarLamparasQuemadas() {
			Console.WriteLine("Cambiando lampara de la plaza "+nombre+".");
		}
		
		public ISector[,] getSectores() {
			return sector;
		}
		public void chispa() {
			this.notificar();
		}
		
		public Plaza(DirectorDeSectores director, string nom, int sup, int arb, int far, Calle cal ) {
			nombre = nom;
			superficie = sup;
			arboles = arb;
			farolas = far;
			calle_asociada = cal;
			//calculosDeSectores();
			this.director = director;
			crearISectores();
		}
		public Plaza(string nom, int sup, int arb, int far, Calle cal ) {
			nombre = nom;
			superficie = sup;
			arboles = arb;
			farolas = far;
			calle_asociada = cal;
			//calculosDeSectores();
			crearISectores();
		}
		public Calle getCalle() {
			return calle_asociada;
		}
		/*
		public void revisarYCambiarLamparasQuemadas() {
			Console.WriteLine("Cambiando lampara de la plaza");
		}*/
		
		
		List<IObservador> observadores = new List<IObservador>();
		public void agregarObservador(IObservador o){
			Console.WriteLine("Agregando observador");
			observadores.Add(o);
		}
		public void quitarObservador(IObservador o){
			Console.WriteLine("Quitando observador");
			observadores.Remove(o);
		}
		public void notificar(){
			foreach(IObservador i in observadores) {
				i.actualizar(this);
			}
		}
		
		void crearISectores(){
			double raiz_sup = Math.Sqrt(superficie);
			double redondeado = Math.Round(raiz_sup);
			int fila_col = (int)redondeado;
			
			Random random = new Random();
			int temperatura = (30 + random.Next(16));
			int viento = (80 + random.Next(171));
			int lluvia = (1 + random.Next(500));
			int gente_asustada = (random.Next(6));
			Console.WriteLine("Temperatura: {0}, Lluvia: {1}, Viento: {2}, Gente asustada: {3}.",temperatura, lluvia, viento,gente_asustada);
			
			//Para obtener el constructor
			ConstructorDeEscenariosAbstracto constructor;
			Console.WriteLine("Ingrese constructor: ");
			Console.WriteLine("1- Constructor Simple: ");
			Console.WriteLine("2- Constructor Favorable: ");
			Console.WriteLine("3- Constructor Desfavorable: ");
			Console.WriteLine("4- Constructor Mixto: ");
			int opcion = int.Parse(Console.ReadLine());
			
			switch (opcion){
				case 1: constructor = new ConstructorSimple(); break;
				case 2: constructor = new ConstructorFavorable(); break;
				case 3: constructor = new ConstructorDesfavorable(); break;
				case 4: constructor = new ConstructorMixto(); break;
				default: constructor = new ConstructorSimple(); break;
			}
			
			sector = DirectorDeSectores.construirMatrizDeSectores(constructor,fila_col, temperatura, lluvia, viento,gente_asustada);
		}
		
		
		/* YA NO SE UTILIZAN
		private void calculosDeSectores() {
			double raiz_sup = Math.Sqrt(superficie);
			double redondeado = Math.Round(raiz_sup);
			int fila_col = (int)redondeado;
			
			Random random = new Random();
			int temperatura = (30 + random.Next(16));
			int viento = (80 + random.Next(171));
			int lluvia = (1 + random.Next(500));
			Console.WriteLine("Temperatura: {0}, Lluvia: {1}, Viento: {2}.",temperatura, lluvia, viento);
			
			Random r = new Random();
			int v = r.Next(101);
			sector = new ISector[fila_col, fila_col];
			for(int i = 0; i < fila_col; i++) {
				for(int j = 0; j < fila_col; j++) {
					v = r.Next(101);
					sector[i,j] = crearISector(v,lluvia, temperatura, viento);
				}
			}
		}
		public ISector decorarISector(ISector sector, int caudalLluvia, int temperatura, int velocidadViento) {
			double probabilidad_de_decorar = 1;
			Random random = new Random();
			if(random.NextDouble() < probabilidad_de_decorar)
				sector = FabricadeISectores.crearSector("Pasto Seco",sector,caudalLluvia,temperatura,velocidadViento);
			if(random.NextDouble() < probabilidad_de_decorar)
				sector = FabricadeISectores.crearSector("Arboles Grandes",sector,caudalLluvia,temperatura,velocidadViento);
			if(random.NextDouble() < probabilidad_de_decorar)
				sector = FabricadeISectores.crearSector("Gente Asustada",sector,caudalLluvia,temperatura,velocidadViento);
			if(temperatura > 30)
				sector = FabricadeISectores.crearSector("Dia De Mucho Calor",sector,caudalLluvia,temperatura,velocidadViento);
			if(velocidadViento > 80)
				sector = FabricadeISectores.crearSector("Dia Ventoso",sector,caudalLluvia,temperatura,velocidadViento);
			if(caudalLluvia > 0)
				sector = FabricadeISectores.crearSector("Dia LLuvioso",sector,caudalLluvia,temperatura,velocidadViento);
			return sector;
		}
		ISector crearISector(double porcentaje_afeccion, int caudalLluvia, int temperatura, int velocidadViento){
			ISector sector = new Sector(porcentaje_afeccion);
			return decorarISector(sector, caudalLluvia, temperatura, velocidadViento);
		}*/
		public string getString() {
			return this.getNombre();
		}
		
		//**********  GET Y SET DE NOMBRE  **************
		public string getNombre() {
			return nombre;
		}
		public void setNombre(string nom) {
			nombre = nom;
		}
			
		//**********  GET Y SET DE SUPERFICIE  **************
		public int getSuperficie() {
			return superficie;
		}
		public void setSuperficie(int sup) {
			superficie = sup;
		}
			
		//**********  GET Y SET DE ARBOLES  **************
		public int getArboles() {
			return arboles;
		}
		public void setSemaforos(int arb) {
			arboles = arb;
		}
			
		//**********  GET Y SET DE FAROLAS  **************
		public int getFarolas() {
			return farolas;
		}
		public void setFarolas(int far) {
			farolas = far;
		}
		
		public void mostrarSectores() {//Mismo que el de casa
			for(int i = 0; i < sector.GetLength(0); i++) {
				for(int j = 0; j < sector.GetLength(1); j++) {
					Console.Write(sector[i,j].getPorcentaje()+" ");
				}
				Console.WriteLine();
			}
		}

	}
	public class Calle : Componente, Iluminable {
		int longitud;
		int farolas;
		double caudal;
			
		
		override public void revisarYCambiarLamparasQuemadas() {
			Console.WriteLine("Cambiando lampara de la Calle");
		}
		
		public Calle(int lon, int far, int cau) {
			longitud = lon;
			farolas = far;
			caudal = cau;
		}
		//**********  GET Y SET DE LONGITUD  **************
		public int getLongitud() {
			return longitud;
		}
		public void setLongitud(int lon) {
			longitud = lon;
		}
			
		//**********  GET Y SET DE FAROLAS  **************
		public int getFarolas() {
			return farolas;
		}
		public void setSemaforos(int far) {
			farolas = far;
		}
			
		//**********  GET Y SET DE CAUDAL  **************
		public double getCaudal() {
			return caudal;
		}
		public void setCaudal(int cau) {
			caudal = cau;
		}
	}
}
