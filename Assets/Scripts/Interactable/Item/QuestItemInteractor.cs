using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;

public class QuestItemInteractor : ItemInteractor
{
    Journal journal;
    public string questId;
    public string stepId;
    public bool startQuest = false;


    public override void Start()
    {
        base.Start();
        journal = Journal.instance;
    }

    public override void Interact()
    {
        base.Interact();


        if (startQuest)
            journal.ActivateQuest(questId);
        else if (journal.CheckIfQuestStepIsCurrent(questId, stepId))
            journal.UpdateQuest(questId, stepId);

        Pickup();

    }
}
