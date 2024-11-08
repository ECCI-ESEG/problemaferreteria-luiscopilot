using System;
using System.Collections.Generic;

namespace Solucion
{
    public class Tabla
    {
        private double ancho;
        private double largo;
        private double precio;
        private double precioBase;
        public Tabla(double ancho, double largo, double precioBase)
        {
            this.ancho = ancho;
            this.largo = largo;
            this.precio = this.ancho * this.largo * precioBase;
            this.precioBase = precioBase;
        }

        public List<Tabla> cortarTabla(double anchoSolicitado, double largoSolicitado)
        {
            if (anchoSolicitado > this.ancho || largoSolicitado > this.largo)
            {
                throw new ArgumentException("No se puede cortar la tabla");
            }
            List<Tabla> tablas = new List<Tabla>();

            // Primer corte
            this.ancho = this.ancho - anchoSolicitado;
            // Caso cuadrado
            if (this.largo == largoSolicitado)
            {
                tablas.Add(new Tabla(anchoSolicitado, largoSolicitado, this.precioBase));
                return tablas;
            }

            // Segundo corte
            double nuevoLargo = this.largo - largoSolicitado;
            tablas.Add(new Tabla(anchoSolicitado, nuevoLargo, this.precioBase));
            tablas.Add(new Tabla(anchoSolicitado, largoSolicitado, this.precioBase));

            return tablas;
        }

        public void calcularPrecio()
        {
            this.precio = this.largo * this.ancho * this.precioBase;
        }
        public void setAncho(double ancho)
        {
            this.ancho = ancho;
        }

        public double getAncho()
        {
            return this.ancho;
        }
        public void setLargo(double largo)
        {
            this.largo = largo;
        }

        public double getLargo()
        {
            return this.largo;
        }

        public double getPrecio()
        {
            return this.precio;
        }

        public bool esMasGrande(Tabla tabla)
        {
            if (this.ancho > tabla.ancho)
            {
                return true;
            }

            return this.ancho == tabla.ancho && this.largo > tabla.largo;
        }

        public bool puedeCortar(double anchoSolicitado, double largoSolicitado)
        {
            return anchoSolicitado <= this.ancho && largoSolicitado <= this.largo;
        }
    }
}
