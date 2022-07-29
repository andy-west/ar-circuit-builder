namespace Assets
{
    public class HandTrackingGrabber : OVRGrabber
    {
        private OVRHand _hand;

        protected override void Start()
        {
            base.Start();
            _hand = GetComponent<OVRHand>();
        }

        public override void Update()
        {
            base.Update();
            CheckIndexPinch();
        }

        private void CheckIndexPinch()
        {
            var pinchStrength = _hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
            var isPinching = pinchStrength > 0.7f;

            if (!m_grabbedObj && isPinching && m_grabCandidates.Count > 0)
            {
                GrabBegin();
            }
            else if (m_grabbedObj && !isPinching)
            {
                GrabEnd();
            }
        }
    }
}
