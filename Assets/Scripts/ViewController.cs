using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class ViewController : MonoBehaviour
{
    [SerializeField] private List<BaseButtonController> uiControllers;
    [SerializeField] private UIDocument document;
    [SerializeField] private bool isBaseView;

    private void OnEnable()
    {
        document = GetComponent<UIDocument>();
        foreach (BaseButtonController controller in uiControllers)
        {
            controller.Enable();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isBaseView)
        {
            document.gameObject.SetActive(false);
        }
    }
}
