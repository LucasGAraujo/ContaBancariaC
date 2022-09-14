using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Conta
{
    public abstract class Conta
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public Decimal Saldo { get; set; }

        public abstract void ExibirSaldo();

        public void ValidarAberturaConta()
        {
            if (DateTime.Now.Year - DataNascimento.Year < 18)
            {
                throw new Exception("Não pode criar uma conta sendo menor de idade");
            }
        }

        public void Transferir(Conta destino, Decimal valor)
        {
            if (this.Saldo <= 0)
            {
                throw new Exception("Não foi possivel transferir, pois seu saldo está zerado ou negativo");
            }

            if (this.Saldo < valor)
            {
                throw new Exception("Não foi possivel transferir, pois seu saldo é menor que o valor da transferencia");
            }

            destino.Depositar(valor);
            this.Saldo = this.Saldo - valor;
        }

        public void Depositar(decimal valor)
        {
            this.Saldo += valor;
        }
    }
}