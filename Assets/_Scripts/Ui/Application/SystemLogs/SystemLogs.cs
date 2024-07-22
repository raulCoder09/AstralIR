using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.SystemLogs
{
    public class SystemLogs : MonoBehaviour
    {
        private UIDocument _systemLogsUIDocument;
        private static VisualElement _systemLogsRoot;
        private static bool _isInterfaceSystemLogsActive;
        internal static bool IsInterfaceSystemLogsActive
        {
            get => _isInterfaceSystemLogsActive;
            set => _isInterfaceSystemLogsActive = value;
        }
        private void Awake()
        {
            _systemLogsUIDocument = GetComponent<UIDocument>();
            if (_systemLogsUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _systemLogsRoot = _systemLogsUIDocument.rootVisualElement;
            }
            HideUi();
        }
        internal static void ShowUi()
        {
            _isInterfaceSystemLogsActive = true;
            if (_systemLogsRoot!=null)
            {
                _systemLogsRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceSystemLogsActive = false;
            if (_systemLogsRoot!=null)
            {
                _systemLogsRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
