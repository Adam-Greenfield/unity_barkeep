using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Quests
{
    public Quest[] items;
}

[System.Serializable]
public class Quest
{
    public string id;
    public string name;
    public string overview;
    public string on_complete;
    public bool active;
    public bool obtained;
    public bool completed;
    public List<Step> steps;

    public Step GetStepById(string stepId)
    {

    }
}

[System.Serializable]
public class Step
{
    public string id;
    public string description;
    public bool obtained;
    public bool completed;
}

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