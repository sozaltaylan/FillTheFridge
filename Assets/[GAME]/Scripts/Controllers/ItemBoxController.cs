using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

namespace ColorAndFill.Controllers
{
    public class ItemBoxController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private List<ItemController> items = new List<ItemController>();

        [SerializeField] private float duration;
        [SerializeField] private float scaleValue;

        private ItemController selectedItem;

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
            GetItemsInBox();
            _startScale = transform.localScale;
        }

        private void GetItemsInBox()
        {
            foreach (Transform child in this.transform)
            {
                if (child.TryGetComponent(out ItemController item))
                {
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
            }
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

        public ItemController GetItem()
        {

            for (int i = 0; i < items.Count; i++)
            {
                selectedItem = items[items.Count - 1];
            }
            return selectedItem;
        }

        public void DestroyItem()
        {
            if (items.Count == 0)
            {
                transform.DOShakePosition(.5f, 10, 30, 90, false, false);
                return;
            }
            else
            {
                Destroy(selectedItem.gameObject);
                RemoveList(selectedItem);
            }
        }

        private void RemoveList(ItemController item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
        }
        #endregion
    }


}
