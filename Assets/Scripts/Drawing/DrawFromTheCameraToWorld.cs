using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawFromTheCameraToWorld : MonoBehaviour
{
    public float distance;
    void Update()
    {
        /*
         ScreenPointToRay returns a ray going from camera through a screen point.
         Because we use the mouse position as the screen point the ray will go from
         the camera to the mouse position.
         */
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        /*
         -We draw the ray on the unity editor for debugging.
         -Every time you multiply a vector by a number, the vector keeps the same direction.
         So we're basically saying "keep adding to this direction until you reach the target"
         */
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.magenta);
    }
}
