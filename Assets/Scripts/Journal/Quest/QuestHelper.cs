using UnityEngine;
using System;

public class QuestHelper
{

    public static Quest[] GetQuests()
    {
        TextAsset asset = Resources.Load<TextAsset>("quests");
        Quests questData = JsonUtility.FromJson<Quests>(asset.text);
        return questData.items;
    }

    public static int GetQuestIndexById(string questId)
    {
        Quest[] quests = GetQuests();
        return Array.FindIndex(quests, item => item.id == questId);
    }

    public static Quest GetQuestById(string questId)
    {
        Quest[] quests = GetQuests();
        return quests[Array.FindIndex(quests, item => item.id == questId)];
    }
}