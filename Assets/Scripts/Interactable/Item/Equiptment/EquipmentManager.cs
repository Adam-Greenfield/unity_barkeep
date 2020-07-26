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
    public PlayerController playerController;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;


    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];

        //Instantiate any equipped equipment
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

        if (onEquipmentChanged != null)
            onEquipmentChanged.Invoke(newItem, oldItem);

        currentEquipment[slotIndex] = newItem;

        //instantiate the equipment
        InstantiateEquipmentOnCharacter(newItem);
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
                onEquipmentChanged.Invoke(null, oldItem);
        }
    }

    public void UnequipAll()
    {
        for(int i = 0; i < currentEquipment.Length; i ++)
        {
            Unequip(i);
        }
    }

    public void InstantiateEquipmentOnCharacter(Equipment equipment)
    {
        Debug.Log("Creating equipment as " + equipment.name);
        GameObject instEquipment = null;

        if (equipment.prefab != null)
        {

            //check currentEquipment[slotIndex] in array of goEquipmentSlots
            GOEquipmentSlot equipSlot = playerController.gOEquipmentSlots.FirstOrDefault(x => x.equipSlot == equipment.equipSlot);


            instEquipment = Instantiate(equipment.prefab);
            instEquipment.transform.SetParent(equipSlot.gObodyPart.transform, false);
        }
    }
}
