using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente Conta = new ContaCorrente(847,489754);
            Console.WriteLine(Conta.Numero);
            Console.ReadLine();
        }
    }
}
