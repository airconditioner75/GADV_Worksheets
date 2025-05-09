using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 6. Inheritance vs Composition
public class Item : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Explodable>()?.Explode();
        }
    }
}
