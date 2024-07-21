using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.SupportAndHelp
{
    public class SupportAndHelp : MonoBehaviour
    {
        private UIDocument _supportAndHelpUIDocument;
        private static VisualElement _supportAndHelpRoot;
        private static bool _isInterfaceSupportAndHelpActive;
        internal bool IsInterfaceSupportAndHelpActive
        {
            get => _isInterfaceSupportAndHelpActive;
            set => _isInterfaceSupportAndHelpActive = value;
        }
        private void Awake()
        {
            _supportAndHelpUIDocument = GetComponent<UIDocument>();
            if (_supportAndHelpUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _supportAndHelpRoot = _supportAndHelpUIDocument.rootVisualElement;
                Debug.Log($"Interface {gameObject.name} found");
            }
            HideUi();
        }
        internal static void ShowUi()
        {
            _isInterfaceSupportAndHelpActive = true;
            if (_supportAndHelpRoot!=null)
            {
                _supportAndHelpRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceSupportAndHelpActive = false;
            if (_supportAndHelpRoot!=null)
            {
                _supportAndHelpRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
