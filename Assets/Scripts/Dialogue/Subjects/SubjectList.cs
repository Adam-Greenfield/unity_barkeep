using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectList : MonoBehaviour
{
    [System.Serializable]
    public struct Subject
    {
        //use game objects for enumeration, then pull all npcs who use the object in the game object

        public enum SubjectName
        {
            Beer,
            Wine,
            Barkeeping,
            Sodomy,
            Closing_time
        }

        public SubjectName name;
        [TextArea(3, 10)]
        public string[] subjectLines;

        public string questId;

        //TODO make a private var called active/discovered, which governs if the player can ask about the subject or not
    }
}