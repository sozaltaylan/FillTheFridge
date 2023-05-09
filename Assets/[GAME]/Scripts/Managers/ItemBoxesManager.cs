using ColorAndFill.Controllers;
using System.Collections.Generic;
using UnityEngine;
using ColorAndFill.Exceptions;


namespace ColorAndFill.Managers
{
    public class ItemBoxesManager : MonoSingleton<ItemBoxesManager>
    {
        #region Variables

        [SerializeField] private List<ItemBoxController> itemBoxes = new List<ItemBoxController>();

        #endregion
        #region Methods

        private void Start()
        {
            var list = ScrollManager.Instance.GetContentList();
            itemBoxes.AddRange(list);
        }

        public void CloseOpenedItemBox()
        {
            for (int i = 0; i < itemBoxes.Count; i++)
            {
                var itemBox = itemBoxes[i];
                if (itemBox.IsOpen)
                {
                    itemBox.CloseItemBox();
                }
            }
        }      
        #endregion


    }


}
