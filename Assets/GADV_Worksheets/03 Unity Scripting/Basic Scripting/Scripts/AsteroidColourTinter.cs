using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidColourTinter : MonoBehaviour
{

    public Color originalColor = Color.white;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Access the SpriteRenderer component
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer.color == originalColor)
            {
                spriteRenderer.color = Color.blue;
            }

            else
            {
                spriteRenderer.color = originalColor;
            }
        }
    }
}

