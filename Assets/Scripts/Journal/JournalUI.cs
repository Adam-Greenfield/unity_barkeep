using UnityEngine;
using System.Collections;

public class JournalUI : MonoBehaviour
{
    public Transform entriesParent;
    public Transform stepsParent;
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
            //instantiate each quest in the journal
            GameObject journalEntry = Instantiate(journalEntryPrefab);
            journalEntry.transform.SetParent(entriesParent);

            foreach(Step step in quest.steps)
            {
                GameObject stepEntry = Instantiate(stepPrefab);
                stepEntry.transform.SetParent(stepsParent);
            }
        }
    }
}
