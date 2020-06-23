using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    private List<string> subjects;


    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    void Start()
    {
        sentences = new Queue<string>();
        subjects = new List<string>();
    }
    
    public void StartDialogue(Dialogue dialogue)  
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        subjects.Clear();

        sentences.Clear();

        foreach (SubjectList.Subjects subject in dialogue.subjects)
        {
            subjects.Add(nameof(subject.name));
        }

        //remember to re enqueue the sentences

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }


}
