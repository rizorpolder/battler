using System;
using Game.Scripts.Configs.UnitConfigs;
using UnityEngine;

namespace Game.Scripts.Data
{
	public class UnitAction
	{
		public Sprite actionSprite;

		public int actionPrice;
		public string actionID;
		public TActionType ActionType;
		public UnitActionParams actionParams;

		public UnitAction(UnitActionConfig _config)
		{
		}
	}

	[Serializable]
	public class UnitActionParams
	{
		public int minActionValue;
		public int maxActionValue;
	}

	public enum TActionType
	{
		Physical,
		Magic,
	}
}