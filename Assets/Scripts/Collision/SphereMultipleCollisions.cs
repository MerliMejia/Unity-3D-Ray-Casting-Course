using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SphereMultipleCollisions : MonoBehaviour
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
        //Store information about ALL the objects colliding with the ray
        RaycastHit[] hit = Physics.SphereCastAll(ray, radius, maxDistance, layerMask);
        //Draw the ray
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.magenta);

        //We can then go through all the hits using a for loop
        for (int i = 0; i < hit.Length; i++)
        {
            Debug.Log(hit[i].collider.name);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position + (Vector3.right * maxDistance), radius);
    }
}
