using System;
using System.Collections.Generic;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.Tools;
using Tekla.Structures.Drawing.UI;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Plugins;

namespace DrawLine
{
    public class PluginData
    {
        [StructuresField("step")]
        public string Step;
        [StructuresField("diameter")]
        public string Diameter;
        [StructuresField("color")]
        public int Color;
    }

    [Plugin("DrawHandrailLine")]
    [InputObjectDependency(PluginBase.InputObjectDependency.DEPENDENT)]
    [PluginUserInterface("DrawLine.MainForm")]
    [UpdateMode(UpdateMode.INPUT_CHANGED)]
    public class DrawLine : DrawingPluginBase
    {
        private PluginData data;

        public PluginData Data
        {
            get { return data; }
            set { data = value; }
        }

        public DrawLine(PluginData data)
        {
            Data = data;
        }

        public override List<InputDefinition> DefineInput()
        {
            List<InputDefinition> inputs = new List<InputDefinition>();
            DrawingHandler drawingHandler = new DrawingHandler();

            if (drawingHandler.GetConnectionStatus())
            {
                Picker picker = drawingHandler.GetPicker();

                StringList prompts = new StringList
                {
                    "Укажите первое положение",
                    "Укажите второе положение"
                };

                picker.PickPoints(2, prompts, out PointList points, out ViewBase view);
                inputs.Add(InputDefinitionFactory.CreateInputDefinition(view, points[0]));
                inputs.Add(InputDefinitionFactory.CreateInputDefinition(view, points[1]));
            }
            return inputs;
        }

        public override bool Run(List<InputDefinition> inputs)
        {
            try
            {
                GetValuesFromDialog();

                if (inputs.Count > 0)
                {
                    double step = Helpers.ParseToDouble(Data.Step);
                    double diameter = Helpers.ParseToDouble(Data.Diameter);

                    Vector stepVector;
                    ViewBase view = InputDefinitionFactory.GetView(inputs[0]);
                    string type = view.GetType().Name;

                    Point firstPickedPoint = InputDefinitionFactory.GetPoint(inputs[0]);
                    Point secondPickedPoint = InputDefinitionFactory.GetPoint(inputs[1]);

                    //Создаем вектор между указанными точками
                    Vector lineVector = new Vector(secondPickedPoint.X - firstPickedPoint.X, secondPickedPoint.Y - firstPickedPoint.Y, 0);

                    //Длина между указанными точками
                    double length = Math.Round(Distance.PointToPoint(firstPickedPoint, secondPickedPoint), 5);

                    #region Шаг с учетом масштаба вида
                    double stepScale = 0.0;
                    if (type == "ContainerView")
                        stepScale = step;
                    else
                        stepScale = step * ((View)view).Attributes.Scale;
                    #endregion

                    #region Диаметр окружности с учетом масштаба вида
                    double diameterScale = 0.0;
                    if (type == "ContainerView")
                        diameterScale = diameter;
                    else
                        diameterScale = diameter * ((View)view).Attributes.Scale;
                    #endregion

                    #region Кол-во кружков на линии
                    int circleNum = 0;
                    bool copy = false;
                    double a = length / stepScale;
                    double b = (int)a * stepScale;
                    double ost = (length - b) * .5;

                    if (length <= diameterScale)
                        circleNum = 0;
                    else if (length > diameterScale && length <= stepScale + diameterScale)
                        circleNum = 1;
                    else if (IsInt(length / stepScale) || IsInt((length - diameterScale) / stepScale) || (ost < diameterScale * .5))
                    {
                        circleNum = (int)(length / stepScale);
                        b = ((int)(a) - 1) * stepScale;
                        ost = (length - b) * .5;
                    }
                    else
                    {
                        circleNum = (int)(length / stepScale) + 1;
                        copy = true;
                    }
                    #endregion

                    #region Рисуем линию
                    if (circleNum == 0)
                        DrawLineIn(view, firstPickedPoint, secondPickedPoint);

                    if (circleNum == 1)
                    {
                        ost = length * .5 - diameterScale * .5;
                        Vector Vector = new Vector(lineVector);

                        Vector.Normalize(ost);
                        Point secPoint = new Point(firstPickedPoint);
                        secPoint.Translate(Vector.X, Vector.Y, 0);
                        DrawLineIn(view, firstPickedPoint, secPoint);

                        Vector.Normalize(length * .5);
                        Point firstCirclePoint = new Point(firstPickedPoint);
                        firstCirclePoint.Translate(Vector.X, Vector.Y, 0);
                        DrawCircleIn(view, firstCirclePoint, diameterScale);

                        Vector.Normalize(ost + diameterScale);
                        Point firstPoint = new Point(firstPickedPoint);
                        firstPoint.Translate(Vector.X, Vector.Y, 0);
                        DrawLineIn(view, firstPoint, secondPickedPoint);
                    }

                    if (circleNum > 1 || copy == true)
                    {
                        #region Вектор для копирования
                        stepVector = new Vector(lineVector);
                        stepVector.Normalize(stepScale);
                        #endregion

                        #region Рисуем первый отрезок
                        Vector firstSegmentVector = new Vector(lineVector);
                        firstSegmentVector.Normalize(ost - diameterScale * .5);
                        Point firstSegmentSecondPoint = new Point(firstPickedPoint);
                        firstSegmentSecondPoint.Translate(firstSegmentVector.X, firstSegmentVector.Y, 0);
                        DrawLineIn(view, firstPickedPoint, firstSegmentSecondPoint);
                        #endregion

                        #region Рисуем шаговый отрезок
                        Vector firstPointSegmentVector = new Vector(lineVector);
                        firstPointSegmentVector.Normalize(ost + diameterScale * .5);
                        Point SegmentFirstPoint = new Point(firstPickedPoint);
                        SegmentFirstPoint.Translate(firstPointSegmentVector.X, firstPointSegmentVector.Y, 0);
                        Vector secondPointSegmentVector = new Vector(lineVector);
                        secondPointSegmentVector.Normalize(ost - diameterScale * .5 + stepScale);
                        Point SegmentSecondPoint = new Point(firstPickedPoint);
                        SegmentSecondPoint.Translate(secondPointSegmentVector.X, secondPointSegmentVector.Y, 0);
                        DrawLineIn(view, SegmentFirstPoint, SegmentSecondPoint);
                        #endregion

                        #region Рисуем окружность
                        Vector centerPointCircle = new Vector(lineVector);
                        centerPointCircle.Normalize(ost);
                        Point circleCenterPoint = new Point(firstPickedPoint);
                        circleCenterPoint.Translate(centerPointCircle.X, centerPointCircle.Y, 0);
                        DrawCircleIn(view, circleCenterPoint, diameterScale);
                        #endregion

                        #region Копирование кружков по длине
                        for (int i = 0; i < circleNum - 1; i++)
                        {
                            circleCenterPoint.Translate(stepVector.X, stepVector.Y, 0);
                            DrawCircleIn(view, circleCenterPoint, diameterScale);
                        }
                        #endregion

                        #region Копирование отрезков по длине
                        for (int j = 0; j < circleNum - 2; j++)
                        {
                            SegmentFirstPoint.Translate(stepVector.X, stepVector.Y, 0);
                            SegmentSecondPoint.Translate(stepVector.X, stepVector.Y, 0);
                            DrawLineIn(view, SegmentFirstPoint, SegmentSecondPoint);
                        }
                        #endregion

                        #region Рисуем последний отрезок
                        SegmentFirstPoint.Translate(stepVector.X, stepVector.Y, 0);
                        DrawLineIn(view, SegmentFirstPoint, secondPickedPoint);
                        #endregion
                    }
                    #endregion

                }
            }
            catch (Exception Exc)
            {
                System.Windows.Forms.MessageBox.Show(Exc.ToString());
            }

            return true;
        }

