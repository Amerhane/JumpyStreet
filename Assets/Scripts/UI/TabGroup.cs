using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Project: JumpyStreet
/// Name: Jacob Frigon
/// Section: SGD 285.4171
/// Instructor: Aurore Locklear
/// Date: 02/25/2024
/// </summary>
public class TabGroup : MonoBehaviour
{
    [SerializeField]
    private List<Tab> tabs = new List<Tab>();

    [SerializeField]
    private List<GameObject> tabPanels = new List<GameObject>();

    [SerializeField]
    private Color tabInactive;
    [SerializeField]
    private Color tabActive;
    [SerializeField]
    private Color tabHover;

    private Tab selectedTab;

    public void AddTab(Tab newTab)
    {
        if (tabs == null)
        {
            tabs = new List<Tab>();
        }

        tabs.Add(newTab);
    }

    public void OnTabEnter(Tab tab)
    {
        ResetTabs();
        if (selectedTab == null || tab != selectedTab)
        {
            tab.SetBackground(tabHover);
        }
    }

    public void OnTabExit(Tab tab)
    {
        ResetTabs();
    }

    public void OnTabSelected(Tab tab)
    {
        selectedTab = tab;
        ResetTabs();
        tab.SetBackground(tabActive);
        
        // Order of tabs must be in same order in editor
        int index = tab.transform.GetSiblingIndex();
        for (int i = 0; i < tabPanels.Count; i++)
        {
            if (i == index)
            {
                tabPanels[i].SetActive(true);
            }
            else
            {
                tabPanels[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach(Tab tab in tabs)
        {
            if (selectedTab != null && selectedTab == tab)
                continue;
            tab.SetBackground(tabInactive);
        }
    }
}
