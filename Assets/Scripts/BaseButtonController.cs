using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[System.Serializable]
public class BaseButtonController
{
    [SerializeField] private UIDocument root;
    [SerializeField] private string id;
    [SerializeField] private UnityEvent onClick = new UnityEvent();

    private Button controlled;
    public Button Controlled { get => controlled; }
    public void Enable()
    {
        controlled = root.rootVisualElement.Q<Button>(id);
        controlled.RegisterCallback<ClickEvent>(ClickMessage);
    }

    protected virtual void ClickMessage(ClickEvent e)
    {
        onClick.Invoke();
    }

    public void ChangeBackgroundImage(VectorImage image)
    {
        controlled.style.backgroundImage = new StyleBackground(image);
    }
}
