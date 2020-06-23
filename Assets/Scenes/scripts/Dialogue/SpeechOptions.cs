using System.Collections.Generic;
using UnityEngine;

public class SpeechOptions : MonoBehaviour
{
    public List<SubjectList.Subjects> this_options;
    public GameObject this_buttonPrefab;
    public RectTransform this_parentPanel;
    private List<GameObject> instButtons;

    public SpeechOptions(List<SubjectList.Subjects> options, GameObject buttonPrefab, RectTransform parentPanel)
    {
        this_options = options;
        this_buttonPrefab = buttonPrefab;
        this_parentPanel = parentPanel;
    }

    

    // Use this for initialization
    void Start()
    {
        foreach (SubjectList.Subjects option in this_options)
        {
            GameObject goButton = Instantiate(this_buttonPrefab);
            goButton.transform.SetParent(this_parentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            instButtons.Add(goButton);
        }
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
    }
}
