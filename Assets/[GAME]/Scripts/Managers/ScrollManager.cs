using ColorAndFill.Controllers;
using System.Collections.Generic;
using UnityEngine;
using ColorAndFill.Exceptions;
using UnityEngine.UIElements;

namespace ColorAndFill.Managers
{
    public class ScrollManager : MonoSingleton<ScrollManager>
    {
        #region Variables

        [SerializeField] private GameObject content;

        [SerializeField] private ScrollView scroll;

        private bool isActive;


        #region Properties
        public bool IsActive => isActive;

        #endregion

        #endregion
        #region Methods

        public List<ItemBoxController> GetContentList()
        {
            List<ItemBoxController> contentList = new List<ItemBoxController>();

            foreach (Transform child in content.transform)
            {
                if (child.TryGetComponent(out ItemBoxController itemBox))
                {
                    if (!contentList.Contains(itemBox))
                    {
                        contentList.Add(itemBox);
                    }
                }


            }

            return contentList;
        }


        #endregion


    }


}
