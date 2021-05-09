using UnityEngine;
using VRQualityTesting.Scripts.BoxSmasherMenu;
using VRQualityTesting.Scripts.Utility;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class WeaponInitializer : MonoBehaviour
    {
        [Header("Left hand")]
        [SerializeField] private GameObject leftHandKatana;
        [SerializeField] private GameObject leftHandHammer;
        [SerializeField] private GameObject leftHandKnife;

        [Header("Right hand")]
        [SerializeField] private GameObject rightHandKatana;
        [SerializeField] private GameObject rightHandHammer;
        [SerializeField] private GameObject rightHandKnife;

        private void Awake() => InitializeWeapons();

        private void InitializeWeapons()
        {
            var leftHandWeaponType = (WeaponType) Settings.GetInt(BoxSmasherKeys.LeftHandWeaponType);
            leftHandKatana.SetActive(leftHandWeaponType == WeaponType.Katana);
            leftHandHammer.SetActive(leftHandWeaponType == WeaponType.Hammer);
            leftHandKnife.SetActive(leftHandWeaponType == WeaponType.Knife);

            var rightHandWeaponType = (WeaponType) Settings.GetInt(BoxSmasherKeys.RightHandWeaponType);
            rightHandKatana.SetActive(rightHandWeaponType == WeaponType.Katana);
            rightHandHammer.SetActive(rightHandWeaponType == WeaponType.Hammer);
            rightHandKnife.SetActive(rightHandWeaponType == WeaponType.Knife);
        }
    }
}
