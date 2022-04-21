using System;
using Trell.Utils;
using UnityEngine;

namespace Trell.Visualizers
{
	[Serializable]
    class Zone
    {
		[field: SerializeField] public CheckingForRange CheckingForRange { get; private set; }
		[field: SerializeField] public Color Color { get; private set; }
		[field: SerializeField] public bool DoDrawZone { get; private set; }
	}

}