using UnityEngine;
using System.Collections;

[System.Serializable]
public class QuestSubject : Subject
{
    public string questId;
    public string stepId;
    public Item stepItemRequirement;

    //step requirement will be a morph many to knowledge and items

    Journal journal;
    Inventory inventory;

    public bool CheckIfSubjectAvailable()
    {
        journal = Journal.instance;
        inventory = Inventory.instance;

        Quest quest = QuestHelper.GetQuestById(questId, journal.quests);
        if (stepId == "")
            return !quest.completed && !quest.obtained;


        Step step = quest.GetStepById(stepId);

        //check if item is in the inventory
        if (stepItemRequirement != null)
            if (!inventory.CheckPresence(stepItemRequirement))
                return false;

        //check if quest is obtained and if the step is obtained
        return step.obtained && !step.completed;
    }
}
