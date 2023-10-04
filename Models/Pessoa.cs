namespace SistemaDeHospedagemDeUmHotel.Models;

public class Pessoa
{
    public Pessoa() { }

    public Pessoa(string nome)
    {
        Nome = nome;
    }

    public Pessoa(string nome, string sobrenome)
    {
        if (nome == "")
        {    
            throw new Exception();    
        }
        else
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
    }

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string NomeCompleto => $"{Nome.Substring(0, 1).ToUpper() + Nome.Substring(1).ToLower()}"
                        + " " + $"{Sobrenome.Substring(0, 1).ToUpper() + Sobrenome.Substring(1).ToLower()}";
    
}