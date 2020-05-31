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

    public delegate void InspectDelegate();

    public delegate void InteractDelegate();


    public void open(Vector3 parentPosition, InspectDelegate Inspect, InteractDelegate Interact)
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

        instMenuInspect.onClick.AddListener(delegate { Inspect(); });
        instMenuInteract.onClick.AddListener(delegate { Interact(); });

        originPosition = parentPosition;
    }
}