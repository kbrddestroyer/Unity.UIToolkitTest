using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ViewSwitcher : MonoBehaviour
{
    public void Action()
    {
        Debug.Log($"Called action on {name} -> {this.name}");
    }

    public void SwitchScene(UIDocument document)
    {
        document.gameObject.SetActive(true);
    }
}
