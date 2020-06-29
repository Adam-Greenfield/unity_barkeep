using UnityEngine;
using System.Collections;

public class JournalUI : MonoBehaviour
{
    public GameObject journalUI;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Journal"))
        {
            journalUI.SetActive(!journalUI.activeSelf);
        }
    }
}
