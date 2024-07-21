using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.AlgorithmsTest
{
    public class AlgorithmsTest : MonoBehaviour
    {
        private UIDocument _algorithmsTestUIDocument;
        private static VisualElement _algorithmsTestRoot;
        private static bool _isInterfaceAlgorithmsTestActive;
        internal bool IsInterfaceAlgorithmsTestActive
        {
            get => _isInterfaceAlgorithmsTestActive;
            set => _isInterfaceAlgorithmsTestActive = value;
        }
        private void Awake()
        {
            _algorithmsTestUIDocument = GetComponent<UIDocument>();
            if (_algorithmsTestUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _algorithmsTestRoot = _algorithmsTestUIDocument.rootVisualElement;
                Debug.Log($"Interface {gameObject.name} found");
            }
            
        }
        internal static void ShowUi()
        {
            _isInterfaceAlgorithmsTestActive = true;
            if (_algorithmsTestRoot!=null)
            {
                _algorithmsTestRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceAlgorithmsTestActive = false;
            if (_algorithmsTestRoot!=null)
            {
                _algorithmsTestRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
