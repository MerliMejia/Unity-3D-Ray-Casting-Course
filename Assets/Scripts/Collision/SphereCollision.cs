﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SphereCollision : MonoBehaviour
{
    //Max distance for detecting collisions and drawing the ray
    public float maxDistance;

    public float radius;
    private void Update()
    {
        raycasting();
    }

    void raycasting()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        /*
         This would cast rays only against colliders in layer 8.
         But if you want to do the oposite(collide against everything except layer 8). The ~ operator does this, it inverts a bitmask.
         Example:
         layerMask = ~layerMask;
         */

        //Create a ray at this object's position aiming to the rigth direction
        Ray ray = new Ray(transform.position, Vector3.right);
        //Store information about the object colliding with the ray
        RaycastHit hit;
        //Draw the ray
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.magenta);

        /*
         Physics.SphereCast return true if something collides with the ray.
         Think at this as a ray which you can specify how thick you want it to be
         If we pass the maxDistance as parameter it will only detects sollisions in between that distance
         Passing the layermask the ray will detects only objects in the layer number 8
         */
        if (Physics.SphereCast(ray, radius, out hit, maxDistance, layerMask))
        {
            Debug.Log(hit.collider.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position + (Vector3.right * maxDistance), radius);
    }
}
