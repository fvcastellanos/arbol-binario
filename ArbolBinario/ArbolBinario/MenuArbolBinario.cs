using System;
using EstructuraDeDatos;

namespace ArbolBinario
{
	public class MenuArbolBinario
	{
		private ArbolBinarioOrdenado arbolBinario;

		public MenuArbolBinario ()
		{
			arbolBinario = new ArbolBinarioOrdenado ();
		}

		private void MostrarMenuPrincipal()
		{
			Console.WriteLine ("1. Agregar un numero");
			Console.WriteLine ("2. Eliminar un numero");
			Console.WriteLine ("3. Mostrar nivel de profunidad de un nodo");
			Console.WriteLine ("4. EntreOden");

			Console.WriteLine ("5. Salir");
			Console.Write ("Ingrese una opcion: ");
		}

		private int solicitarNumero()
		{
			Console.WriteLine ("Ingrese un numero: ");
			string valor = Console.ReadLine ();
			return int.Parse (valor);
		}

		public void MenuPrincipal()
		{
			string opcion = "";
			int opc = 0;
			while (opc != 5)
			{
				MostrarMenuPrincipal ();
				opcion = Console.ReadLine ();
				opc = int.Parse (opcion);

				switch (opc)
				{
				case 1:
					arbolBinario.Insertar (solicitarNumero ());
						break;
					case 2:
						break;
				case 3:
					arbolBinario.BuscarValor (solicitarNumero ());
						break;
				case 4:
					arbolBinario.ImprimirEntreConNivel ();
					break;
				}

			}
		}

	}
}

