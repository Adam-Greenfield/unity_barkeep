using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Shield", menuName = "Inventory/Equipment/Shield")]
public class Shield : Equipment, IBlocker
{
    public string blockAnimation { get; set; }
}