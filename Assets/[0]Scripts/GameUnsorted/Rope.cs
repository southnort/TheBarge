using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Default
{
    internal sealed class Rope : MonoBehaviour
    {
        [SerializeField] private int PointsCount;
        [SerializeField] private LineRenderer LineRend;
        [SerializeField] private float PointsDistance;
        [SerializeField] private float PointColliderRadius;

        List<Rigidbody> GeneratedPoints;

        [HideInInspector] public Transform PointA;
        [HideInInspector] public Transform PointB;

        // Start is called before the first frame update
        void Start()
        {
            GeneratedPoints = new List<Rigidbody>();

            Vector3 Start = PointA.position;
            Vector3 End = PointB.position;
            Vector3 Dir = End - Start;

            for (int i = 0; i < PointsCount; i++)
            {
                GameObject ChainPoint = new GameObject();
                ChainPoint.transform.SetParent(transform.parent);
                SphereCollider SC = ChainPoint.AddComponent<SphereCollider>();
                SC.radius = PointColliderRadius;
                Rigidbody RB = ChainPoint.AddComponent<Rigidbody>();
                GeneratedPoints.Add(RB);
                RB.drag = 1;
                if (i == 0 || i == PointsCount - 1)
                {
                    RB.isKinematic = true;
                }
                ChainPoint.layer = LayerMask.NameToLayer("Rope");
                ChainPoint.transform.position = Start + Dir * ((float)i / (float)PointsCount);
                if (i > 0)
                {
                    ConfigurableJoint CJ = ChainPoint.AddComponent<ConfigurableJoint>();
                    CJ.connectedBody = GeneratedPoints[i - 1];
                    CJ.xMotion = ConfigurableJointMotion.Limited;
                    CJ.yMotion = ConfigurableJointMotion.Limited;
                    CJ.zMotion = ConfigurableJointMotion.Limited;

                    SoftJointLimit SJL = CJ.linearLimit;
                    SJL.limit = PointsDistance;
                    SJL.bounciness = 1;
                    SoftJointLimitSpring SJLS = CJ.linearLimitSpring;
                    SJLS.damper = 3;
                    SJLS.spring = 999;
                    CJ.linearLimit = SJL;
                    CJ.linearLimitSpring = SJLS;

                    CJ.autoConfigureConnectedAnchor = false;
                    CJ.connectedAnchor = Vector3.zero;
                }
            }
            LineRend.positionCount = PointsCount;
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < GeneratedPoints.Count; i++)
            {
                LineRend.SetPosition(i, GeneratedPoints[i].transform.position);
                if (i == 0)
                {
                    GeneratedPoints[i].transform.position = PointA.position;
                }
                else if (i == GeneratedPoints.Count - 1)
                {
                    GeneratedPoints[i].transform.position = PointB.position;
                }
            }
        }
    }
}