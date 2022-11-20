using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinsUIFramework;
public class UIRoot : MonoBehaviour
{
    private void Start()
    {
        UIManager uiManager = UIManager.Instance;
        uiManager.PushPanel(UIPanelType.MainPanel);
    }
}
