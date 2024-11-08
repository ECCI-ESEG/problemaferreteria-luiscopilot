using System;

namespace Solucion
{
    public class Ferreteria
    {
        private Almacen almacen;
        private double precioBase;
        private double anchoInicial;
        private double largoInicial;
        public Ferreteria(double anchoInicial, double largoInicial, double precioBase)
        {
            this.precioBase = precioBase;
            this.anchoInicial = anchoInicial;
            this.largoInicial = largoInicial;

            this.almacen = new Almacen(500);
            this.almacen.agregarTabla(new Tabla(anchoInicial, largoInicial, precioBase));
        }

        
        public double ProcesarSolicitud(double anchoSolicitado, double largoSolicitado)
        {

            // Es imposible cortar una tabla mas grande que la inicial
            if (anchoSolicitado > this.anchoInicial || largoSolicitado > this.largoInicial)
            {
                return -1;
            }

            // Intente cortar o si ya la tiene retorne esa
            foreach (var tabla in this.almacen.getTablas())
            {
                if (tabla.puedeCortar(anchoSolicitado, largoSolicitado))
                {
                    List<Tabla> tablasCortadas = tabla.cortarTabla(anchoSolicitado, largoSolicitado);
                    
                    if (tablasCortadas.Count == 2)
                    {
                        this.almacen.agregarTabla(tablasCortadas[1]);
                    }

                    this.almacen.ordenarAlmacen();
                    
                    return tablasCortadas[0].getPrecio();
                }
            }
            
            // No pudo cortar ninguna tabla, toca usar la base

            Tabla tablaBase = new Tabla(this.anchoInicial, this.largoInicial, this.precioBase);
            List<Tabla> tablasCortadasBase = tablaBase.cortarTabla(anchoSolicitado, largoSolicitado);
            if (tablasCortadasBase.Count == 2)
            {
                this.almacen.agregarTabla(tablasCortadasBase[1]);
            }
            this.almacen.agregarTabla(tablaBase);
            this.almacen.ordenarAlmacen();


            return tablasCortadasBase[0].getPrecio();
        }
    }
}