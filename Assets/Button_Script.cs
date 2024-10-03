using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Script : MonoBehaviour
{
    public Camera camera; // Reference to the Camera.
    public Transform targetPos; // The target position where the camera should move.
    public float moveDelayTime = 1.5f; // Delay time in seconds.
    public static bool currentlyMoving = false;
    public AudioSource runningSound;
    
    public GameObject sleepingObject; // Reference to the object with the Sleeping_Code script
    public bool canSleep = false;  // Tracks if the player is in the area to sleep.
    void Start()
    {
        runningSound.Stop();
    }

    void Update()
    {
        // Left mouse button is clicked.
        if (Input.GetMouseButtonDown(0))
        {
            if (currentlyMoving == false)
            {
                // Convert the mouse position to a 2D world point.
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Perform a raycast to check if the object was clicked.
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
                
                // Check if the clicked object has this script attached (this object).
                if (hit.collider != null && hit.collider.transform == transform)
                {
                    OnObjectClicked();
                    //Make sure they player can't move to another location.
                    currentlyMoving = true;
                    runningSound.Play();
                    Debug.Log("FADE");

                    if (targetPos == CompareTag("atBed"))
                    {
                        canSleep = true;
                        
                    }

                    else if (targetPos == CompareTag("notAtBed"))
                    {
                        canSleep = false;
                    }
                }
            }
        }
    }

    // This method gets triggered when the object is clicked.
    void OnObjectClicked()
    {
        Debug.Log("Moving to location.");
        
        StartCoroutine(MoveCameraWithDelay());
    }

    // Coroutine to wait for a delay before moving the camera.
    IEnumerator MoveCameraWithDelay()
    {
        // Wait for the specified amount of time.
        yield return new WaitForSeconds(moveDelayTime);

        // Move the camera to the target position after the delay.
        camera.transform.position = new Vector3(targetPos.position.x, targetPos.position.y, -10);
        
        Debug.Log("Went to location.");
        
        //Allow the Player to move again.
        currentlyMoving = false;
        runningSound.Stop();
    }
    
    // This function is called when the user clicks on the button object
    void OnMouseDown()
    {
        // If the sleepingObject is assigned, trigger the reappearing/disappearing process
        if (sleepingObject != null)
        {
            Fade_code sleepingScript = sleepingObject.GetComponent<Fade_code>();
            if (sleepingScript != null)
            {
                sleepingScript.StartReappear();
            }
        }
    }
}