using ContaBancaria.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Interface
{
    public interface IContaRepository : IDisposable
    {
        void Cadastrar(Conta.Conta conta);
        List<Conta.Conta> ObterPorCPF(string cpf);
        void Atualizar(Conta.Conta conta);

    }
}