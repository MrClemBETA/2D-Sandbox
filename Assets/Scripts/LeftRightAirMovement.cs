using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightAirMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float flyDistance = 10.0f;

    private float distanceMoved = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        if (transform.localScale.x > 0 && distanceMoved < flyDistance)
        {
            float newX = pos.x + speed * Time.deltaTime;
            distanceMoved += Math.Abs(newX - pos.x);
            transform.position = new Vector2(newX, pos.y);
            
        } else if(transform.localScale.x < 0 && distanceMoved < flyDistance)
        {
            float newX = pos.x - speed * Time.deltaTime;
            distanceMoved += Math.Abs(newX - pos.x);
            transform.position = new Vector2(newX, pos.y);
        }

        if (distanceMoved > flyDistance)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            distanceMoved = 0;
        }
    }
}
