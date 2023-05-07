using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorAndFill.Exceptions;
using ColorAndFill.Controllers;

namespace ColorAndFill.Managers
{

    public class InputManager : MonoSingleton<InputManager>

    {
        #region Variables

        private float downTime;
        private float upTime;
        private float clickDuration;

        private bool isClicking;

        #endregion
        #region Methods

        private void Update()
        {
            SetInput();

            if (isClicking)
                clickDuration = Time.time - downTime;

            Debug.Log(clickDuration);
        }

        private void SetInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetClick();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                SetClickUp();
            }

        }

        private void SetClick()
        {
            downTime = Time.time;
            isClicking = true;


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out BoxController box))
                {
                    if (!box.IsActive)
                        box.OpenBox();
                    else
                        box.CloseBox();
                }
                else if (hit.collider.TryGetComponent(out DoorController door))
                    door.OpenDoor();

                else if (hit.collider.TryGetComponent(out ItemBoxController itemBox))
                {
                    if (!itemBox.IsOpen && clickDuration > .2)
                        itemBox.OpenItemBox();
                    else
                        itemBox.CloseItemBox();
                }
            }
        }

        private void SetClickUp()
        {
            upTime = Time.time;
            isClicking = false;

            clickDuration = upTime - downTime;
        }



    }
}

#endregion