        private bool IsInt(object obj)
        {
            return Convert.ToInt32(obj) == Convert.ToDouble(obj);
        }

        private void DrawLineIn(ViewBase view, Point firstPoint, Point secondPoint)
        {
            Tekla.Structures.Drawing.Line Line = new Tekla.Structures.Drawing.Line(view, firstPoint, secondPoint);
            Line.Attributes.Line.Color = (DrawingColors)this.Data.Color;
            Line.Insert();
        }

        private void DrawCircleIn(ViewBase view, Point centerPoint, double diameter)
        {
            Circle Circle = new Circle(view, centerPoint, diameter * .5);
            Circle.Attributes.Line.Color = (DrawingColors)this.Data.Color;
            Circle.Insert();
        }

        private void GetValuesFromDialog() //Получаем данные
        {
            if (IsDefaultValue(this.Data.Step))
                this.Data.Step = "20";

            if (IsDefaultValue(this.Data.Diameter))
                this.Data.Diameter = "2";

            if (IsDefaultValue(this.Data.Color))
                this.Data.Color = (int)DrawingColors.Red;
        }
    }

    public class Helpers
    {
        /// <summary>
        /// Переводит значение в число, в независимости от системного разделителя
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ParseToDouble(string value)
        {
            value = value.Trim();
            if (!double.TryParse(value, System.Globalization.NumberStyles.Any, 
                System.Globalization.CultureInfo.GetCultureInfo("ru-RU"), out double result))
            {
                if (!double.TryParse(value, System.Globalization.NumberStyles.Any, 
                    System.Globalization.CultureInfo.GetCultureInfo("en-US"), out result))
                    return double.NaN;
            }
            return result;
        }
    }
}
