using UnityEngine;


public class SpeechObject : MonoBehaviour
{
    public GameObject textBox;
    private Vector3 textPosition;
    TextMesh instTextMesh;


    void start()
    {
       // textBox = this.gameObject.GetComponent<TextMesh>();
    }

    public void speak(string words)
    {
        Debug.Log(textPosition);
        var instTextBox = Instantiate(textBox, textPosition, Quaternion.Euler(0, 0, 0));
        instTextMesh = instTextBox.GetComponent<TextMesh>();
        instTextMesh.text = "Hello World";
    }

    public void setPosition(Vector3 position)
    {
        textPosition = position;
    }
}