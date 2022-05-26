using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectTopUIScr : MonoBehaviour
{
  public Text text;
  public Image image;


  public void InitUI(string Name)
  {
    text.text = Name;
  }

}
