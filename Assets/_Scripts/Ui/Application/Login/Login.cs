using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.Login
{
    public class Login : MonoBehaviour
    {
        private UIDocument _loginUIDocument;
        private static VisualElement _loginRoot;
        private static bool _isInterfaceLoginActive;
        internal bool IsInterfaceLoginActive
        {
            get => _isInterfaceLoginActive;
            set => _isInterfaceLoginActive = value;
        }
        private void Awake()
        {
            _loginUIDocument = GetComponent<UIDocument>();
            if (_loginUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _loginRoot = _loginUIDocument.rootVisualElement;
                Debug.Log($"Interface {gameObject.name} found");
            }
            HideUi();
            
        }
        internal static void ShowUi()
        {
            _isInterfaceLoginActive = true;
            if (_loginRoot!=null)
            {
                _loginRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceLoginActive = false;
            if (_loginRoot!=null)
            {
                _loginRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
