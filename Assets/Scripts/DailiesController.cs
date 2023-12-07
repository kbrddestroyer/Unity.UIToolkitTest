using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class DailiesController : MonoBehaviour
{
    private int dayStreak;

    public void Start()
    {
        if (!DailyRewards.Instance)
        {
            Debug.LogError("There's no DailyReward controller initialised");
            return;
        }
        DateTime current = DateTime.Now;
        //current.AddDays(2);
        string lastSessionString = PlayerPrefs.GetString("lastSession", "");
        dayStreak = PlayerPrefs.GetInt("streak", 0);
        DateTime lastSession = (lastSessionString == "") ? current : Convert.ToDateTime(lastSessionString);
        Debug.Log($"Got new session request {(lastSession - current).TotalHours}");
        if ((lastSession == current) || (current - lastSession).TotalHours > 24 && (current - lastSession).TotalHours < 48)
        {
            Debug.Log($"{DailyRewards.Instance.getReward(dayStreak)} with {dayStreak} streak");
            dayStreak++;
        }
        else if ((lastSession - current).TotalHours > 48)
        {
            Debug.Log($"{DailyRewards.Instance.getReward(dayStreak)} with {dayStreak} streak");
            dayStreak = 0;
        }

        PlayerPrefs.SetString("lastSession", Convert.ToString(current));
        PlayerPrefs.SetInt("streak", dayStreak);
        PlayerPrefs.Save();
    }
}
