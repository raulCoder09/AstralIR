using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.Settings
{
    public class Settings : MonoBehaviour
    {
        private UIDocument _settingsUIDocument;
        private static VisualElement _settingsRoot;
        private static bool _isInterfaceSettingsActive;
        internal bool IsInterfaceSettingsActive
        {
            get => _isInterfaceSettingsActive;
            set => _isInterfaceSettingsActive = value;
        }
        private void Awake()
        {
            _settingsUIDocument = GetComponent<UIDocument>();
            if (_settingsUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _settingsRoot = _settingsUIDocument.rootVisualElement;
                Debug.Log($"Interface {gameObject.name} found");
            }
            HideUi();
            
        }
        internal static void ShowUi()
        {
            _isInterfaceSettingsActive = true;
            if (_settingsRoot!=null)
            {
                _settingsRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceSettingsActive = false;
            if (_settingsRoot!=null)
            {
                _settingsRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
