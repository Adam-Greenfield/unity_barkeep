using UnityEngine;
using System.Collections;

public class JournalUI : MonoBehaviour
{
    public Transform entriesParent;

    public GameObject journalUI;
    public GameObject journalEntryPrefab;
    public GameObject stepPrefab;

    Journal journal;

    JournalEntry[] entires;
    void Start()
    {
        journal = Journal.instance;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Journal"))
        {
            journalUI.SetActive(!journalUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        foreach(Quest quest in journal.quests)
        {
            
            GameObject goJournalEntry = Instantiate(journalEntryPrefab);
            goJournalEntry.transform.SetParent(entriesParent);
            JournalEntry journalEntry = goJournalEntry.GetComponent<JournalEntry>();

            foreach (Step step in quest.steps)
            {
                GameObject stepEntry = Instantiate(stepPrefab);
                stepEntry.transform.SetParent(journalEntry.stepsParent);
            }
        }
    }
}
