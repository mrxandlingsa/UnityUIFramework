using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinsUIFramework;


[RequireComponent(typeof(CanvasGroup))]
public class MainMenuScr : BasePanel
{
    private CanvasGroup canvasGroup;
    private void Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
    }
    
    public override void OnEnter()
    {
        Debug.Log("MainMenuScr" + "OnEnter");
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
