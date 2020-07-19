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
    public GameObject rightHandObject;
    GameObject instWeapon;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        InstantiateWeapon(equippedWeapon);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetInstWeapon()
    {
        return instWeapon;
    }

    public void EquipWeapon(Weapon weapon)
    {
        Debug.Log("Equipping weapon " + weapon);
        equippedWeapon = weapon;
        InstantiateWeapon(weapon);
    }

    public void InstantiateWeapon(Weapon weapon)
    {
        Debug.Log("Creating weapon as " + weapon.name);
        instWeapon = Instantiate(weapon.prefab);
        instWeapon.transform.SetParent(rightHandObject.transform, false);
    }
}
