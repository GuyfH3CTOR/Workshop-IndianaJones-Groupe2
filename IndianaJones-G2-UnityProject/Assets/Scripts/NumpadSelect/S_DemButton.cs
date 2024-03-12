using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DemButton : MonoBehaviour
{
    // Camera
    [SerializeField] private Transform InteractCamera;

    // Select code
    [SerializeField] private GameObject code;
    private NumpadSelectPuzzle selectScript;

    [Space(10)] // 10 pixels of spacing here.

    // Shader GameObject
    [SerializeField] private GameObject onOverShader;
    private Renderer shaderRenderer;
    
    // Shader Materials
    [SerializeField] private Material m_noShader;
    [SerializeField] private Material m_ShaderOff;
    [SerializeField] private Material m_ShaderOn;

    [Space(10)] // 10 pixels of spacing here.

    // Boolean
    [SerializeField] private bool interactable = true;
    private bool Over;
    private bool selected;

    [Space(10)] // 10 pixels of spacing here.

    // Correct info
    [SerializeField] private GameObject g_self;
    [SerializeField] public bool b_IsIncorrect;
    [SerializeField] private int i_correctNumber;
    [SerializeField] private GameObject g_plateVisual;

    void Start()
    {
        // Get renderers
        shaderRenderer = onOverShader.GetComponent<Renderer>();

        // Get NumpadSelectPuzzle Script
        selectScript = code.GetComponent<NumpadSelectPuzzle>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Over == true)
        {         
            // Puzzle Script Edit
            selectScript.i_SelectedIsIncorrect = b_IsIncorrect;
            selectScript.g_SelectedPlateVisual = g_plateVisual;
            selectScript.i_selectedNumber = i_correctNumber;
            selectScript.g_SelectedTile = g_self;

            // Puzzle Scipt Call
            selectScript.NumpadSelectUpdate();

            selected = true;
            HighlightOn();
        }

    }

    private void OnMouseEnter()
    {
        if(Camera.main.transform.position == InteractCamera.position && selected == false && interactable == true)
        {
            HighlightSemiOn();
            Over = true;
            // Set Cursor
            CursorManagement.b_IsCursorNormal = false;
        }
    }

    private void OnMouseExit()
    {
        Over = false;
        if(selected == false)
        {
            NoHighlight();
        }

        // Set Cursor
        CursorManagement.b_IsCursorNormal = true;
    }

    public void SetMaterial()
    {

    }

    public void NoHighlight()
    {
        shaderRenderer.material = m_noShader;
        selected = false;
    }

    public void HighlightSemiOn()
    {
        shaderRenderer.material = m_ShaderOff;
    }

    public void HighlightOn()
    {
        shaderRenderer.material = m_ShaderOn;
    }
}
