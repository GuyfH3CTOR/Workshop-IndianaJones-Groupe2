using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class NumpadLockPuzzle : MonoBehaviour
{
    // Event if correct Lock Number
    [Serializable]
    public class NumpadCorrect : UnityEvent {}
    [FormerlySerializedAs("onClick")]
    [SerializeField]
    private NumpadCorrect m_OnCorrect = new NumpadCorrect();

    [SerializeField]
    private GameObject[] numpadLock;
    [SerializeField]
    private string correctLockNumber;
    [SerializeField]
    private Material basicMaterial;

    [SerializeField] private AudioSource as_Success;
    [SerializeField] private AudioSource as_Failure;

    private int currentLockNumber = 0;
    private int totalLockNumber;
    private string lockNumber;
    
    [HideInInspector]
    public int newLockNumber;
    [HideInInspector]
    public Material newLockMaterial;

    private bool correctLock;

    void Start()
    {
        totalLockNumber = numpadLock.Length;
        // Debug.Log(totalLockNumber);
    }
    
    public void NumpadLockUpdate()
    {
        if(correctLock == false)
        {
            // Lock SetVisual
            numpadLock[currentLockNumber].GetComponent<MeshRenderer>().material = newLockMaterial;

            lockNumber = lockNumber + newLockNumber.ToString();
            // Debug.Log(lockNumber);

            currentLockNumber++;

            if(currentLockNumber>totalLockNumber-1)
            {
                if(lockNumber == correctLockNumber)
                {
                    m_OnCorrect.Invoke();
                    // Debug.Log("correct");
                    correctLock = true;
        
                    as_Success.Play(0);
                }
                else
                {
                    lockNumber = "";                
                    // Debug.Log("incorrect");
                    foreach(GameObject m in numpadLock) 
                    {
                        m.GetComponent<MeshRenderer>().material = basicMaterial;
                    }
                    currentLockNumber = 0;
        
                    as_Failure.Play(0);
                }
            }
        }
    }
}
