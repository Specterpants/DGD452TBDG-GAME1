using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = System.Numerics.Vector3;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 LastClickedPos;

    private bool moving;
    
    
    
    
    

    // Update is called once per frame
    void Update()
    {
        // if press left mouse player moves to position of the mouse
        if (Input.GetMouseButtonDown(0))
        {
            LastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }

        if (moving && (Vector2)transform.position != LastClickedPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, LastClickedPos, step);
            
        }
        else
        {
            moving = false;
        }
    }
}
