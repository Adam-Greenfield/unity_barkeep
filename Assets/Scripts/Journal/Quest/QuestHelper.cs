using UnityEngine;
using System;

public class QuestHelper
{

    public static Quest[] GetQuestData()
    {
        TextAsset asset = Resources.Load<TextAsset>("quests");
        QuestDataWrapper questData = JsonUtility.FromJson<QuestDataWrapper>(asset.text);
        return questData.items;
    }

    public static int GetQuestIndexById(string questId, Quest[] quests)
    {
        return Array.FindIndex(quests, item => item.id == questId);
    }

    public static Quest GetQuestById(string questId, Quest[] quests)
    {
        return quests[Array.FindIndex(quests, item => item.id == questId)];
    }
}