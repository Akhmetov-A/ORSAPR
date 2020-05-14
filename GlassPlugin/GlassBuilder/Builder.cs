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
        /// <param name="kompas">объект компас</param>
        public Builder(KompasObject kompas)
        {
            _kompas = kompas;
            var document = (ksDocument3D)kompas.Document3D();
            document.Create();
        }

        /// <summary>
        /// Построение модели
        /// </summary>
        /// <param name="parameters">входные параметры</param>
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

            //Построение подставки и ножки
            sketchEdit.ksLineSeg(0, 0, -standRadius, 0, 1);
            sketchEdit.ksLineSeg(-(legRadius + roundingRadius), -5, -standRadius, -5, 1);
            sketchEdit.ksLineSeg(-standRadius, 0, -standRadius, -5, 1);
            sketchEdit.ksLineSeg(-legRadius, -(5 + roundingRadius), -legRadius, -(5+legHeight), 1);
            sketchEdit.ksLineSeg(0, -(5 + legHeight), -legRadius, -(5 + legHeight), 1);

            //Скругление
            var supportingCurve = sketchEdit.ksCircle(-legRadius - roundingRadius, -(5 + roundingRadius), roundingRadius, 1);
            sketchEdit.ksTrimmCurve(supportingCurve, -legRadius, -(5 + roundingRadius), -(legRadius + roundingRadius), -5,
                -(legRadius + roundingRadius - roundingRadius), -(5 + roundingRadius - roundingRadius), 1);

            //Построение нижнего бокала
            sketchEdit.ksNurbs(3, false, 1);
            sketchEdit.ksPoint(-legRadius, -(5 + legHeight), 0);
            sketchEdit.ksPoint(-(glassRadius + legRadius)*0.7, -(5+legHeight+lowerGlassHeight)*0.7, 0);
            sketchEdit.ksPoint(-glassRadius, -(5 + lowerGlassHeight + legHeight), 0);
            sketchEdit.ksEndObj();

            //Построение верхнего бокала
            sketchEdit.ksNurbs(3, false, 1);
            sketchEdit.ksPoint(-glassRadius, -(5 + lowerGlassHeight + legHeight), 0);
            sketchEdit.ksPoint(-(glassRadius+glassNeckRadius)*0.6, -(5 + legHeight + lowerGlassHeight + upperGlassHeight)*0.8, 0);
            sketchEdit.ksPoint(-glassNeckRadius, -(5 + legHeight + lowerGlassHeight + upperGlassHeight), 0);
            sketchEdit.ksEndObj();

            //Построение оси вращения
            sketchEdit.ksLineSeg(0, 0, 0, -10, 3);
            definitionSketch.EndEdit();

            //Вращение
            ksEntity rotatedEntity = part.NewEntity((short)Obj3dType.o3d_bossRotated);
            ksBossRotatedDefinition rotatedDefinition = rotatedEntity.GetDefinition();
            ksRotatedParam rotatedParam = (ksRotatedParam)rotatedDefinition.RotatedParam();
            rotatedParam.toroidShape = true;
            rotatedDefinition.SetThinParam(true);
            rotatedDefinition.toroidShapeType = true;
            rotatedDefinition.SetSketch(sketch);
            rotatedEntity.Create();

        }
    }
}
