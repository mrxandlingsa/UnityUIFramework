
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
    [UnityEngine.Scripting.Preserve]
    internal sealed class YAxisHander : AxisHandler<YAxis>
    {
        protected override Orient orient { get { return Orient.Vertical; } }

        public override void InitComponent()
        {
            InitYAxis(component);
        }

        public override void Update()
        {
            UpdateAxisMinMaxValue(component.index, component);
            UpdatePointerValue(component);
        }

        public override void DrawBase(VertexHelper vh)
        {
            DrawYAxisSplit(vh, component.index, component);
            DrawYAxisLine(vh, component.index, component);
            DrawYAxisTick(vh, component.index, component);
        }

        private void InitYAxis(YAxis yAxis)
        {
            var theme = chart.theme;
            var yAxisIndex = yAxis.index;
            yAxis.painter = chart.painter;
            yAxis.refreshComponent = delegate ()
            {
                var grid = chart.GetChartComponent<GridCoord>(yAxis.gridIndex);
                if (grid != null)
                {
                    var xAxis = chart.GetChartComponent<YAxis>(yAxis.index);
                    InitAxis(yAxis, xAxis, chart, this,
                        orient,
                        grid.context.x,
                        grid.context.y,
                        grid.context.height,
                        grid.context.width);
                }
            };
            yAxis.refreshComponent();
        }

        internal override void UpdateAxisLabelText(Axis axis)
        {
            base.UpdateAxisLabelText(axis);
            if (axis.IsTime() || axis.IsValue())
            {
                for (int i = 0; i < axis.context.labelObjectList.Count; i++)
                {
                    var label = axis.context.labelObjectList[i];
                    if (label != null)
                    {
                        var pos = GetLabelPosition(0, i);
                        label.SetPosition(pos);
                        CheckValueLabelActive(axis, i, label, pos);
                    }
                }
            }
        }

        protected override Vector3 GetLabelPosition(float scaleWid, int i)
        {
            var grid = chart.GetChartComponent<GridCoord>(component.gridIndex);
            if (grid == null)
                return Vector3.zero;

            return GetLabelPosition(i, Orient.Vertical, component, null,
                chart.theme.axis,
                scaleWid,
                grid.context.x,
                grid.context.y,
                grid.context.height,
                grid.context.width);
        }

        private void DrawYAxisSplit(VertexHelper vh, int yAxisIndex, YAxis yAxis)
        {
            if (AxisHelper.NeedShowSplit(yAxis))
            {
                var grid = chart.GetChartComponent<GridCoord>(yAxis.gridIndex);
                if (grid == null)
                    return;
                var relativedAxis = chart.GetChartComponent<XAxis>(yAxis.gridIndex);
                var dataZoom = chart.GetDataZoomOfAxis(yAxis);
                DrawAxisSplit(vh, yAxis, chart.theme.axis, dataZoom,
                    Orient.Vertical,
                    grid.context.x,
                    grid.context.y,
                    grid.context.height,
                    grid.context.width,
                    relativedAxis);
            }
        }

        private void DrawYAxisTick(VertexHelper vh, int yAxisIndex, YAxis yAxis)
        {
            if (AxisHelper.NeedShowSplit(yAxis))
            {
                var grid = chart.GetChartComponent<GridCoord>(yAxis.gridIndex);
                if (grid == null)
                    return;

                var dataZoom = chart.GetDataZoomOfAxis(yAxis);

                var startX = grid.context.x + yAxis.offset;
                if (yAxis.IsRight())
                    startX += grid.context.width;
                else
                    startX += ComponentHelper.GetYAxisOnZeroOffset(chart.components, yAxis);

                DrawAxisTick(vh, yAxis, chart.theme.axis, dataZoom,
                    Orient.Vertical,
                    startX,
                    grid.context.y,
                    grid.context.height);
            }
        }

        private void DrawYAxisLine(VertexHelper vh, int yAxisIndex, YAxis yAxis)
        {
            if (yAxis.show && yAxis.axisLine.show)
            {
                var grid = chart.GetChartComponent<GridCoord>(yAxis.gridIndex);
                if (grid == null)
                    return;

                var startX = grid.context.x + yAxis.offset;
                if (yAxis.IsRight())
                    startX += grid.context.width;
                else
                    startX += ComponentHelper.GetYAxisOnZeroOffset(chart.components, yAxis);

                DrawAxisLine(vh, yAxis, chart.theme.axis,
                    Orient.Vertical,
                    startX,
                    grid.context.y,
                    grid.context.height);
            }
        }
    }
}