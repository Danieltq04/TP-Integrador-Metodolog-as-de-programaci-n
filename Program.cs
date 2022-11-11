/*
 * Created by SharpDevelop.
 * User: Win
 * Date: 29/08/2019
 * Time: 09:38 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;


namespace TrabajoIntegrador
{
	class HeroesDeCiudad {
		public static void apagarIterando(ILugar lugar, Calle calle, int i, int j) {
			while(!lugar.getSectores()[i,j].estaApagado()) {
				Console.Write("-> " + lugar.getSectores()[i,j].getPorcentaje() + " ");
				lugar.getSectores()[i,j].mojar(calle.getCaudal());
				//Console.ReadKey(true);
			}
			Console.WriteLine("-> " + lugar.getSectores()[i,j].getPorcentaje()+".");
		}
		private static Componente crearCiudad(){
			Esquina esquina1 = new Esquina(1);
			Esquina esquina2 = new Esquina(1);
			Esquina esquina3 = new Esquina(1);
			Esquina esquina4 = new Esquina(1);
			Calle calle1 = new Calle(1000, 4, 50);
			Calle calle2 = new Calle(1000, 4, 50);
			Calle calle3 = new Calle(1000, 4, 50);
			Calle calle4 = new Calle(1000, 4, 50);
			Plaza plaza1 = new Plaza("Plaza 1", 16,3,2,calle1);
			Plaza plaza2 = new Plaza("Plaza 2", 10,3,2,calle2);
			Compuesto manzana = new Compuesto();
			manzana.agregarHijo(esquina1);
			manzana.agregarHijo(esquina2);
			manzana.agregarHijo(esquina3);
			manzana.agregarHijo(esquina4);
			manzana.agregarHijo(calle1);
			manzana.agregarHijo(calle2);
			manzana.agregarHijo(calle3);
			manzana.agregarHijo(calle4);
			
			Compuesto barrioA = new Compuesto();
			barrioA.agregarHijo(manzana);
			barrioA.agregarHijo(manzana);
			barrioA.agregarHijo(manzana);
			barrioA.agregarHijo(manzana);
			barrioA.agregarHijo(manzana);
			barrioA.agregarHijo(manzana);
			barrioA.agregarHijo(manzana);
			barrioA.agregarHijo(manzana);
			barrioA.agregarHijo(manzana);
			barrioA.agregarHijo(plaza1);
			barrioA.agregarHijo(plaza2);
			
			Compuesto barrioB = new Compuesto();
			barrioB.agregarHijo(manzana);
			barrioB.agregarHijo(manzana);
			barrioB.agregarHijo(manzana);
			barrioB.agregarHijo(manzana);
			barrioB.agregarHijo(manzana);
			barrioB.agregarHijo(manzana);
			barrioB.agregarHijo(manzana);
			barrioB.agregarHijo(plaza1);
			
			Compuesto barrioC = new Compuesto();
			barrioC.agregarHijo(manzana);
			barrioC.agregarHijo(manzana);
			barrioC.agregarHijo(manzana);
			barrioC.agregarHijo(manzana);
			barrioC.agregarHijo(manzana);
			barrioC.agregarHijo(plaza1);
			barrioC.agregarHijo(plaza2);
			
			Compuesto barrioD = new Compuesto();
			barrioD.agregarHijo(manzana);
			barrioD.agregarHijo(manzana);
			barrioD.agregarHijo(manzana);
			barrioD.agregarHijo(manzana);
			barrioD.agregarHijo(manzana);
			barrioD.agregarHijo(manzana);
			
			Compuesto ciudad = new Compuesto();
			ciudad.agregarHijo(barrioA);
			ciudad.agregarHijo(barrioB);
			ciudad.agregarHijo(barrioC);
			ciudad.agregarHijo(barrioD);
			
			return ciudad;
		}
		private static Componente crearCiudad2(){
			Esquina d111 = new Esquina(1);
			Calle d112 = new Calle(1000, 4, 50);

			Compuesto d11 = new Compuesto();
			d11.agregarHijo(d111);
			d11.agregarHijo(d112);
			
			Esquina d12 = new Esquina(1);
			Calle d13 = new Calle(1000, 4, 50);

			Esquina d21 = new Esquina(1);
			Calle d22 = new Calle(1000, 4, 50);

			Compuesto d1 = new Compuesto();
			d1.agregarHijo(d11);
			d1.agregarHijo(d12);
			d1.agregarHijo(d13);
			
			Compuesto d2 = new Compuesto();
			d2.agregarHijo(d21);
			d2.agregarHijo(d22);
			
			Compuesto d = new Compuesto();
			d.agregarHijo(d1);
			d.agregarHijo(d2);
			
			return d;
		}
		private static void TestingStrategy() {
			//Testeo del patrón Strategy, Decorator y Factory Method
			Bombero bom = new Bombero();
			Calle calle = new Calle(1000, 4, 50);
			Casa casa = new Casa(4,30,6,calle);
			
			FormaDeApagado forma = new Escalera();
			bom.cambiarForma(forma);
			casa.mostrarSectores();
			Console.WriteLine();
			bom.apagarIncendio(casa);
			Console.ReadKey(true);
			Console.Clear();
			
			Plaza plaza = new Plaza("Plaza", 16, 3, 4,calle);
			forma = new Espiral();
			bom.cambiarForma(forma);
			plaza.mostrarSectores();
			Console.WriteLine();
			bom.apagarIncendio(plaza);
			Console.ReadKey(true);
			Console.Clear();
		}
		private static void TestingObserver() {
			//Testeo del patrón Observer
			Bombero bom = new Bombero();
			Calle calle = new Calle(1000, 4, 50);
			Casa casa1 = new Casa(2 ,30,3,calle);
			Casa casa2 = new Casa(1,25,2,calle);
			Casa casa3 = new Casa(4,36,6,calle);
			Casa casa4 = new Casa(5,25,5,calle);
			Casa casa5 = new Casa(4,30,6,calle);
			Plaza plaza = new Plaza("Plaza", 16, 3, 4,calle);
			
			casa1.agregarObservador(bom);
			casa2.agregarObservador(bom);
			casa3.agregarObservador(bom);
			casa4.agregarObservador(bom);
			casa5.agregarObservador(bom);
			plaza.agregarObservador(bom);
			
			FormaDeApagado forma = new Escalera();
			bom.cambiarForma(forma);
			casa3.mostrarSectores();
			casa3.chispa();
			Console.ReadKey(true);
			Console.Clear();
			
			forma = new Espiral();
			bom.cambiarForma(forma);
			plaza.mostrarSectores();
			plaza.chispa();
			Console.ReadKey(true);
			Console.Clear();
		}
		private static void TestingComposite() {
			//Testeo del patrón Composite
			Electricista electricista = new Electricista();
			Componente c = crearCiudad();
			electricista.revisar(c);
		}
		private static void TestingDecorator() {
			//Testeo rápido del Decorator, pero el testeo del integrador es con Strategy
			Bombero bombero = new Bombero();
			Calle calle = new Calle(1000, 4, 50);
			Casa casa1 = new Casa(4,25,6,calle);
			Casa casa2 = new Casa(4,25,6,calle);
			Casa casa3 = new Casa(4,25,6,calle);
			Casa casa4 = new Casa(4,25,6,calle);
			bombero.apagarIncendio(casa1);
			bombero.apagarIncendio(casa2);
			bombero.apagarIncendio(casa3);
			bombero.apagarIncendio(casa4);
		}
		private static void TestingCommand() {
			Calle calle = new Calle(1000, 4, 50);
			Casa casa1 = new Casa(4,30,6,calle);
			Casa casa2 = new Casa(4,30,6,calle);
			Casa casa3 = new Casa(4,30,6,calle);
			Casa casa4 = new Casa(4,30,6,calle);
			Casa casa5 = new Casa(4,30,6,calle);
			Plaza plaza1 = new Plaza("Plaza 1", 16, 3, 4,calle);
			Plaza plaza2 = new Plaza("Plaza 2", 16, 3, 4,calle);
			Plaza plaza3 = new Plaza("Plaza 3", 16, 3, 4,calle);
			Plaza plaza4 = new Plaza("Plaza 4", 16, 3, 4,calle);
			Plaza plaza5 = new Plaza("Plaza 5", 16, 3, 4,calle);
			Esquina esquina1 = new Esquina(2);
			Esquina esquina2 = new Esquina(5);
			Esquina esquina3 = new Esquina(4);
			Esquina esquina4 = new Esquina(2);
			Esquina esquina5 = new Esquina(2);
			
			Policia policia = new Policia();
			policia.setOrdenPop(new DarVozDeAlto());
			policia.patrullarCalles(casa1);
			policia.patrullarCalles(casa2);
			policia.patrullarCalles(casa3);
			policia.patrullarCalles(casa4);
			policia.patrullarCalles(casa5);
			Console.WriteLine();
			
			policia.setOrdenPop(new PerseguirDelincuente());
			policia.patrullarCalles(plaza1);
			policia.patrullarCalles(plaza2);
			policia.patrullarCalles(plaza3);
			policia.patrullarCalles(plaza4);
			policia.patrullarCalles(plaza5);
			Console.WriteLine();
			
			policia.setOrdenPop(new PedirRefuerzos());
			policia.patrullarCalles(esquina1);
			policia.patrullarCalles(esquina2);
			policia.patrullarCalles(esquina3);
			policia.patrullarCalles(esquina4);
			policia.patrullarCalles(esquina5);
			Console.WriteLine();
		}
		
		private static void TestingTemplateMethod() {
			//Testeo del patrón Template Method
			Medico medico = new Medico(); 
			ProtocoloRCP protocolo = new FormaA();
			medico.setProtocolo(protocolo);
			Transeunte transeunte = new Transeunte(50,20,50);
			medico.AtenderInfarto(transeunte);
		}
		private static void TestingAdapter() {
			//Testeo del patrón Adapter
			Medico medico = new Medico();
			ProtocoloRCP protocolo = new FormaB();
			medico.setProtocolo(protocolo);
			IPasserby passerby = new Passerby(50,50,50);
			IInfartable adaptador = new InfartableAdapter(passerby);
			medico.AtenderInfarto(adaptador);
		}
		private static void TestingBuilder() {
			DirectorDeSectores director1 = new DirectorDeSectores();
			DirectorDeSectores director2 = new DirectorDeSectores();
			DirectorDeSectores director3 = new DirectorDeSectores();
			DirectorDeSectores director4 = new DirectorDeSectores();
			//4 Constructores
			
			Calle calle = new Calle(1000, 4, 50);
			
			Casa casa1 = new Casa(director1,4,30,6,calle);
			Casa casa2 = new Casa(director2,4,30,6,calle);
			Plaza plaza1 = new Plaza(director3,"Plaza 1", 16, 3, 4,calle);
			Plaza plaza2 = new Plaza(director4,"Plaza 2", 16, 3, 4,calle);
			
			Bombero bom = new Bombero();
			bom.cambiarForma(new Escalera());
			casa1.mostrarSectores();
			bom.apagarIncendio(casa1);
			casa2.mostrarSectores();
			bom.apagarIncendio(casa2);
			plaza1.mostrarSectores();
			bom.apagarIncendio(plaza1);
			plaza2.mostrarSectores();
			bom.apagarIncendio(plaza2);
			Console.ReadKey(true);
		}
		private static void TestingIterator() {
			Bombero bom = new Bombero();
			bom.cambiarForma(new Escalera());
			BomberoSecretario bombero = new BomberoSecretario(bom);
			
			DirectorDeSectores director1 = new DirectorDeSectores();
			DirectorDeSectores director2 = new DirectorDeSectores();
			DirectorDeSectores director3 = new DirectorDeSectores();
			DirectorDeSectores director4 = new DirectorDeSectores();
			
			//DENUNCIAS POR TABLERO
			Calle calle = new Calle(1000, 4, 50);
			Casa casaA = new Casa(director1,4,30,6,calle);
			Casa casaB = new Casa(director2,4,30,6,calle);
			Casa casaC = new Casa(director2,4,30,6,calle);
			Casa casaD = new Casa(director2,4,30,6,calle);
			Casa casaE = new Casa(director2,4,30,6,calle);
			Plaza plazaF = new Plaza(director2,"Plaza F",30,6,4,calle);
			Plaza plazaG = new Plaza(director2,"Plaza G",30,6,4,calle);
			Plaza plazaH = new Plaza(director2,"Plaza H",30,6,4,calle);
			Plaza plazaI = new Plaza(director2,"Plaza I",30,6,4,calle);
			Plaza plazaJ = new Plaza(director2,"Plaza J",30,6,4,calle);
			
			//Denuncias por tablero
			IDenuncias denuncias_por_tablero = new DenunciasPorTablero();
			casaA.agregarObservador((IObservador)denuncias_por_tablero);
			casaB.agregarObservador((IObservador)denuncias_por_tablero);
			casaC.agregarObservador((IObservador)denuncias_por_tablero);
			casaD.agregarObservador((IObservador)denuncias_por_tablero);
			casaE.agregarObservador((IObservador)denuncias_por_tablero);
			plazaF.agregarObservador((IObservador)denuncias_por_tablero);
			
			//Denuncias por whatsapp
			IDenuncias denuncias_por_whatsapp = new DenunciasPorWhatsapp();
			IDenuncia denuncia1 = new DenunciaDeIncendio(plazaG);
			IDenuncia denuncia2 = new DenunciaDeIncendio(plazaH);
			IDenuncia denuncia3 = new DenunciaDeIncendio(plazaI);
			denuncias_por_whatsapp.agregarDenuncia(denuncia1);
			denuncias_por_whatsapp.agregarDenuncia(denuncia2);
			denuncias_por_whatsapp.agregarDenuncia(denuncia3);
			
			//Denuncias por mostrador
			IDenuncias denuncia_por_mostrador = new DenunciasPorMostrador();
			IDenuncia denuncia4 = new DenunciaDeIncendio(plazaJ);
			denuncia_por_mostrador.agregarDenuncia(denuncia4);
			
			casaB.chispa();
			plazaF.chispa();
			bombero.atenderDenuncias(denuncias_por_tablero);
			bombero.atenderDenuncias(denuncias_por_whatsapp);
			bombero.atenderDenuncias(denuncia_por_mostrador);
		}
		private static void TestingChainOfResponsability() {
			DirectorDeSectores director1 = new DirectorDeSectores();
			DirectorDeSectores director2 = new DirectorDeSectores();
			DirectorDeSectores director3 = new DirectorDeSectores();
			DirectorDeSectores director4 = new DirectorDeSectores();
			
			Calle calle = new Calle(1000, 4, 50);
			Casa casa = new Casa(director1,4,30,6,calle);
			Plaza plaza = new Plaza(director2,"Plaza",25,3,4,calle);
			
			//Agrego denuncias de incendio
			IDenuncias denuncias_por_whatsapp = new DenunciasPorWhatsapp();
			IDenuncia denuncia1 = new DenunciaDeIncendio(casa);
			IDenuncia denuncia2 = new DenunciaDeIncendio(plaza);
			denuncias_por_whatsapp.agregarDenuncia(denuncia1);
			denuncias_por_whatsapp.agregarDenuncia(denuncia2);
			
			
			//Agrego Denuncias de infarto
			Transeunte transeunte = new Transeunte(50,20,50);
			IPasserby passerby = new Passerby(50,20,40);
			IInfartable adaptadorPasserby = new InfartableAdapter(passerby);
			IDenuncia denuncia3 = new DenunciaDeInfarto(transeunte);
			IDenuncia denuncia4 = new DenunciaDeInfarto(adaptadorPasserby);
			denuncias_por_whatsapp.agregarDenuncia(denuncia3);
			denuncias_por_whatsapp.agregarDenuncia(denuncia4);
			
			//Agrego Denuncias de robo
			Esquina esquina = new Esquina(0);
			IDenuncia denuncia5 = new DenunciaDeRobo(casa); //Verificar si casa es patrullable
			IDenuncia denuncia6 = new DenunciaDeRobo(plaza);
			IDenuncia denuncia7 = new DenunciaDeRobo(esquina);
			denuncias_por_whatsapp.agregarDenuncia(denuncia5);
			denuncias_por_whatsapp.agregarDenuncia(denuncia6);
			denuncias_por_whatsapp.agregarDenuncia(denuncia7);
			
			//Agrego denuncias por lámparas quemadas
			Compuesto componente = new Compuesto();
			componente.agregarHijo(calle);
			componente.agregarHijo(esquina);
			componente.agregarHijo(plaza);
			componente.agregarHijo(esquina);
			componente.agregarHijo(plaza);
			IDenuncia denuncia8 = new DenunciaDeLamparaQuemada(componente);
			denuncias_por_whatsapp.agregarDenuncia(denuncia8);
			
			//Encadeno los manejadores
			Manejador manejador = new Bombero(null);
			manejador = new Policia(manejador);
			manejador = new Medico(manejador);
			manejador = new Electricista(manejador);
			Operador911 operador = new Operador911(manejador);
			
			//Atiendo todas las denuncias
			operador.atenderDenuncias(denuncias_por_whatsapp);
		}
		private static void TestingAbstractFactory() {
			//Testeo del patrón Abstract Factory y Singleton
			IFabricaDeHeroes bomberos = new FabricaDeBomberos();
			IFabricaDeHeroes medicos = new FabricaDeMedicos();
			IFabricaDeHeroes policias = new FabricaDePolicias();
			IFabricaDeHeroes electricistas = new FabricaDeElectricistas();
			
			DirectorDeSectores director1 = new DirectorDeSectores();
			Calle calle = new Calle(1000, 4, 50);
			Casa casa1 = new Casa(director1,4,30,6,calle);
			
			ICuartel cbomberos = crearHeroe(bomberos);
			IResponsable responsable1 = cbomberos.getPersonal();
			((Bombero)responsable1).apagarIncendio(casa1);
			Console.ReadKey();
			Console.Clear();
			
			ICuartel cmedicos = crearHeroe(medicos);
			IResponsable responsable2 = cmedicos.getPersonal();
			Transeunte transeunte = new Transeunte(50,20,50);
			((Medico)responsable2).setProtocolo(new FormaB());
			((Medico)responsable2).AtenderInfarto(transeunte);
			Console.ReadKey();
			Console.Clear();
			
			ICuartel cpolicias = crearHeroe(policias);
			IResponsable responsable3 = cpolicias.getPersonal();
			((Policia)responsable3).setOrdenPop(new DarVozDeAlto());
			((Policia)responsable3).patrullarCalles(casa1);
			Console.ReadKey();
			Console.Clear();
			
			ICuartel celectricistas = crearHeroe(electricistas);
			IResponsable responsable4 = celectricistas.getPersonal();
			Componente ciudad = crearCiudad();
			((Electricista)responsable4).revisar(ciudad);
			Console.ReadKey();
			Console.Clear();
			
			//Creo más héroes para el mismo  cuartel porque usa Singleton
			ICuartel cbomberos2 = crearHeroe(bomberos);
			ICuartel cmedicos2 = crearHeroe(medicos);
			ICuartel cpolicias2 = crearHeroe(policias);
			ICuartel celectricistas2 = crearHeroe(electricistas);
			//Testeo del patrón Singleton
			IResponsable resp1 = cbomberos.getPersonal();
			IResponsable resp2 = cmedicos.getPersonal();
			IResponsable resp3 = cpolicias.getPersonal();
			IResponsable resp4 = celectricistas.getPersonal();
		}
		private static void TestingProxy() {
			DirectorDeSectores director1 = new DirectorDeSectores();
			DirectorDeSectores director2 = new DirectorDeSectores();
			DirectorDeSectores director3 = new DirectorDeSectores();
			DirectorDeSectores director4 = new DirectorDeSectores();
			
			Calle calle = new Calle(1000, 4, 50);
			Casa casa = new Casa(director1,4,30,6,calle);
			Plaza plaza = new Plaza(director2,"Plaza",25,3,4,calle);
			
			//Agrego denuncias de incendio
			IDenuncias denuncias_por_whatsapp = new DenunciasPorWhatsapp();
			IDenuncia denuncia1 = new DenunciaDeIncendio(casa);
			IDenuncia denuncia2 = new DenunciaDeIncendio(plaza);
			denuncias_por_whatsapp.agregarDenuncia(denuncia1);
			denuncias_por_whatsapp.agregarDenuncia(denuncia2);
			
			
			//Agrego Denuncias de infarto
			Transeunte transeunte = new Transeunte(50,20,50);
			IPasserby passerby = new Passerby(50,20,40);
			IInfartable adaptadorPasserby = new InfartableAdapter(passerby);
			IDenuncia denuncia3 = new DenunciaDeInfarto(transeunte);
			IDenuncia denuncia4 = new DenunciaDeInfarto(adaptadorPasserby);
			denuncias_por_whatsapp.agregarDenuncia(denuncia3);
			denuncias_por_whatsapp.agregarDenuncia(denuncia4);
			
			//Agrego Denuncias de robo
			Esquina esquina = new Esquina(0);
			IDenuncia denuncia5 = new DenunciaDeRobo(casa); //Verificar si casa es patrullable
			IDenuncia denuncia6 = new DenunciaDeRobo(plaza);
			IDenuncia denuncia7 = new DenunciaDeRobo(esquina);
			denuncias_por_whatsapp.agregarDenuncia(denuncia5);
			denuncias_por_whatsapp.agregarDenuncia(denuncia6);
			denuncias_por_whatsapp.agregarDenuncia(denuncia7);
			
			//Agrego denuncias por lámparas quemadas
			Compuesto componente = new Compuesto();
			componente.agregarHijo(calle);
			componente.agregarHijo(esquina);
			componente.agregarHijo(plaza);
			componente.agregarHijo(esquina);
			componente.agregarHijo(plaza);
			IDenuncia denuncia8 = new DenunciaDeLamparaQuemada(componente);
			denuncias_por_whatsapp.agregarDenuncia(denuncia8);
			
			IFabricaDeHeroes fabrica_medicos = new FabricaDeMedicos();
			IFabricaDeHeroes fabrica_policias = new FabricaDePolicias();
			IFabricaDeHeroes fabrica_electricistas = new FabricaDeElectricistas();
			
			//Encadeno los manejadores
			Manejador manejador = new BomberoProxy(null);
			manejador = new PoliciaProxy(manejador);
			manejador = new MedicoProxy(manejador);
			manejador = new ElectricistaProxy(manejador);
			
			//Atiendo todas las denuncias
			Operador911 operador = new Operador911(manejador);
			operador.atenderDenuncias(denuncias_por_whatsapp);
		}
		private static void Testing2() {
			
		}
		public static void Main(string[] args) {
			
			TestingStrategy();
			//TestingObserver();
			//TestingComposite();
			//TestingCommand();
			//TestingTemplateMethod();
			//TestingAdapter();
			//TestingBuilder();
			//TestingIterator();
			//TestingChainOfResponsability();
			//TestingAbstractFactory();
			//TestingProxy();
			
			
			
			
			
			
			Console.ReadKey(true);
		}
		
		
		private static ICuartel crearHeroe(IFabricaDeHeroes fabrica) {
			ICuartel cuartel = fabrica.crearCuartel();
			
			IResponsable responsable = fabrica.crearHeroe();
			IVehiculo vehiculo = fabrica.crearVehiculo();
			IHerramienta herramienta = fabrica.crearHerramienta();
			cuartel.agregarPersonal(responsable);
			cuartel.agregarVehiculo(vehiculo);
			cuartel.agregarHerramienta(herramienta);
			
			return cuartel;
		}
	}
}





/*:
	* Que se hace con la cantidad de personas, y si cantpersonas son los habitantes de la casa
	* Como hacer que nada más las plazas tengan los constructores, si las casas también son ilugares
	* //(LUGAR es lo que devuelve el toString del ILugar afectado)
	* 
*/

/*
 Preguntar si todos los cuarteles no pueden heredar los metodos de una clase abstracta Cuartel
 */
