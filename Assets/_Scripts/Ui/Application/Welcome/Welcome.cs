using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.Welcome
{
    public class Welcome : MonoBehaviour
    {
        private UIDocument _welcomeUIDocument;
        private static VisualElement _welcomeRoot;
        private static bool _isInterfaceWelcomeActive;
        internal static bool IsInterfaceWelcomeActive
        {
            get => _isInterfaceWelcomeActive;
            set => _isInterfaceWelcomeActive = value;
        }
        private void Awake()
        {
            _welcomeUIDocument = GetComponent<UIDocument>();
            if (_welcomeUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _welcomeRoot = _welcomeUIDocument.rootVisualElement;
            }
            HideUi();
        }
        internal static void ShowUi()
        {
            _isInterfaceWelcomeActive = true;
            if (_welcomeRoot!=null)
            {
                _welcomeRoot.style.display = DisplayStyle.Flex;
            }
            else
            {
                print("Error interface!!");
            }
        }
        internal static void HideUi()
        {
            _isInterfaceWelcomeActive = false;
            if (_welcomeRoot!=null)
            {
                _welcomeRoot.style.display = DisplayStyle.None;
            }else
            {
                print("Error interface!!");
            }
        }
    }
}
