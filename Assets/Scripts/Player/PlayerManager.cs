using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("more than one instance of PlayerManager");
        }
        instance = this;
    }
    #endregion

    public Weapon equippedWeapon;
    public GameObject player;
    //TODO get player stats to check if dead

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Weapon GetWeapon()
    {
        return equippedWeapon;
    }


}
