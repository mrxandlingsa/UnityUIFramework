using System;
using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;

public class TemplateSingleton<T>:MonoBehaviour where T:TemplateSingleton<T>
{
    private static T _instance;
    
    public static T Instance
    {
        get 
        {
            return _instance;
        }
    }


    protected virtual void Awake()
    {
        if (_instance != null)
            Destroy(this.gameObject);
        else
            _instance = (T) this;
    }

    public static bool IsInit
    {
       get
       {
           return _instance != null;
       }
    }
    
    protected void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
