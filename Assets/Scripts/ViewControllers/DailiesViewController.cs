using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DailiesViewController : MonoBehaviour
{
    [SerializeField] private UIDocument root;
    [SerializeField] private string ticketsId;
    [SerializeField] private string dayId;

    private Label ticketsLabel;
    private Label dayLabel;
    private int ticketsCount;
    private int dayStreak;

    public int Tickets {
        get => ticketsCount;
        set
        {
            ticketsCount = value;
            ticketsLabel.text = $"x{ticketsCount}";
        }
    }

    public int Day
    {
        get => dayStreak;
        set
        {
            dayStreak = value;
            dayLabel.text = $"DAY {(dayStreak)}";
        }
    }

    private void OnEnable()
    {
        ticketsLabel = root.rootVisualElement.Q<Label>(ticketsId);
        dayLabel = root.rootVisualElement.Q<Label>(dayId);
    }
}
