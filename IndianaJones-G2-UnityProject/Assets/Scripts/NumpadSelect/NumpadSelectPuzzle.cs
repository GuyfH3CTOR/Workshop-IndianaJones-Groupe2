using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class NumpadSelectPuzzle : MonoBehaviour
{
    // Event if correct Select Number
    [Serializable] public class AllSelectedCorrect : UnityEvent {}
    [FormerlySerializedAs("onClick")]
    [SerializeField] private AllSelectedCorrect m_AllCorrect = new AllSelectedCorrect();

    [Space(10)] // 10 pixels of spacing here.

    // Arrays
    [SerializeField] private GameObject[] numpadSelectTiles;    
    private S_DemButton tilesScript;

    [Space(10)] // 10 pixels of spacing here.

    [SerializeField] private AudioSource as_Success;
    [SerializeField] private AudioSource as_GoodSelection;
    [SerializeField] private AudioSource as_Failure;

    // Selected Tile
    [HideInInspector] public int i_selectedNumber;
    [HideInInspector] public bool i_SelectedIsIncorrect;
    [HideInInspector] public GameObject g_SelectedTile;
    private S_DemButton s_SelectedTilesScript;
    [HideInInspector] public GameObject g_SelectedPlateVisual;    
    private Renderer r_plateVisual;

    // Selected Button
    [HideInInspector] public int i_buttonNumber;    
    [HideInInspector] public Material i_buttonMaterial;

    private bool correctLock;

    public void NumpadSelectUpdate()
    {
        foreach(var g in numpadSelectTiles)
        {
            g.GetComponent<S_DemButton>().NoHighlight();
        }
    }

    public void NumpadSelectCheck()
    {
        if(i_selectedNumber == i_buttonNumber)
        {
            // Get renderers
            r_plateVisual = g_SelectedPlateVisual.GetComponent<Renderer>();
            r_plateVisual.material = i_buttonMaterial;

            g_SelectedTile.GetComponent<S_DemButton>().b_IsIncorrect = false;

            // Check if Solution Found
            bool _SolutionFound = true;
            for(int i=0; i < numpadSelectTiles.Length; i++)
            {
                if (numpadSelectTiles[i].GetComponent<S_DemButton>().b_IsIncorrect)
                {
                    _SolutionFound = false;
                }
            }
            if(_SolutionFound)
            {
                m_AllCorrect.Invoke();
                // Debug.Log("correct");
            }
            // Debug.Log("true");
        }
        else
        {
            // Debug.Log("false");
            as_Failure.Play(0);
        }

        // Reset Highlight
        foreach(var g in numpadSelectTiles)
        {
            g.GetComponent<S_DemButton>().NoHighlight();
        }
    }
}
