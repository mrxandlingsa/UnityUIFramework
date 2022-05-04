using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinsUIFramework;


[RequireComponent(typeof(CanvasGroup))]
public class SmallMenuScr : BasePanel
{
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
    }

    public override void OnEnter()
    {
        Debug.Log("SmallMenuScr" + "OnEnter");
    }

    public override void OnPause()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public override void OnResume()
    {
        canvasGroup.blocksRaycasts = true;
    }

    public override void OnExit()
    {

    }
}
