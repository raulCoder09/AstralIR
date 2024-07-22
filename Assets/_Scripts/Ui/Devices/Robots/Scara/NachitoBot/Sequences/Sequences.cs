using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.Sequences
{
    public class Sequences : MonoBehaviour
    {
        private UIDocument _sequencesUIDocument;
        private static VisualElement _sequencesRoot;
        private static bool _isInterfaceSequencesActive;
        internal bool IsInterfaceSequencesActive
        {
            get => _isInterfaceSequencesActive;
            set => _isInterfaceSequencesActive = value;
        }
        private void Awake()
        {
            _sequencesUIDocument = GetComponent<UIDocument>();
            if (_sequencesUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _sequencesRoot = _sequencesUIDocument.rootVisualElement;
                Debug.Log($"Interface {gameObject.name} found");
            }
            
        }
        internal static void ShowUi()
        {
            _isInterfaceSequencesActive = true;
            if (_sequencesRoot!=null)
            {
                _sequencesRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal void HideUi()
        {
            _isInterfaceSequencesActive = false;
            if (_sequencesRoot!=null)
            {
                _sequencesRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
