using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBox : MonoBehaviour
{
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RegisterHit()
    {
        Debug.Log("I am the blocking box, and I'm about to register");
    }
}
