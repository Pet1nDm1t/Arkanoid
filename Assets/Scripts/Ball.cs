using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

namespace Arkanoid
{
    public class Ball : MonoBehaviour
    {
        [SerializeField, Range(0, 1000)] private float _startSpeed;
        [SerializeField, Range(0, 1000)] private float _maxSpeed;
        [SerializeField, Range(0, 10)] private float _boost;

        private GameObject _parent;
            
        private bool IsCanMove = false;

        private void Awake()
        {
            _parent = transform.parent.gameObject;
            StartCoroutine(MoveBall());
        }
        private void OnCollisionEnter(Collision collision)
        {
            Vector3 collisionNormal = collision.contacts[0].normal;

            Vector3 reflectedDirection = Vector3.Reflect(transform.forward, collisionNormal);

            transform.forward = reflectedDirection;

        }
        public IEnumerator MoveBall() 
        {
            
            while (true)
            {
                if (IsCanMove)
                {
                    transform.parent = null;
                    transform.position += _startSpeed * transform.forward * Time.deltaTime;
                }
                yield return null;
            }
        }
        public void BoostSpeed()
        {
            if (_startSpeed >= _maxSpeed) return;
            _startSpeed += _boost;            
        }
        public void StartBall()
        {
            transform.parent = null;
            IsCanMove = true;
        }
        public void StoptBall()
        {
            IsCanMove = false;
            transform.parent = _parent.transform;
            transform.position = _parent.transform.position + new Vector3(0, 0, 1);
            transform.rotation = _parent.transform.rotation;
        }

    }

}
