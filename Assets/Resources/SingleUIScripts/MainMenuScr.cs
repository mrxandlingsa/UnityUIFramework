using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinsUIFramework;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class MainMenuScr : BasePanel
{
    public Button BtnSwithch1;
    public Button BtnSwithch2;
    private CanvasGroup canvasGroup;
    private void Awake()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        BtnSwithch1.onClick.AddListener(delegate(){ UIManager.Instance.PushPanel(UIPanelType.SmallMenu);});
        BtnSwithch2.onClick.AddListener(delegate () { UIManager.Instance.PushPanel(UIPanelType.RightMenu); });
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
