using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
   public Transform TopUITrans;
   private Canvas SmallUICanvas;

   private Transform CurrentGenTrans;

   private GameObject GeneratedObject;
   [SerializeField]
   private bool IsInit = false;
   private void OnEnable()
   {
      foreach (var c in FindObjectsOfType<Canvas>())
      {
         SmallUICanvas = c;
      }
   }

   private void OnMouseDown()
   {
      GenerateTopUI();
   }

   public void GenerateTopUI()
   {
      var prefab = Resources.Load("Prefabs/ObjectTopUI");
      GeneratedObject = (GameObject) Instantiate(prefab, SmallUICanvas.transform);
      GeneratedObject.transform.position = TopUITrans.position;
      var scr = GeneratedObject.GetComponent<ObjectTopUIScr>();
      scr.InitUI("Test");
   }

   private void LateUpdate()
   {
      LookAtCamera();
   }

   void LookAtCamera()
   {
      if (GeneratedObject != null)
      {
         GeneratedObject.transform.forward = -Camera.main.transform.forward;
      }
   }

}
