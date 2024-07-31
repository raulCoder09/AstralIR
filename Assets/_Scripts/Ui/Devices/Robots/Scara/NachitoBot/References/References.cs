using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.References
{
    public class References : MonoBehaviour
    {
        private UIDocument _referencesUIDocument;
        private VisualElement _referencesRoot;
        private bool _isInterfaceReferencesActive;
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
            }
            
        }
        private void OnEnable()
        {
            HideUi();
        }
        internal void ShowUi()
        {
            _isInterfaceReferencesActive = true;
            if (_referencesRoot!=null)
            {
                _referencesRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal void HideUi()
        {
            _isInterfaceReferencesActive = false;
            if (_referencesRoot!=null)
            {
                _referencesRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
