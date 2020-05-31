using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MenuObject : MonoBehaviour
{
    public GameObject menu;
    private GameObject instMenu;
    private Vector2 canvasPos;
    private Vector2 screenPoint;
    private RectTransform rectTransform;
    private GameObject instMenuPanel;
    private Button instMenuInspect;
    private Button instMenuInteract;
    private Vector3 originPosition;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (instMenu)
        {
            rectTransform = instMenu.GetComponent<RectTransform>();
            screenPoint = Camera.main.WorldToScreenPoint(originPosition);
            //get position of object in relation to camera and covert to canvas redable coordinates
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, null, out canvasPos);
            instMenuPanel.GetComponent<RectTransform>().localPosition = canvasPos;
        }
    }

    public void open(Vector3 parentPosition)
    {
        if (instMenu)
        {
            Debug.Log("Menu already instantiated for this object");
            return;
        }
        
        instMenu = Instantiate(menu);
        instMenuPanel = instMenu.transform.Find("Panel").gameObject;
        instMenuInspect = instMenuPanel.transform.Find("TextBox").gameObject.transform.Find("InspectButton").GetComponent<Button>();
        instMenuInteract = instMenuPanel.transform.Find("TextBox").gameObject.transform.Find("InteractButton").GetComponent<Button>();

        instMenuInspect.onClick.AddListener(Inspect);
        instMenuInteract.onClick.AddListener(Interact);

        originPosition = parentPosition;

/*        GameObject textBox = instMenuPanel.transform.Find("TextBox").gameObject;
        Button button = textBox.AddComponent<Button>();
        Text buttonText = Button.AddComponent<Text>();
        Debug.Log(testText);

        testText.text = "testing";
        testText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");;
        testText.color = Color.black;*/
    }

    private void Inspect()
    {

    }

    private void Interact()
    {

    }
}