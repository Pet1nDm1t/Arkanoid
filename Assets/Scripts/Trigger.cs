using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class Trigger : MonoBehaviour
    {        
        private void OnTriggerEnter(Collider other)
        {
            GameManager.Instate.SetDamage(1);
        }
    }

}
