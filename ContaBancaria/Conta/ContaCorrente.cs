using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Conta
{
    public class ContaCorrente : Conta
    {
        public override void ExibirSaldo()
        {
            if (this.Saldo < 0)
            {
                var saldoAtual = this.Saldo - (this.Saldo * 0.10M);
                Console.WriteLine($"O Saldo para a sua conta poupança é {saldoAtual}");
            }
            else
            {
                Console.WriteLine($"O Saldo para a sua conta corrente é {this.Saldo}");
            }

        }

    }
}