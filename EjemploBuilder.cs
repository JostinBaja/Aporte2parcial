using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Nombres y apeliidos : Jostin Alexander Bajaña Bravo
 * Paralelo : B
 * Nivel : 3er semestres
 * Ejemplo con la implementacion del patron de diseño builder
 */
namespace AporteBuilder
{
    class EjemploBuilder
    {
        static void Main(string[] args)
        {
            var cocina = new Cocina();

            // El cliente tiene como pedido en especifico un chaulafan mixto 
            // Se seara de esta maner la cocina por la implementacion del del diseño builder
            cocina.Recepciondechaulafan(new Chaulafanmixto(" Mixto"));
            cocina.Cocinarchaulafanenpasos();
            var Chaulafancontressalsas = cocina.ChaulafanListo;

        }

        // Aqui estan algunas partes importantes del producto final del consumidor
        public class Chaulafan
        {
            public string Cantidad { get; set; } // Cantidad de salsa
            public string Salsa { get; set; }  // Tipo de salsa
            public string tamaño { get; set; }  // Tamaño de chaulafan
            public string Caja { get; set; }   // Tipo de caja preferida

            public Chaulafan()
            {

            }

            public Chaulafan(string caja, string cantidad, string salsa) : this()
            {
                Caja = caja;
                Cantidad = cantidad;
                Salsa = salsa;
               
            }
        }

        // Implementacion del builder 
        public abstract class chaulafanbuilders
        {
            // chaulafan esta con la funcion protected para que las clases que implementen si puedan acceder
            protected Chaulafan chaulafan;
            public string Tamaño { get; set; }
           
            // Se obtiene y se retorna el chaulafan
            public Chaulafan Obtenerchaulafan() { return chaulafan; }


            // Dada la implementacion del patron de diseño builder se separan estos pasos.
            // En esta parte del codigo se especifican algunos de los pasos
            // importantes que deben llevar las propiedades que fueron descritas al
            // Principio
            public virtual void Preaparalosfideo() // Paso 1
            {

            }

            public virtual void SeAñadesalsa() // Paso 2
            {

            }

            public virtual void Sepreparalacaja() // Paso 3
            {

            }
        }
        // aqui realizamos un builder en concreto el cual de igual manera tambien se especifican los pasos 
        // para preparar la orden del chaulafan con los requerimientos del usuario, 
        // Cada paso que vemos en el codigo es referenciado con que caja desea y con que 
        // Salsa desea.
        public class Chaulafanmixto : chaulafanbuilders
        {
            public Chaulafanmixto(string tamaño)
            {
                chaulafan = new Chaulafan
                {
                    Caja = tamaño
                };
            }
            // Se prepara los fideos del chaulafan
            public override void Preaparalosfideo()
            {
            }
            // Se añade la salsa correspondiente al chaulafan
            public override void SeAñadesalsa()
            {
                chaulafan.Salsa = " Salsa china";
            }
            // Se prepara la caja para insertar el chaulfana completo
            public override void Sepreparalacaja()
            {
                chaulafan.tamaño = " Grande";
            }
        }

        // Se construye un objeto implementando que fue descrita como builder
        public class Cocina
        {
            private chaulafanbuilders Chaulfansitobuilder;
           
            // Se recepta el pedido del chaulafan 
            public void Recepciondechaulafan(chaulafanbuilders Chaulafanbuilderpro)
            {
                Chaulfansitobuilder = Chaulafanbuilderpro;
            }
            // Este metodo cocina el chaulafan con los pasos descritos anterior mente 
            public void Cocinarchaulafanenpasos()
            {
                Chaulfansitobuilder.Preaparalosfideo(); // Prepara fideos
                Chaulfansitobuilder.SeAñadesalsa();     // añade saldsa
                Chaulfansitobuilder.Sepreparalacaja();  // Preparacion de caja
            }
            // Por ultimo este metodolo que hace es tener ya el
            // El pedido Listo para el respectivo consumo
            public Chaulafan ChaulafanListo
            {
                get { return Chaulfansitobuilder.Obtenerchaulafan(); }

            }
        }
    }
}