﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct Quest
{
    public string id;
    public string name;
    public string overview;
    public string on_complete;
    public bool active;
    public bool obtained;
    public bool completed;
    public List<Stage> stages;


}

public struct Stage
{
    public string id;
    public string description;
    public bool completed;
}

public struct Reward
{
    public string name;
}

[System.Serializable]
public class Quests
{
    public Quest[] quests;
}


