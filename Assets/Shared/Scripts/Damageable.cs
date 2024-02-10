#region

using UnityEngine;

#endregion

namespace Shared.Scripts
{
    public class Damageable : MonoBehaviour
    {
    #region Public Methods

        public void TakeDamage()
        {
            Debug.Log($"{gameObject.name}_TakeDamage: 10");
        }

    #endregion
    }
}