using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DrawInBetweenObjects : MonoBehaviour
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

        //Vector3.Distance returns the distance in between 2 vectors
        float distance = Vector3.Distance(transform.position, target.position);

        /*
         -We draw the ray on the unity editor for debugging.
         -Every time you multiply a vector by a number, the vector keeps the same direction.
         So we're basically saying "keep adding to this direction until you reach the target"
         */
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.black);

    }
}
