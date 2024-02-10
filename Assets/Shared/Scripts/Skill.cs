using UnityEngine;

namespace Shared.Scripts
{
    public class Skill : MonoBehaviour
    {
    #region Private Methods

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log($"TriggerEnter: {col.gameObject}");
        }

    #endregion
    }
}