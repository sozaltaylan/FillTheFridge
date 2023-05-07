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

        private Vector3 _mousefirstPosition;
        private Vector3 _mouseHoldPosition;

        private Ray _ray;
        private RaycastHit _hit;

        #endregion
        #region Methods
      
        private void Update()
        {
            SetInput();
        }

        private void SetInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetClick();
            }
            else if (Input.GetMouseButton(0))
            {

            }
            
        }

        public void SetClick()
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit))
            {
                if (_hit.collider.TryGetComponent(out BoxController box))
                {
                    if (!box.IsActive)
                    {
                        box.OpenBox();
                    }
                    else
                    {
                        box.CloseBox();
                    }
                }
                if (_hit.collider.TryGetComponent(out DoorController door))
                {
                    door.OpenDoor();
                }
            }
        }
        
    }
    #endregion
}