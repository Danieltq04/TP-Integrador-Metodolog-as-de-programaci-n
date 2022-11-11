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
	public interface ISector {
		void mojar(double agua);
		bool estaApagado();
		double getPorcentaje();
	}
	
	public class Sector : ISector {
		double porcentaje_afectado = 0;
		public Sector(double afectado) {
			porcentaje_afectado = afectado;
		}
		public void mojar(double agua) {
			//Console.WriteLine("Agua recibida para mojar = {0}", Math.Round(agua,2));
			porcentaje_afectado = Math.Round((porcentaje_afectado - agua),2);
			if(porcentaje_afectado<0) {
				porcentaje_afectado = 0;
			}
		}
		public double getPorcentaje() {
			return porcentaje_afectado;
		}
		public bool estaApagado() {
			if(porcentaje_afectado == 0){
				return true;
			}
			return false;
		}
	}
	
	public abstract class AdicionalDecorator : ISector{
		ISector adicional;
		public AdicionalDecorator(ISector variante){
			adicional = variante;
		}
		virtual public void mojar(double agua){
			if(adicional != null) {
				adicional.mojar(agua);
			}
		}
		virtual public bool estaApagado(){
			return adicional.estaApagado();
		}
		virtual public double getPorcentaje(){
			return adicional.getPorcentaje();
		}
	}
	public class PastoSeco : AdicionalDecorator {
		public PastoSeco(ISector variante) : base(variante) {
		}
		override public void mojar(double agua){
			base.mojar(agua /2);
		}
		override public bool estaApagado(){
			return base.estaApagado();
		}
		override public double getPorcentaje(){
			return base.getPorcentaje();
		}
	}
	public class ArbolesGrandes : AdicionalDecorator {

		public ArbolesGrandes(ISector variante) : base(variante) {
		}
		override public void mojar(double agua){
			base.mojar(agua - agua*25/100);
		}
		override public bool estaApagado(){
			return base.estaApagado();
		}
		override public double getPorcentaje(){
			return base.getPorcentaje();
		}
	}
	public class DiaDeMuchoCalor : AdicionalDecorator {
		int temperatura;
		public DiaDeMuchoCalor(int temp, ISector variante) : base(variante){
			temperatura = temp;
		}
		override public void mojar( double agua){
			base.mojar(agua - (0.1 * temperatura));
		}
		override public bool estaApagado(){
			return base.estaApagado();
		}
		override public double getPorcentaje(){
			return base.getPorcentaje();
		}
	}
	
	
	public class DiaVentoso : AdicionalDecorator {
		double velocidad_viento;
		public DiaVentoso(int velocidad, ISector variante) : base(variante){
			velocidad_viento = velocidad;
		}
		override public void mojar( double agua){
			base.mojar(agua - Math.Exp(velocidad_viento/100));
		}
		override public bool estaApagado(){
			return base.estaApagado();
		}
		override public double getPorcentaje(){
			return base.getPorcentaje();
		}
	}
	
	public class GenteAsustada : AdicionalDecorator {
		double cantidad_personas;
		int contador;
		public GenteAsustada(int personas, ISector variante) : base(variante){
			cantidad_personas = personas;
			contador = 0;
		}
		override public void mojar( double agua){
			if (contador<cantidad_personas) {
				//Console.WriteLine("Contador: "+contador+", gente asustada: "+cantidad_personas+", le paso "+(agua - agua*75/100));
				//Console.ReadKey(true);
				contador++;
				base.mojar(agua - agua*75/100);
			}
			else {
				//Console.WriteLine("Contador : "+contador+" le paso "+agua);
				base.mojar(agua);
			}
		}
		override public bool estaApagado(){
			return base.estaApagado();
		}
		override public double getPorcentaje(){
			return base.getPorcentaje();
		}
	}
	
	public class DiaLLuvioso : AdicionalDecorator {
		double intensidad_lluvia;
		public DiaLLuvioso(int lluvia, ISector variante) : base(variante){
			intensidad_lluvia = lluvia;
		}
		override public void mojar( double agua){
			base.mojar(agua + intensidad_lluvia);
		}
		override public bool estaApagado(){
			return base.estaApagado();
		}
		override public double getPorcentaje(){
			return base.getPorcentaje();
		}
	}
}
