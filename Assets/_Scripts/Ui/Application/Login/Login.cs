using System;
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
        }
        private void AdjustStyles()
        {
            var widthScreen = _container.resolvedStyle.width;
            var heightScreen=_container.resolvedStyle.height;
            
            if (!float.IsNaN(widthScreen))
            {
                print(widthScreen);
                switch (widthScreen)
                {
                    case < 400:
                        _tittle.style.fontSize = 12;
                        _username.style.width = _password.style.width=180;
                        _username.style.height = _password.style.height =30;
                        _username.style.fontSize = _password.style.fontSize= 7;
                        break;
                    case < 600 and >= 400:
                        _tittle.style.fontSize = 12;
                        _username.style.width = _password.style.width=180;
                        _username.style.height = _password.style.height =30;
                        _username.style.fontSize = _password.style.fontSize= 7;
                        break;
                    case < 800 and >= 600:
                        _tittle.style.fontSize = 20;
                        _username.style.width = _password.style.width=180;
                        _username.style.height = _password.style.height =30;
                        _username.style.fontSize = _password.style.fontSize= 7;
                        break;
                    case < 1000 and >= 800:
                        _tittle.style.fontSize = 23;
                        _username.style.width = _password.style.width=250;
                        _username.style.height = _password.style.height =45;
                        _username.style.fontSize = _password.style.fontSize= 18;
                        break;
                    case < 1200 and >= 1000:
                        _tittle.style.fontSize = 20;
                        _username.style.width = _password.style.width=180;
                        _username.style.height = _password.style.height =30;
                        _username.style.fontSize = _password.style.fontSize= 7;
                        break;
                    case < 1500 and >= 1200:
                        _tittle.style.fontSize = 40;
                        _username.style.width = _password.style.width=400;
                        _username.style.height = _password.style.height =50;
                        _username.style.fontSize = _password.style.fontSize= 22;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
