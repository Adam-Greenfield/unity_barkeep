using System.Collections;
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
        Debug.Log("Hitbox is colliding with " + entity);
        onTriggerActivatedCallback.Invoke(entity);
    }
}
