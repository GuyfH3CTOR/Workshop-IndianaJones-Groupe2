using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCursorOverNewPosition : MonoBehaviour
{
    [SerializeField]
    private Material baseMaterial;
    [SerializeField]
    private Material overMaterial;

    // Start is called before the first frame update
    void Start()
    {
        // Set Material
        GetComponent<Renderer>().material = baseMaterial;
    }

    private void OnMouseEnter()
    {
        // Set Material
        GetComponent<Renderer>().material = overMaterial;
        CursorManagement.b_IsCursorNormal = false;
    }

    private void OnMouseExit()
    {
        // Set Material
        GetComponent<Renderer>().material = baseMaterial;        
        CursorManagement.b_IsCursorNormal = true;
    }
}
