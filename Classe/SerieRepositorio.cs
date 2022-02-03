using System.Collections.Generic;
using DIO.Series.Interface;

namespace DIO.Series.Classe
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        public List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie objeto)
        {
            if ( id < listaSerie.Count)
            {
                listaSerie[id] = objeto;
            }
            else
            {
                System.Console.WriteLine($"Id: {id} - não encontrado !!!!");
            }
        }

        public void Exclui(int id)
        {
            if ( id < listaSerie.Count)
            {
                listaSerie[id].Excluir();
            }
            else
            {
                System.Console.WriteLine($"Id: {id} - não encontrado !!!!");
            }
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add( objeto );
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}