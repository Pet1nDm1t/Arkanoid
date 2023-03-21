using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Arkanoid
{
    public class SpawnBloks : MonoBehaviour
    {
        [SerializeField] private float _distance;
        [SerializeField] private float _countBlocks;
        [SerializeField] private Block _block;
        [SerializeField] private List<Material> _materials;

        [HideInInspector] public List<Block> Blocks;
        
        private void Awake()
        {
            Blocks = new List<Block>();
            SpawnBlocks();
        }
        private void SpawnBlocks()
        {
            for (int i = 0; i < _countBlocks; i++)
            {           
                Blocks.Add(Instantiate(_block, Random.insideUnitSphere * _distance + transform.position,
                    Random.rotation, transform));

                Blocks[i].SetMaterial(_materials[Random.Range(0, _materials.Count)]);
            }
        }   

    }
}

