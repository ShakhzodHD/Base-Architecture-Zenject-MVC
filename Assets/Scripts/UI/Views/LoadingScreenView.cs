using Core;
using UnityEngine;

namespace UIManager
{
    public class LoadingScreenView : UIView, ILoadingScreenView
    {
        protected override void OnShow()
        {
            Debug.Log("Loading Screen Show");
        }

        protected override void OnHide()
        {
            Debug.Log("Loading Screen Hidden");
        }
    }
}