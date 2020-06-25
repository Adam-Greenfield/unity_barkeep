using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
public class ItemInteractor : Interactable
{
    private SceneLoader levelLoader;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        levelLoader = GetComponent<SceneLoader>();
    }


    public override void InspectFromMenu()
    {
        throw new System.NotImplementedException();
    }

    public override void InteractFromMenu()
    {
        levelLoader.FadeToLevel();
        //call level script to change level
    }


}
