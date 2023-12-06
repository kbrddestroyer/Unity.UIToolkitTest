using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[Serializable]
[RequireComponent(typeof(UIDocument))]
public class BaseButtonController : MonoBehaviour
{
    [Header("GUI Setup")]
    [SerializeField] private UIDocument root;
    [SerializeField] private string id;
    [SerializeField] private UnityEvent onClick = new UnityEvent();

    private Button controlled;

    private void OnEnable()
    {
        controlled = root.rootVisualElement.Q<Button>(id);
        controlled.RegisterCallback<ClickEvent>(ClickMessage);
    }

    protected virtual void ClickMessage(ClickEvent e)
    {
        onClick.Invoke();
    }
}
