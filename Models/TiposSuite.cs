using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeHospedagemDeUmHotel.Models
{
    public class TiposSuite
    {
        public List<(string nome, int capacidade, decimal preco)> NomesSuite 
        { 
            get{
                return new List<(string nome, int capacidade, decimal preco)>()
                {
                    (nome: "Quarto de Solteiro", capacidade: 1, preco: 20.00m),
                    (nome: "Duplo Solteiro", capacidade: 2, preco: 50.00m),
                    (nome: "Quarto Casal", capacidade: 2, preco: 70.00m),
                    (nome: "Apartamentos", capacidade: 8, preco: 200.00m),
                    (nome: "Dormitórios", capacidade: 10, preco: 150.00m),

                };
                }
        }
    }
}