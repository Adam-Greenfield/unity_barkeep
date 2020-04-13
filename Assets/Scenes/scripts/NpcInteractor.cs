using UnityEngine;

[RequireComponent(typeof(SpeechObject))]
class NpcInteractor : Interactable
{
    private float npcHeight;
    SpeechObject speech;

    void Start()
    {
        speech = GetComponent<SpeechObject>();
        
    }
    
    public override void Interact()
    {
        Debug.Log("I am interacting with an npc");
        npcHeight = interactionTransform.localScale.y;
        var speechPosition = new Vector3(interactionTransform.position.x, interactionTransform.position.y + 1, interactionTransform.position.z);
        // here we will lock the camera above the npc and player, and start some dialogue
        speech.speak("Hello world", speechPosition);
    }
}

