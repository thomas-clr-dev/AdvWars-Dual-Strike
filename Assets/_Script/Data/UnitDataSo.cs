using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "AdvWars Dual Strike/Unit Data")]
public class UnitDataSo : ScriptableObject
{
    public string UnitName;
    public int AttackPower;
    public int MaxMovement;
    public int Price;
    public Sprite Icon;
    public GameObject PrefabModel;
}
