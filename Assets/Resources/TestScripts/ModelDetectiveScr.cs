using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelDetectiveScr : MonoBehaviour
{
    // private void OnMouseDown()
    // {
    //     Debug.Log("OnMouseEnter");
    // }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.gameObject.name);
                SetMat();
            }

        }

    }


    public void SetMat()
    {
        Material Mat = Resources.Load("Materials/FresnelMat",typeof(Material)) as Material;
        this.gameObject.GetComponent<MeshRenderer>().material = Mat;
    }
}
