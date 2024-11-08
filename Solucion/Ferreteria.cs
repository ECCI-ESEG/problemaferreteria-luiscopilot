using System;

namespace Solucion
{
    public class Ferreteria
    {
        private Almacen almacen;
        public Ferreteria(double anchoInicial, double largoInicial, double precioBase)
        {
            this.almacen = new Almacen(500);
            this.almacen.agregarTabla(new Tabla(anchoInicial, largoInicial, precioBase));
        }

        
        public double ProcesarSolicitud(double anchoSolicitado, double largoSolicitado)
        {


            return 0;
        }
    }
}