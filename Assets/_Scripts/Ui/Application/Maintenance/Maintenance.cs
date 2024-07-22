using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.Maintenance
{
    public class Maintenance : MonoBehaviour
    {
        private UIDocument _maintenanceUIDocument;
        private static VisualElement _maintenanceRoot;
        private static bool _isInterfaceMaintenanceActive;
        internal static bool IsInterfaceMaintenanceActive
        {
            get => _isInterfaceMaintenanceActive;
            set => _isInterfaceMaintenanceActive = value;
        }
        private void Awake()
        {
            _maintenanceUIDocument = GetComponent<UIDocument>();
            if (_maintenanceUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _maintenanceRoot = _maintenanceUIDocument.rootVisualElement;
            }
            HideUi();
            
        }
        internal static void ShowUi()
        {
            _isInterfaceMaintenanceActive = true;
            if (_maintenanceRoot!=null)
            {
                _maintenanceRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceMaintenanceActive = false;
            if (_maintenanceRoot!=null)
            {
                _maintenanceRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
