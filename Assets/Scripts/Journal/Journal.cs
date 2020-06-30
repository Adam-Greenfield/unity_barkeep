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
    }
    #endregion

    //quests should be kept here, and activated/updated from external events
    //quests should have a log of events
    public List<string> characters;
    public List<string> events;

    public Quest[] quests;

    // Use this for initialization
    void Start()
    {
        TextAsset asset = Resources.Load<TextAsset>("quests");
        Quests questData = JsonUtility.FromJson<Quests>(asset.text);
        quests = questData.items;
        foreach (Quest quest in quests)
        {
            //populate journal with quests
            Debug.Log(quest.steps);
        }

    }


// Update is called once per frame
    void Update()
    {

    }

    public void ActivateQuest(string questId)
    {
        //set quest where questId to active
        Quest questToActivate = Array.Find(quests, quest => quest.id == questId);
        questToActivate.obtained = true;
        Debug.Log(questToActivate.name);
    }
}
