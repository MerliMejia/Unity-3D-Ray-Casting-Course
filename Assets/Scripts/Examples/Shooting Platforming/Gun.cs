﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public abstract class Gun : MonoBehaviour
{
    abstract public float aimingThickness { get; }
    float maxdistance = 0;

    Ray aimingRay;
    Ray cameraToMouseRay;

    Vector3 mousePosition;
    Vector3 mousedirection;

    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    private void LateUpdate()
    {
        cameraToMouseRaycasting();
        aimingRaycasting();
    }

    void aimingRaycasting()
    {
        mousedirection = -(transform.position - new Vector3(mousePosition.x, mousePosition.y, 0)).normalized;
        aimingRay = new Ray(transform.position, mousedirection);
        float mouseDistance = Vector3.Distance(transform.position, mousePosition);

        
        RaycastHit hit;

        if (Physics.SphereCast(aimingRay, aimingThickness, out hit, mouseDistance, 1 << 9))
        {
            maxdistance = hit.distance;
        }
        else
        {
            maxdistance = mouseDistance;
        }
         

        Debug.DrawRay(aimingRay.origin, aimingRay.direction * maxdistance, Color.red);

        lineRenderer.SetPosition(0, aimingRay.origin);
        lineRenderer.SetPosition(1, aimingRay.GetPoint(maxdistance + aimingThickness));
        lineRenderer.widthMultiplier = aimingThickness * 2;
    }

    void cameraToMouseRaycasting()
    {
        Vector3 playerPosition = transform.position;
        cameraToMouseRay = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerPosition.z));
        float distance = Vector3.Distance(Camera.main.transform.position, playerPosition);
        mousePosition = cameraToMouseRay.GetPoint(distance);
        Debug.DrawRay(cameraToMouseRay.origin, cameraToMouseRay.direction * distance, Color.blue);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + (mousedirection * maxdistance), aimingThickness);
    }
}
