using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadena_De_Responsabilidades
{
    public class Pedido
    {
        //atributos de la clase
        public string aprobador;
        public int valor;
        Ejecutivo[] unEjecutivo;

        //constructor de la clase
        public Pedido()
        {
            aprobador = "sin aprobación";
            valor = 0;
        }

        public Pedido(Ejecutivo[] arregloEjecutivos, string nombre, string cargo, int monto)
        {
            
        }

        //Propiedades para los atributos
        public string Aprobador
        {
            get { return aprobador; }
            set { aprobador = value; }
        }

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }
    }
}
