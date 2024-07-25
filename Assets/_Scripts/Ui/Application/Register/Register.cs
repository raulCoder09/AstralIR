using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.Register
{
    public class Register : MonoBehaviour
    {
        private UIDocument _registerUIDocument;
        private static VisualElement _registerRoot;
        private VisualElement _container;
        private Button _exit;
        private Button _register;
        private Label _link;
        private static bool _isInterfaceRegisterActive;
        internal static bool IsInterfaceRegisterActive
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
        private void SettingsUiElements()
        {
            _container=_registerRoot.Q<VisualElement>("Container");
            _register = _registerRoot.Q<Button>("Register");
            _register.clicked += RegisterUser;
            _exit = _registerRoot.Q<Button>("Exit");
            _exit.clicked += QuitApplication;
            _link = _registerRoot.Q<Label>("Link");
            _link.RegisterCallback<ClickEvent>( evt =>LogInUi());
        }
        private void LogInUi()
        {
            HideUi();
            Login.Login.ShowUi();
        }


        private void RegisterUser()
        {
            HideUi();
            Dashboard.Dashboard.ShowUi();
        }
        private void QuitApplication()
        {
            UnityEngine.Application.Quit();
            EndSession();
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
                        _exit.style.width = _register.style.width=90;
                        break;
                    case < 600 and >= 400:
                        _exit.style.width = _register.style.width=180;
                        break;
                    case < 800 and >= 600:
                        break;
                    case < 1000 and >= 800:
                        break;
                    case < 1200 and >= 1000:
                        break;
                    case < 1500 and >= 1200:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
