using ContaBancaria.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.InFile
{
    public class ContaInFile : IContaRepository
    {
        private bool disposedValue;

        private List<Conta.Conta> Contas { get; set; }

        public ContaInFile()
        {
            LerArquivo();
        }

        private void LerArquivo()
        {
            using var file = File.Open("Contas.json", FileMode.OpenOrCreate, FileAccess.Read);
            using var reader = new StreamReader(file);

            var json = reader.ReadToEnd();
            this.Contas = JsonConvert.DeserializeObject<List<ContaBancaria.Conta.Conta>>(json);
            reader.Close();

            if (Contas == null)
                this.Contas = new List<Conta.Conta>();
        }

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
                if (disposing)
                {
                    this.EscreverArquivo();
                }

                this.Contas = null;
                disposedValue = true;
            }
        }

        private void EscreverArquivo()
        {
            using var file = File.Open("Contas.json", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using var writer = new StreamWriter(file);

            var json = JsonConvert.SerializeObject(this.Contas);
            writer.Write(json);
            writer.Flush();
            writer.Close();
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}