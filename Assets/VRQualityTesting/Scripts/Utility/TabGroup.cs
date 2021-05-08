using System.Collections.Generic;
using UnityEngine;

namespace VRQualityTesting.Scripts.Utility
{
    public class TabGroup : MonoBehaviour
    {
        [SerializeField] private List<Tab> tabs;
        [SerializeField] private int initiallySelectedTabIndex;

        private void Awake()
        {
            foreach (var tab in tabs)
            {
                tab.OnClicked += HandleTabClicked;
            }

            SelectTab(initiallySelectedTabIndex);
        }

        private void HandleTabClicked(Tab clickedTab)
        {
            var clickedTabIndex = tabs.FindIndex(tab => tab == clickedTab);
            SelectTab(clickedTabIndex);
        }

        private void SelectTab(int index)
        {
            for (var i = 0; i < tabs.Count; i++)
            {
                tabs[i].Content.SetActive(i == index);
            }
        }
    }
}