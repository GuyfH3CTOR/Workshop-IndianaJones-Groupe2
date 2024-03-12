using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class MultipleLock : MonoBehaviour
{
    // Event if correct Lock Number
    [Serializable]
    public class LockOpened : UnityEvent {}
    [FormerlySerializedAs("onClick")]
    [SerializeField]
    private LockOpened e_LockOpened = new LockOpened();
    
    [SerializeField]
    private int i_NumberOfLock;
    private int i_NumberOfOpened = 0;

    // Start is called before the first frame update
    public void NewLockOpened()
    {
        i_NumberOfOpened++;

        if(i_NumberOfOpened == i_NumberOfLock)
        {
            e_LockOpened.Invoke();
        }
    }
}
