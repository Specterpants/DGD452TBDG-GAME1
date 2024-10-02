using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBarController : MonoBehaviour
{
    private bool IsInTriggerArea = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInTriggerArea && Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space bar is being pressed in bed area");
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        IsInTriggerArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        IsInTriggerArea = false;
    }
}
