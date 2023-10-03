using System.Linq.Expressions;
using System.Text;
using SistemaDeHospedagemDeUmHotel.Models;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Bem vindo ao sistema de hospedagem de um hotel");
Console.Write("Digite a quantidade de dias que deseja reservar: ");
int diasReservados = Convert.ToInt32(Console.ReadLine());
Reserva reserva = new Reserva(diasReservados: diasReservados);

while (true)
{
    Console.Clear();
    
    Console.WriteLine("O que deseja fazer?");
    Console.WriteLine("1 - Escolher suíte");
    Console.WriteLine("2 - Cadastrar hóspedes");
    Console.WriteLine("3 - Fazer reserva");
    Console.WriteLine("4 - Sair");
    Console.Write("Digite a opção desejada: ");
    Console.WriteLine();


    switch (Console.ReadLine())
    {
        case "2":
            if (reserva.Suite == null)
            {
                Console.WriteLine("Escolha uma suíte antes de cadastrar os hóspedes");
                break;
            }

            Console.WriteLine();
            Console.Write("Quantos hóspedes deseja cadastrar? ");
            List<Pessoa> hospede = new List<Pessoa>(Convert.ToInt32(Console.ReadLine()));

            if (reserva.Suite.Capacidade < hospede.Capacity)
            {
                Console.WriteLine("A quantidade de hóspedes é maior que a capacidade da suíte"
                + " escolha outra suíte ou diminua a quantidade de hóspedes.");
                break;
            }
            

            for (int i = 0; i < hospede.Capacity; i++)
                {
                Console.WriteLine("Digite o NOME do hóspede e aperte ENTER "
                + "em seguida digite o SOBRENOME do hóspede: ");

                string nome = Console.ReadLine();
                string sobrenome = Console.ReadLine();
                hospede.Add(new Pessoa(nome: nome,sobrenome: sobrenome));
                }

            reserva.CadastrarHospedes(hospede);
            
            break;
        case "1":
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
        case "3":
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
        case "4":
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