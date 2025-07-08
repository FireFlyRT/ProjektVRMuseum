using UnityEngine;

namespace Assets.Scripts
{
    public class DoorInteractable : SimpleHingeInteractable
    {
        [SerializeField]
        private Transform _doorObject;

        [SerializeField]
        private bool _negateValue;

        [SerializeField]
        private float _offset;

        protected override void Update()
        {
            base.Update();

            float eulerX = transform.localEulerAngles.x + _offset;
            if (_negateValue) 
                eulerX = -eulerX;

            if (_doorObject != null)
                _doorObject.localEulerAngles = new Vector3(
                    _doorObject.localEulerAngles.x,
                    _doorObject.localEulerAngles.y,
                    eulerX
                    );
        }
    }
}
