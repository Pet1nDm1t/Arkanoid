using UnityEngine;
using System;
namespace Arkanoid
{
    public class Block : MonoBehaviour
    {
        private MeshRenderer _mesh;

        public event Action OnBlockDestroyed;

        private void Awake()
        {
            _mesh = GetComponent<MeshRenderer>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Ball")
            {
                DestroyBlock();                
            }
        }
        private void DestroyBlock()
        {
            OnBlockDestroyed?.Invoke();
            Destroy(gameObject);                             
        }
        public void SetMaterial(Material material)
        {
            _mesh.sharedMaterial = material;
        }
    }
}
