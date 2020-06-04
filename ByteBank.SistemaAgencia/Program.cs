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
            ContaCorrente Conta = new ContaCorrente(123,456);
            
            Console.WriteLine(Conta.Numero);

            Conta.Sacar(10);
            
            
            
            Console.ReadLine();
        }
    }
}
