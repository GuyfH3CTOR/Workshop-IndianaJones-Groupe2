using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class OnEnterEvent : MonoBehaviour
{
    // Event if correct Select Number
    [Serializable] public class EnterEvent : UnityEvent {}
    [FormerlySerializedAs("onClick")]
    [SerializeField] private EnterEvent e_EnterEvent = new EnterEvent();

    // Camera
    [SerializeField] private Transform t_InteractCamera;

    [SerializeField] private AudioSource as_Journal;

    // boolean
    private bool b_HasBeenDoneOnce;

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.transform.position == t_InteractCamera.position && b_HasBeenDoneOnce == false)
        {
            // Setup
            b_HasBeenDoneOnce = true;

            as_Journal.Play(0);

            // Calls
            e_EnterEvent.Invoke();
        }
    }
}
