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
            Debug.Log("I exsit");
            instTextBox.transform.rotation = Camera.main.transform.rotation;
        }
    }

    public void speak(string words, Vector3 position)
    {
        instTextBox = Instantiate(textBox, position, Quaternion.Euler(0, 0, 0));
        instTextMesh = instTextBox.GetComponent<TextMesh>();
        instTextMesh.text = "Hello World";
    }
}