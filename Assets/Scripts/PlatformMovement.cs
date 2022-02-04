using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 5f;

    private BoxCollider2D bc;
    private RectTransform rect;

    private float xSize;
    private float ySize;
    private float xOffset;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        xSize = bc.size.x;
        ySize = bc.size.y;
        xOffset = bc.offset.x;
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move character based on position
        float xPos = transform.position.x;
        float newX = xPos + transform.localScale.x * speed * Time.deltaTime;
        transform.position = new Vector2(newX, transform.position.y);

        // Determine the front of the sprite
        float frontOfSpriteX = rect.position.x + transform.localScale.x * (xSize / 2 + xOffset);
        float frontOfSpriteY = rect.position.y - ySize / 2;

        // Debug ray
        Debug.DrawRay(new Vector2(frontOfSpriteX, frontOfSpriteY), Vector3.down, Color.red);

        if (!Physics2D.Raycast(new Vector2(frontOfSpriteX, frontOfSpriteY), Vector2.down, 1))
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
