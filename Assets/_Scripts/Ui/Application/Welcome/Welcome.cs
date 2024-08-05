using UnityEngine;
using UnityEngine.UIElements;
namespace _Scripts.Ui.Application.Welcome
{
    public class Welcome : MonoBehaviour
    {
        private UIDocument _welcomeUIDocument;
        private static VisualElement _welcomeRoot;
        private VisualElement _container;
        private Label _title;
        private VisualElement _logo;
        private Label _message;
        private Button _launch;
        private Button _exit;
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

        private void OnEnable()
        {
            SettingUiElements();
            AdjustStyles();
        }

        private void Update()
        {
            AdjustStyles();
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
        private void SettingUiElements()
        {
            _container = _welcomeRoot.Q<VisualElement>("Container");
            _title = _welcomeRoot.Q<Label>("Tittle");
            _logo = _welcomeRoot.Q<VisualElement>("Logo");
            _message=_welcomeRoot.Q<Label>("Message");
            _launch = _welcomeRoot.Q<Button>("Launch");
            _launch.clicked += ShowLogin;
            _exit = _welcomeRoot.Q<Button>("Exit");
            _exit.clicked += QuitApplication;
        }
        
        private void ShowLogin()
        {
            HideUi();
            Login.Login.ShowUi();
        }
        private void QuitApplication()
        {
            UnityEngine.Application.Quit();
        }

        private void AdjustStyles()
        {
            var widthScreen = _container.resolvedStyle.width;
            var heightScreen = _container.resolvedStyle.height;
        }
    }
}
