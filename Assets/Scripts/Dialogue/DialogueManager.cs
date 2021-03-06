﻿using System;
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

    Journal journal;

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
        journal = Journal.instance;
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
            //check if the subject has a quest attached, if it does, issue quest
            ShowMenu();
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



        foreach (Subject subject in this_dialogue.subjects)
        {
            GameObject goButton = CreateButton();

            Text goButtonText = goButton.GetComponentInChildren<Text>();
            goButtonText.text = subject.name.ToString();

            goButton.GetComponent<Button>().onClick.AddListener(() => StartSubject(subject));

            instButtons.Add(goButton);
        }

        //only show the subject if it has been obtained
        foreach (QuestSubject questSubject in this_dialogue.questSubjects)
        {
            if (questSubject.CheckIfSubjectAvailable())
            {
                GameObject goButton = CreateButton();

                Text goButtonText = goButton.GetComponentInChildren<Text>();
                goButtonText.text = questSubject.name.ToString();

                goButton.GetComponent<Button>().onClick.AddListener(() => StartQuestSubject(questSubject));

                instButtons.Add(goButton);
            }
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

    void StartSubject(Subject subject)
    {
        ClearMenu();

        foreach (string sentence in subject.subjectLines)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void StartQuestSubject(QuestSubject subject)
    {
        
        ClearMenu();
        
        journal.ObtainOrUpdateQuest(subject.questId, subject.stepId);

        if(subject.stepItemRequirement)
        {
            //remove required item from inventory
            Inventory.instance.Remove(subject.stepItemRequirement);
        }

        foreach (string sentence in subject.subjectLines)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
}
