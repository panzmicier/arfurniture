using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    [Header("Tab Buttons Colors")]
    [SerializeField] Color defaultButtonColor;
    [SerializeField] Color hoverButtonColor;
    [SerializeField] Color activeButtonColor;

    private TabButton selectedButton;

    private List<TabButton> tabButtons;
    [SerializeField] List<GameObject> tabObjects;

    public void SubscribeButton(TabButton button)
    {
        if (tabButtons == null)
            tabButtons = new List<TabButton>();

        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedButton == null || button != selectedButton)
            button.Background.color = hoverButtonColor;
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedButton = button;
        ResetTabs();
        button.Background.color = activeButtonColor;
        int index = button.transform.GetSiblingIndex();

        for (int i = 0; i < tabObjects.Count; i++)
        {
            if (i == index)
                SetTabActive(i, true);
            else SetTabActive(i, false);
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedButton != null && button == selectedButton)
                continue;

            button.Background.color = defaultButtonColor;
        }
    }

    private void SetTabActive(int i, bool choice) => tabObjects[i].SetActive(choice);
}
