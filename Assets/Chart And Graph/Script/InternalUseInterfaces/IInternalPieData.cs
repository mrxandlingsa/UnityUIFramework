#define Graph_And_Chart_PRO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChartAndGraph
{
    interface IInternalPieData
    {
        ChartSparseDataSource InternalDataSource { get; }
    }
}
