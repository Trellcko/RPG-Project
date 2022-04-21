using UnityEngine;

namespace Trell.Visualizers
{
    public class ZoneVisualizer : MonoBehaviour
	{
		[SerializeField] private Zone[] _zones;
        private void OnDrawGizmos()
        {
			foreach (var zone in _zones)
			{
				if (zone.DoDrawZone)
				{
					DrawZone(zone.CheckingForRange.Range, zone.Color);
				}
			}
        }

		private void DrawZone(int radius, Color color)
        {
			Gizmos.color = color;
			Gizmos.DrawWireSphere(transform.position, radius);
        }

    }

}