using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


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

    public int GetStepIndexById(string stepId)
    {
        Debug.Log(stepId);
        return steps.FindIndex(item => item.id == stepId);
    }

    public Step GetStepById(string stepId)
    {
        return steps[GetStepIndexById(stepId)];
    }
}
