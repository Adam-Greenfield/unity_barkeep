﻿using System.Collections;
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
    Transform camTransform;



    float speed = 30.0f;

    void Start()
    {
        camTransform = Camera.main.transform;
    }

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            //Use transform.Translate to move relative to the camera, transform.position would move relative to the world
            transform.Translate(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0.0f);

        }

        if (Input.GetKey("left"))
        {
            Debug.Log("left was pressed");
            Ray ray = new Ray(camTransform.position, camTransform.forward);

            RaycastHit hit; 

            if(Physics.Raycast (ray, out hit, 500))
            {
                transform.RotateAround(hit.point, Vector3.up, 100.0f * Time.deltaTime);
            }
        }

        if (Input.GetKey("right"))
        {
            Debug.Log("right was pressed");
            Ray ray = new Ray(camTransform.position, camTransform.forward);

            RaycastHit hit; 

            if(Physics.Raycast (ray, out hit, 500))
            {
                transform.RotateAround(hit.point, Vector3.down, 100.0f * Time.deltaTime);
            }

        }

    }

}
