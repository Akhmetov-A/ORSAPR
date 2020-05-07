using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlassParameters;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace GlassBuilder
{
    /// <summary>
    /// Построение рюмки
    /// </summary>
    public class Builder
    {
        /// <summary>
        /// Объект Компас API
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="kompas"></param>
        public Builder(KompasObject kompas)
        {
            _kompas = kompas;
            var document = (ksDocument3D)kompas.Document3D();
            document.Create();
        }

        /// <summary>
        /// Построение модели
        /// </summary>
        /// <param name="parameters"></param>
        public void CreateModel(Parameters parameters)
        {
            int standRadius = parameters.StandDiameter / 2;
            int legRadius = parameters.LegDiameter / 2;
            int roundingRadius = parameters.RoundingDiameter/2;
            int legHeight = parameters.LegHeight;
            int glassRadius = parameters.GlassDiameter / 2;
            int lowerGlassHeight = parameters.LowerGlassHeight;
            int glassNeckRadius = parameters.GlassNeckDiameter / 2;
            int upperGlassHeight = parameters.UpperGlassHeight;

            //Создание эскиза
            var document = (ksDocument3D)_kompas.ActiveDocument3D();
            var part = (ksPart)document.GetPart((short)Part_Type.pTop_Part);
            var planeXOZ = part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
            var sketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            var definitionSketch = sketch.GetDefinition();
            definitionSketch.SetPlane(planeXOZ);
            sketch.Create();

            //Построение 2D эскиза
            var sketchEdit = (ksDocument2D)definitionSketch.BeginEdit();
            sketchEdit.ksLineSeg(0, 0, standRadius, 0, 1);
            sketchEdit.ksLineSeg(0, 2, standRadius, 2, 1);
            sketchEdit.ksLineSeg(standRadius, 0, standRadius, 2, 1);
            sketchEdit.ksLineSeg(legRadius, 2, legRadius, legHeight+2, 1);
            //Скругление
            ksCornerParam ksCornerParam = (ksCornerParam)sketchEdit.GetDocument2DNotify();
            ksCornerParam.index = 1;
            ksCornerParam.fillet = true;
            ksCornerParam.l1 = roundingRadius;
            //Построение бокала
            //Построение нижнего бокала
            //Построение верхнего бокала
        }
    }
}
