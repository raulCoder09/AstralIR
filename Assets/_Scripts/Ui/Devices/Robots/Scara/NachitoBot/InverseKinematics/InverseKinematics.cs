using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.InverseKinematics
{
    public class InverseKinematics : MonoBehaviour
    {
        private UIDocument _inverseKinematicsUIDocument;
        private VisualElement _inverseKinematicsRoot;
        private bool _isInterfaceInverseKinematicsActive;
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
            }
            
        }
        private void OnEnable()
        {
            HideUi();
        }
        internal void ShowUi()
        {
            _isInterfaceInverseKinematicsActive = true;
            if (_inverseKinematicsRoot!=null)
            {
                _inverseKinematicsRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal void HideUi()
        {
            _isInterfaceInverseKinematicsActive = false;
            if (_inverseKinematicsRoot!=null)
            {
                _inverseKinematicsRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
