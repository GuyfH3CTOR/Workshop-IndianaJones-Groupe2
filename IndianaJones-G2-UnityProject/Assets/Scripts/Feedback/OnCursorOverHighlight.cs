using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCursorOverHighlight : MonoBehaviour
{    
    // Select ViewCameraTransform
    [SerializeField]
    private Transform InteractCamera;  
    
    // Select Renderer Color
    [SerializeField]
    private Color onOverColor;    
    private Renderer[] renderers;
    
    void Start()
    {
        // Get renderers
        renderers = GetComponentsInChildren<Renderer>();
    }

    private void OnMouseOver()
    {
        if(Camera.main.transform.position == InteractCamera.position)
        {            
            //Highlight ON
            foreach(var r in renderers)
            {
                r.material.color = onOverColor;
            }
        
            // Set Cursor
            CursorManagement.b_IsCursorNormal = false;
        }
    }

    private void OnMouseExit()
    {
        //Highlight Off
        foreach(var r in renderers)
        {
            r.material.color = Color.white;
        }
        
        // Set Cursor
        CursorManagement.b_IsCursorNormal = true;
    }
}
