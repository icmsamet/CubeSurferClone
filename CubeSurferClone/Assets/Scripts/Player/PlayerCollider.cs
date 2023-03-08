using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using DG.Tweening;
using UnityEngine;
using System;

namespace Player
{
    public class PlayerCollider : Player
    {
        PlayerProperties m_Properties;
        SplineFollower m_SplineFollower;
        bool onTop;
        public PlayerCollider(PlayerProperties _properties)
        {
            m_Properties = _properties;
            m_SplineFollower = m_Properties.splineFollower;
        }

        public IEnumerator CollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                if(m_Properties.cubeHolder.transform.childCount > 0)
                {
                    var distance = GetZBoundSize(collision.gameObject.GetComponent<Obstacle.Obstacle>().activeObs.transform) + GetZBoundSize(m_Properties.childModel.transform);
                    var speed = m_SplineFollower.followSpeed;
                    var t = distance / speed;
                    yield return new WaitForSeconds(t);
                    Player.instance.CheckAllCollectable();
                    //collision.gameObject.tag = "Untagged";
                }
                else
                {
                    GameManager.GameManager.instance.FailGame();
                }
            }
            else if(collision.gameObject.tag == "Stair")
            {
                if (m_Properties.cubeHolder.transform.childCount > 0)
                {
                    var distance = GetZBoundSize(m_Properties.childModel.transform);
                    var speed = m_SplineFollower.followSpeed;
                    var t = distance / speed;
                    yield return new WaitForSeconds(t);
                    Player.instance.CheckAllCollectable();
                    //collision.gameObject.tag = "Untagged";
                }
                else
                {
                    GameManager.GameManager.instance.FailGame();
                }
            }
        }

        float GetZBoundSize(Transform obj)
        {
            return obj.gameObject.GetComponent<MeshRenderer>().bounds.size.z;
        }
    }
}
