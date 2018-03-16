using System;
using System.Collections.Generic;
using System.Linq;
using Beam.Utilities;
using UnityEngine;

namespace Beam.UI
{
	// Token: 0x020007CE RID: 1998
	public class GameUI : MonoBehaviour
	{
		// Token: 0x06002E18 RID: 11800 RVA: 0x000119FE File Offset: 0x0000FBFE
		private void Awake()
		{
			if (GameUI._Instance != null)
			{
				BeamTeam.Destroy<GameObject>(base.gameObject);
			}
			else
			{
				GameUI._Instance = this;
			}
			// This is StrandedCMenu Code // 
			this.cmenuObject = new GameObject();
			this.cmenuObject.AddComponent<CMenu>();
		}

		// Token: 0x06002E19 RID: 11801 RVA: 0x00011A37 File Offset: 0x0000FC37
		private void OnDestroy()
		{
			GameUI._Instance = null;
		}

		// Token: 0x06002E1A RID: 11802 RVA: 0x000FFCA8 File Offset: 0x000FDEA8
		public static T GetUIComponent<T>() where T : Component
		{
			GameUI instance = GameUI._Instance;
			object obj;
			if (instance == null)
			{
				obj = null;
			}
			else
			{
				obj = instance._components.FirstOrDefault((MonoBehaviour thing) => thing.GetType() == typeof(T));
			}
			return obj as T;
		}

		// Token: 0x040024CB RID: 9419
		private static GameUI _Instance;

		// Token: 0x040024CC RID: 9420
		[SerializeField]
		private List<MonoBehaviour> _components;

		// Token: 0x040024CD RID: 9421
		public GameObject cmenuObject;
	}
}
