using UnityEngine;

[RequireComponent(typeof(SpeechObject))]
class NpcInteractor : Interactable
{
    private float npcHeight;
    private Vector3 currentPosition;
    SpeechObject speech;

    void Start()
    {
        speech = GetComponent<SpeechObject>();
        menu = GetComponent<MenuObject>();
    }

    public override void Update()
    {
        //take all in base update func, then set speech position to 
        base.Update();
        speech.updatePosition(new Vector3(interactionTransform.position.x, interactionTransform.position.y + 2.5f, interactionTransform.position.z));
    }
    
    public override void Interact()
    {
        Debug.Log("I am interacting with an npc");
        npcHeight = interactionTransform.localScale.y;
        // here we will lock the camera above the npc and player, and start some dialogue
        speech.speak("Hello world");
        openMenu();
    }

    public override void openMenu()
    {
        currentPosition = new Vector3(interactionTransform.position.x, interactionTransform.position.y + 2.5f, interactionTransform.position.z);

        menu.open(currentPosition);
        //create a menu above the interactable clicked on, with a list of 
    }
}

