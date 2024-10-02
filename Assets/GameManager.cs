using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ClockText;
    
    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        // get key down - only the first frame
        // maybe we want to add a black sprite with translucence on it in front of camera?
        
        if (Input.GetKey(KeyCode.Space)) 
        {
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
        }

        // theres gotta be a get key up!, so when key is up, on first frame its up
        // remove black sprite with translucence?
        
       // else
      //  {
      //      elapsedTime = Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            ClockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            
        // some other if statement based on the value of elapsed time right?
        // if elapsed time is greater than some value, then switch scenes to the you win scene?
        if (elapsedTime>10)
            
        {
            Debug.Log("you win");
        }
        
        
    }

   
}
