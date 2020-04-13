using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 1.5f;
    public Transform interactionTransform;

    bool isFocus = false;
    bool hasInteracted = false;
    Transform player;


    public virtual void Interact()
    {
        //overwrite in class
        Debug.Log("Interacting with " + transform.name);
    }

    public virtual void Update()
    {
        if (isFocus && !hasInteracted)
        {
            //Debug.Log(player.position);
            //Debug.Log(interactionTransform.position);

            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void onFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;

    }

    public void onDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
