using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureInteractor : Interactable
{
    public override void InspectFromMenu()
    {
        throw new System.NotImplementedException();
    }

    public override void InteractFromMenu()
    {
        Open();
    }

    void Open()
    {
        transform.position += new Vector3(0, 4, 0);
    }
}
