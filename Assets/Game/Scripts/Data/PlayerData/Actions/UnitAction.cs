using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Data
{
	public class UnitAction
	{
		public Sprite ActionSprite;
		public int ActionPrice;
		public string ActionID;
		public TActionType ActionType;
		public UnitActionParams ActionParams;
		public List<UnitActonEffects> Effcts;
	}
}