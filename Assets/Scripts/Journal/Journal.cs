using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class Journal : MonoBehaviour
{
    #region Singleton
    public static Journal instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of journal found");
        }
        instance = this;

        TextAsset asset = Resources.Load<TextAsset>("quests");
        Quests questData = JsonUtility.FromJson<Quests>(asset.text);
        quests = questData.items;
    }
    #endregion

    //quests should be kept here, and activated/updated from external events
    //quests should have a log of events
    public List<string> characters;
    public List<string> events;

    public Quest[] quests;

    // Use this for initialization
    void Start()
    {
        
        foreach (Quest quest in quests)
        {
            //populate journal with quests
            Debug.Log(quest.steps);
        }

    }


// Update is called once per frame
    void Update()
    {

    }

    public void ActivateQuest(string questId)
    {
        //set quest where questId to active
        int questToActivateIndex = Array.FindIndex(quests, quest => quest.id == questId);
        quests[questToActivateIndex].obtained = true;
        //activate first step also
        quests[questToActivateIndex].steps[0].obtained = true;


    }

    public void UpdateQuest(string questId, string stepId)
    {
        int questToActivateIndex = Array.FindIndex(quests, item => item.id == questId);
        Quest quest = quests[questToActivateIndex];
        int stepToActivateIndex = quest.steps.FindIndex(step => step.id == stepId);

        if(stepToActivateIndex > 0)
        {
            if (!quest.steps[stepToActivateIndex - 1].obtained)
                Debug.LogWarning("The prior step has not been obtained, not updating quest");

            if (!quest.steps[stepToActivateIndex - 1].completed)
                Debug.LogWarning("The prior step has not been completed, not updating quest");
        }
        



    }

    public bool CheckIfQuestStepIsCurrent(string questId, string stepId)
    {
        int questToActivateIndex = Array.FindIndex(quests, item => item.id == questId);
        Quest quest = quests[questToActivateIndex];
        //If the quest has not been obtained, or has been completed, return false
        if (!quest.obtained || quest.completed)
            return false;

        //If the step has not been reached or has been completed, return false
        int stepToActivateIndex = quest.steps.FindIndex(item => item.id == stepId);
        Step step = quest.steps[stepToActivateIndex];

        if (!step.obtained || step.completed)
            return false;

        return true;
    }
}
