using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class DailiesController : MonoBehaviour
{
    [SerializeField] private UIDocument root;
    [SerializeField] private string id;
    [SerializeField] private DailiesViewController dailiesView;

    private Label ticketsText;
    private int dayStreak;
    private int totalTickets = 0;

    private void AddReward(int dailyStreak)
    {
        totalTickets += DailyRewards.Instance.getReward(dayStreak);
        dayStreak++;
        dailiesView.gameObject.SetActive(true);
        dailiesView.Tickets = totalTickets;
        dailiesView.Day = dayStreak;
    }

    public void Start()
    {
        ticketsText = root.rootVisualElement.Q<Label>(id);
        totalTickets = PlayerPrefs.GetInt("tickets", 0);

        if (!DailyRewards.Instance)
        {
            Debug.LogError("There's no DailyReward controller initialised");
            return;
        }
        DateTime current = DateTime.Now;
        current = current.AddDays(6);
        string lastSessionString = PlayerPrefs.GetString("lastSession", "");
        dayStreak = PlayerPrefs.GetInt("streak", 0);
        DateTime lastSession = (lastSessionString == "") ? current : Convert.ToDateTime(lastSessionString);

        if ((lastSession == current) || ((current - lastSession).TotalDays > 1 && (current - lastSession).TotalDays < 2))
        {
            AddReward(dayStreak);
        }
        else if ((lastSession - current).TotalDays > 2)
        {
            dayStreak = 0;
            AddReward(dayStreak);
        }
        ticketsText.text = totalTickets.ToString();
        PlayerPrefs.SetString("lastSession", Convert.ToString(current));
        PlayerPrefs.SetInt("streak", dayStreak);
        PlayerPrefs.SetInt("tickets", totalTickets);
        PlayerPrefs.Save();
    }
}
