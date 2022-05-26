using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    private Vector3 LookAtTargetPosition;
    [SerializeField]
    private Transform LookAtTargetTrans;
    //default ObjectDirection2Camera

    public Vector3 ObjectDefaultDir;

    public float Distance;
    
    
    [Tooltip("Time it takes to interpolate camera rotation 99% of the way to the target."), Range(0.001f, 1f)]
    public float rotationLerpTime = 0.01f;
    
    [Tooltip("Time it takes to interpolate camera position 99% of the way to the target."), Range(0.001f, 1f)]
    public float positionLerpTime = 0.2f;
    
    [Tooltip("X = Change in mouse position.\nY = Multiplicative factor for camera rotation.")]
    public AnimationCurve mouseSensitivityCurve = new AnimationCurve(new Keyframe(0f, 0.5f, 0f, 5f), new Keyframe(1f, 2.5f, 0f, 0f));
    
    
    public float yaw;
    public float pitch;
    
    public float Targetyaw;
    public float Targetpitch;
    
    
    public float roll;
    public float x;
    public float y;
    public float z;
    
    
    public void TransCamera()
    {

        // var TranslatedPosition = CalcuteCameraPosition();
        
    }

    public Vector3 CalClickedObjectPos()
    {
        return CalcuteCameraPosition();
    }
    

    public Vector3 CalcuteCameraPosition()
    {
        var pos = LookAtTargetPosition;
        return new Vector3(pos.x+ObjectDefaultDir.x*Distance,pos.y+ObjectDefaultDir.y*Distance,pos.z+ObjectDefaultDir.z*Distance);
        return new Vector3(0, 0, 0);
    }
    
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        if (Input.GetMouseButton(1))
        {
            var mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            var mouseSensitivityFactor = mouseSensitivityCurve.Evaluate(mouseMovement.magnitude);
            Targetyaw += mouseMovement.x * mouseSensitivityFactor;
            Targetpitch += mouseMovement.y * mouseSensitivityFactor;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            RayCastDetective();
        }
        if (LookAtTargetTrans != null)
        {
            var positionLerpPct = 1f - Mathf.Exp((Mathf.Log(1f - 0.99f) / positionLerpTime) * Time.deltaTime);
            var rotationLerpPct = 1f - Mathf.Exp((Mathf.Log(1f - 0.99f) / rotationLerpTime) * Time.deltaTime);
            var pos = CalcuteCameraPosition();
            Vector3 CurrentCameraPosition = this.transform.position;
            LerpPosTowards(pos, positionLerpPct);
            var arg = new Vector3(Targetpitch,Targetyaw,roll);
            LerpRotTowards(arg,rotationLerpPct);
            
            UpdateTransform(transform);
            // var Vector3D = new Vector3(pos.x-LookAtTargetPosition.x,pos.y-LookAtTargetPosition.y,pos.z-LookAtTargetPosition.z);
            
        }
    }

    RaycastHit hit;
    public void RayCastDetective()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            LookAtTargetPosition = hit.collider.gameObject.transform.position;
            LookAtTargetTrans = hit.collider.gameObject.transform;
        }
    }
    
    
    public void LerpPosTowards(Vector3 Position, float positionLerpPct)
    {
        x = Mathf.Lerp(x, Position.x, positionLerpPct);
        y = Mathf.Lerp(y, Position.y, positionLerpPct);
        z = Mathf.Lerp(z, Position.z, positionLerpPct);
    }
    
    public void LerpRotTowards(Vector3 rotaion, float rotationLerpPct)
    {
        yaw = Mathf.Lerp(yaw, rotaion.x, rotationLerpPct);
        pitch = Mathf.Lerp(pitch, rotaion.y, rotationLerpPct);
        roll = Mathf.Lerp(roll, rotaion.z, rotationLerpPct);
    }
    
    public void UpdateTransform(Transform t)
    {
        t.eulerAngles = new Vector3(yaw, pitch, roll);
        t.position = new Vector3(x, y, z);
    }
    

}
