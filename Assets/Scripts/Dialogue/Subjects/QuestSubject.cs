using UnityEngine;
using System.Collections;

[System.Serializable]
public class QuestSubject : Subject
{
    public string questId;
    public string stepId;
    public string stepRequirement;

    //step requirement will be a morph many to knowledge and items



    public void CheckIfSubjectAvailable()
    {
        Quest quest = QuestHelper.GetQuestById(questId);
        Step step = quest.GetStepById()
        //check if quest is obtained and if the step is obtained
    }
}
