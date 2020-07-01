using UnityEngine;
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
}

[System.Serializable]
public class Step
{
    public string id;
    public string description;
    public bool obtained;
    public bool completed;
}




