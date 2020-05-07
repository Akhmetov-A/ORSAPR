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
            int data;
            try
            {
                int.TryParse(D1TextBox.Text, out data);
                _parameters.StandDiameter = data;
                D1TextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                D1TextBox.BackColor = Color.Salmon;
            }
        }

        private void D2TextBox_TextChanged(object sender, EventArgs e)
        {
            int data;
            try
            {
                int.TryParse(D2TextBox.Text, out data);
                _parameters.LegDiameter = data;
                D2TextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                D2TextBox.BackColor = Color.Salmon;
            }
        }

        private void D3TextBox_TextChanged(object sender, EventArgs e)
        {
            int data;
            try
            {
                int.TryParse(D3TextBox.Text, out data);
                _parameters.RoundingDiameter = data;
                D3TextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                D3TextBox.BackColor = Color.Salmon;
            }
        }

        private void H1TextBox_TextChanged(object sender, EventArgs e)
        {
            int data;
            try
            {
                int.TryParse(H1TextBox.Text, out data);
                _parameters.LegHeight = data;
                H1TextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                H1TextBox.BackColor = Color.Salmon;
            }
        }

        private void D4TextBox_TextChanged(object sender, EventArgs e)
        {
            int data;
            try
            {
                int.TryParse(D4TextBox.Text, out data);
                _parameters.GlassDiameter = data;
                D4TextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                D4TextBox.BackColor = Color.Salmon;
            }
        }

        private void H2TextBox_TextChanged(object sender, EventArgs e)
        {
            int data;
            try
            {
                int.TryParse(H2TextBox.Text, out data);
                _parameters.LowerGlassHeight = data;
                H2TextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                H2TextBox.BackColor = Color.Salmon;
            }
        }

        private void D5TextBox_TextChanged(object sender, EventArgs e)
        {
            int data;
            try
            {
                int.TryParse(D5TextBox.Text, out data);
                _parameters.GlassNeckDiameter = data;
                D5TextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                D5TextBox.BackColor = Color.Salmon;
            }
        }

        private void H3TextBox_TextChanged(object sender, EventArgs e)
        {
            int data;
            try
            {
                int.TryParse(H3TextBox.Text, out data);
                _parameters.UpperGlassHeight = data;
                H3TextBox.BackColor = Color.White;
            }
            catch(Exception)
            {
                H3TextBox.BackColor = Color.Salmon;
            }
        }

        /// <summary>
        /// Кнопка удаления данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            D1TextBox.Clear();
            D2TextBox.Clear();
            D3TextBox.Clear();
            H1TextBox.Clear();
            D4TextBox.Clear();
            H2TextBox.Clear();
            D5TextBox.Clear();
            H3TextBox.Clear();
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
