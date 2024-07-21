using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.ControlPanel
{
    public class ControlPanel : MonoBehaviour
    {
        private UIDocument _controlPanelUIDocument;
        private static VisualElement _controlPanelRoot;
        private static bool _isInterfaceControlPanelActive;
        internal bool IsInterfaceControlPanelActive
        {
            get => _isInterfaceControlPanelActive;
            set => _isInterfaceControlPanelActive = value;
        }
        private void Awake()
        {
            _controlPanelUIDocument = GetComponent<UIDocument>();
            if (_controlPanelUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _controlPanelRoot = _controlPanelUIDocument.rootVisualElement;
                Debug.Log($"Interface {gameObject.name} found");
            }
            
        }
        internal static void ShowUi()
        {
            _isInterfaceControlPanelActive = true;
            if (_controlPanelRoot!=null)
            {
                _controlPanelRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceControlPanelActive = false;
            if (_controlPanelRoot!=null)
            {
                _controlPanelRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
