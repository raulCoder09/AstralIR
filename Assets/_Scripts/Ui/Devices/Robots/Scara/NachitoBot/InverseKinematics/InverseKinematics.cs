using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.InverseKinematics
{
    public class InverseKinematics : MonoBehaviour
    {
        private UIDocument _inverseKinematicsUIDocument;
        private static VisualElement _inverseKinematicsRoot;
        private static bool _isInterfaceInverseKinematicsActive;
        internal bool IsInterfaceInverseKinematicsActive
        {
            get => _isInterfaceInverseKinematicsActive;
            set => _isInterfaceInverseKinematicsActive = value;
        }
        private void Awake()
        {
            _inverseKinematicsUIDocument = GetComponent<UIDocument>();
            if (_inverseKinematicsUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _inverseKinematicsRoot = _inverseKinematicsUIDocument.rootVisualElement;
                Debug.Log($"Interface {gameObject.name} found");
            }
            
        }
        internal static void ShowUi()
        {
            _isInterfaceInverseKinematicsActive = true;
            if (_inverseKinematicsRoot!=null)
            {
                _inverseKinematicsRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceInverseKinematicsActive = false;
            if (_inverseKinematicsRoot!=null)
            {
                _inverseKinematicsRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
