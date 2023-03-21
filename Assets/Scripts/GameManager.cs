using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace Arkanoid
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instate;

        private Controller _controller;

        [SerializeField] private int _health;

        [SerializeField] private Ball _ball;

        [SerializeField] private SpawnBloks _spawnBloks;
        private void Awake()
        {           
            _controller = new Controller();
            Instate = this;
        }
        private void Start()
        {
            foreach (Block block in _spawnBloks.Blocks)
            {
                if (block != null)
                {
                    block.OnBlockDestroyed += HandleBlockDestroyed;                    
                }
            }
        }

        private void OnEnable()
        {
            _controller.ActionMap.Start.Enable();
            _controller.ActionMap.Start.performed += _ => _ball.StartBall();
        }
        private void OnDisable()
        {
            _controller.ActionMap.Start.Disable();
        }
        private void HandleBlockDestroyed()
        {            
            _ball.BoostSpeed();
            _spawnBloks.Blocks.RemoveAll(block => block == null);
            if (_spawnBloks.Blocks.Count < 2)
            {
                Debug.Log("You win!");
                EditorApplication.isPaused = true;
            }
        }

        public void SetDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Debug.Log("Game over");
                EditorApplication.isPaused = true;
            }
            else
            {
                _ball.StoptBall();
                Debug.Log($"You health:{_health}");                
            }
        }
     

    }

}
