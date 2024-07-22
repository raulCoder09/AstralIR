using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Application.IoTGateway
{
    public class IoTGateway : MonoBehaviour
    {
        private UIDocument _ioTGatewayUIDocument;
        private static VisualElement _ioTGatewayRoot;
        private static bool _isInterfaceIoTGatewayActive;
        internal static bool IsInterfaceIoTGatewayActive
        {
            get => _isInterfaceIoTGatewayActive;
            set => _isInterfaceIoTGatewayActive = value;
        }
        private void Awake()
        {
            _ioTGatewayUIDocument = GetComponent<UIDocument>();
            if (_ioTGatewayUIDocument==null)
            {
                Debug.Log("Interface dont found");
            }
            else
            {
                _ioTGatewayRoot = _ioTGatewayUIDocument.rootVisualElement;
            }
            HideUi();
            
        }
        internal static void ShowUi()
        {
            _isInterfaceIoTGatewayActive = true;
            if (_ioTGatewayRoot!=null)
            {
                _ioTGatewayRoot.style.display = DisplayStyle.Flex;
            }
        }
        internal static void HideUi()
        {
            _isInterfaceIoTGatewayActive = false;
            if (_ioTGatewayRoot!=null)
            {
                _ioTGatewayRoot.style.display = DisplayStyle.None;
            }
        }
    }
}
