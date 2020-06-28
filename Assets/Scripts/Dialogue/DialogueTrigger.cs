using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = DialogueManager.instance;
    }
    public void TriggerDialalogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }
}
