﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public delegate void OnTriggerActivated(Collider entity);
    public OnTriggerActivated onTriggerActivatedCallback;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider entity)
    {
        if (entity is IHittable && onTriggerActivatedCallback != null)
        {
            //if collider is a block box, check if it's active
            BlockBox blockBox = entity.GetComponent<BlockBox>();

            if (blockBox && blockBox.active)
            {
                onTriggerActivatedCallback.Invoke(entity);
                onTriggerActivatedCallback = delegate { };

                return;
            }

        }
    }
}
