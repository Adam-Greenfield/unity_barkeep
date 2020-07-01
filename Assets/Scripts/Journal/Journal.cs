﻿using UnityEngine;
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

    //A function to start and progress quests, in the case that this quest returns a warning it means that either... 
    //...something in our quest design has gone wrong, or a prior step of the quest has not been completed
    public void ObtainOrUpdateQuest(string questId, string stepId = null)
    {
        int questToObtainOrProgressIndex = Array.FindIndex(quests, item => item.id == questId);
        Quest quest = quests[questToObtainOrProgressIndex];

        if (quest.completed)
        {
            Debug.LogWarning("This quest has already been completed");
            return;
        }

        //If the player has not obtained the quest
        if(!quest.obtained)
        {
            //If no step has been passed and quest is unobtained, assume we want to obtain the quest at the first step
            if (stepId == null)
            {
                //We can assign the quest and first step
                quests[questToObtainOrProgressIndex].obtained = true;
                quests[questToObtainOrProgressIndex].steps[0].obtained = true;
                return;
            } else
            {
                Debug.LogWarning("A later step of an un-obtained quest is attempting to be progressed!");
                return;
            }            
        }

        if(stepId == null)
        {
            Debug.LogWarning("Trying to obtain already obtained quest");
            return;
        }

        //The quest has been obtained, now make sure the step is the next step to progress
        int stepToProgressIndex = quest.steps.FindIndex(item => item.id == stepId);

        //Check the previous steps are completed
        if (stepToProgressIndex > 0)
        {
            if (!quest.steps[stepToProgressIndex - 1].obtained)
            {
                Debug.LogWarning("The prior step has not been obtained, not updating quest");
                return;
            }
                
            if (!quest.steps[stepToProgressIndex - 1].completed)
            {
                Debug.LogWarning("The prior step has not been completed, not updating quest");
                return;
            }
        }

        //set step to complete and obtain the next step
        Step step = quest.steps[stepToProgressIndex];

        //last checks to see if the step has been obtained, and has not already been completed
        if (!step.obtained)
        {
            Debug.LogWarning("The step has not been obtained");
            return;
        } else if (step.completed)
        {
            Debug.LogWarning("The step has already been completed");
            return;
        }

        //set the step to completed and the next step to obtained
        quests[questToObtainOrProgressIndex].steps[stepToProgressIndex].completed = true;

        //TODO check all prior steps have been completed before issuing a new step, then we can obtain multiple steps at once
        quests[questToObtainOrProgressIndex].steps[stepToProgressIndex + 1].obtained = true;

    }
}
