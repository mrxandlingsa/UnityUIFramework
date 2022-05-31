using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Target;
    void Start()
    {
        transform.LookAt(Target, Vector3.left);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
