using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;

public class QuestItemInteractor : ItemInteractor
{
    Journal journal;
    public string questId;
    public string stepId;


    public override void Start()
    {
        base.Start();
        journal = Journal.instance;
    }

    public override void Interact()
    {
        base.Interact();

        journal.ObtainOrUpdateQuest(questId, stepId);

    }
}
