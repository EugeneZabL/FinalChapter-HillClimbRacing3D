using UnityEngine;

[CreateAssetMenu(fileName = "NewCoinType", menuName = "ScriptableObjects/Bonus/CoinSettings", order = 1)]
public class CoinSettings : ScriptableObject
{
    public int Value = 1;
    public float Size = 1;
    public float ScoreMulti = 1;
}