using UnityEngine;
using UnityEngine.EventSystems;

namespace VRQualityTesting.Scripts.Utility
{
    public class Tab : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject content;
        public GameObject Content => content;

        public delegate void ClickHandler(Tab clickedTab);
        public event ClickHandler OnClicked;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke(this);
        }
    }
}