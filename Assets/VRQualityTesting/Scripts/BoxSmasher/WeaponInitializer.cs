using UnityEngine;
using VRQualityTesting.Scripts.BoxSmasherMenu;
using VRQualityTesting.Scripts.Core;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class WeaponInitializer : MonoBehaviour
    {
        [Header("Left hand")]
        [SerializeField] private GameObject leftHandKatana;
        [SerializeField] private GameObject leftHandGrabber;

        [Header("Right hand")]
        [SerializeField] private GameObject rightHandKatana;
        [SerializeField] private GameObject rightHandGrabber;

        private void Awake() => InitializeWeapons();

        private void InitializeWeapons()
        {
            var leftHandWeaponType = (WeaponType) Settings.GetInt(BoxSmasherKeys.LeftHandWeaponType);
            leftHandKatana.SetActive(leftHandWeaponType == WeaponType.Katana);
            leftHandKatana.GetComponent<WeaponHandSide>().HandSide = HandSide.Left;
            leftHandKatana.transform.position = leftHandGrabber.transform.position;

            var leftHandKatanaScale = leftHandKatana.transform.localScale;
            leftHandKatanaScale.y = Settings.GetFloat(BoxSmasherKeys.LeftHandWeaponLength);
            leftHandKatana.transform.localScale = leftHandKatanaScale;

            var rightHandWeaponType = (WeaponType) Settings.GetInt(BoxSmasherKeys.RightHandWeaponType);
            rightHandKatana.SetActive(rightHandWeaponType == WeaponType.Katana);
            rightHandKatana.GetComponent<WeaponHandSide>().HandSide = HandSide.Right;
            rightHandKatana.transform.position = rightHandGrabber.transform.position;

            var rightHandKatanaScale = rightHandKatana.transform.localScale;
            rightHandKatanaScale.y = Settings.GetFloat(BoxSmasherKeys.RightHandWeaponLength);
            rightHandKatana.transform.localScale = rightHandKatanaScale;
        }
    }
}
