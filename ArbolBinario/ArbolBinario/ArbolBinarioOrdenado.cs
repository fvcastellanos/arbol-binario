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

            // Esta forma es muy ineficiente, se deberia de calcular el nivel cuando se inserta el nodo
            CalcularNivel();
        }

        public bool Existe(int info)
        {
            Nodo nodo = Buscar(info);
            if(nodo != null)
            {
                return true;
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
            Nodo nodo = Buscar(info);
            if (nodo != null) {
                Console.WriteLine("Nodo: " + nodo.info + " Nivel: " + nodo.nivel);
            } else {
                Console.WriteLine("Valor no encontrado");
            }
        }

        private bool EsHoja(Nodo nodo)
        {
            if((nodo.izq == null) && (nodo.der == null))
            {
                return true;
            }

            return false;
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

        private void ImprimirEntreConNivel(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirEntreConNivel(reco.izq);
                Console.WriteLine("Nodo: " + reco.info + " Nivel: [" + reco.nivel + "]");
                ImprimirEntreConNivel(reco.der);
            }
        }

        private void CalcularNivel(Nodo reco, int nivel)
        {
            if(reco != null)
            {
                CalcularNivel(reco.izq, nivel + 1);
                reco.nivel = nivel + 1;
                CalcularNivel(reco.der, nivel + 1);
            }
        }

        private void CalcularNivel()
        {
            int nivel = 0;
            CalcularNivel(raiz, nivel);
        }

        public void ImprimirEntreConNivel()
        {
            Console.WriteLine("Imprime entre orden con nivel: ");
            ImprimirEntreConNivel(raiz);
            Console.WriteLine();
        }


        private void EliminarHoja(Nodo nodo, Nodo padre)
        {
            if (padre == null)
            {
                // La raiz es el unico elemento del arbol
                raiz = null;
            }
            else
            {
                if (padre.der == nodo)
                {
                    padre.der = null;
                }
                else if (padre.izq == nodo)
                {
                    padre.izq = null;
                }
            }

        }

        public void Borrar(int valor)
        {
            Nodo reco = raiz;
            Nodo padre = null;
            Nodo nodo = null;

            while (reco != null)
            {
                if (valor == reco.info)
                {
                    if(EsHoja(reco))
                    {
                        EliminarHoja(reco, padre);
                        break;
                    }
                    else
                    {
                        padre = reco;
                        if(reco.der != null)
                        {
                            nodo = reco.der;
                            while(nodo.izq != null)
                            {
                                padre = nodo;
                                nodo = nodo.izq;
                            }
                        }
                        else
                        {
                            nodo = reco.izq;
                            while(nodo.der != null)
                            {
                                padre = nodo;
                                nodo = nodo.der;
                            }
                        }

                        int aux = reco.info;
                        reco.info = nodo.info;
                        nodo.info = aux;
                        reco = nodo;
                    }
                }
                else
                {
                    padre = reco;
                    if (valor > reco.info)
                        reco = reco.der;
                    else
                        reco = reco.izq;
                }
            }

            CalcularNivel();
        }
    }
}
