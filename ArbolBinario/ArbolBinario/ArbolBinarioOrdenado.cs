using System;

namespace EstructuraDeDatos
{
    public class ArbolBinarioOrdenado
    {
        class Nodo
        {
            public int info;
			public int nivel;
            public Nodo izq, der;
        }
        private Nodo raiz;
        private int cant;
        private int altura;

        public ArbolBinarioOrdenado()
        {
            raiz = null;
        }

        public void Insertar(int info)
        {
            if (!Existe(info))
            {
                Nodo nuevo;
                nuevo = new Nodo();
                nuevo.info = info;
                nuevo.izq = null;
                nuevo.der = null;
                if (raiz == null)
                    raiz = nuevo;
                else
                {
                    Nodo anterior = null, reco;
                    reco = raiz;
                    while (reco != null)
                    {
                        anterior = reco;
                        if (info < reco.info)
                            reco = reco.izq;
                        else
                            reco = reco.der;
                    }
                    if (info < anterior.info)
                        anterior.izq = nuevo;
                    else
                        anterior.der = nuevo;
                }
            }
        }

        public bool Existe(int info)
        {
            Nodo reco = raiz;
            while (reco != null)
            {
                if (info == reco.info)
                    return true;
                else
                    if (info > reco.info)
                    reco = reco.der;
                else
                    reco = reco.izq;
            }
            return false;
        }

		private Nodo Buscar(int info) 
		{
			Nodo reco = raiz;
			while (reco != null)
			{
				if (info == reco.info)
					return reco;
				else
					if (info > reco.info)
						reco = reco.der;
					else
						reco = reco.izq;
			}
			return null;
		}

		public void BuscarValor(int info)
		{
			Nodo nodo = Buscar (info);
			if (nodo != null) {
				Console.WriteLine ("Nodo: " + nodo.info + " Nivel: " + nodo.nivel);
			} else {
				Console.WriteLine ("Valor no encontrado");
			}
		}

        private void ImprimirEntre(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirEntre(reco.izq);
                Console.Write(reco.info + " ");
                ImprimirEntre(reco.der);
            }
        }

        public void ImprimirEntre()
        {
            ImprimirEntre(raiz);
            Console.WriteLine();
        }


        private void Cantidad(Nodo reco)
        {
            if (reco != null)
            {
                cant++;
                Cantidad(reco.izq);
                Cantidad(reco.der);
            }
        }

        public int Cantidad()
        {
            cant = 0;
            Cantidad(raiz);
            return cant;
        }

        private void CantidadNodosHoja(Nodo reco)
        {
            if (reco != null)
            {
                if (reco.izq == null && reco.der == null)
                    cant++;
                CantidadNodosHoja(reco.izq);
                CantidadNodosHoja(reco.der);
            }
        }

        public int CantidadNodosHoja()
        {
            cant = 0;
            CantidadNodosHoja(raiz);
            return cant;
        }

        private void ImprimirEntreConNivel(Nodo reco, int nivel)
        {
            if (reco != null)
            {
                ImprimirEntreConNivel(reco.izq, nivel + 1);
                Console.Write(reco.info + " (" + nivel + ") - ");
                ImprimirEntreConNivel(reco.der, nivel + 1);
            }
        }

        public void ImprimirEntreConNivel()
        {
            ImprimirEntreConNivel(raiz, 1);
            Console.WriteLine();
        }

        private void RetornarAltura(Nodo reco, int nivel)
        {
            if (reco != null)
            {
                RetornarAltura(reco.izq, nivel + 1);
				if (nivel > altura)
				{
					altura = nivel;
					reco.nivel = nivel;
				}
                RetornarAltura(reco.der, nivel + 1);
            }
        }

        public int RetornarAltura()
        {
            altura = 0;
            RetornarAltura(raiz, 1);
            return altura;
        }

        public void MayorValorl()
        {
            if (raiz != null)
            {
                Nodo reco = raiz;
                while (reco.der != null)
                    reco = reco.der;
                Console.WriteLine("Mayor valor del árbol:" + reco.info);
            }
        }

        public void BorrarMenor()
        {
            if (raiz != null)
            {
                if (raiz.izq == null)
                    raiz = raiz.der;
                else
                {
                    Nodo atras = raiz;
                    Nodo reco = raiz.izq;
                    while (reco.izq != null)
                    {
                        atras = reco;
                        reco = reco.izq;
                    }
                    atras.izq = reco.der;
                }
            }
        }
    }
}
