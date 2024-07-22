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
            if (!float.IsNaN(widthScreen))
            {
                switch (widthScreen)
                {
                    case < 400:
                        _message.style.fontSize = 8;
                        _title.style.fontSize = 30;
                        _logo.style.height =_logo.style.width = 60;
                        _launch.style.width =_exit.style.width= 60;
                        _launch.style.height =_exit.style.height= 12;
                        break;
                    case < 600 and >= 400:
                        _message.style.fontSize = 10;
                        _title.style.fontSize = 35;
                        _logo.style.height =_logo.style.width = 100;
                        _launch.style.width =_exit.style.width= 80;
                        _launch.style.height =_exit.style.height= 20;
                        break;
                    case < 800 and >= 600:
                        _message.style.fontSize = 15;
                        _title.style.fontSize = 50;
                        _logo.style.height =_logo.style.width = 150;
                        _launch.style.width =_exit.style.width= 100;
                        _launch.style.height =_exit.style.height= 30;
                        break;
                    case < 1000 and >= 800:
                        _message.style.fontSize = 20;
                        _title.style.fontSize = 60;
                        _logo.style.height = _logo.style.width = 200;
                        _launch.style.width =_exit.style.width= 120;
                        _launch.style.height =_exit.style.height= 40;
                        break;
                    case < 1200 and >= 1000:
                        _message.style.fontSize = 25;
                        _title.style.fontSize = 70;
                        _logo.style.height = _logo.style.width = 250;
                        _launch.style.width =_exit.style.width= 140;
                        _launch.style.height =_exit.style.height= 60;
                        break;
                    case < 1400 and >= 1200:
                        _message.style.fontSize = 30;
                        _title.style.fontSize = 80;
                        _logo.style.height = _logo.style.width = 300;
                        _launch.style.width =_exit.style.width= 160;
                        _launch.style.height =_exit.style.height= 80;
                        break;
                    default:
                        _message.style.fontSize = 35;
                        _title.style.fontSize = 90;
                        _logo.style.height =_logo.style.width = 400;
                        _launch.style.width =_exit.style.width= 160;
                        _launch.style.height =_exit.style.height= 80;
                        break;
                }
            }
        }
    }
}
