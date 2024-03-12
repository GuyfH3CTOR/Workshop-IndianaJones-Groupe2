using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumpadLockButton : MonoBehaviour
{
    [SerializeField]
    private int buttonNumber;
    [SerializeField]
    private Material NumberMaterial;
    
    [SerializeField]
    private GameObject Lock;
    
    //Select transform Camera;
    [SerializeField]
    private Transform ViewCameraTransform;

    private NumpadLockPuzzle lockScript;

    private bool overObject;

    // Start is called before the first frame update
    void Start()
    {
        // Get NumpadLockPuzzle Script
        lockScript = Lock.GetComponent<NumpadLockPuzzle>();
    }

    private void OnMouseEnter()
    {
        overObject = true;
    }

    private void OnMouseExit()
    {
        overObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Camera.main.transform.position == ViewCameraTransform.position && overObject == true)
        {
            lockScript.newLockNumber = buttonNumber;
            lockScript.newLockMaterial = NumberMaterial;
            lockScript.NumpadLockUpdate();
        }
    }
}
