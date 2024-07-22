using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.SupportAndHelp
{
    public class SupportAndHelp : MonoBehaviour
    {
        private UIDocument _supportAndHelpUIDocument;
        private static VisualElement _supportAndHelpRoot;
        private static bool _isInterfaceSupportAndHelpAndHelpActive;
        internal static bool IsInterfaceSupportAndHelpActive
        {
            get => _isInterfaceSupportAndHelpAndHelpActive;
            set => _isInterfaceSupportAndHelpAndHelpActive = value;
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
            }
            HideUi();
            
        }
        internal static void ShowUi()
        {
            _isInterfaceSupportAndHelpAndHelpActive = true;
            if (_supportAndHelpRoot!=null)
            {
                _supportAndHelpRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceSupportAndHelpAndHelpActive = false;
            if (_supportAndHelpRoot!=null)
            {
                _supportAndHelpRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
