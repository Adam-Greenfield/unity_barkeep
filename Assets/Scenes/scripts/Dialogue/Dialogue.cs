﻿using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)]
    public string[] introduction;


    [TextArea(3, 10)]
    public string[] sentences;

    public List<Subjects> Subjects = new List<Subjects>();

}


[System.Serializable]
public struct Subjects
{
    //use game objects for enumeration, then pull all npcs who use the object in the game obnject

    public enum SubjectName
    {
        Beer,
        Wine,
        Barkeeping,
        Sodomy
    }

    public SubjectName name;
    [TextArea(3, 10)]
    public string[] subjectLines;
}