using UnityEngine;
using UnityEngine.Events;

namespace Script.Presentation.UI
{
    public abstract class UIView : MonoBehaviour
    {
        public UnityEvent onUIShow;
        public UnityEvent onUIHide;
    }
}