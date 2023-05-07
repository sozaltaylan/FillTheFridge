using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorAndFill.Controllers
{
    public class DoorController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Vector3 rotationPos;

        [SerializeField] private float duration;

        private Vector3 _startpos;

        [SerializeField] private Collider coll;

        private Sequence _sequence;


        #endregion
        #region Methods

        private void Start()
        {
            _startpos = transform.position;
        }
        public void OpenDoor()
        {
            transform.DORotate(rotationPos, duration);
        }
        #endregion
    }
}
