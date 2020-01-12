using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    //public Vector3 offset;
    public float pitch = 1f;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    private float currentZoom = 5f;


    float speed = 30.0f;

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            //Use transform.Translate to move relative to the camera, transform.position would move relative to the world
            transform.Translate(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0.0f);

        }
    }

}
