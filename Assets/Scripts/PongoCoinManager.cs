using UnityEngine;
using System.Collections;

public static class PongoCoinManager 
{
    private static int _balance;
    private static bool _isInitialized = false;

    public static int GetBalance()
    {
        if (!_isInitialized)
            Initialize();
        return _balance;
    }

    public static void Initialize()
    {
        _balance =  PlayerPrefs.GetInt("PongoCoins", 0);
        _isInitialized = true;
    }

    public static void Deposit(int depAmt)
    {
        if (!_isInitialized)
            Initialize();
        _balance += depAmt;
        PlayerPrefs.SetInt("PongoCoins", _balance);
    }

    public static void Spend(int spdAmt)
    {
        if (!_isInitialized)
            Initialize();
        if (_balance >= spdAmt)
        {
            _balance -= spdAmt;
            PlayerPrefs.SetInt("PongoCoins", _balance);
        }    
    }
    

    public static int PongoCoinsForScene(string sceneName)
    {
        if (!_isInitialized)
            Initialize();
        switch (sceneName)
        {
            case "Level01": return 1;
            case "Level02": return 2;
            case "Level03": return 1;
            case "Level04": return 2;
            case "Level05": return 2;
            case "Level06": return 3;
            case "Level07": return 3;
            case "Level08": return 3;
            default: return 0;
        }
    }

}
