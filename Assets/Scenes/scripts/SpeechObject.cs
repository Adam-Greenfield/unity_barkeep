using UnityEngine;


public class SpeechObject : MonoBehaviour
{
    public GameObject textBox;
    private GameObject instTextBox;

    TextMesh instTextMesh;


    void Start()
    {
       // textBox = this.gameObject.GetComponent<TextMesh>();
    }

    void Update()
    {
        if (instTextBox)
        {
            instTextBox.transform.rotation = Camera.main.transform.rotation;
        }
    }

    public void updatePosition(Vector3 position)
    {
        if (instTextBox)
        {
            instTextBox.transform.position = position;
        }
    }

    public void speak(string words)
    {
        instTextBox = Instantiate(textBox);
        instTextMesh = instTextBox.GetComponent<TextMesh>();
        instTextMesh.text = "Hello World";
    }
}