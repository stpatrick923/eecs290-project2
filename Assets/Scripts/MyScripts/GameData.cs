/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static GameData instance;

    private GameData()
    {
        instance = this;
        Paused = false;
        dialog = null;
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject newGO = new GameObject("new name");
                newGO.AddComponent("GameData");
                instance = newGO.GetComponent<GameData>();
                instance.Deaths = 0;
                instance.Coins = 0;
                instance.SpecialCoins = 0;
            }
            return instance;
        }
    }

    private int score = 0;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public int Deaths
    {
        get;
        set;
    }

    public bool Paused
    {
        get;
        set;
    }

    public Dialog dialog
    {
        get;
        set;
    }

    public int SpecialCoins
    {
        get;
        set;
    }
    public int Coins
    {
        get;
        set;
    }

    internal void reset()
    {
        Coins = 0;
        SpecialCoins = 0;
        Deaths = 0;
        Score = 0;
    }
}
