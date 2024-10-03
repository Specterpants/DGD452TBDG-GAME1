using UnityEngine;
using UnityEngine.SceneManagement;

public class Sleeping_Code : MonoBehaviour
{
    public GameObject targetObject;   // The object whose opacity will change
    public float countdownTime = 5f;  // The countdown duration in seconds
    private float currentCountdown;   // Tracks the current time left in the countdown
    public Button_Script buttonScript; // Reference to the Button_Script that controls canSleep
    private SpriteRenderer targetSpriteRenderer;  // Reference to the SpriteRenderer of the target object

    void Start()
    {
        // Get the SpriteRenderer component of the target object
        if (targetObject != null)
        {
            targetSpriteRenderer = targetObject.GetComponent<SpriteRenderer>();
            SetTargetObjectOpacity(0f);  // Set the target object to be invisible initially
        }
        else
        {
            Debug.LogError("Target Object is not assigned in the Inspector!");
        }

        // Initialize the countdown timer
        currentCountdown = countdownTime;
    }

    void Update()
    {
        // Access canSleep from Button_Script and check if Space Bar is being held down
        if (buttonScript != null && buttonScript.canSleep && Input.GetKey(KeyCode.Space))
        {
            // Decrease the countdown timer
            currentCountdown -= Time.deltaTime;

            // Update the target object's opacity to make it visible
            SetTargetObjectOpacity(1f);

            // Check if the countdown timer has reached 0
            if (currentCountdown <= 0f)
            {
                // Load the "WinRoom" scene when the timer reaches 0
                SceneManager.LoadScene("WinRoom");
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            // Make the target object invisible and stop the countdown when Space Bar is released
            SetTargetObjectOpacity(0f);
        }
    }

    // Function to change the target object's opacity
    private void SetTargetObjectOpacity(float alpha)
    {
        if (targetSpriteRenderer != null)
        {
            Color color = targetSpriteRenderer.color;
            color.a = alpha;  // Set the alpha (opacity) value
            targetSpriteRenderer.color = color;
        }
    }
}
