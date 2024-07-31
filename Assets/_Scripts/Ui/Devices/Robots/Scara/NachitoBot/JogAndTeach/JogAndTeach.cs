using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.JogAndTeach
{
    public class JogAndTeach : MonoBehaviour
    {
        private string _nameDevice;
        internal string NameDevice
        {
            get => _nameDevice;
            set => _nameDevice = value;
        }
        private string _category;
        internal string Category
        {
            get => _category;
            set => _category = value;
        }
        private string _tag;
        internal string Tag
        {
            get => _tag;
            set => _tag = value;
        }
        private UIDocument _jogAndTeachUIDocument;
        private static VisualElement _jogAndTeachRoot;
        private static bool _isInterfaceJogAndTeachActive;
        internal bool IsInterfaceJogAndTeachActive
        {
            get => _isInterfaceJogAndTeachActive;
            set => _isInterfaceJogAndTeachActive = value;
        }

        // internal JogAndTeach(string nameDevice,string category, string tag )
        // { 
        //     _nameDevice=nameDevice;
        //     _category=category;
        //     _tag=tag;
        // }
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
            }
        }
        private void OnEnable()
        {
            HideUi();
        }
        internal void ShowUi()
        {
            _isInterfaceJogAndTeachActive = true;
            if (_jogAndTeachRoot!=null)
            {
                _jogAndTeachRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal void HideUi()
        {
            _isInterfaceJogAndTeachActive = false;
            if (_jogAndTeachRoot!=null)
            {
                _jogAndTeachRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
