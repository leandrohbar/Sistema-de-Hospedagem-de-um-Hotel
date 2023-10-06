using System.Linq.Expressions;
using System.Text;
using SistemaDeHospedagemDeUmHotel.Models;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Bem vindo ao sistema de hospedagem de um hotel");

int diasReservados;
while (true)
{
    Console.Write("Digite a quantidade de dias que deseja reservar: ");
    if (int.TryParse(Console.ReadLine(), out diasReservados) && diasReservados > 0)
    {
        break;
    }
    Console.WriteLine("A quantidade de dias deve ser um número inteiro e deve ser maior que 0");
}
// Instanciar a classe Reserva
Reserva reserva = new Reserva(diasReservados: diasReservados);

while (true)
{ // Menu principal
    Console.Clear();
    
    Console.WriteLine("O que deseja fazer?");
    Console.WriteLine("1 - Escolher suíte");
    Console.WriteLine("2 - Cadastrar hóspedes");
    Console.WriteLine("3 - Fazer reserva");
    Console.WriteLine("4 - Sair");
    Console.Write("Digite a opção desejada: ");
    Console.WriteLine();


    switch (Console.ReadLine())
    { // Menu de opções
        case "2": // Cadastrar hóspedes
            if (reserva.Suite == null)
            {// Verificar se a suíte foi escolhida
                Console.WriteLine("Escolha uma suíte antes de cadastrar os hóspedes");
                break;
            }

            try // Verificar se a quantidade de hóspedes é maior que a capacidade da suíte
            {
                Console.WriteLine();
                Console.Write("Quantos hóspedes deseja cadastrar? ");
                List<Pessoa> hospede = new List<Pessoa>(Convert.ToInt32(Console.ReadLine()));
                reserva.CapacidadeHospedes(hospede);

                if (reserva.Hospedes == null)
                {
                    break;
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Cadastre pelo menos um hóspede");
                break;
            }
            
            // Cadastrar hóspedes
            for (int i = 0; i < reserva.Hospedes.Capacity; i++)
                {
                try
                    {
                    Console.WriteLine("Digite o NOME do hóspede e aperte ENTER "
                    + "em seguida digite o SOBRENOME do hóspede: ");

                    string nome = Console.ReadLine();
                    string sobrenome = Console.ReadLine();
                    reserva.Hospedes.Add(new Pessoa(nome: nome,sobrenome: sobrenome));
                    }
                catch (Exception)
                {
                    Console.WriteLine("Nome e sobrenome não podem estar vazios");
                    break;
                }
                }
            break;
        case "1": // Escolher suíte
            TiposSuite tiposSuite = new TiposSuite();
            Console.WriteLine("Escolha uma suíte disponível: ");
            Console.WriteLine();
            
            for (int i = 0; i < tiposSuite.NomesSuite.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {tiposSuite.NomesSuite[i].nome} com "
                + $"capacidade para {tiposSuite.NomesSuite[i].capacidade} pessoas, "
                + $"valor da diária: {tiposSuite.NomesSuite[i].preco:C}");
            }
            
            Console.WriteLine();
            Console.Write("Digite a opção desejada: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            Suite suite = new Suite(
            tipoSuite: tiposSuite.NomesSuite[opcao - 1].nome,
            capacidade: tiposSuite.NomesSuite[opcao - 1].capacidade,
            valorDiaria: tiposSuite.NomesSuite[opcao - 1].preco);
            
            reserva.CadastrarSuite(suite);

            break;
        case "3": // Fazer reserva
            if (reserva.Hospedes == null)
            {
                Console.WriteLine("Cadastrae os hóspedes primeiro");
                break;
            }
            
            Console.WriteLine("\nConfira suas informações: ");
            Console.WriteLine($"Tipo de quarto: {reserva.Suite.TipoSuite}");
            Console.WriteLine($"Valor diária: {reserva.Suite.ValorDiaria:C}");
            Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Dias reservados: {reserva.DiasReservados}");
            Console.WriteLine("\nDeseja confirmar a reserva? (S/N)");

            if (Console.ReadLine().ToUpper() == "S")
            {
                Console.WriteLine("Reserva confirmada!");
                if (reserva.DiasReservados < 10)
                {    
                    Console.WriteLine($"Valor total: {reserva.Suite.ValorDiaria * reserva.DiasReservados:C}");
                }
                else
                {
                    decimal desconto = reserva.Suite.ValorDiaria * reserva.DiasReservados * 0.1m;
                    Console.WriteLine($"Valor total: {reserva.Suite.ValorDiaria * reserva.DiasReservados - desconto:C}");
                }
            }
            else
            {
                Console.WriteLine("Reserva cancelada!");
                break;
            }
            break;
        case "4": // Sair
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
    
    Console.Write("Pressione qualquer tecla para continuar...");
    Console.ReadKey();


}