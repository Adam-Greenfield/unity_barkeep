
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    int baseValue;


    public int GetValue()
    {
        return baseValue;
    }
}
