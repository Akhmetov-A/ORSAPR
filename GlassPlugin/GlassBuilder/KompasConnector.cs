using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GlassParameters;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace GlassBuilder
{
    public class KompasConnector
    {
        /// <summary>
        /// Объект компас API
        /// </summary>
        private KompasObject _kompas = null;

        /// <summary>
        /// Запуск Компас-3D
        /// </summary>
        public void StartKompas()
        {
            try
            {
                if(_kompas!=null)
                {
                    _kompas.Visible = true;
                    _kompas.ActivateControllerAPI();
                }

                if (_kompas==null)
                {
                    Type kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    _kompas = (KompasObject)Activator.CreateInstance(kompasType);
                    StartKompas();
                    if (_kompas==null)
                    {
                        throw new Exception("Не удается открыть Компас-3D");
                    }
                }
            }
            catch (COMException)
            {
                _kompas = null;
                StartKompas();
            }
        }

        /// <summary>
        /// Вызов функции построения модели
        /// </summary>
        /// <param name="glass">входные параметры</param>
        public void BuildGlass(Parameters glass)
        {
            try
            {
                Builder model = new Builder(_kompas);
                model.CreateModel(glass);
            }
            catch
            {
                throw new Exception("Не удается построить модель");
            }
        }
    }
}
