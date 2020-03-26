using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Gun))]
public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public Gun gun;
    Rigidbody rg;

    private Ray downRay;
    public int jumpCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        rg = this.GetComponent<Rigidbody>();
        gun = this.GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        downRaycasting();
    }

    void downRaycasting()
    {
        downRay = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit;
        GameObject playerBody = transform.GetChild(0).gameObject;
        float distance = (playerBody.transform.localScale.y / 2) + (playerBody.transform.localScale.y * 0.01f);

        if(Physics.Raycast(downRay, out hit, distance, 1 << 9))
        {
            Debug.DrawRay(downRay.origin, downRay.direction * distance, Color.green);
            jumpCounter = 0;
        }
        else
        {
            if(jumpCounter < 1)
            {
                Debug.DrawRay(downRay.origin, downRay.direction * distance, Color.green);
            }
            else
            {
                Debug.DrawRay(downRay.origin, downRay.direction * distance, Color.red);
            }
        }
    }

    void move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < 1)
        {
            rg.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCounter++;
        }
    }
}
