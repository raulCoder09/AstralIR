using System.Collections.Generic;
using _Scripts.Ui.Devices.Robots.Scara.NachitoBot.ControlPanel;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.Simulator
{
    public class Simulator : MonoBehaviour
    {
        [SerializeField] private GameObject nbt01;
        [SerializeField] private GameObject nbtUi01;
        private static UIDocument _simulatorUIDocument;
        private static VisualElement _simulatorRoot;
        
        private DropdownField _selectionDevice;
        private string _deviceSelected;
        
        private static bool _isInterfaceSettingsActive;
        private Button _launchSimulator;
        private ControlPanel _controlPanelUiNbt01;
        private void Awake()
        {
            _simulatorUIDocument = GetComponent<UIDocument>();
            if (_simulatorUIDocument==null)
            {
                print("Error interface");
            }
            else
            {
                _simulatorRoot = _simulatorUIDocument.rootVisualElement;
                HideUi();
            }
            
        }
        private void OnEnable()
        {
            SettingUiElements();
        }

        private void Start()
        {
            _selectionDevice.value = "Select device";
        }

        private static void HideUi()
        {
            _isInterfaceSettingsActive = false;
            _simulatorRoot.style.display = DisplayStyle.None;
        }
        internal static void ShowUi()
        {
            _isInterfaceSettingsActive = true;
            _simulatorRoot.style.display = DisplayStyle.Flex;
        }
        private void SettingUiElements()
        {
            _selectionDevice= _simulatorRoot.Q<DropdownField>("SelectionDevice");
            _selectionDevice.RegisterValueChangedCallback(evt =>
            {
                CreateSecondDropdown(evt.newValue);
            });
            _launchSimulator = _simulatorRoot.Q<Button>("LaunchSimulator");
            _launchSimulator.clicked += LaunchSimulator;

        }
        private void CreateSecondDropdown(string option)
        {
            
            var dropdownPanel = _simulatorRoot.Q<VisualElement>("DropdownPanel");
            var linearActuator = _simulatorRoot.Q<DropdownField>("LinearActuator");
            var rotatingActuator = _simulatorRoot.Q<DropdownField>("RotatingActuator");
            var complexAutomationSystem=_simulatorRoot.Q<DropdownField>("ComplexAutomationSystem");
            switch (option)
            { 
            case "Complex Automation System":
                if (linearActuator!=null)
                {
                    linearActuator.RemoveFromHierarchy();
                }
                if (rotatingActuator!=null)
                {
                    rotatingActuator.RemoveFromHierarchy();
                }
        
                if (_simulatorRoot.Q<DropdownField>("ComplexAutomationSystem")==null)
                {
                    
                    complexAutomationSystem = new DropdownField
                    {
                        name = "ComplexAutomationSystem",
                        choices = new List<string> { "SCARA robot", "Cartesian robot", "Articulated robot" },
                        value = "Select device"
                    };
                    dropdownPanel.Add(complexAutomationSystem);
                }
                
                complexAutomationSystem.RegisterValueChangedCallback(evt =>
                {
                    CreateThirdDropdown(evt.newValue);
                });
                
                break;
            case "Linear actuator":
                if (complexAutomationSystem!=null)
                {
                    complexAutomationSystem.RemoveFromHierarchy();
                }
                if (rotatingActuator!=null)
                {
                    rotatingActuator.RemoveFromHierarchy();
                }
        
                
                if (_simulatorRoot.Q<DropdownField>("LinearActuator")==null)
                {  
                    linearActuator = new DropdownField
                    {
                        name = "LinearActuator",
                        choices = new List<string> { "Linear actuator 1", "Linear actuator 2", "Linear actuator 3" },
                        value = "Select device"
                    };
                    dropdownPanel.Add(linearActuator);
                }
                break;
            case "Rotating actuator":
                if (complexAutomationSystem!=null)
                {
                    complexAutomationSystem.RemoveFromHierarchy();
                }
                if (linearActuator!=null)
                {
                    linearActuator.RemoveFromHierarchy();
                }
                
                if (_simulatorRoot.Q<DropdownField>("RotatingActuator")==null)
                {  
                    rotatingActuator = new DropdownField
                    {
                        name = "RotatingActuator",
                        choices = new List<string> { "Rotating actuator 1", "Rotating actuator 2", "Rotating actuator 3" },
                        value = "Select device"
                    };
                    dropdownPanel.Add(rotatingActuator);
                }
                break;
            default:
                if (complexAutomationSystem != null)
                {
                    complexAutomationSystem.RemoveFromHierarchy();
                }
                if (linearActuator != null)
                {
                    linearActuator.RemoveFromHierarchy();
                }
                if (rotatingActuator!=null)
                {
                    rotatingActuator.RemoveFromHierarchy();
                }
                break;
         }
           

        }
        private void CreateThirdDropdown(string option)
        {
            var dropdownPanel = _simulatorRoot.Q<VisualElement>("DropdownPanel");
            
            
            switch (option)
            {
                case "SCARA robot":
                    if (_simulatorRoot.Q<DropdownField>("ScaraRobots")==null)
                    {
                    
                        var scaraRobots = new DropdownField
                        {
                            name = "ScaraRobots",
                            choices = new List<string> { "NchitoBot", "MEDARA", "LS10-B" },
                            value = "Select device"
                        };
                        dropdownPanel.Add(scaraRobots);
                        
                        scaraRobots.RegisterValueChangedCallback(evt =>
                        {
                            _deviceSelected = evt.newValue;
                        });
                        if (scaraRobots.value!="Select device")
                        {
                            _deviceSelected = scaraRobots.value;
                        }
                        
                    }
                    break;
                case "Cartesian robot":
                    print("Cartesian robot");
                    break;
                case "Articulated robot":
                    print("Articulated robot");
                    break;
            }
        }

        private void LaunchSimulator()
        {
            if (_deviceSelected!=null)
            {
                _launchSimulator.text = "Start simulator";
                HideUi();
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.LoadScene("Simulator");
                
            }
            else
            {
                _launchSimulator.text = "Selection error";
            }
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name=="Simulator")
            {
                var nachitoBot=Instantiate(nbt01, Vector3.zero, quaternion.identity);
                var nachitoBotUi = Instantiate(nbtUi01, Vector3.zero, quaternion.identity);
                nachitoBotUi.name = "NbtUi01";
                nachitoBot.name = "Nbt01";
                nachitoBotUi.transform.SetParent(GameObject.FindGameObjectWithTag($"UiDevicesScara").transform);
                _controlPanelUiNbt01= GameObject.Find("ControlPanelNb")?.GetComponent<ControlPanel>();
                _controlPanelUiNbt01.ShowUi();

            }
        }
    }
}
