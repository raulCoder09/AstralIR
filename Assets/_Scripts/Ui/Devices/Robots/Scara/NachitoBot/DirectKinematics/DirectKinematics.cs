using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.DirectKinematics
{
    public class DirectKinematics : MonoBehaviour
    {
        private UIDocument _directKinematicsUIDocument;
        private VisualElement _directKinematicsRoot;
        private bool _isInterfaceDirectKinematicsActive;
        internal bool IsInterfaceDirectKinematicsActive
        {
            get => _isInterfaceDirectKinematicsActive;
            set => _isInterfaceDirectKinematicsActive = value;
        }
        private void Awake()
        {
            _directKinematicsUIDocument = GetComponent<UIDocument>();
            if (_directKinematicsUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _directKinematicsRoot = _directKinematicsUIDocument.rootVisualElement;
            }
            
        }
        private void OnEnable()
        {
            HideUi();
        }
        internal void ShowUi()
        {
            _isInterfaceDirectKinematicsActive = true;
            if (_directKinematicsRoot!=null)
            {
                _directKinematicsRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal void HideUi()
        {
            _isInterfaceDirectKinematicsActive = false;
            if (_directKinematicsRoot!=null)
            {
                _directKinematicsRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
