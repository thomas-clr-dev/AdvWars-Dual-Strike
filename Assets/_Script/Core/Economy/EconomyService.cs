using System.Collections.Generic;
using UnityEngine;

public class EconomyService : IEconomyService
{
    private Dictionary<int, int> _wallets = new Dictionary<int, int>();

    public EconomyService()
    {
        _wallets.Clear();
        _wallets.Add(1, 0);
        _wallets.Add(2, 0);
    }

    public int GetGold(int playerID)
    {
        return _wallets.ContainsKey(playerID) ? _wallets[playerID] : 0;
    }

    public void AddGold(int playerID, int amount)
    {
        if (_wallets.ContainsKey(playerID))
        {
            _wallets[playerID] += amount;
            Utils.ColorLog($"Player {playerID} get {amount} gold. Total gold : {_wallets[playerID]}");
        }
    }
}
