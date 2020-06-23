using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    private List<string> subjects;


    public Text nameText;
    public Text introductionText;

    public GameObject buttonPrefab;

    public Animator animator;
    public RectTransform boxTransform;

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

        foreach (string introductionText in dialogue.introduction)
        {
            sentences.Enqueue(introductionText);
        }

        foreach (SubjectList.Subjects subject in dialogue.subjects)
        {
            subjects.Add(nameof(subject.name));
        }

        //remember to re enqueue the sentences

        DisplayNextSentence(dialogue);
    }

    public void DisplayNextSentence(Dialogue dialogue)
    {
        if(sentences.Count == 0)
        {
            //when sentences run out, display dialogue menu
            ShowMenu(dialogue);
            //EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        introductionText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            introductionText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    void ShowMenu(Dialogue dialogue)
    {
        SpeechOptions speechOptions = new SpeechOptions(dialogue.subjects, buttonPrefab, boxTransform);
        //build a menu made out of buttons for dialogue choices. Probaly best to put this into a seperate class
    }


}
