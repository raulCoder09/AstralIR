using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.Dashboard
{
    public class Dashboard : MonoBehaviour
    {
        private static UIDocument _dashboardUIDocument;
        private static VisualElement _dashboardRoot;
        private static bool _isInterfaceDashboardActive;
        private Button _simulator;
        private Button _mbar;
        private Button _xr;
        private Button _ar;
        private Button _supportAndHelp;
        private Button _systemLogs;
        private Button _settings;
        private Button _welcome;
        private Button _exit;
        internal static bool IsInterfaceDashboardActive
        {
            get => _isInterfaceDashboardActive;
            set => _isInterfaceDashboardActive = value;
        }
        private void Awake()
        {
            _dashboardUIDocument = GetComponent<UIDocument>();
            if (_dashboardUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _dashboardRoot = _dashboardUIDocument.rootVisualElement;
            }
            HideUi();
        }
        private void OnEnable()
        {
            SettingsUiElements();
        }
        internal static void ShowUi()
        {
            _isInterfaceDashboardActive = true;
            if (_dashboardRoot!=null)
            {
                _dashboardRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceDashboardActive = false;
            if (_dashboardRoot!=null)
            {
                _dashboardRoot.style.display = DisplayStyle.None;
            }
        }
        private void SettingsUiElements()
        {
        _simulator=_dashboardRoot.Q<Button>("Simulator");
        _simulator.clicked += ShowSimulator;
        _mbar=_dashboardRoot.Q<Button>("MarkerBasedAugmentedReality");
        _mbar.clicked += ShowMbar;
        _xr=_dashboardRoot.Q<Button>("ExtendedReality");
        _xr.clicked += ShowXr;
        _ar=_dashboardRoot.Q<Button>("AugmentedReality");
        _ar.clicked += ShowAr;
        _supportAndHelp=_dashboardRoot.Q<Button>("SupportAndHelp");
        _supportAndHelp.clicked += ShowSupportAndHelp;
        _systemLogs=_dashboardRoot.Q<Button>("SystemLogs");
        _systemLogs.clicked += ShowSystemLogs;
        _settings=_dashboardRoot.Q<Button>("Settings");
        _settings.clicked += ShowSettings;
        _welcome = _dashboardRoot.Q<Button>("Welcome");
        _welcome.clicked += ShowWelcome;
        _exit = _dashboardRoot.Q<Button>("Exit");
        _exit.clicked += QuitApplication;
        }
        private void ShowWelcome()
        {
            HideUi();
            Welcome.Welcome.ShowUi();
        }
        private void QuitApplication()
        {
            UnityEngine.Application.Quit();
        }
        private void ShowSettings()
        {
            HideUi();
            print("ShowSettings");
        }
        private void ShowSystemLogs()
        {
            HideUi();
            print("ShowSystemLogs");
        }
        private void ShowSupportAndHelp()
        {
            HideUi();
            print("ShowSupportAndHelp");
        }
        private void ShowAr()
        {
            HideUi();
            print("ShowAr");
        }
        private void ShowXr()
        {
            HideUi();
            print("ShowXr");
        }
        private void ShowMbar()
        {
            HideUi();
            print("ShowMbar");
        }
        private void ShowSimulator()
        {
            HideUi();
            Simulator.Simulator.ShowUi();
        }
    }
}
