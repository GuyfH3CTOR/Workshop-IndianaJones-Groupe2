using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackToRoomCenter : MonoBehaviour
{
    // Initialization
    private bool getLerping;
    private bool hello;

    [SerializeField]
    private Transform roomCameraPosition;
    [SerializeField]
    private Transform mainCamera;

    private Transform puzzleCameraPosition;
    
    [SerializeField]
    private float cameraMovSpeed = 1.0F;

    private float startTime;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        getLerping = false;
        hello = false;

        startTime = Time.time;
        journeyLength = Vector3.Distance(puzzleCameraPosition.position, roomCameraPosition.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            getLerping = true;
            puzzleCameraPosition = mainCamera;
        }

        if(getLerping == true && hello == true)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * cameraMovSpeed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(puzzleCameraPosition.position, roomCameraPosition.position, fractionOfJourney);

            if(fractionOfJourney == 1)
            {
                getLerping = false;
            }
        }
    }
}
