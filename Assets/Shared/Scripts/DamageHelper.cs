#region

using System.Linq;
using rStarUtility.Util.Extensions.Csharp;
using UnityEngine;

#endregion

namespace Shared.Scripts
{
    public class DamageHelper
    {
    #region Public Methods

        public static void DealDamage(Vector2 position)
        {
            var damageables = CastHelper.Cast(position , Vector2.one);
            Debug.Log($"damageables count: {damageables.Count()}");
            damageables.ForEach(damageable => Debug.Log($"{damageable}"));
        }

    #endregion
    }
}