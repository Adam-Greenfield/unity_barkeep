using UnityEngine;

[RequireComponent(typeof(MenuObject))]
public abstract class Interactable : MonoBehaviour
{

    public float radius = 1.5f;
    public Transform interactionTransform;
    public MenuObject menu;
    private Vector3 currentPosition;

    bool isFocus = false;
    bool hasInteracted = false;
    Transform playerTransform;


    public virtual void Interact()
    {
        //overwrite in class
        Debug.Log("Interacting with " + transform.name);
    }

    public virtual void Update()
    {
        if (isFocus && !hasInteracted)
        {

            float distance = Vector3.Distance(playerTransform.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void onFocused(Transform transform)
    {
        isFocus = true;
        playerTransform = transform;
        hasInteracted = false;

    }

    public void onDefocused()
    {
        isFocus = false;
        playerTransform = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    public void OpenMenu()
    {
        currentPosition = new Vector3(interactionTransform.position.x, interactionTransform.position.y + 2.5f, interactionTransform.position.z);

        menu.open(currentPosition, InspectFromMenu, InteractFromMenu);
    }

    public abstract void InspectFromMenu();

    public abstract void InteractFromMenu();

}
