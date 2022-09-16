using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Conta
{
    public class ContaPoupanca : Conta
    {
        public override void ExibirSaldo()
        {
            var saldoAtual = this.Saldo * (1.05M);

            Console.WriteLine($"O Saldo para a sua conta poupança é {saldoAtual}");

        }
    }
}
