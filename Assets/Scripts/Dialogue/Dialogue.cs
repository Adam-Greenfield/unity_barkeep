using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)]
    public string[] introduction;

    public List<Subject> subjects = new List<Subject>();
    public List<QuestSubject> questSubjects = new List<QuestSubject>();
}


