using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractor : Interactable
{

    public Item item;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        base.Interact();

        Pickup();

    }

    public void Pickup()
    {
        Debug.Log("picking up " + item.name);

        if(Inventory.instance.Add(item))
            Destroy(gameObject);

    }

    public override void InspectFromMenu()
    {
        throw new System.NotImplementedException();
    }

    public override void InteractFromMenu()
    {
        player.SetFocus(this);
    }


}
