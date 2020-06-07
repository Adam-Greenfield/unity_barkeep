using UnityEngine;

[RequireComponent(typeof(SpeechObject))]
class NpcInteractor : Interactable
{
    private float npcHeight;
    SpeechObject speech;

    public override void Start()
    {
        base.Start();
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
        menu.close();
        npcHeight = interactionTransform.localScale.y;
/*        Camera.main.GetComponent<CameraController>().moveTowardsInteraction(interactionTransform);
*/        // here we will lock the camera above the npc and player, and start some dialogue
    }


    public override void InspectFromMenu()
    {
        Debug.Log("Inspected npc");
    }

    public override void InteractFromMenu()
    {
        Debug.Log("Interacted with npc");
        player.SetFocus(this);
    }
}

