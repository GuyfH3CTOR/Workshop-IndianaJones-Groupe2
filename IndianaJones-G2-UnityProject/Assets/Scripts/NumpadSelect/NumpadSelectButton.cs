using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumpadSelectButton : MonoBehaviour
{
    //Select transform Camera;
    [SerializeField] private Transform ViewCameraTransform;
    
    [Space(10)] // 10 pixels of spacing here.

    // Puzzle GameObject + Script
    [SerializeField] private GameObject g_PuzzleManagement;
    private NumpadSelectPuzzle SelectScript;
    
    [Space(10)] // 10 pixels of spacing here.

    // Button Info
    [SerializeField] private int i_buttonNumber;
    [SerializeField] private Material m_buttonMaterial;    

    // boolean
    private bool overObject;

    // Start is called before the first frame update
    void Start()
    {
        // Get Numpadg_PuzzleManagementPuzzle Script
        SelectScript = g_PuzzleManagement.GetComponent<NumpadSelectPuzzle>();
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
            // Update Puzzle Button Info
            SelectScript.i_buttonNumber = i_buttonNumber;
            SelectScript.i_buttonMaterial = m_buttonMaterial;

            // Call Puzzle Script
            SelectScript.NumpadSelectCheck();
        }
    }
}
