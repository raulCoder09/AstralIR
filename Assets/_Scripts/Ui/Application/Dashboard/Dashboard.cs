using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.Dashboard
{
    public class Dashboard : MonoBehaviour
    {
        private UIDocument _dashboardUIDocument;
        private static VisualElement _dashboardRoot;
        private static bool _isInterfaceDashboardActive;
        internal bool IsInterfaceDashboardActive
        {
            get => _isInterfaceDashboardActive;
            set => _isInterfaceDashboardActive = value;
        }
        private void Awake()
        {
            _dashboardUIDocument = GetComponent<UIDocument>();
            if (_dashboardUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _dashboardRoot = _dashboardUIDocument.rootVisualElement;
                Debug.Log($"Interface {gameObject.name} found");
            }
            HideUi();
        }
        internal static void ShowUi()
        {
            _isInterfaceDashboardActive = true;
            if (_dashboardRoot!=null)
            {
                _dashboardRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceDashboardActive = false;
            if (_dashboardRoot!=null)
            {
                _dashboardRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
