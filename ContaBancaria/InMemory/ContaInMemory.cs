using ContaBancaria.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.InMemory
{
    public class ContaInMemory : IContaRepository
    {
        private bool disposedValue;

        private List<Conta.Conta> Contas { get; set; } = new List<Conta.Conta>();

        public void Atualizar(Conta.Conta conta)
        {
            var index = Contas.IndexOf(conta);
            Contas[index] = conta;
        }

        public void Cadastrar(Conta.Conta conta)
        {
            Contas.Add(conta);
        }

        public List<Conta.Conta> ObterPorCPF(string cpf)
        {
            return this.Contas.Where(x => x.CPF == cpf).ToList();

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}