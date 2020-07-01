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
    bool active;

    //TODO make a private var called active/discovered, which governs if the player can ask about the subject or not

}
