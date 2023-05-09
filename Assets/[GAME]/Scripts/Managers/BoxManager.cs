using ColorAndFill.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorAndFill.Exceptions;

namespace ColorAndFill.Managers
{
    public class BoxManager : MonoSingleton<BoxManager>
    {
        #region Variables
        [SerializeField] private List<BoxController> boxes = new List<BoxController>();

        #endregion
        #region Methods
        private void Start()
        {
            GetAllBoxes();
        }

        private void GetAllBoxes()
        {
            foreach (Transform child in this.transform)
            {
                if (child.TryGetComponent(out BoxController box))
                {
                    if (!boxes.Contains(box))
                    {
                        boxes.Add(box);
                    }
                }
            }
        }

        public void CloseOpenedBox() 
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                var box = boxes[i];
                if (box.IsActive)
                    box.CloseBox();
            }
        }


        public bool IsEmpty()
        {
            bool isEmpty = default;

            for (int i = 0; i < boxes.Count; i++)
            {
                var box = boxes[i];
                if (box.IsActive)
                {
                    isEmpty = box.IsEmpty();        
                }
            }
            return isEmpty;
        }




        #endregion
    }

}
