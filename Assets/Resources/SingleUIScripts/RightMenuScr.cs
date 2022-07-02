using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinsUIFramework;
using UnityEngine.UI;


[RequireComponent(typeof(CanvasGroup))]
public class RightMenuScr : BasePanel
{
    private CanvasGroup canvasGroup;

    public Button CloseBtn;
    private void Awake()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        CloseBtn.onClick.AddListener(delegate { UIManager.Instance.PopPanel(); });
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