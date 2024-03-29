﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static SA2.ViewModels.DadosPessoaisPageViewModel;
using static SA2.ViewModels.DocumentosPageViewModel;
using static SA2.ViewModels.EnderecoPageViewModel;
using static SA2.ViewModels.identificacaoPageViewModel;

namespace SA2.Models
{
    public class ClienteModels
    {
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
        public string Email { get; set; }
        public string ConfirmacaoEmail { get; set; }
        public string Nome_Mae { get; set; }
        public Profissao Profissao { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public Estado_Civil Estado_Civil { get; set; }
        public string RG_CNH { get; set; }
        public string Orgao_Emissor { get; set; }

        public UnidadeFederal UF { get; set; }
        public DateTime Data_Emissao { get; set; }
        public Cidade Cidade { get; set; }
        public string CEP { get; set; }
        public string LograDouro { get; set; }
        public string Bairro { get; set; }
        public Estado Estado { get; set; }
        public string NumeroCasa { get; set; }
        public string Complemento { get; set; }
        public string Nome { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Telefone_Celular { get; set; }
        public double Valor_Limite { get; set; }
        public double Valor_Renda { get; set; }
        public DateTime Vencimento_Fatura { get; set; }
        public Sexo Sexo { get; set; }
        public ImageSource Selfie{get;set; }
        public ImageSource RG_CNH_FT { get; set; }
        public ImageSource Residencia_FT { get; set; }
        public ImageSource Renda { get; set; }



    }
}
