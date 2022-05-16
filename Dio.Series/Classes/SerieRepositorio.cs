using System;
using System.Collections.Generic;
using Dio.Series.Interfaces;

namespace Dio.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        //  Variaveis
        private List<Serie> listaSerie = new();

        //  Métodos
        public void Atualiza(int id, Serie serie)
        {
            listaSerie[id] = serie;
        }
        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }
        public void Insere(Serie serie)
        {
            listaSerie.Add(serie);
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