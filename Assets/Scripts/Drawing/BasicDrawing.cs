using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BasicDrawing : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        /*
         The direction in between 2 vectors can be calculated by getting the negative value of 
         the subtraction of the two vectors.
        */
        Vector3 direction = -(transform.position - target.position);

        //We create a ray at this object's position and use the direction in between this object and the target.
        Ray ray = new Ray(transform.position, direction);

        //We draw the ray on the unity editor for debugging.
        Debug.DrawRay(ray.origin, ray.direction, Color.black);
        
    }
}
