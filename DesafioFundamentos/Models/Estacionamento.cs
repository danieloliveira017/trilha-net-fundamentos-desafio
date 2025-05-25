namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento()
        {

        }

        public void AddPrecos()
        {
            precoInicial = ValidarEntradaDecimal("Digite o valor inciial: ");
            precoPorHora = ValidarEntradaDecimal("Digite o valor da hora: ");
        }

        public void AdicionarVeiculo()
        {

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Erro: Placa invalida");
                return;
            }
            if (veiculos.Any(v => v.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Carro ja estacionado");
                return;
            }
            veiculos.Add(placa.ToUpper());
            Console.WriteLine($"Veiculo adicionado com sucesso {placa.ToUpper()}");


        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");


            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horasValor = 0;
                bool entradaValida = false;

                while (!entradaValida)
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");


                    string horosEstacionada = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(horosEstacionada))
                    {
                        Console.WriteLine("Favor de digitar a hora estacionada");
                        continue;
                    }

                    if (!int.TryParse(horosEstacionada, out horasValor) || horasValor < 0)
                    {
                        Console.WriteLine("Digite um número inteiro válido e maior ou igual a zero.");
                        continue;
                    }

                    int horas = int.Parse(horosEstacionada);
                    decimal valorTotal = precoInicial + (horas * precoPorHora);



                    veiculos.RemoveAll(v => v.Equals(placa, StringComparison.CurrentCultureIgnoreCase));

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    entradaValida = true;
                }


            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {


            if (veiculos.Any())
            {
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Os veículos estacionados são: {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }


        //  Metodo para validar entradas dos valores 
        private static decimal ValidarEntradaDecimal(string msg)
        {
            decimal valores;
            string entrada;

            while (true)
            {
                Console.WriteLine(msg);
                entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("Error: Valor nao digitado");
                    continue;
                }
                if (!decimal.TryParse(entrada, out valores))
                {
                    Console.WriteLine("Error: Valor errado digite um numero!");
                    continue;
                }
                if (valores < 0)
                {
                    Console.WriteLine("Error: o valor nao pode ser menor que 0");
                    continue;
                }
                break;
            }

            return valores;

        }



    }
}