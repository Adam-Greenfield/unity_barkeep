using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Equipment/Weapon")]
public class Weapon : Item
{
    public int damage;
    public GameObject prefab;
}
