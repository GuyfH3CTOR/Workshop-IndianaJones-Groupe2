using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class OnEnterEventTrap : MonoBehaviour
{
    // Event if correct Select Number
    [Serializable] public class StartEvent : UnityEvent {}
    [FormerlySerializedAs("onClick")]
    [SerializeField] private StartEvent e_StartEvent = new StartEvent();

    [Serializable] public class StopEvent : UnityEvent {}
    [FormerlySerializedAs("onClick")]
    [SerializeField] private StopEvent e_StopEvent = new StopEvent();
    
    [Serializable] public class EndEvent : UnityEvent {}
    [FormerlySerializedAs("onClick")]
    [SerializeField] private EndEvent e_EndEvent = new EndEvent();

    // Camera
    [SerializeField] private Transform t_InteractCamera;
    
    // Water
    [SerializeField] private Transform t_Water;
    [SerializeField] private float f_WaterSpeed;

    [SerializeField] private AudioSource as_Water;

    // Lerp
    private Vector3 v3_start;
    private Vector3 v3_end;
    private float f_startTime;
    private float f_journeyLength;
    private bool b_GetLerping;
    private bool b_trapActivated = true;

    // boolean
    private bool b_HasBeenDoneOnce;

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.transform.position == t_InteractCamera.position && b_HasBeenDoneOnce == false)
        {
            // Setup
            v3_start = t_Water.position;
            v3_end = t_InteractCamera.position;

            // Calls
            e_StartEvent.Invoke();
            StartLerping();
            b_HasBeenDoneOnce = true;
        
            as_Water.Play(0);
        }

        if(b_GetLerping)
        {
            LerpingToNewPosition();
        }
    }

    public void StopTrap()
    {
        // Setup        
        v3_end = v3_start;
        v3_start = t_Water.position;

        // Calls
        StartLerping();
        b_trapActivated = false;
        e_StopEvent.Invoke();
        
        as_Water.Stop();
    }

    private void StartLerping()
    {
        // Set StartTime at the lerping first tick
        f_startTime = Time.time;

        // Get Length between startMarker and endMarker
        f_journeyLength = Vector3.Distance(v3_start, v3_end);

        // Start Lerping Update
        b_GetLerping = true;
    }
    
    private void LerpingToNewPosition()
    {          
        // Distance moved equals elapsed time times speed..
        float _f_distCovered = (Time.time - f_startTime) * f_WaterSpeed;

        // Fraction of journey completed equals current distance divided by total distance.
        float _f_fractionOfJourney = Mathf.Clamp(_f_distCovered / f_journeyLength,0,1);

        // Set our position as a fraction of the distance between the markers.
        t_Water.position = Vector3.Lerp(v3_start, v3_end, _f_fractionOfJourney);

        // check if lerp is done and if the player was NOT looking at the puzzle 
        if(_f_fractionOfJourney >= 1)
        {            
            // reset _f_fractionOfJourney
            _f_fractionOfJourney = 0;
            
            // Stop Lerping
            b_GetLerping = false;

            if(b_trapActivated)
            {
                e_EndEvent.Invoke();
        
                as_Water.Stop();
            }
        }
    }
}
