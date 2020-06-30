using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class JournalUI : MonoBehaviour
{
    public Transform entriesParent;

    public GameObject journalUI;
    public GameObject journalEntryPrefab;
    public GameObject stepPrefab;


    Journal journal;

    List<GameObject> instJournalEntries = new List<GameObject>();

    void Start()
    {
        journal = Journal.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Journal"))
        {
            if (!journalUI.activeSelf)
                BuildJournal();
            else
                ClearJournal();

            journalUI.SetActive(!journalUI.activeSelf);
        }
    }

    public void BuildJournal()
    {
        foreach (Quest quest in journal.quests)
        {
            if(quest.obtained)
            {
                GameObject goJournalEntry = Instantiate(journalEntryPrefab);
                goJournalEntry.transform.SetParent(entriesParent);
                JournalEntry journalEntry = goJournalEntry.GetComponent<JournalEntry>();
                journalEntry.journalTitle.GetComponent<Text>().text = quest.name;
                instJournalEntries.Add(goJournalEntry);

                foreach (Step step in quest.steps)
                {
                    if(step.obtained)
                    {
                        GameObject goStepEntry = Instantiate(stepPrefab);
                        goStepEntry.transform.SetParent(journalEntry.stepsParent);
                        JournalEntryStep journalEntryStep = goStepEntry.GetComponent<JournalEntryStep>();
                        Text text = journalEntryStep.stepText.GetComponent<Text>();
                        text.text = step.description;

                        if(step.completed)
                        {
                            text.text += "... COMPLETE!";

                        }
                    }
                }
            }
        }
    }

    public void ClearJournal()
    {
        foreach(GameObject instJournalEntry in instJournalEntries)
        {
            Destroy(instJournalEntry);
        }
    }

    void UpdateUI()
    {
        
    }
}
