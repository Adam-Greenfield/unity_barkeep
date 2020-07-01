using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Subject
{

    public string name;
    [TextArea(3, 10)]
    public string[] subjectLines;

    public string questId;
    public string stepId;
    bool active;



    //TODO if a subject is part of a quest, or not, have a reference to a quest item/quest knowledge, or not

    //TODO make a private var called active/discovered, which governs if the player can ask about the subject or not
}
