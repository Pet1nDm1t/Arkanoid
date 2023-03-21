using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        private Controller _controller;
        private Rigidbody _body;
        [SerializeField] private playerNumber _players;
        [SerializeField] private float _speed;
        private Vector2 direction;
        private void Awake()
        {
            _controller = new Controller();
            _body = GetComponent<Rigidbody>();
        }
        private void OnEnable()
        {
            _controller.ActionMap.Enable();
        }
        private void FixedUpdate()
        {
            Move();
        }

        private void OnDisable()
        {
            _controller.ActionMap.Disable();
        }
        private void Move()
        {
            if (_players == playerNumber.PlayerOne)
            {
                direction = _controller.ActionMap.MoveWASD.ReadValue<Vector2>();

                _body.velocity += new Vector3(direction.x, direction.y, 0) * _speed * Time.fixedDeltaTime;
            }
            else if (_players == playerNumber.PlayerTwo)
            {
                direction = _controller.ActionMap.MoveArrow.ReadValue<Vector2>();

                _body.velocity += new Vector3(-direction.x, direction.y, 0) * _speed * Time.fixedDeltaTime;
            }

            
            
        }
        private enum playerNumber
        {
            PlayerOne,
            PlayerTwo
        }
    }

}
