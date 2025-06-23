using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GA_Odev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPopulationSize.Text = "30";
            txtGenerationCount.Text = "50";
            txtCrossoverRate.Text = "0.8";
            txtMutationRate.Text = "0.1";
            txtElitismCount.Text = "2";

            chartConvergence.Series.Clear();
            chartConvergence.ChartAreas[0].AxisX.Title = "Jenerasyon";
            chartConvergence.ChartAreas[0].AxisY.Title = "En İyi Uygunluk (Fitness)";
            chartConvergence.ChartAreas[0].AxisY.IsLogarithmic = false;
        }
 
        private async void btnRunGA_Click(object sender, EventArgs e)
        {
            
            btnRunGA.Enabled = false;
            btnRunGA.BackColor = Color.Gray;

            try
            {
                int populationSize = int.Parse(txtPopulationSize.Text);
                int generationCount = int.Parse(txtGenerationCount.Text);
                double crossoverRate = double.Parse(txtCrossoverRate.Text);
                double mutationRate = double.Parse(txtMutationRate.Text);
                int elitismCount = int.Parse(txtElitismCount.Text);

               
                int dimension = 2;
                GeneticAlgorithm ga = new GeneticAlgorithm(
                    populationSize,
                    dimension,
                    crossoverRate,
                    mutationRate,
                    elitismCount);

            
                List<double> bestFitnessHistory = await Task.Run(() => ga.Run(generationCount));


                Chromosome best = ga.BestIndividual;
                double bestFitness = best.Fitness;

             
                string paramStr = "";
                for (int i = 0; i < dimension; i++)
                {
                    paramStr += $"x[{i}] = {best.Genes[i]:F10}\n";
                }

                MessageBox.Show(
                    $"En iyi çözüm parametreleri:\n{paramStr}\n" +
                    $"Amaç fonksiyonu (fitness) değeri: {bestFitness:F10}"
                );

  
                DrawConvergenceChart(bestFitnessHistory);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
            finally
            {
           
                btnRunGA.Enabled = true;
                btnRunGA.BackColor = Color.LightGreen;
            }
        }

        private void DrawConvergenceChart(List<double> bestFitnessHistory)
        {
            chartConvergence.Series.Clear();
            Series series = new Series("En İyi Fitness")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderWidth = 2
            };

            for (int i = 0; i < bestFitnessHistory.Count; i++)
            {
                series.Points.AddXY(i, bestFitnessHistory[i]);
            }

            chartConvergence.Series.Add(series);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
