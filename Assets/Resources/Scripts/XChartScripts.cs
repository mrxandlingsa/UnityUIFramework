using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using XCharts.Runtime;
using Random = UnityEngine.Random;

public class XChartScripts : MonoBehaviour
{
    public PieChart pieChart;
    private void Awake()
    {
        
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        // add a chart serie
        var serie = pieChart.AddSerie<Pie>();
        for (int i = 0; i < 10; i++)
        {
            var serieData = pieChart.AddData(0, Random.Range(0,15));
        }
    }

    void Refresh()
    {
        
        
        
    }




}
