using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    PlayerManager playerManager;

    public Weapon weapon;
    public GameObject weaponObject;
    public bool isDefault;

    // Start is called before the first frame update
    void Start()
    {
        if(weapon)
        {
            playerManager = PlayerManager.instance;
            if (isDefault)
                playerManager.EquipWeapon(weapon);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Equip()
    {
        playerManager.EquipWeapon(weapon);
    }
}
