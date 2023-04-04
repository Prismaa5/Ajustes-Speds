﻿using System.Text;
using System.Threading.Tasks;
using FiscalBr.EFDContribuicoes;
using System;
using FiscalBr.EFDFiscal;

namespace ProjetosEngage.Classes
{
    internal class GravarArquivo
    {
        public async void ExecSped(ArquivoEFDContribuicoes _SpedContribuicoes, MainWindow window)
        {
            //var arquivo = Common.SalvaArquivo("txt", "Sped");
            String competencia = Convert.ToString(_SpedContribuicoes.Bloco0.Reg0000.DtFin).Replace("/", "").Replace(" ", "").Replace(":", "").Substring(2, 6);

            var arquivo = $"C:\\sped_contribuicoes\\test\\sped_contribuicoes_{competencia}.txt";
            if (arquivo != null)
            {
                await Task.Run(() =>
                {
                    _SpedContribuicoes.GerarLinhas();
                    _SpedContribuicoes.CalcularBloco9();
                    _SpedContribuicoes.Escrever(arquivo.Replace(".", "_ajustado."), Encoding.GetEncoding(1252));
                });
                window.BlocoTxt.Text += "Feito";
                window.BtnExecSped.IsEnabled = true;
                window.BtnSelSped.IsEnabled = true;
            }
        }

        public async void ExecSped(ArquivoEFDFiscal _SpedFiscal, MainWindow window)
        {
            //var arquivo = Common.SalvaArquivo("txt", "Sped");
            String competencia = Convert.ToString(_SpedFiscal.Bloco0.Reg0000.DtFin).Replace("/", "").Replace(" ", "").Replace(":", "").Substring(2, 6);

            var arquivo = $"C:\\sped_contribuicoes\\sped_fiscal_{competencia}.txt";
            if (arquivo != null)
            {
                await Task.Run(() =>
                {
                    _SpedFiscal.GerarLinhas();
                    _SpedFiscal.CalcularBloco9();
                    _SpedFiscal.Escrever(arquivo.Replace(".", "_ajustado."), Encoding.GetEncoding(1252));
                });
                window.BlocoTxt.Text += "Feito";
                window.BtnExecSped.IsEnabled = true;
                window.BtnSelSped.IsEnabled = true;
            }
        }
    }
}
