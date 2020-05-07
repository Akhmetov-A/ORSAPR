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
                if (value < 100 || value > 180) 
                {
                    throw new ArgumentException("Диаметр подставки должен быть от 100 до 180 мм");
                }
                else
                {
                    _standDiameter = value;
                }
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
                if (value < 10 || value > 20)
                {
                    throw new ArgumentException("Диаметр ножки должен быть от 10 до 20 мм");
                }
                else
                {
                    _legDiameter = value;
                }
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
                if (value < 10 || value > 30) 
                {
                    throw new ArgumentException("Диаметр скругление должен быть от 10 до 30 мм");
                }
                else
                {
                    _roundingDiameter = value;
                }
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
                if (value < 100 || value > 200)
                {
                    throw new ArgumentException("Высота ножки должна быть от 100 до 200 мм");
                }
                else
                {
                    _legHeight = value;
                }
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
                if (value < 100 || value > 250)
                {
                    throw new ArgumentException("Диаметр бокала должен быть от 100 до 250 мм");
                }
                else
                {
                    _glassDiameter = value;
                }
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
                if (value < 100 || value > 200)
                {
                    throw new ArgumentException("Высота нижнего бокала должна быть от 100 до 200 мм");
                }
                else
                {
                    _lowerGlassHeight = value;
                }
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
                if (value < 100 || value > 180)
                {
                    throw new ArgumentException("Диаметр горлышка должен быть от 100 до 180 мм");
                }
                else
                {
                    _glassNeckDiameter = value;
                }
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
                if (value < 100 || value > 200)
                {
                    throw new ArgumentException("Высота верхнего бокала должна быть от 100 до 200 мм");
                }
                else
                {
                    _upperGlassHeight = value;
                }
            }
        }


    }
}
