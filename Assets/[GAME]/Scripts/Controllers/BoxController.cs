using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ColorAndFill.Managers;

namespace ColorAndFill.Controllers
{
    public class BoxController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private List<ItemController> itemsInBox = new List<ItemController>();

        [SerializeField] private Vector3 destinationPos;
        [SerializeField] private Vector3 rotationPos;

        private Vector3 _startpos;
        private Quaternion _startRotPos;

        [SerializeField] private Collider coll;

        private Sequence _sequence;

        private bool isActive;
        private bool isCreate;

        #region Properties
        public bool IsActive => isActive;
        public bool IsCreate => isCreate;

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

        private void AddList(ItemController item)
        {
            if (!itemsInBox.Contains(item))
            {
                itemsInBox.Add(item);
            }
        }
        public void CreateItem(Vector3 pos)
        {
            if (!ItemBoxesManager.Instance.GetItem())
                return;
            var item = Instantiate(ItemBoxesManager.Instance.GetItem(), pos, Quaternion.identity);
            item.transform.parent = this.transform;
            AddList(item);
        }

        public bool IsEmpty()
        {
            bool isEmpty = itemsInBox.Count > 0 ? false : true;
            return isEmpty;
        }  











        #endregion
    }

}
