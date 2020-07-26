using UnityEngine;
using System.Collections;
using System.Runtime.ExceptionServices;

public class EquipmentManager : MonoBehaviour
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

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
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
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;
        }
    }

    public void UnequipAll()
    {
        for(int i = 0; i < currentEquipment.Length; i ++)
        {
            Unequip(i);
        }
    }
}
