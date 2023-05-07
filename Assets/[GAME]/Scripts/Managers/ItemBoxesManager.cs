using ColorAndFill.Controllers;
using System.Collections.Generic;
using UnityEngine;


namespace ColorAndFill.Managers
{
    public class ItemBoxesManager : MonoBehaviour
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

        private void SetBoxesCollider()
        {
            for (int i = 0; i < itemBoxes.Count; i++)
            {
                var box = itemBoxes[i];
                
            }
        }
        #endregion


    }


}
