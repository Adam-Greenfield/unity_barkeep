using UnityEngine;


public class MenuObject : MonoBehaviour
{
    public GameObject menu;
    private GameObject instMenu;
    private Camera camera;
    private Vector2 canvasPos;
    private Vector2 screenPoint;
    private Canvas menuCanvas;
    private RectTransform rectTransform;

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
        menuCanvas = instMenu.GetComponent<Canvas>();
        rectTransform = menuCanvas.GetComponent<RectTransform>();
        camera = Camera.main;
        screenPoint = Camera.main.WorldToScreenPoint(parentPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(menuCanvas., screenPoint, null, out canvasPos);
        Debug.Log("I am the menu, here I open!");
        instMenu = Instantiate(menu);
        //instMenu.transform.localPosition = Vector3.MoveTowards(parentPosition, camera.transform.position, 2);
    }
}