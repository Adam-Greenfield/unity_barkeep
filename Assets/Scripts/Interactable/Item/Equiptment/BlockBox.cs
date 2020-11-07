using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBox : MonoBehaviour, IHittable
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

    void OnDrawGizmos()
    {
        if (active)
        {
            Gizmos.color = Color.red;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, transform.localScale);
        }
    }

    public void RecieveHit(int damage)
    {
        throw new System.NotImplementedException();
    }
}
