using ByteBank.Modelos;
using Humanizer;
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
            DateTime datafimPagamento = new DateTime(2020, 06, 03);

            DateTime datacorrente = DateTime.Now;

            TimeSpan Diferença = TimeSpan.FromMinutes(20); //datafimPagamento - datacorrente;
            
            
            string Mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(Diferença);
            Console.WriteLine(Mensagem);

            Console.ReadLine();
        }
        
        
    }
}
