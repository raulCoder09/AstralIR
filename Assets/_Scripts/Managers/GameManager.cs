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
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            //todo ver que se puede hacer para definir si se destruye o no una ui dependiendo del dispositivo
            DontDestroyOnLoad(GameObject.Find("Ui"));
        }

        private void Start()
        {
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
            
            #region UiNachitoBot

                AlgorithmsTest.HideUi();
                ControlPanel.HideUi();
                DirectKinematics.HideUi();
                InverseKinematics.HideUi();
                JogAndTeach.HideUi();
                Points.HideUi();
                References.HideUi();
                Sequences.HideUi();
                SupportAndHelp.HideUi();

            #endregion






        } 
    }
}
