using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace ColorAndFill.Controllers
{
    public class BoxController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Vector3 destinationPos;
        [SerializeField] private Vector3 rotationPos;

        private Vector3 _startpos;
        private Quaternion _startRotPos;

        [SerializeField] private Collider coll;

        private Sequence _sequence;

        private bool isActive;

        #region Properties
        public bool IsActive => isActive;

        #endregion
        #endregion
        #region Methods

        private void Start()
        {
            _startpos = transform.position;
            _startRotPos = transform.rotation;
        }
        public void OpenBox()
        {
                _sequence = DOTween.Sequence();
                _sequence.Append(transform.DOLocalMove(destinationPos, 1));
                _sequence.Join(transform.DOLocalRotate(rotationPos, 1));
                isActive = true;
            
        }

        public void CloseBox()
        {
            if (isActive)
            {
                _sequence = DOTween.Sequence();
                _sequence.Append(transform.DOLocalMove(_startpos, 1));
                _sequence.Join(transform.DOLocalRotate(_startRotPos.eulerAngles, 1));
                isActive = false;
            }
            
        }











        #endregion
    }

}
