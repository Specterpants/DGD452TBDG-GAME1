using UnityEngine;
using System.Collections;

public class Fade_code : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component attached to the GameObject
        originalColor = spriteRenderer.color; // Store the original color of the sprite.
        SetSpriteOpacity(0f); // Initially make the object invisible.
    }

    // Public method to start the reappearing and disappearing process.
    public void StartReappear()
    {
        StartCoroutine(FadeInAndOut());
    }

    // Coroutine to fade in the object, wait for 2 seconds, then fade it out.
    IEnumerator FadeInAndOut()
    {
        // Fade in.
        for (float alpha = 0f; alpha < 1f; alpha += 0.05f)
        {
            SetSpriteOpacity(alpha);
            yield return new WaitForSeconds(0.05f);
        }

        // Ensure it's fully visable.
        SetSpriteOpacity(1f);

        // Wait for 2 seconds while the object is fully visible.
        yield return new WaitForSeconds(1.3f);

        // Fade out.
        for (float alpha = 1f; alpha > 0; alpha -= 0.05f)
        {
            SetSpriteOpacity(alpha);
            yield return new WaitForSeconds(0.05f);
        }

        // Ensure the opacity is fully gone at the end.
        SetSpriteOpacity(0f);
    }

    // Helper function to set the sprite's opacity.
    private void SetSpriteOpacity(float alpha)
    {
        Color newColor = originalColor;
        newColor.a = alpha;
        spriteRenderer.color = newColor;
    }
}





/*
public float fadeDuration = 0.5f;
    private SpriteRenderer spriteRenderer;
    private float fadeElapsed = 0f;
    private bool shouldFade = false;

    // States for whether fading in or fading out
    private bool isFadingOut = false;
    private bool isFadingIn = false;
    
    void Start()
    {
        // Get the SpriteRenderer component from the object
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // When the player presses space, start fading in
        if (Button_Script.currentlyMoving == false)
        {
            isFadingIn = true;
            isFadingOut = false;  // Cancel fade out if it's in progress
            shouldFade = false;
            //fadeElapsed = 0f;    // Reset fade timer
        }

        // When the player releases space, start fading out
        else if (Button_Script.currentlyMoving == true)
        {
            isFadingOut = true;
            isFadingIn = false;  // Cancel fade in if it's in progress
            shouldFade = true;
            //fadeElapsed = 0f;  // Reset fade timer
        }

        //Same shit but for the Player Moving

        if (!shouldFade)
        {
            return;
        }
            
        // Fading out
        if (isFadingOut)
        {
            fadeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, fadeElapsed / fadeDuration);
            
            //No idea
            Color newColor = new Color(0,0,0, alpha);
            spriteRenderer.color = newColor;

            // Stop fading out when the object is fully in
            if (alpha <= 0f)
            {
                isFadingOut = false;
                fadeElapsed = 0;
                shouldFade = false;
            }
        }

        // Fading in
        else if (isFadingIn)
        {
            fadeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, fadeElapsed / fadeDuration);
            Debug.Log(fadeElapsed);
            //No idea
            Color newColor = new Color(0,0,0, alpha);
            spriteRenderer.color = newColor;

            // Stop fading in when the object is fully in
            if (alpha >= 1f)
            {
                isFadingIn = false;
                fadeElapsed = 0;
                shouldFade = false;
            }
        }
    }
*/