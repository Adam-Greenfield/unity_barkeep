using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Equipment/Weapon")]
[RequireComponent(typeof(HitBox))]
public class Weapon : Equipment
{
    public string attackAnimation;
}
