using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 6.Inheritance vs Composition
public class Explodable : MonoBehaviour
{
    public void Explode()
    {
        Debug.Log("Boom!");
        Destroy(gameObject);
    }
}

