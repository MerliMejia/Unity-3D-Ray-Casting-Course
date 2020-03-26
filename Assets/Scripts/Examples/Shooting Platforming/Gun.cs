using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public float aimingThickness;
    Ray aimingRay;
    Ray cameraToMouseRay;

    Vector3 mousePosition;

    GameObject cannon;

    private void Start()
    {
        cannon = transform.GetChild(0).gameObject;
    }

    private void LateUpdate()
    {
        cameraToMouseRaycasting();
        aimingRaycasting();
    }

    void aimingRaycasting()
    {
        Vector3 origin = cannon.transform.position + new Vector3(cannon.transform.localScale.x / 2, 0, 0);
        Vector3 mousedirection = -(origin - new Vector3(mousePosition.x, mousePosition.y, 0)).normalized;
        aimingRay = new Ray(origin, mousedirection);
        float mouseDistance = Vector3.Distance(origin, mousePosition);
        Debug.DrawRay(aimingRay.origin, aimingRay.direction * mouseDistance, Color.red);
    }

    void cameraToMouseRaycasting()
    {
        Vector3 playerPosition = transform.parent.parent.position;
        cameraToMouseRay = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerPosition.z));
        float distance = Vector3.Distance(Camera.main.transform.position, playerPosition);
        mousePosition = cameraToMouseRay.GetPoint(distance);
        Debug.DrawRay(cameraToMouseRay.origin, cameraToMouseRay.direction * distance, Color.blue);
    }
}
