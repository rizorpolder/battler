using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Common
{
	public class ToggleController : MonoBehaviour
	{
		public System.Action<int, bool> OnToggleInvoked = (i,b) => { };

		[SerializeField] private int _defaultToggleIndex = 0;

		[SerializeField] private ToggleGroup _toggleGroup;

		private Toggle _lastToggle;
		private Dictionary<int, Toggle> _togglesCache;

		protected virtual void Awake()
		{
			CacheToggles();
			SetToggle(_defaultToggleIndex, true);
		}

		private void CacheToggles()
		{
			_togglesCache = new Dictionary<int, Toggle>();
			var toggles = _toggleGroup.transform.GetComponentsInChildren<Toggle>();
			foreach (var customToggle in toggles)
			{
				var index = customToggle.transform.GetSiblingIndex();
				_togglesCache.Add(index, customToggle);
			}
		}

		public void SetToggle(int index, bool withoutNotify = false)
		{
			if (!_togglesCache.TryGetValue(index, out Toggle customToggle))
			{
#if UNITY_EDITOR
				Debug.Log($"TOGGLE NOT FOUND");
#endif
				return;
			}

			_lastToggle = customToggle;
			_lastToggle.SetIsOnWithoutNotify(withoutNotify);
		}

		public virtual void OnToggleAction(Toggle self)
		{
			if (!self.isOn)
				return;
			
			int index = self.transform.GetSiblingIndex();

			if (!_togglesCache.TryGetValue(index, out var customToggle))
				return;

			_lastToggle = customToggle;

			OnToggleInvoked?.Invoke(index, customToggle.isOn);
		}
	}
}