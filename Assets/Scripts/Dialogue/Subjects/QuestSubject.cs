using UnityEngine;
using System.Collections;

[System.Serializable]
public class QuestSubject : Subject
{
    public string questId;
    public string stepId;
    public string stepRequirement;

    //step requirement will be a morph many to knowledge and items



    public bool CheckIfSubjectAvailable()
    {
        Quest quest = QuestHelper.GetQuestById(questId);
        if (stepId == "")
            return !quest.completed;


        Step step = quest.GetStepById(stepId);

        //check if quest is obtained and if the step is obtained
        return step.obtained && !step.completed;
    }
}
