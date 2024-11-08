using System;

namespace Solucion
{
    public class Almacen
    {
        private List<Tabla> tablas;
        private int capacidadMaxima;
        public Almacen(int capacidadMaxima)
        {
            this.capacidadMaxima = capacidadMaxima;
            this.tablas = new List<Tabla>();
        }

        public void agregarTabla(Tabla tabla)
        {
            if (this.tablas.Count == this.capacidadMaxima)
            {
                throw new ArgumentException("No se pueden agregar más tablas");
            }
            this.tablas.Add(tabla);
        }

        public void ordenarAlmacen() 
        {
            this.tablas.Sort((t1, t2) =>
            {
                if (t1.esMasGrande(t2)) return 1;
                if (t2.esMasGrande(t1)) return -1;
                return 0;
            });
        }
    }
}
