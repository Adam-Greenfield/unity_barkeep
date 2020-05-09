using UnityEngine;


public class MenuObject : MonoBehaviour
{
    public GameObject menu;
    private GameObject instMenu;

    void Start()
    {
        
    }

    void Update()
    {
        if (instMenu)
        {
            instMenu.transform.rotation = Camera.main.transform.rotation;
        }
    }

    public void open(Vector3 parentPosition)
    {
        Debug.Log("I am the menu, here I open!");
        instMenu = Instantiate(menu);
        instMenu.transform.position = parentPosition;
    }
}