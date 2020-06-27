using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)]
    public string[] introduction;

    public List<SubjectList.Subject> subjects = new List<SubjectList.Subject>();
}


