using UnityEngine;


public class MenuObject : MonoBehaviour
{
    public GameObject menu;
    private GameObject instMenu;
    private Vector2 canvasPos;
    private Vector2 screenPoint;
    private RectTransform rectTransform;
    private GameObject instMenuPanel;
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
            instMenu.transform.GetChild(0).GetComponent<RectTransform>().localPosition = canvasPos;
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
        originPosition = parentPosition;
        
    }
}