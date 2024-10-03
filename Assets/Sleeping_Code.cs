using UnityEngine;
using UnityEngine.SceneManagement;

public class Sleeping_Code : MonoBehaviour
{
    public GameObject targetObject;       // The object to fade in and out
    public float fadeSpeed = 5f;          // Speed of fading in and out
    public float countdownTime = 20f;      // Duration for the countdown
    private float currentCountdown;       // Tracks the remaining time in the countdown
    public Button_Script buttonScript;    // Reference to the Button_Script that controls canSleep
    private SpriteRenderer targetRenderer; // Reference to the SpriteRenderer of the target object

    void Start()
    {
        // Get the SpriteRenderer component of the target object
        if (targetObject != null)
        {
            targetRenderer = targetObject.GetComponent<SpriteRenderer>();
            SetTargetObjectOpacity(0f);  // Initially make the target object invisible
        }
        else
        {
            Debug.LogError("Target not assigned");
        }

        // Initialize the countdown timer
        currentCountdown = countdownTime;
    }

    void Update()
    {
        // Check if canSleep is true from Button_Script and if Space Bar is held down
        if (buttonScript != null && buttonScript.canSleep && Input.GetKey(KeyCode.Space))
        {
            // Decrease the countdown timer
            currentCountdown -= Time.deltaTime;

            // Fade in the object quickly
            FadeInTargetObject();

            // Check if the countdown reaches 0, then load the "WinRoom" scene
            if (currentCountdown <= 0f)
            {
                SceneManager.LoadScene("WinRoom");
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            // Pause the countdown and fade out the object when Space Bar is released
            FadeOutTargetObject();
        }
    }

    // Function to fade in the target object
    private void FadeInTargetObject()
    {
        if (targetRenderer != null)
        {
            Color color = targetRenderer.color;
            color.a = Mathf.MoveTowards(color.a, 1f, fadeSpeed * Time.deltaTime); // Increase opacity
            targetRenderer.color = color;
        }
    }

    // Function to fade out the target object
    private void FadeOutTargetObject()
    {
        if (targetRenderer != null)
        {
            Color color = targetRenderer.color;
            color.a = Mathf.MoveTowards(color.a, 0f, fadeSpeed * Time.deltaTime); // Decrease opacity
            targetRenderer.color = color;
        }
    }

    // Helper function to directly set the target object's opacity
    private void SetTargetObjectOpacity(float alpha)
    {
        if (targetRenderer != null)
        {
            Color color = targetRenderer.color;
            color.a = alpha;  // Set the alpha (opacity) value
            targetRenderer.color = color;
        }
    }
}
