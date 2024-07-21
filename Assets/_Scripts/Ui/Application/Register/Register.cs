using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.Register
{
    public class Register : MonoBehaviour
    {
        private UIDocument _registerUIDocument;
        private static VisualElement _registerRoot;
        private static bool _isInterfaceRegisterActive;
        internal bool IsInterfaceRegisterActive
        {
            get => _isInterfaceRegisterActive;
            set => _isInterfaceRegisterActive = value;
        }
        private void Awake()
        {
            _registerUIDocument = GetComponent<UIDocument>();
            if (_registerUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _registerRoot = _registerUIDocument.rootVisualElement;
                Debug.Log($"Interface {gameObject.name} found");
            }
            HideUi();
            
        }
        internal static void ShowUi()
        {
            _isInterfaceRegisterActive = true;
            if (_registerRoot!=null)
            {
                _registerRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceRegisterActive = false;
            if (_registerRoot!=null)
            {
                _registerRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
