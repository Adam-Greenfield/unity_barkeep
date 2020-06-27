using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    // Start is called before the first frame update
    new public string name = "New Item";
    public Sprite icon = null;

    public virtual void Use()
    {
        //Use the item and do something else
        Debug.Log("Using " + name);
    }
}
