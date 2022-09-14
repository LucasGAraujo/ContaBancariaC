using ContaBancaria.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria
{
    public class ContaManager
    {
        private IContaRepository ContaRepository { get; set; }

        public ContaManager(IContaRepository contaRepository)
        {
            ContaRepository = contaRepository;
        }

        public void Cadastrar(Conta.Conta conta)
        {
            this.ContaRepository.Cadastrar(conta);
        }

        public List<Conta.Conta> ObterContas(string cpf)
        {
            return this.ContaRepository.ObterPorCPF(cpf);
        }

        public void Atualizar(Conta.Conta conta)
        {
            this.ContaRepository.Atualizar(conta);

        }
    }
}
