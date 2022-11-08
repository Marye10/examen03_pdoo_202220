using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadena_De_Responsabilidades
{
    public  class Program
    {
        static public void Main(string[] args)
        {
            Console.WriteLine("Patrón GoF - Cadena de Responsabilidad");
            Console.WriteLine("Aprobación de Pedidos");

            Ejecutivo[] JerarquiaEjecutivos = new Ejecutivo[3];
            JerarquiaEjecutivos[0] = new Coordinador();
            JerarquiaEjecutivos[1] = new Director();
            JerarquiaEjecutivos[2] = new Presidente();

            //Aqui definimos nombres, montos y jefes
            for (int i = 0; i < JerarquiaEjecutivos.Length; i++)
            {
                AsignaValoresEjecutivo(JerarquiaEjecutivos[i]);

                //Aqui asignamos los jefes
                if (i < JerarquiaEjecutivos.Length - 1)
                    JerarquiaEjecutivos[i].AsignaJefe(JerarquiaEjecutivos[i + 1]);
            }

            //2 - Validar que los montos de aprobación estén de acuerdo a la jerarquía
            string resultadoEvaluacion;
            bool evaluacionJerarquiaCorrecta = EvaluaJerarquia(JerarquiaEjecutivos, out resultadoEvaluacion);

            if (evaluacionJerarquiaCorrecta == false)
            {
                Console.WriteLine("La jerarquía de ejecutivos no es válida");
                Console.WriteLine($"{resultadoEvaluacion}");
            }
            else
            {
                //De lo contrario, la jerarquía es correcta podemos hacer el pedido de compra
                Console.WriteLine("Jerarquía de ejecutivos es correcta!");

                //3 - Leer la información del pedido
                Pedido elPedido = new Pedido();
                bool valorPedidoCorrecto = false;

                do
                {
                    try
                    {
                        Console.Write("\nIngresa el valor del pedido: ");
                        elPedido.Valor = int.Parse(Console.ReadLine());
                        valorPedidoCorrecto = true;
                    }
                    catch (FormatException elError)
                    {
                        Console.WriteLine("El valor ingresado no es un dato numérico. Intenta nuevamente!");
                        Console.WriteLine(elError.Message);
                    }
                }
                while (valorPedidoCorrecto == false);

                //4 - Iniciar la cadena de aprobación según la jerarquía de ejecutivos
                JerarquiaEjecutivos[0].ProcesaPedido(elPedido);

                //5 - Visualizar resultados de la aprobación
                Console.WriteLine($"El resultado del proceso de validación es \n" +
                    $"{elPedido.Aprobador}");
            }
            //4.5 quién aprueba el pedido?
            Pedido unPedido = new Pedido(); 
            string AprobacionPedido()
            {
                string quienAprobo;
                //si el monto es menor que JerarquiaEjecutivo[0], es aprobado por coordinador
                if (JerarquiaEjecutivos[0].Monto > unPedido.Valor)
                {
                    quienAprobo = unPedido.Aprobador;
                }
                //si el monto es mayor que JerarquiaEjecutivo[0], es aprobado por director
                if (JerarquiaEjecutivos[0].Monto < unPedido.Valor)
                {
                    quienAprobo = unPedido.Aprobador;
                }
                //si el monto es mayor que JerarquiaEjecutivo[1], es aprobado por presidente
                if (JerarquiaEjecutivos[1].Monto > unPedido.Valor)
                {
                    quienAprobo = unPedido.Aprobador;
                }
                return quienAprobo;
            }

            //Evalua si la jerarquia es válida para aprobar pedidos
            bool EvaluaJerarquia(Ejecutivo[] losEjecutivos, out string mensajeError)
            {
                bool resultado = false;
                mensajeError = "";

                //aqui verificamos que tengan valores asignados diferentes a los predeterminados
                if (losEjecutivos[0].Monto > 0 && losEjecutivos[1].Monto > 0 && losEjecutivos[2].Monto > 0)
                {
                    //aqui validamos que los valores estén escalonados de menor a mayor
                    if (losEjecutivos[0].Monto < losEjecutivos[1].Monto && losEjecutivos[1].Monto < losEjecutivos[2].Monto)
                    {
                        resultado = true;
                        mensajeError = "Jerarquia Válida";
                    }
                    else
                    {
                        resultado = false;
                        mensajeError = "Montos no definen jerarquia de aprobación";
                    }
                }
                else
                {
                    resultado = false;
                    mensajeError = "No se han asignado valores o los valores son negativos para los montos de los ejecutivos!";
                }

                return resultado;
            }

            void AsignaValoresEjecutivo(Ejecutivo unEjecutivo)
            {
                bool datosCorrectos = false;

                do
                {
                    try
                    {
                        Console.Write($"\nIngresa el nombre del {unEjecutivo.Cargo}: ");
                        unEjecutivo.Nombre = Console.ReadLine();

                        Console.Write("Ingresa el monto máximo de aprobación: ");
                        unEjecutivo.Monto = int.Parse(Console.ReadLine());

                        datosCorrectos = true;
                    }
                    catch (FormatException elError)
                    {
                        Console.WriteLine("El monto ingresado no es un dato numérico. Intenta nuevamente!");
                        Console.WriteLine(elError.Message);
                    }
                }
                while (datosCorrectos == false);
            }
        }
    }
}
