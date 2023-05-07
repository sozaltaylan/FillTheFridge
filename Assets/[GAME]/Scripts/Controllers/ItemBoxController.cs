using UnityEngine;
using DG.Tweening;

namespace ColorAndFill.Controllers
{
    public class ItemBoxController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float duration;
        [SerializeField] private float scaleValue;

        private bool isOpen;

        private Vector3 _startScale;

        [SerializeField] private Collider coll;

        #region Properties

        public bool IsOpen => isOpen;

        #endregion
        #endregion
        #region Methods

        private void Start()
        {
            _startScale = transform.localScale;
        }
        public void OpenItemBox()
        {
            if (!isOpen)
            {
                transform.DOScale(transform.localScale * scaleValue, duration);
                isOpen = true;
            }
        }
        public void CloseItemBox()
        {
            if (isOpen)
            {
                transform.DOScale(_startScale, duration);
                isOpen = false;

            }
        }

        public void SetCollider(bool active)
        {
            coll.enabled = active;
        }
        #endregion
    }


}
