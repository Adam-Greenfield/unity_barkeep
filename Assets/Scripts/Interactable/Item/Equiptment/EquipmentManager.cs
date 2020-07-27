using UnityEngine;
using System.Collections;
using System.Runtime.ExceptionServices;
using System.Linq;

public class EquipmentManager : MonoBehaviour, IInstantiateEquipment
{
    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one instance of EquipmentManager");
        }
        instance = this;
    }
    #endregion
    // Use this for initialization
    Equipment[] currentEquipment;
    GameObject[] currentInstEquipment;
    public PlayerController playerController;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem, GameObject instEquipment);
    public OnEquipmentChanged onEquipmentChangedCallback;


    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        //include an array of instantiated equipment so we can deal with things like hitboxes
        currentInstEquipment = new GameObject[numSlots];

        //TODO Instantiate any equipped equipment
    }

    void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }*/
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        currentEquipment[slotIndex] = newItem;

        //instantiate the equipment
        GameObject instEquipment = InstantiateEquipmentOnCharacter(newItem, slotIndex);
        currentInstEquipment[slotIndex] = instEquipment;

        if (onEquipmentChangedCallback != null)
            onEquipmentChangedCallback.Invoke(newItem, oldItem, instEquipment);
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChangedCallback != null)
                onEquipmentChangedCallback.Invoke(null, oldItem, null);
        }
    }

    public void UnequipAll()
    {
        for(int i = 0; i < currentEquipment.Length; i ++)
        {
            Unequip(i);
        }
    }

    public Equipment GetWeapon()
    {
        int slot = (int)EquipmentSlot.Weapon;
        return currentEquipment[slot];
    }

    public GameObject GetInstWeapon()
    {
        int slot = (int)EquipmentSlot.Weapon;
        return currentInstEquipment[slot];
    }

    public GameObject InstantiateEquipmentOnCharacter(Equipment equipment, int slotIndex)
    {
        Debug.Log("Creating equipment as " + equipment.name);
        GameObject instEquipment = null;

        if (equipment.prefab != null)
        {
            GOEquipmentSlot equipSlot = playerController.gOEquipmentSlots.FirstOrDefault(x => x.equipSlot == equipment.equipSlot);

            instEquipment = Instantiate(equipment.prefab);
            instEquipment.transform.SetParent(equipSlot.gObodyPart.transform, false);

            return instEquipment;
        }

        return null;

    }
}
