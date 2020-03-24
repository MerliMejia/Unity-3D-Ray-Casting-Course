using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BasicCollision : MonoBehaviour
{
    //Max distance for detecting collisions and drawing the ray
    public float maxDistance;
    private void Update()
    {
        raycasting();   
    }

    void raycasting()
    {
        //Create a ray at this object's position aiming to the rigth direction
        Ray ray = new Ray(transform.position, Vector3.right);
        //Store information about the object colliding with the ray
        RaycastHit hit;
        //Draw the ray
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.magenta);

        /*
         Physics.Raycast return true if something collides with the ray.
         If we pass the maxDistance as parameter it will only detects sollisions in between that distance
         */
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Debug.Log(hit.collider.name);
        }
    }

}
