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

            if (GetHandType() == OVRHand.Hand.HandLeft)
            {
                CheckIndexPinch();
            }
        }

        private OVRHand.Hand GetHandType()
        {
            return ((OVRSkeleton.IOVRSkeletonDataProvider) _hand).GetSkeletonType() == OVRSkeleton.SkeletonType.HandLeft
                ? OVRHand.Hand.HandLeft
                : OVRHand.Hand.HandRight;
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
