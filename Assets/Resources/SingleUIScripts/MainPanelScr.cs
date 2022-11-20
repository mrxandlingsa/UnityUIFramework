using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinsUIFramework;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class MainPanelScr : BasePanel
{
    public Button BtnSwithch1;
    private CanvasGroup canvasGroup;
    private void Awake()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        BtnSwithch1.onClick.AddListener(delegate(){ UIManager.Instance.PushPanel(UIPanelType.Type1Panel);});
    }
    
    public override void OnEnter()
    {
        canvasGroup.alpha = 1;
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
        canvasGroup.alpha = 0;
    }








}
