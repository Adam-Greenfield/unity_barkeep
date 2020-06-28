using UnityEngine;

[RequireComponent(typeof(SpeechObject))]
class NpcInteractor : Interactable
{
    private float npcHeight;
    private DialogueTrigger dialogueTrigger;
    SpeechObject speech;

    public override void Start()
    {
        base.Start();
        speech = GetComponent<SpeechObject>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public override void Update()
    {
        //take all in base update func, then set speech position to 
        base.Update();
        speech.UpdatePosition(new Vector3(interactionTransform.position.x, interactionTransform.position.y + 2.5f, interactionTransform.position.z));
    }

    public override void Interact()
    {
        base.Interact();
        npcHeight = interactionTransform.localScale.y;
        /*        Camera.main.GetComponent<CameraController>().moveTowardsInteraction(interactionTransform);
        */        //here we will lock the camera above the npc and player, and start some dialogue
        dialogueTrigger.TriggerDialalogue();
    }


    public override void InspectFromMenu()
    {
        Debug.Log("Inspected npc");
    }

    public override void InteractFromMenu()
    {
        player.SetFocus(this);
    }
}

