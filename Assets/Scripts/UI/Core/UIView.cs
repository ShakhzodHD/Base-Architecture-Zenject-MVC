using Core;
using UnityEngine;

namespace UIManager
{
    public abstract class UIView : MonoBehaviour, IUIView
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private GameObject rootObject;

        public bool IsVisible { get; private set; }

        protected virtual void Awake()
        {
            if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
            if (rootObject == null) rootObject = gameObject;
        }
        public virtual void Show()
        {
            if (IsVisible) return;

            rootObject.SetActive(true);
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
            IsVisible = true;
            OnShow();
        }

        public virtual void Hide()
        {
            if (!IsVisible) return;

            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0f;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
            rootObject.SetActive(false);
            IsVisible = false;
            OnHide();
        }

        protected virtual void OnShow() { }
        protected virtual void OnHide() { }
    }
}