using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    public static DialogueManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of dialogue manager found");
        }
        instance = this;
    }
    #endregion

    Queue<string> sentences;
    List<string> subjects;
    List<GameObject> instButtons;
    Dialogue this_dialogue;


    public Text nameText;
    public Text introductionText;

    public GameObject buttonPrefab;
    public GameObject continueButton;

    public Animator animator;
    public RectTransform boxTransform;


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
        ClearMenu();
        animator.SetBool("IsOpen", false);
    }

    void ShowMenu()
    {
        continueButton.SetActive(false);

        foreach (SubjectList.Subject subject in this_dialogue.subjects)
        {
            GameObject goButton = CreateButton();

            Text goButtonText = goButton.GetComponentInChildren<Text>();
            goButtonText.text = subject.name.ToString();

            goButton.GetComponent<Button>().onClick.AddListener(() => StartSubject(subject));

            instButtons.Add(goButton);
        }

        GameObject exitButton = CreateButton();

        Text exitText = exitButton.GetComponentInChildren<Text>();
        exitText.text = "Goodbye";

        exitButton.GetComponent<Button>().onClick.AddListener(() => EndDialogue());

        instButtons.Add(exitButton);
    }

    void ClearMenu()
    {
        foreach (GameObject button in instButtons)
        {
            Destroy(button);
        }
    }

    GameObject CreateButton()
    {
        GameObject button = Instantiate(buttonPrefab);
        button.transform.SetParent(boxTransform, false);
        button.transform.localScale = new Vector3(1, 1, 1);
        return button;
    }

    void StartSubject(SubjectList.Subject subject)
    {

        ClearMenu();

        foreach (string sentence in subject.subjectLines)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }
}
