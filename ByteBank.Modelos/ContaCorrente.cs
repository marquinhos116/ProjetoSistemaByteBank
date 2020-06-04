using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{   /// <summary>
/// Define uma Classe ContaCorreente do Projeto ByteBank.SistemaInterno.
/// </summary>
    public class ContaCorrente
    {
        private static int TaxaOperacao;

        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }
        /// <summary>
        /// cria Uma Instancia ContaCorrente com os atributos utilizados.
        /// </summary>
        /// <param name="agencia"> Representa a propriedade <see cref="Agencia"/> e o  Valor Declarado deve ser maior que Zero.</param> 
        /// <param name="numero">Representa a propriedade <see cref="Numero"/> e o  Valor Declarado deve ser maior que Zero.</param>
        public ContaCorrente(int agencia, int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }
        /// <summary>
        /// Realiza o saque e atualiza o Valor da propriedade <see cref="Saldo"/>see
        /// </summary><exception cref="ArgumentException">  exeção Lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/></exception>
        /// <exception cref="SaldoInsuficienteException">Exeção lançada quando o valor de <paramref name="valor"/> é maior que a propriedade <see cref="Saldo"/></exception>
        /// <param name="valor">Representa o Valor do Saque, deve ser maior que zero e menor que <see cref="Saldo"/></param>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }
    }

}
