using UnityEngine;


public class MenuObject : MonoBehaviour
{
    public GameObject menu;
    private GameObject instMenu;
    private Camera mainCamera;
    private Vector2 canvasPos;
    private Vector2 screenPoint;
    private RectTransform rectTransform;
    private GameObject instMenuPanel;

    void Start()
    {
        
    }

    void Update()
    {
        if (instMenu)
        {
            //instMenu.transform.rotation = Camera.main.transform.rotation * Quaternion.Euler(270, 0, 0);
        }
    }

    public void open(Vector3 parentPosition)
    {
        
        Debug.Log("I am the menu, here I open!");
        instMenu = Instantiate(menu);

        rectTransform = instMenu.GetComponent<RectTransform>();
        mainCamera = Camera.main;
        screenPoint = Camera.main.WorldToScreenPoint(parentPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, null, out canvasPos);
        instMenu.GetComponentInChildren<RectTransform>().localPosition = canvasPos;
    }
}