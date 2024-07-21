using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.References
{
    public class References : MonoBehaviour
    {
        private UIDocument _referencesUIDocument;
        private static VisualElement _referencesRoot;
        private static bool _isInterfaceReferencesActive;
        internal bool IsInterfaceReferencesActive
        {
            get => _isInterfaceReferencesActive;
            set => _isInterfaceReferencesActive = value;
        }
        private void Awake()
        {
            _referencesUIDocument = GetComponent<UIDocument>();
            if (_referencesUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _referencesRoot = _referencesUIDocument.rootVisualElement;
                Debug.Log($"Interface {gameObject.name} found");
            }
            
        }
        internal static void ShowUi()
        {
            _isInterfaceReferencesActive = true;
            if (_referencesRoot!=null)
            {
                _referencesRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceReferencesActive = false;
            if (_referencesRoot!=null)
            {
                _referencesRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
