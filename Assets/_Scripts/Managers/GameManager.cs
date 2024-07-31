
using _Scripts.Ui.Application.Dashboard;
using _Scripts.Ui.Application.IoTGateway;
using _Scripts.Ui.Application.Login;
using _Scripts.Ui.Application.Maintenance;
using _Scripts.Ui.Application.Register;
using _Scripts.Ui.Application.Settings;
using _Scripts.Ui.Application.SupportAndHelp;
using _Scripts.Ui.Application.SystemLogs;
using _Scripts.Ui.Application.Welcome;


using _Scripts.Ui.Devices.Robots.Scara.NachitoBot.AlgorithmsTest;
using _Scripts.Ui.Devices.Robots.Scara.NachitoBot.ControlPanel;
using _Scripts.Ui.Devices.Robots.Scara.NachitoBot.DirectKinematics;
using _Scripts.Ui.Devices.Robots.Scara.NachitoBot.InverseKinematics;
using _Scripts.Ui.Devices.Robots.Scara.NachitoBot.JogAndTeach;
using _Scripts.Ui.Devices.Robots.Scara.NachitoBot.Points;
using _Scripts.Ui.Devices.Robots.Scara.NachitoBot.References;
using _Scripts.Ui.Devices.Robots.Scara.NachitoBot.Sequences;
using UnityEngine;

namespace _Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {

        #region VariablesNachitoBot
            private AlgorithmsTest _algorithmsTestNb;
            private ControlPanel _controlPanelNb;
            private DirectKinematics _directKinematicsNb;
            private InverseKinematics _inverseKinematicsNb;
            private JogAndTeach _jogAndTeachNb;
            private Points _pointsNb;
            private References _referencesNb;
            private Sequences _sequencesNb;
        #endregion

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            //todo ver que se puede hacer para definir si se destruye o no una ui dependiendo del dispositivo
            DontDestroyOnLoad(GameObject.Find("Ui"));
            
        }

        private void Start()
        {
            #region UiNachitoBotGameObjectFind
                _algorithmsTestNb = GameObject.Find("AlgorithmsTestNb")?.GetComponent<AlgorithmsTest>();
                _controlPanelNb= GameObject.Find("ControlPanelNb")?.GetComponent<ControlPanel>();
                _directKinematicsNb= GameObject.Find("DirectKinematicsNb")?.GetComponent<DirectKinematics>();
                _inverseKinematicsNb= GameObject.Find("InverseKinematicsNb")?.GetComponent<InverseKinematics>();
                _jogAndTeachNb= GameObject.Find("JogAndTeachNb")?.GetComponent<JogAndTeach>();
                _pointsNb= GameObject.Find("PointsNb")?.GetComponent<Points>();
                _referencesNb= GameObject.Find("ReferencesNb")?.GetComponent<References>();
                _sequencesNb= GameObject.Find("SequencesNb")?.GetComponent<Sequences>();
            #endregion
            
            HideAllUi();
            Welcome.ShowUi();
        }
        private void HideAllUi()
        {
            #region UiApplication
                Dashboard.HideUi();
                IoTGateway.HideUi();
                Login.HideUi();
                Maintenance.HideUi();
                Register.HideUi();
                Settings.HideUi();
                SupportAndHelp.HideUi();
                SystemLogs.HideUi();
                Welcome.HideUi();
            #endregion
        } 
    }
}
