using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Shield", menuName = "Inventory/Equipment/Shield")]
[RequireComponent(typeof(BlockBox))]
public class Shield : Equipment, IBlocker
{
    [SerializeField]
    string _blockingAnimation;
   
    public string blockAnimation { get { return _blockingAnimation; } set { _blockingAnimation = value; } }
}