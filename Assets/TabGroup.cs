using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButton;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    // Start is called before the first frame update
    public void Subscride(TabButton button)
    {
        if (tabButton == null)
        {
            tabButton = new List<TabButton>();
        }

        tabButton.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        Resettabs();
        button.background.sprite = tabHover;
    }

    public void OnTabExit(TabButton button)
    {
        Resettabs();
    }

    public void OnTabSelected(TabButton button)
    {
        Resettabs();
        button.background.sprite = tabActive;
    }

    void Resettabs()
    {
        foreach (var tab in tabButton)
        {
            tab.background.sprite = tabIdle;

        }
    }
}
