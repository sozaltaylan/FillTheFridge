using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorAndFill.Exceptions;
using DG.Tweening;

namespace ColorAndFill.Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        #region Variables

        [SerializeField] private GameObject okButton;
        [SerializeField] private GameObject cancelButton;

        [SerializeField] private float endValue;
        [SerializeField] private float duration;

        #endregion

        #region Methods

        public void OpenOkButton()
        {
            okButton.transform.DOMoveX(endValue, duration);
        }

        public void CloseOkButton()
        {
            okButton.transform.DOMoveX(-endValue, duration);
        }
        public void OpenCancelButton()
        {
            cancelButton.transform.DOMoveX(endValue, duration);
        }
        public void CloseCancelButton()
        {
            cancelButton.transform.DOMoveX(-endValue, duration);
        }
        private void Update()
        {
            if (!BoxManager.Instance.IsEmpty())
            {
                OpenCancelButton();
            }
            else
            {
                CloseCancelButton();
            }
            
        }

        #endregion

    }

}
