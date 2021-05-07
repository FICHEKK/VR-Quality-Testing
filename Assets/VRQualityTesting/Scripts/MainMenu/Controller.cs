using UnityEngine;
using VRQualityTesting.Scripts.MainMenu;

namespace VrQualityTesting.Scripts.MainMenu
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Validator validator;
        [SerializeField] private Scribe scribe;
        [SerializeField] private Router router;

        public void ContinueToNextSceneIfPossible()
        {
            if (!validator.AreAllSettingsValid()) return;

            scribe.SaveSettings();
            router.RouteToNextScene();
        }
    }
}
