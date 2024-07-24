using System;
using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.Login
{
    public class Login : MonoBehaviour
    {
        private UIDocument _loginUIDocument;
        private static VisualElement _loginRoot;
        private VisualElement _container;
        private Label _tittle;
        private TextField _username;
        private TextField _password;
        private Label _link;
        private Toggle _rememberMe;
        private Button _login;
        private Button _exit;
        private static bool _isInterfaceLoginActive;
        internal static bool IsInterfaceLoginActive
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
            }
            HideUi();
            
        }
        private void OnEnable()
        {
            SettingsUiElements();
        }

        private void Update()
        {
            AdjustStyles();
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
        private void SettingsUiElements()
        {
            _container = _loginRoot.Q<VisualElement>("Container");
            _tittle = _loginRoot.Q<Label>("Tittle");
            _username = _loginRoot.Q<TextField>("Username");
            _password = _loginRoot.Q<TextField>("Password");
            _link = _loginRoot.Q<Label>("Link");
            _rememberMe = _loginRoot.Q<Toggle>("RememberMe");
            _login = _loginRoot.Q<Button>("Login");
            _login.clicked += LogIn;
            _exit = _loginRoot.Q<Button>("Exit");
            _exit.clicked += QuitApplication;
        }
        private void QuitApplication()
        {
            UnityEngine.Application.Quit();
            EndSession();
        }
        private void LogIn()
        {
            //ToDo logica para iniciar sesion
            if (true)
            {
                HideUi();
                Dashboard.Dashboard.ShowUi();
            }
            else
            {
                print("error de inicio de sesion");
            }
        }
        private void EndSession()
        {
            print("terminando sesion");
        }
        private void AdjustStyles()
        {
            var widthScreen = _container.resolvedStyle.width;
            var heightScreen=_container.resolvedStyle.height;
            
            if (!float.IsNaN(widthScreen))
            {
                switch (widthScreen)
                {
                    case < 400:
                        _tittle.style.fontSize = 12;
                        _username.style.width = _password.style.width=180;
                        _username.style.height = _password.style.height =30;
                        _username.style.fontSize = _password.style.fontSize= 7;
                        _link.style.fontSize = _rememberMe.style.fontSize=8;
                        _rememberMe.style.height =  12;
                        _rememberMe.style.width = 100;
                        _login.style.width = _exit.style.width = 50;
                        _login.style.height = _exit.style.height = 12;
                        break;
                    case < 600 and >= 400:
                        _tittle.style.fontSize = 18;
                        _username.style.width = _password.style.width=180;
                        _username.style.height = _password.style.height =30;
                        _username.style.fontSize = _password.style.fontSize= 7;
                        _link.style.fontSize = _rememberMe.style.fontSize=9;
                        _rememberMe.style.height =  12;
                        _rememberMe.style.width = 100;
                        _login.style.width = _exit.style.width = 100;
                        _login.style.height = _exit.style.height = 25;
                        break;
                    case < 800 and >= 600:
                        _tittle.style.fontSize = 25;
                        _username.style.width = _password.style.width=225;
                        _username.style.height = _password.style.height =40;
                        _username.style.fontSize = _password.style.fontSize= 11;
                        _link.style.fontSize =_rememberMe.style.fontSize= 12;
                        _rememberMe.style.height =  14;
                        _rememberMe.style.width = 110;
                        _login.style.width = _exit.style.width = 100;
                        _login.style.height = _exit.style.height = 20;
                        break;
                    case < 1000 and >= 800:
                        _tittle.style.fontSize = 23;
                        _username.style.width = _password.style.width=250;
                        _username.style.height = _password.style.height =45;
                        _username.style.fontSize = _password.style.fontSize= 18;
                        _link.style.fontSize = _rememberMe.style.fontSize=22;
                        _rememberMe.style.height =  18;
                        _rememberMe.style.width = 200;
                        _login.style.width = _exit.style.width = 120;
                        _login.style.height = _exit.style.height = 30;
                        break;
                    case < 1200 and >= 1000:
                        _tittle.style.fontSize = 41;
                        _username.style.width = _password.style.width=415;
                        _username.style.height = _password.style.height =50;
                        _username.style.fontSize = _password.style.fontSize= 22;
                        _link.style.fontSize =_rememberMe.style.fontSize= 22;
                        _rememberMe.style.height =  20;
                        _rememberMe.style.width = 200;
                        _login.style.width = _exit.style.width = 130;
                        _login.style.height = _exit.style.height = 40;
                        break;
                    case < 1500 and >= 1200:
                        _tittle.style.fontSize = 40;
                        _username.style.width = _password.style.width=400;
                        _username.style.height = _password.style.height =50;
                        _username.style.fontSize = _password.style.fontSize= 22;
                        _link.style.fontSize =_rememberMe.style.fontSize= 22;
                        _rememberMe.style.height =  20;
                        _rememberMe.style.width = 250;
                         _login.style.width = _exit.style.width = 200;
                        _login.style.height = _exit.style.height = 50;
                        break;
                    default:

                        break;
                }
            }
        }
    }
}
