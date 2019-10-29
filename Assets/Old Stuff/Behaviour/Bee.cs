//%GenSrc:1:z/jQWu3utUORRioZJvjvew
/*
 * This code was generated by InstinctAI.
 *
 * It is safe to edit this file.
 */

namespace instinctai.usr.behaviours
{
    using UnityEngine;
    using com.kupio.instinctai;

    public partial class Bee : MonoBehaviour
    {
        public bool hasNectar = false;
        public bool flowerHunting = true;
        public Flower targetFlower;
        public Transform targetLoc;
        public Vector3 wanderDir = new Vector3(0, 0, 0); 

        public NodeVal Wander()
        {
            float newX = Random.Range(-10, 10f);
            float newZ = Random.Range(-10, 10f);
            wanderDir = new Vector3(newX, 2, newZ);
            return NodeVal.Success;
        }

        public NodeVal FindFlower()
        {
            Collider[] nearbyFlowers = Physics.OverlapSphere(transform.position, 2f);

            if (nearbyFlowers.Length > 0)
            {
                for (int i = 0; i < nearbyFlowers.Length; i++)
                {
                    if (nearbyFlowers[i].GetComponent<Flower>())
                    {
                        Flower possibleTarget = nearbyFlowers[i].GetComponent<Flower>();
                        if (!possibleTarget.ignore)
                        {
                            if (targetFlower == null)
                            {
                                targetFlower = possibleTarget;
                                targetLoc = targetFlower.transform;
                                if (nearbyFlowers.Length == 1)
                                {
                                    flowerHunting = false;
                                }
                            }
                            else if (Vector3.Distance(transform.position, targetFlower.transform.position) > Vector3.Distance(transform.position, possibleTarget.transform.position))
                            {
                                possibleTarget = targetFlower;
                                flowerHunting = false;
                                targetLoc = targetFlower.transform;
                            }
                        }
                    }
                }
            }
            return NodeVal.Success;
        }

        public NodeVal TakeNectar()
        {
            if (targetFlower.nectar > 0)
            {
                hasNectar = true;
                targetFlower.nectar--;
            }
            else
            {
                targetFlower.ignore = true;
                targetFlower = null;
                flowerHunting = true;
            }
            return NodeVal.Success;
        }

        public NodeVal DeliverNectar()
        {
            hasNectar = false;
            return NodeVal.Success;
        }
    }
}