using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlassParameters;
using GlassBuilder;

namespace GlassPluginUI
{
    /// <summary>
    /// Форма для ввода параметров модели
    /// </summary>
    public partial class MainForm : Form
    {

        /// <summary>
        /// Объект класса параметров
        /// </summary>
        private Parameters _parameters = new Parameters();

        /// <summary>
        /// Объект связи с Компас-3D
        /// </summary>
        private KompasConnector _kompasConnector=new KompasConnector();

        public MainForm()
        {
            InitializeComponent();
        }

        private void D1TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(D1TextBox, _parameters.StandDiameter);
        }

        private void D2TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(D2TextBox, _parameters.LegDiameter);
        }

        private void D3TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(D3TextBox, _parameters.RoundingDiameter);
        }

        private void H1TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(H1TextBox, _parameters.LegHeight);
        }

        private void D4TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(D4TextBox, _parameters.GlassDiameter);
        }

        private void H2TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(H2TextBox, _parameters.LowerGlassHeight);
        }

        private void D5TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(D5TextBox, _parameters.GlassNeckDiameter);
        }

        private void H3TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(H3TextBox, _parameters.UpperGlassHeight);
        }

        /// <summary>
        /// Функция присаивания значений в полях
        /// </summary>
        /// <param name="textBox">поле ввода</param>
        /// <param name="parameter">параметр</param>
        private void TextBoxChanged(TextBox textBox, int parameter)
        {     
            try
            {
                int data;
                int.TryParse(textBox.Text, out data);
                parameter = data;
                textBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                textBox.BackColor = Color.Salmon;
            }
        }

        /// <summary>
        /// Кнопка ввода параметров по умолчанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defaultBuildButton_Click(object sender, EventArgs e)
        {
            _parameters.StandDiameter = 150;
            D1TextBox.Text = Convert.ToString(_parameters.StandDiameter);
            _parameters.LegDiameter = 15;
            D2TextBox.Text = Convert.ToString(_parameters.LegDiameter);
            _parameters.RoundingDiameter = 15;
            D3TextBox.Text = Convert.ToString(_parameters.RoundingDiameter);
            _parameters.LegHeight = 100;
            H1TextBox.Text = Convert.ToString(_parameters.LegHeight);
            _parameters.GlassDiameter = 200;
            D4TextBox.Text = Convert.ToString(_parameters.GlassDiameter);
            _parameters.LowerGlassHeight = 100;
            H2TextBox.Text = Convert.ToString(_parameters.LowerGlassHeight);
            _parameters.GlassNeckDiameter = 150;
            D5TextBox.Text = Convert.ToString(_parameters.GlassNeckDiameter);
            _parameters.UpperGlassHeight = 100;
            H3TextBox.Text = Convert.ToString(_parameters.UpperGlassHeight);
        }

        /// <summary>
        /// Кнопка удаления данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            D1TextBox.Clear();
            D1TextBox.BackColor = Color.White;
            D2TextBox.Clear();
            D2TextBox.BackColor = Color.White;
            D3TextBox.Clear();
            D3TextBox.BackColor = Color.White;
            H1TextBox.Clear();
            H1TextBox.BackColor = Color.White;
            D4TextBox.Clear();
            D4TextBox.BackColor = Color.White;
            H2TextBox.Clear();
            H2TextBox.BackColor = Color.White;
            D5TextBox.Clear();
            D5TextBox.BackColor = Color.White;
            H3TextBox.Clear();
            H3TextBox.BackColor = Color.White;
        }

        /// <summary>
        /// Кнопка построение модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            try
            {
                _parameters.StandDiameter = int.Parse(D1TextBox.Text);
                _parameters.LegDiameter = int.Parse(D2TextBox.Text);
                _parameters.RoundingDiameter = int.Parse(D3TextBox.Text);
                _parameters.LegHeight = int.Parse(H1TextBox.Text);
                _parameters.GlassDiameter = int.Parse(D4TextBox.Text);
                _parameters.LowerGlassHeight = int.Parse(H2TextBox.Text);
                _parameters.GlassNeckDiameter = int.Parse(D5TextBox.Text);
                _parameters.UpperGlassHeight = int.Parse(H3TextBox.Text);
                _kompasConnector.StartKompas();
                _kompasConnector.BuildGlass(_parameters);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверный ввод данных");
            }
        }
    }
}
