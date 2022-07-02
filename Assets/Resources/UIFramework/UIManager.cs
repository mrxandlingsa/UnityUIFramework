using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SinsUIFramework;
using LitJson;

namespace SinsUIFramework
{
    
    public class UIManager : TemplateSingleton<UIManager>
    {
        private Transform canvasTransform;
        private Transform CanvasTransform
        {
            get
            {
                if (canvasTransform == null)
                {
                    canvasTransform = GameObject.Find("UICanvas").transform;
                    if (canvasTransform == null)
                    {
                        Debug.LogError("did not find UICanvas");
                    }
                }
                return canvasTransform;
            }
        }

        private Dictionary<string, string> panelPathDict;
        private Dictionary<string, BasePanel> panelDict;
        private Stack<BasePanel> PanelStack;

        // private UIManager()
        // {
        //     ParseUIPanelTypeJson();
        // }

        protected override void Awake()
        {
            base.Awake();
            ParseUIPanelTypeJson();
        }

        private void ParseUIPanelTypeJson()
        {
            panelPathDict = new Dictionary<string, string>();
            TextAsset textUIPanelType = Resources.Load<TextAsset>("SystemFile/UIPanelTypePath");
            UIPanelInfoList panelInfoList = JsonMapper.ToObject<UIPanelInfoList>(textUIPanelType.text);
            foreach (UIPanelInfo panelInfo in panelInfoList.panelInfoList)
            {
                panelPathDict.Add(panelInfo.panelType, panelInfo.path);
            }
        }

        //void Test()
        //{
        //    UIManager.Instance.PushPanel(UIPanelType.MainMenu);
        //    //UIManager.Instance.PushPanel(UIPanelType.SmallMenu);
        //}

        private BasePanel GetPanel(string panelType)
        {
            if (panelDict == null)
            {
                panelDict = new Dictionary<string, BasePanel>();
            }

            BasePanel panel = panelDict.GetValue(panelType);
            if (panel == null)
            {
                string path = panelPathDict.GetValue(panelType);
                GameObject panelGo = Instantiate(Resources.Load<GameObject>(path), CanvasTransform, false);
                panel = panelGo.GetComponent<BasePanel>();
                panelDict.Add(panelType, panel);
            }
            return panel;
        }

        public void PushPanel(string panelType)
        {
            if (PanelStack == null)
            {
                PanelStack = new Stack<BasePanel>();
            }
            if (PanelStack.Count > 0)
            {
                BasePanel topPanel = PanelStack.Peek();
                topPanel.OnPause();
            }
            BasePanel panel = GetPanel(panelType);
            PanelStack.Push(panel);
            panel.OnEnter();
        }

        public void PopPanel()
        {
            if (PanelStack == null)
            {
                PanelStack = new Stack<BasePanel>();
            }
            if (PanelStack.Count <= 0)
            {
                return;
            }

            //退出栈顶面板
            BasePanel topPanel = PanelStack.Pop();
            topPanel.OnExit();

            //恢复上一个面板
            if (PanelStack.Count > 0)
            {
                BasePanel panel = PanelStack.Peek();
                panel.OnResume();
            }

        }

        //次级页面进入后,初始的页面会不可点击,如果需要任意点击关闭,则需要此函数
        public void ClosePanel(string panelType)
        {
            
        }







    }
    
    
    
}

