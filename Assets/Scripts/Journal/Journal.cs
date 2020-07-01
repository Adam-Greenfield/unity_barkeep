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
            //If no step has been passed and quest is unobtained, assume we want to obtain the quest at the first step, or...
            //...If the step matches the first step of the quest
            if (stepId == null ||
                quest.steps[0].id == stepId)
            {
                //We can assign the quest and first step
                quests[questToObtainOrProgressIndex].obtained = true;
                quests[questToObtainOrProgressIndex].steps[0].obtained = true;
                return;
            } else
            {
                Debug.LogWarning("A later step of an un-obtained quest is attempting to be prgressed!");
                return;
            }            
        }

        //The quest has been obtained, now make sure the step is the next step to progress
        int stepToProgressIndex = quest.steps.FindIndex(item => item.id == stepId);

        //Check the previous steps are completed, for safety, may not need this if CheckIfQuestStepIsCurrent works as intended
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
        } else if (step.completed)
        {
            Debug.LogWarning("The step has already been completed");
        }

        quests[questToObtainOrProgressIndex].steps[stepToProgressIndex].completed = true;
        quests[questToObtainOrProgressIndex].steps[stepToProgressIndex + 1].obtained = true;

    }
}
