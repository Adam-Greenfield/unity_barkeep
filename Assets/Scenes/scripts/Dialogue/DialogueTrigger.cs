using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialalogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        Debug.Log(dialogue.Subjects[1].name);
    }
}
