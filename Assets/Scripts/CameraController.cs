using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float pitch = 1f;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    Transform camTransform;



    float speed = 45.0f;

    void Start()
    {
        camTransform = Camera.main.transform;
    }



    void Update()
    {
        
        if (Input.GetMouseButton(2))
        {
            transform.position = transform.position + Quaternion.Euler(0, transform.eulerAngles.y, 0)
                * new Vector3(-Input.GetAxisRaw("Mouse X"), 0, -Input.GetAxisRaw("Mouse Y"))
                * speed
                * Time.deltaTime;
        }

        if (Input.GetKey("left"))
        {
            Ray ray = new Ray(camTransform.position, camTransform.forward);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 500))
            {
                transform.RotateAround(hit.point, Vector3.up, 100.0f * Time.deltaTime);
            }
        }

        if (Input.GetKey("right"))
        {
            Ray ray = new Ray(camTransform.position, camTransform.forward);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 500))
            {
                transform.RotateAround(hit.point, Vector3.down, 100.0f * Time.deltaTime);
            }

        }


        //wsad options
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }

}
