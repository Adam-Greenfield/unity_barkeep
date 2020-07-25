using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/Weapon")]
public class Weapon : ScriptableObject
{
    new public string name = "New Weapon";
    public Sprite icon = null;
    public int damage;
    public GameObject prefab;
}
