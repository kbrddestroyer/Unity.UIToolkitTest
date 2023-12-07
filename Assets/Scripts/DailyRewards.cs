using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class DailyRewards : MonoBehaviour
{
    [SerializeField] public int[] dailies = new int[6];

    private static DailyRewards instance;
    public static DailyRewards Instance { get => instance; }

    public int getReward(int streak)
    {
        return dailies[streak % 6];
    }

    public void Awake()
    {
        if (!instance)
            instance = this;
    }
}
