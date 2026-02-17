using UnityEngine;

public interface IEconomyService
{
    int GetGold(int playerID);
    void AddGold(int playerID, int amout);
}
