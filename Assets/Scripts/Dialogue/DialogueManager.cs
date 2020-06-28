using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    private List<string> subjects;
    private List<GameObject> instButtons;
    private Dialogue this_dialogue;


    public Text nameText;
    public Text introductionText;

    public GameObject buttonPrefab;

    public Animator animator;
    public RectTransform boxTransform;

    public GameObject continueButton;

    void Start()
    {
        sentences = new Queue<string>();
        subjects = new List<string>();
        instButtons = new List<GameObject>();
    }
    
    public void StartDialogue(Dialogue dialogue)  
    {
        this_dialogue = dialogue;
        animator.SetBool("IsOpen", true);

        nameText.text = this_dialogue.name;

        subjects.Clear();

        sentences.Clear();

        foreach (string introductionText in this_dialogue.introduction)
        {
            sentences.Enqueue(introductionText);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            //when sentences run out, display dialogue menu
            ShowMenu();
            //EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        continueButton.SetActive(true);
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

    void ShowMenu()
    {
        /*        SpeechOptions speechOptions = new SpeechOptions(dialogue.subjects, buttonPrefab, boxTransform);
        */
        continueButton.SetActive(false);

        foreach (SubjectList.Subject subject in this_dialogue.subjects)
        {
            GameObject goButton = Instantiate(buttonPrefab);
            goButton.transform.SetParent(boxTransform, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Text text = goButton.GetComponentInChildren<Text>();
            text.text = subject.name.ToString();

            goButton.GetComponent<Button>().onClick.AddListener(() => StartSubject(subject));

            instButtons.Add(goButton);
        }
        //build a menu made out of buttons for dialogue choices. Probaly best to put this into a seperate class
    }

    void StartSubject(SubjectList.Subject subject)
    {

        //remove subject buttons
        foreach (GameObject button in instButtons)
        {
            Destroy(button);
        }


        foreach(string sentence in subject.subjectLines)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    


}
