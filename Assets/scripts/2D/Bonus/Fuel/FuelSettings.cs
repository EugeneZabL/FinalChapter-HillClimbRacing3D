using UnityEngine;

[CreateAssetMenu(fileName = "NewTypeFuel", menuName = "ScriptableObjects/Bonus/FuelSettings", order = 1)]
public class FuelSettings : ScriptableObject
{
    public string SpecialName = "Fuel";
    public int Value = 1;
    public float Size = 1;
}