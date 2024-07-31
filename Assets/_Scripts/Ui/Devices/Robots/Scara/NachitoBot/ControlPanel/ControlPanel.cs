using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.ControlPanel
{
    public class ControlPanel : MonoBehaviour
    {
        private UIDocument _controlPanelUIDocument;
        private VisualElement _controlPanelRoot;

        private bool _isInterfaceControlPanelActive;
        
        internal bool IsInterfaceControlPanelActive
        {
            get => _isInterfaceControlPanelActive;
            set => _isInterfaceControlPanelActive = value;
        }
        private AlgorithmsTest.AlgorithmsTest _algorithmsTest;
        private DirectKinematics.DirectKinematics _directKinematics;
        private InverseKinematics.InverseKinematics _inverseKinematics;
        private JogAndTeach.JogAndTeach _jogAndTeach;
        private Points.Points _points;
        private References.References _references;
        private Sequences.Sequences _sequences;
        
            
        private void Awake()
        {
            _controlPanelUIDocument = GetComponent<UIDocument>();
            if (_controlPanelUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _controlPanelRoot = _controlPanelUIDocument.rootVisualElement;
            }
            _algorithmsTest = gameObject.AddComponent<AlgorithmsTest.AlgorithmsTest>();
            _directKinematics = gameObject.AddComponent<DirectKinematics.DirectKinematics>();
            _inverseKinematics = gameObject.AddComponent<InverseKinematics.InverseKinematics>();
            _jogAndTeach = gameObject.AddComponent<JogAndTeach.JogAndTeach>();
            _points = gameObject.AddComponent<Points.Points>();
            _references = gameObject.AddComponent<References.References>();
            _sequences = gameObject.AddComponent<Sequences.Sequences>();
        }
        private void OnEnable()
        {
            HideUi();
            SettingUiElements();
        }
        internal void ShowUi()
        {
            _isInterfaceControlPanelActive = true;
            if (_controlPanelRoot!=null)
            {
                _controlPanelRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal void HideUi()
        {
            _isInterfaceControlPanelActive = false;
            if (_controlPanelRoot!=null)
            {
                _controlPanelRoot.style.display = DisplayStyle.None;
            }
        }

        private void SettingUiElements()
        {
            var menu = _controlPanelRoot.Q<DropdownField>("Menu");
            menu.value = "Control panel";
            menu.RegisterValueChangedCallback(evt =>
            {
                ChangeUi(evt.newValue);
            });
            var motorOff=_controlPanelRoot.Q<Button>("MotorOff");
            motorOff.clicked += TurnOffMotors;
            var motorOn=_controlPanelRoot.Q<Button>("MotorOn");
            motorOn.clicked += TurnOnMotors;
            var powerLow=_controlPanelRoot.Q<Button>("PowerLow");
            powerLow.clicked += PowerLowMotors;
            var powerHigh=_controlPanelRoot.Q<Button>("PowerHigh");
            powerHigh.clicked += PowerHighMotors;
            var reset=_controlPanelRoot.Q<Button>("Reset");
            reset.clicked += ResetMotors;
            var home=_controlPanelRoot.Q<Button>("Home");
            home.clicked += HomeMotors;
            var freeAll = _controlPanelRoot.Q<Button>("FreeAll");
            freeAll.clicked += FreeAllJoints;
            var lockAll = _controlPanelRoot.Q<Button>("LockAll");
            lockAll.clicked += LockAllJoints;
            var j1 = _controlPanelRoot.Q<Toggle>("J1");
            j1.RegisterValueChangedCallback(evt =>
            {
                LockJ1(evt.newValue);
            });
            var j2 = _controlPanelRoot.Q<Toggle>("J2");
            j2.RegisterValueChangedCallback(evt =>
            {
                LockJ2(evt.newValue);
            });
            var j3 = _controlPanelRoot.Q<Toggle>("J3");
            j3.RegisterValueChangedCallback(evt =>
            {
                LockJ3(evt.newValue);
            });
            var j4 = _controlPanelRoot.Q<Toggle>("J4");
            j4.RegisterValueChangedCallback(evt =>
            {
                LockJ4(evt.newValue);
            });
        }
        private void LockJ4(bool state)
        {
            print($"j4: {state}");
        }
        private void LockJ3(bool state)
        {
            print($"j3: {state}");
        }
        private void LockJ2(bool state)
        {
            print($"j2: {state}");
        }
        private void LockJ1(bool state)
        {
            print($"j1: {state}");
        }
        private void LockAllJoints()
        {
            var j1 = _controlPanelRoot.Q<Toggle>("J1");
            j1.value = true;
            var j2 = _controlPanelRoot.Q<Toggle>("J2");
            j2.value = true;
            var j3 = _controlPanelRoot.Q<Toggle>("J3");
            j3.value = true;
            var j4 = _controlPanelRoot.Q<Toggle>("J4");
            j4.value = true;
        }
        private void FreeAllJoints()
        {
            var j1 = _controlPanelRoot.Q<Toggle>("J1");
            j1.value = false;
            var j2 = _controlPanelRoot.Q<Toggle>("J2");
            j2.value = false;
            var j3 = _controlPanelRoot.Q<Toggle>("J3");
            j3.value = false;
            var j4 = _controlPanelRoot.Q<Toggle>("J4");
            j4.value = false;
        }
        private void HomeMotors()
        {
            throw new System.NotImplementedException();
        }
        private void ResetMotors()
        {
            throw new System.NotImplementedException();
        }
        private void PowerHighMotors()
        {
            var powerLow=_controlPanelRoot.Q<Button>("PowerLow");
            powerLow.style.backgroundColor = Color.gray;
            powerLow.enabledSelf = true;
            var powerHigh=_controlPanelRoot.Q<Button>("PowerHigh");
            powerHigh.style.backgroundColor = Color.green;
            powerHigh.enabledSelf = false;
            var power = _controlPanelRoot.Q<Label>("Power");
            power.text = "Power: High";
        }
        private void PowerLowMotors()
        {
            var powerLow=_controlPanelRoot.Q<Button>("PowerLow");
            powerLow.style.backgroundColor = Color.green;
            powerLow.enabledSelf = false;
            var powerHigh=_controlPanelRoot.Q<Button>("PowerHigh");
            powerHigh.enabledSelf = true;
            powerHigh.style.backgroundColor = Color.gray;
            var power = _controlPanelRoot.Q<Label>("Power");
            power.text = "Power: Low";
        }
        private void TurnOnMotors()
        {
            var motorOff=_controlPanelRoot.Q<Button>("MotorOff");
            motorOff.enabledSelf = true;
            var motorOn=_controlPanelRoot.Q<Button>("MotorOn");
            motorOn.enabledSelf = false;
            var powerLow=_controlPanelRoot.Q<Button>("PowerLow");
            powerLow.enabledSelf = true;
            var powerHigh=_controlPanelRoot.Q<Button>("PowerHigh");
            powerHigh.enabledSelf = true;
            var motors = _controlPanelRoot.Q<Label>("Motors");
            motors.style.color = Color.green;
            motors.text = "Motors: on";
            var freeAll = _controlPanelRoot.Q<Button>("FreeAll");
            freeAll.enabledSelf = true;
            var lockAll = _controlPanelRoot.Q<Button>("LockAll");
            lockAll.enabledSelf = true;

        }
        private void TurnOffMotors()
        {
            var motorOff=_controlPanelRoot.Q<Button>("MotorOff");
            motorOff.enabledSelf = false;
            var motorOn=_controlPanelRoot.Q<Button>("MotorOn");
            motorOn.enabledSelf = true;
            var powerLow=_controlPanelRoot.Q<Button>("PowerLow");
            powerLow.enabledSelf = false;
            var powerHigh=_controlPanelRoot.Q<Button>("PowerHigh");
            powerHigh.enabledSelf = false;
            var motors = _controlPanelRoot.Q<Label>("Motors");
            motors.style.color = Color.red;
            powerLow.style.backgroundColor = Color.gray;
            powerHigh.style.backgroundColor = Color.gray;
            motors.text = "Motors: off";
            var freeAll = _controlPanelRoot.Q<Button>("FreeAll");
            freeAll.enabledSelf = false;
            var lockAll = _controlPanelRoot.Q<Button>("LockAll");
            lockAll.enabledSelf = false;
        }
        private void ChangeUi(string ui)
        {
            print(ui);
            switch (ui)
            {
                case "Algorithms test":
                    HideUi();
                    break;
                case "Direct Kinematics":
                    HideUi();
                    break;
                case "Inverse Kinematics":
                    HideUi();
                    break;
                case "Jog and teach":
                    HideUi();
                    _jogAndTeach.ShowUi();
                    break;
                case "Points":
                    HideUi();
                    break;
                case "References":
                    HideUi();
                    break;
                case "Sequences":
                    HideUi();
                    break;
                default:
                    break;
                    
            }
           
        }
    }
}
