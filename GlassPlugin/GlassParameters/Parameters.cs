using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassParameters
{
    /// <summary>
    /// Класс, содержащий параметры рюмки
    /// </summary>
    public class Parameters
    {
        private int _standDiameter;
        private int _legDiameter;
        private int _roundingDiameter;
        private int _legHeight;
        private int _glassDiameter;
        private int _lowerGlassHeight;
        private int _glassNeckDiameter;
        private int _upperGlassHeight;

        /// <summary>
        /// Свойство диаметра подставки
        /// </summary>
        public int StandDiameter
        {
            get
            {
                return _standDiameter;
            }

            set
            {
                _standDiameter = Condition(value, 100, 180, "\"диаметр подставки\"");
            }
        }

        /// <summary>
        /// Свойство диаметра ножки
        /// </summary>
        public int LegDiameter
        {
            get
            {
                return _legDiameter;
            }

            set
            {
                _legDiameter = Condition(value, 10, 20, "\"диаметр ножки\"");
            }
        }

        /// <summary>
        /// Свойство диаметра скругления
        /// </summary>
        public int RoundingDiameter
        {
            get
            {
                return _roundingDiameter;
            }

            set
            {
                _roundingDiameter = Condition(value, 10, 30, "\"диаметр скругления\"");
            }
        }

        /// <summary>
        /// Свойство высоты ножки
        /// </summary>
        public int LegHeight
        {
            get
            {
                return _legHeight;
            }

            set
            {
                _legHeight = Condition(value, 100, 200, "\"высота ножки\"");
            }
        }

        /// <summary>
        /// Свойство диаметра бокала
        /// </summary>
        public int GlassDiameter
        {
            get
            {
                return _glassDiameter;
            }

            set
            {
                _glassDiameter = Condition(value, 100, 250, "\"диаметр бокала\"");
            }
        }

        /// <summary>
        /// Свойство высоты нижнего бокала
        /// </summary>
        public int LowerGlassHeight
        {
            get
            {
                return _lowerGlassHeight;
            }

            set
            {
                _lowerGlassHeight = Condition(value, 100, 200, "\"высота нижнего бокала\"");
            }
        }

        /// <summary>
        /// Свойство диаметра горлышка
        /// </summary>
        public int GlassNeckDiameter
        {
            get
            {
                return _glassNeckDiameter;
            }

            set
            {
                _glassNeckDiameter = Condition(value, 100, 180, "\"диаметр горлышка\"");
            }          
        }

        /// <summary>
        /// Свойство высоты верхнего бокала
        /// </summary>
        public int UpperGlassHeight
        {
            get
            {
                return _upperGlassHeight;
            }

            set
            {
                _upperGlassHeight = Condition(value, 100, 200, "\"высота верхнего бокала\"");
            }
        }

        /// <summary>
        /// Условие для свойств
        /// </summary>
        /// <param name="parameter">параметр</param>
        /// <param name="minValue">минимальное значение</param>
        /// <param name="maxValue">максимальное значение</param>
        /// <param name="name">имя параметра</param>
        /// <returns></returns>
        public int Condition(int parameter, int minValue, int maxValue, string name)
        {
            if (parameter < minValue || parameter > maxValue) 
            {
                throw new ArgumentException("Значение параметра " + name + " должно быть от " + minValue + " до " + maxValue + " мм");
            }
            else
            {
                return parameter;
            }
        }

    }
}
