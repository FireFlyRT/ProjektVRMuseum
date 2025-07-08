using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Assets.Scripts
{
    public class SimpleHingeInteractable : XRSimpleInteractable
    {
        private Transform grabHand;

        protected virtual void Update()
        {
            if (grabHand != null)
                transform.LookAt(grabHand, transform.forward);
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);
            grabHand = args.interactorObject.transform;
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);
            grabHand = null;
        }
    }
}