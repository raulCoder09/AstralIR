using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Devices.Robots.Scara.NachitoBot.Points
{
    public class Points : MonoBehaviour
    {
        private UIDocument _pointsUIDocument;
        private VisualElement _pointsRoot;
        private bool _isInterfacePointsActive;
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
            }
            
        }
        private void OnEnable()
        {
            HideUi();
        }
        internal void ShowUi()
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
