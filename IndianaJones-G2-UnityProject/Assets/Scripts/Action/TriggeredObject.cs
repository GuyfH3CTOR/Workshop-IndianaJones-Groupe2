using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredObject : MonoBehaviour
{
    // Door Event
    public bool triggerOpen = false;
    public bool triggerClose = false;

    // Select trigger move Speed
    [SerializeField]
    private float doorMovSpeed = 10F;

    // Select trigger Variables
    private Vector3 ClosePosition;
    [SerializeField]
    private Vector3 OpenPosition;

    [SerializeField] private AudioSource as_SlidingDoor;

    //Set Lerping variable
    private bool getLerpingTriggerOpen;
    private bool getLerpingTriggerClose;
    private float startTime;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        // Set triggerClosePosition
        ClosePosition = transform.localPosition;
    }

    public void TriggerOn ()
    {
        triggerOpen = true;
        as_SlidingDoor.Play(0);
    }

    public void TriggerOff ()
    {
        triggerClose = true;
        as_SlidingDoor.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
// Input get TriggerLerping permit going once to open
        if(triggerOpen == true)
        {
            // Set StartTime at the lerping first tick
            startTime = Time.time;

            // Set Lerping Permit
            getLerpingTriggerClose = true;

            // Get Length between startMarker and endMarker
            journeyLength = Vector3.Distance(ClosePosition, OpenPosition);

            triggerOpen = false;
        }

    // Ask if Camera Lerping is permitted to Open
        if(getLerpingTriggerClose == true)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * doorMovSpeed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = Mathf.Clamp(distCovered / journeyLength,0,1);

            // Set our position as a fraction of the distance between the markers.
            transform.localPosition = Vector3.Lerp(ClosePosition, OpenPosition, fractionOfJourney);

            // Debug.Log(fractionOfJourney);

        // check if lerp is done and if the player was NOT looking at the puzzle 
            if(fractionOfJourney == 1)
            {
                // Stop Lerping
                getLerpingTriggerClose = false;
            }
        }
        
// Input get DoorLerping permit going once to open
        if(triggerClose == true)
        {
            // Set StartTime at the lerping first tick
            startTime = Time.time;

            // Set Lerping Permit
            getLerpingTriggerOpen = true;

            // Get Length between startMarker and endMarker
            journeyLength = Vector3.Distance(ClosePosition, OpenPosition);
            
            triggerClose = false;
        }

    // Ask if Camera Lerping is permitted to Open
        if(getLerpingTriggerOpen == true)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * doorMovSpeed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = Mathf.Clamp(distCovered / journeyLength,0,1);

            // Set our position as a fraction of the distance between the markers.
            transform.localPosition = Vector3.Lerp(OpenPosition, ClosePosition, fractionOfJourney);

            // Debug.Log(fractionOfJourney);

        // check if lerp is done and if the player was NOT looking at the puzzle 
            if(fractionOfJourney == 1)
            {
                // Stop Lerping
                getLerpingTriggerOpen = false;
            }
        }
    }
}
