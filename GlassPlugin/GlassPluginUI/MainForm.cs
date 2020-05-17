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

            //Привязка всех полей ввода к одному событию
            foreach(Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.TextChanged += new EventHandler(TextBoxChanged);
                }
            }
            List<string> glassName = new List<string>
            {
                "Своя",
                "Рюмка для вина",
                "Рюмка для шампанского",
                "Рюмка для коньяка"
            };
            GlassComboBox.DataSource = glassName;
            GlassComboBox.DisplayMember = "Своя";
        }

        /// <summary>
        /// Обработчик полей для ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            try
            {
                int data;
                int.TryParse(textBox.Text, out data);
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
            Assignment(150, 15, 15, 100, 200, 100, 150, 100);
        }

        /// <summary>
        /// Кнопка удаления данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text = null;
                    c.BackColor = Color.White;
                }
            }
            GlassComboBox.SelectedItem = "Своя";
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

        /// <summary>
        /// Кнопка с выбором модели рюмок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = (string)GlassComboBox.SelectedItem;
            if (name=="Рюмка для вина")
            {
                Assignment(150, 15, 20, 200, 200, 100, 150, 100);
            }
            else if (name=="Рюмка для шампанского")
            {
                Assignment(100, 10, 30, 150, 120, 150, 100, 120);
            }
            else if (name=="Рюмка для коньяка")
            {
                Assignment(180, 20, 10, 100, 250, 100, 130, 150);
            }
        }

        /// <summary>
        /// Функция присваивания значений по нажатию кнопок
        /// </summary>
        /// <param name="d1">диаметр подставки</param>
        /// <param name="d2">диаметр ножки</param>
        /// <param name="d3">диаметр скругления</param>
        /// <param name="h1">высота ножки</param>
        /// <param name="d4">диаметр бокала</param>
        /// <param name="h2">высота нижнего бокала</param>
        /// <param name="d5">диаметр горлышка</param>
        /// <param name="h3">высота верхнего бокала</param>
        public void Assignment(int d1, int d2, int d3, int h1, int d4, int h2, int d5, int h3)
        {
            _parameters.StandDiameter = d1;
            D1TextBox.Text = Convert.ToString(_parameters.StandDiameter);
            _parameters.LegDiameter = d2;
            D2TextBox.Text = Convert.ToString(_parameters.LegDiameter);
            _parameters.RoundingDiameter = d3;
            D3TextBox.Text = Convert.ToString(_parameters.RoundingDiameter);
            _parameters.LegHeight = h1;
            H1TextBox.Text = Convert.ToString(_parameters.LegHeight);
            _parameters.GlassDiameter = d4;
            D4TextBox.Text = Convert.ToString(_parameters.GlassDiameter);
            _parameters.LowerGlassHeight = h2;
            H2TextBox.Text = Convert.ToString(_parameters.LowerGlassHeight);
            _parameters.GlassNeckDiameter = d5;
            D5TextBox.Text = Convert.ToString(_parameters.GlassNeckDiameter);
            _parameters.UpperGlassHeight = h3;
            H3TextBox.Text = Convert.ToString(_parameters.UpperGlassHeight);
        }
    }
}
