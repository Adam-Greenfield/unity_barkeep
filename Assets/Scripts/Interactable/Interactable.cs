using UnityEngine;

[RequireComponent(typeof(MenuObject))]
public abstract class Interactable : MonoBehaviour
{

    public Transform interactionTransform;
    Transform playerTransform;
    private MenuObject menu;
    public PlayerController player;
    private Vector3 currentPosition;

    public float radius = 1.5f;
    bool isFocus = false;
    bool hasInteracted = false;
    

    public virtual void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        menu = GetComponent<MenuObject>();
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

    public virtual void Interact()
    {
        //overwrite in class
        menu.Close();
        Debug.Log("Interacting with " + transform.name);
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
        if (!interactionTransform)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    public void OpenMenu()
    {
        currentPosition = new Vector3(interactionTransform.position.x, interactionTransform.position.y + 2.5f, interactionTransform.position.z);

        menu.Open(currentPosition, InspectFromMenu, InteractFromMenu);
    }

    public abstract void InspectFromMenu();

    public abstract void InteractFromMenu();

}
