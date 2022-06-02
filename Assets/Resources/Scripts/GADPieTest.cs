using System.Collections;
using System.Collections.Generic;
using ChartAndGraph;
using UnityEngine;

public class GADPieTest : MonoBehaviour
{
    [SerializeField]
    private PieChart pie;
    
    void Start ()
    {
        if(pie != null)
        {
            pie.DataSource.SetValue("Category 1", 10f);
            pie.DataSource.SetValue("Category 2", 20f);
        }
    }
    
    
    
}
