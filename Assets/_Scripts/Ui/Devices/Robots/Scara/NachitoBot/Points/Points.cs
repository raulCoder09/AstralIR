using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.Points
{
    public class Points : MonoBehaviour
    {
        private UIDocument _pointsUIDocument;
        private static VisualElement _pointsRoot;
        private static bool _isInterfacePointsActive;
        internal bool IsInterfacePointsActive
        {
            get => _isInterfacePointsActive;
            set => _isInterfacePointsActive = value;
        }
        private void Awake()
        {
            _pointsUIDocument = GetComponent<UIDocument>();
            if (_pointsUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _pointsRoot = _pointsUIDocument.rootVisualElement;
                Debug.Log($"Interface {gameObject.name} found");
            }
            
        }
        internal static void ShowUi()
        {
            _isInterfacePointsActive = true;
            if (_pointsRoot!=null)
            {
                _pointsRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal void HideUi()
        {
            _isInterfacePointsActive = false;
            if (_pointsRoot!=null)
            {
                _pointsRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
