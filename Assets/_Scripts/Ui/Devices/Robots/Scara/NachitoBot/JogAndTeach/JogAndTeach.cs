using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.JogAndTeach
{
    public class JogAndTeach : MonoBehaviour
    {
        private UIDocument _jogAndTeachUIDocument;
        private static VisualElement _jogAndTeachRoot;
        private static bool _isInterfaceJogAndTeachActive;
        internal bool IsInterfaceJogAndTeachActive
        {
            get => _isInterfaceJogAndTeachActive;
            set => _isInterfaceJogAndTeachActive = value;
        }
        private void Awake()
        {
            _jogAndTeachUIDocument = GetComponent<UIDocument>();
            if (_jogAndTeachUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _jogAndTeachRoot = _jogAndTeachUIDocument.rootVisualElement;
                Debug.Log($"Interface {gameObject.name} found");
            }
            
        }
        internal static void ShowUi()
        {
            _isInterfaceJogAndTeachActive = true;
            if (_jogAndTeachRoot!=null)
            {
                _jogAndTeachRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceJogAndTeachActive = false;
            if (_jogAndTeachRoot!=null)
            {
                _jogAndTeachRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
