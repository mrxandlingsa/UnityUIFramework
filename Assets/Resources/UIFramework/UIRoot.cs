using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinsUIFramework;
public class UIRoot : MonoBehaviour
{
    private void Awake()
    {
        UIManager uiManager = UIManager.Instance;
        uiManager.PushPanel(UIPanelType.MainMenu);
    }
}
