using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medidas_Descritivas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        List<double> teste = new List<double>(); double soma_; double desPadrao; double CV;
        double var; List<double> lista = new List<double>(); double aux; int y;
        double soma;  double media; public double mediana; double valor;
        //double[] items = new double[4];
        List<double> itens = new List<double>();
        public List<double> NumerosMedia = new List<double>();
        private void Button1_Click(object sender, EventArgs e)
        {
            ////////////////////   MÉDIA  ////////////////////
            NumerosMedia.Add(Convert.ToDouble(numericUpDown1.Value));
            soma = 0;
            for (int i = 0; i < NumerosMedia.Count; i++)
            {
                soma = soma + NumerosMedia[i];
            }
            media = (soma / NumerosMedia.Count);
            lblMedia.Text = Convert.ToString(Math.Round(media, 2));

            ////////////////////   MEDIANA  ////////////////////

            lista.Add(valor);
            CalcularMediana(Convert.ToDouble(numericUpDown1.Value));
            void CalcularMediana(double valor)
            {
                var Mediana = 0.0;
                itens.Add(valor);
                var qntItens = itens.Count; //pega a quantidade 
                itens.Sort(); //ordena os valores
                if (qntItens % 2 == 0) // verifica se a quantidade eh par
                {
                    //Calculo da mediana (A + B / 2) = ?
                    var primeiroValor = itens[(itens.Count / 2) - 1]; 
                    var segundoValor = itens[(itens.Count / 2)];
                    Mediana = (primeiroValor + segundoValor) / 2.0;
                }
                if (qntItens % 2 == 1)// verifica se a quantidade eh impar
                {
                    Mediana = itens[(itens.Count / 2)];
                }
                lblMediana.Text = Mediana.ToString();
            }
        }
        











        private void Amostral_Padrao(int A_P)
        {
            aux = 0;y = 0;var = 0;teste.Clear();soma_ = 0;
            ////////////////////   VARIAÇÃO AMOSTRAL  ////////////////////
            while (y < lista.Count)
            {
                valor = Convert.ToDouble(numericUpDown1.Value);
                var = lista[y] - media;
                var = var * var; //resultado ao quadrado
                teste.Add(var);
                y++;
            }
            for (int i = 0; i < teste.Count; i++) //somar
            {
                soma_ += teste[i];
            }
            aux = soma_ / (lista.Count - A_P);
            if (A_P == 0)//populacional
            {
                lblPopula.Text = Convert.ToString(Math.Round(aux, 2));
            }
            if (A_P == 1)//amostral
            {
                lblAmostral.Text = Convert.ToString(Math.Round(aux, 2));
                desPadrao = Math.Round(Math.Sqrt(aux),2); // Raiz / Desvio Padrao 
                lblPadrao.Text = desPadrao.ToString();   // Desvio Padrao
                CV = Math.Round((desPadrao / media * 100), 2);
                lblCV.Text = CV + "%";
                if(CV <= 30)
                {
                    lblCVH.ForeColor = Color.Green;
                    lblCVH.Text = "Homogêneo";
                }
                else
                {
                    lblCVH.ForeColor = Color.Red;
                    lblCVH.Text = "Heterogêneo";
                }
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Amostral_Padrao(0);
            Amostral_Padrao(1);
        }
    }
}
