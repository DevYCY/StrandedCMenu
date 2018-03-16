using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Beam.Crafting;
using Beam.UI.Crafting;
using UnityEngine;

namespace Beam.UI
{
	// Token: 0x020009E4 RID: 2532
	public class CMenu : MonoBehaviour
	{
		// Token: 0x06003CE9 RID: 15593 RVA: 0x00122104 File Offset: 0x00120304
		public void OnGUI()
		{
			float num = (float)Screen.width;
			int height = Screen.height;
			int num2 = 800;
			int num3 = 500;
			GUI.skin.button.normal.background = this.tabTex;
			GUI.skin.button.active.background = this.tabActiveTex;
			GUI.skin.horizontalSlider.normal.background = this.hNormalSliderTex;
			GUI.skin.horizontalSlider.fixedHeight = 40f;
			GUI.skin.horizontalSliderThumb.normal.background = this.hSliderThumbTex;
			GUI.skin.horizontalSliderThumb.fixedWidth = 40f;
			GUI.skin.horizontalSliderThumb.fixedHeight = 40f;
			GUI.skin.label.normal.textColor = Color.black;
			GUI.skin.horizontalScrollbarThumb.normal.background = this.hScrollThumbTex;
			GUI.skin.verticalScrollbarThumb.normal.background = this.vScrollThumbTex;
			if (this.enableMinimap)
			{
				this.ShowMinimap(true);
			}
			else
			{
				this.ShowMinimap(false);
			}
			if (this.toggleCount == 1)
			{
				this.PauseCamera(true);
				GUI.BeginGroup(new Rect(num / 2f - (float)(num2 / 2), (float)(height / 2 - num3 / 2), (float)num2, (float)num3));
				GUI.DrawTexture(new Rect(0f, 0f, (float)num2, (float)num3), this.mainFrameSkin);
				if (GUI.Button(new Rect(10f, 30f, 150f, 40f), "Main"))
				{
					this.currentSelectedTabIndex = 0;
				}
				if (GUI.Button(new Rect(160f, 30f, 150f, 40f), "Time & Weather"))
				{
					this.currentSelectedTabIndex = 1;
				}
				if (GUI.Button(new Rect(310f, 30f, 150f, 40f), "Spawn Menu"))
				{
					this.currentSelectedTabIndex = 2;
				}
				if (GUI.Button(new Rect(460f, 30f, 150f, 40f), "Minimap"))
				{
					this.currentSelectedTabIndex = 3;
				}
				GUI.BeginGroup(new Rect(10f, 70f, (float)num2 - 20f, (float)num3 - 100f));
				GUI.DrawTexture(new Rect(0f, 0f, (float)num2 - 10f, (float)num3 - 100f), this.tabContainerTex);
				if (this.currentSelectedTabIndex == 0)
				{
					this.mainTabScrollIndex = GUI.BeginScrollView(new Rect(0f, 0f, (float)num2 - 20f, (float)num3 - 100f), this.mainTabScrollIndex, new Rect(0f, 0f, (float)num2 - 20f, (float)num3));
					GUI.Label(new Rect(10f, 20f, 200f, 20f), "Player Statistics:");
					this.player_health = GUI.HorizontalSlider(new Rect(10f, 40f, (float)num2 - 55f, 60f), this.player_health, 0f, 700f);
					GUI.Label(new Rect(350f, 50f, 200f, 20f), "Health : " + ((int)this.player_health).ToString());
					this.player_hunger = GUI.HorizontalSlider(new Rect(10f, 100f, (float)num2 - 55f, 60f), this.player_hunger, 0f, 700f);
					GUI.Label(new Rect(350f, 110f, 200f, 20f), "Hunger : " + ((int)this.player_hunger).ToString());
					this.player_thirsty = GUI.HorizontalSlider(new Rect(10f, 160f, (float)num2 - 55f, 100f), this.player_thirsty, 0f, 700f);
					GUI.Label(new Rect(350f, 170f, 200f, 20f), "Thirsty : " + ((int)this.player_thirsty).ToString());
					this.player_sleep = GUI.HorizontalSlider(new Rect(10f, 220f, (float)num2 - 55f, 60f), this.player_sleep, 0f, 700f);
					GUI.Label(new Rect(350f, 230f, 200f, 20f), "Sleep : " + ((int)this.player_sleep).ToString());
					GUI.Label(new Rect(10f, 300f, 200f, 20f), "Player Settings");
					this.enable_quicksave = GUI.Toggle(new Rect(10f, 320f, 200f, 20f), this.enable_quicksave, "Enable Quick Save");
					this.enable_blockSunburn = GUI.Toggle(new Rect(10f, 340f, 200f, 20f), this.enable_blockSunburn, "Enable No Sunburn");
					GUI.Label(new Rect(10f, 360f, 200f, 20f), "Player Speed");
					this.player_walkSpeed = GUI.HorizontalSlider(new Rect(10f, 380f, (float)num2 - 55f, 60f), this.player_walkSpeed, 0f, 256f);
					GUI.Label(new Rect(350f, 390f, 200f, 20f), "WalkSpeed : " + ((int)this.player_walkSpeed).ToString());
					this.player_runSpeed = GUI.HorizontalSlider(new Rect(10f, 440f, (float)num2 - 55f, 60f), this.player_runSpeed, 0f, 256f);
					GUI.Label(new Rect(350f, 450f, 200f, 20f), "RunSpeed : " + ((int)this.player_runSpeed).ToString());
					GUI.EndScrollView();
				}
				if (this.currentSelectedTabIndex == 1)
				{
					this.mainTabScrollIndex = GUI.BeginScrollView(new Rect(0f, 0f, (float)num2 - 20f, (float)num3 - 80f), this.mainTabScrollIndex, new Rect(0f, 0f, (float)num2 - 20f, (float)num3 - 80f));
					GUI.Label(new Rect(10f, 20f, 200f, 20f), "Set Current Time:");
					this.currentGameTime = GUI.HorizontalSlider(new Rect(10f, 40f, (float)num2 - 40f, 60f), this.currentGameTime, 0f, 24f);
					if (this.currentGameTime > 0f)
					{
						Singleton<GameTime>.Instance.MilitaryTime = this.currentGameTime;
					}
					GUI.Label(new Rect(10f, 100f, 200f, 20f), "Weather");
					if (GUI.Button(new Rect(10f, 120f, ((float)num2 - 40f) / 3f, 200f), this.weatherIconSunneyTex))
					{
						this.SetCurrentWorldWeather(0);
					}
					if (GUI.Button(new Rect(10f + ((float)num2 - 40f) / 3f, 120f, ((float)num2 - 40f) / 3f, 200f), this.weatherIconRaineyTex))
					{
						this.SetCurrentWorldWeather(1);
					}
					if (GUI.Button(new Rect(10f + ((float)num2 - 40f) / 3f * 2f, 120f, ((float)num2 - 40f) / 3f, 200f), this.weatherIconThunderTex))
					{
						this.SetCurrentWorldWeather(2);
					}
					GUI.EndScrollView();
				}
				if (this.currentSelectedTabIndex == 2)
				{
					this.complatedConstruct = GUI.Toggle(new Rect((float)num2 - 40f - 120f, 20f, 120f, 20f), this.complatedConstruct, "Complated Build");
					if (GUI.Button(new Rect(10f, 20f, ((float)num2 - 20f) / 6f, 30f), "Foundation/Floor"))
					{
						this.currentSeletectSpawnTab = 0;
					}
					if (GUI.Button(new Rect(10f + ((float)num2 - 20f) / 6f, 20f, ((float)num2 - 20f) / 6f, 30f), "Wall/Stairs"))
					{
						this.currentSeletectSpawnTab = 1;
					}
					if (this.currentSeletectSpawnTab == 0)
					{
						this.spawnmenuTabScrollIndex = GUI.BeginScrollView(new Rect(10f, 50f, (float)num2 - 40f, (float)num3 - 100f), this.spawnmenuTabScrollIndex, new Rect(0f, 0f, (float)num2 - 20f, ((float)num3 - 80f) / 2f * 8f));
						this.InitIcons();
						float num4 = ((float)num2 - 20f) / 3f;
						float num5 = ((float)num3 - 80f) / 2f;
						if (GUI.Button(new Rect(0f, 0f, num4, num5), this.listSpawnableObject[0]))
						{
							this.InstantBuild("DRIFTWOOD_FOUNDATION");
						}
						if (GUI.Button(new Rect(num4, 0f, num4, num5), this.listSpawnableObject[1]))
						{
							this.InstantBuild("WOOD_FOUNDATION");
						}
						if (GUI.Button(new Rect(num4 * 2f, 0f, num4, num5), this.listSpawnableObject[2]))
						{
							this.InstantBuild("PLANK_FOUNDATION");
						}
						if (GUI.Button(new Rect(0f, num5, num4, num5), this.listSpawnableObject[3]))
						{
							this.InstantBuild("CORRUGATED_FOUNDATION");
						}
						if (GUI.Button(new Rect(num4, num5, num4, num5), this.listSpawnableObject[4]))
						{
							this.InstantBuild("BRICK_FOUNDATION");
						}
						if (GUI.Button(new Rect(num4 * 2f, num5, num4, num5), this.listSpawnableObject[5]))
						{
							this.InstantBuild("DRIFTWOOD_FLOOR");
						}
						if (GUI.Button(new Rect(0f, num5 * 2f, num4, num5), this.listSpawnableObject[6]))
						{
							this.InstantBuild("WOOD_FLOOR");
						}
						if (GUI.Button(new Rect(num4, num5 * 2f, num4, num5), this.listSpawnableObject[7]))
						{
							this.InstantBuild("PLANK_FLOOR");
						}
						if (GUI.Button(new Rect(num4 * 2f, num5 * 2f, num4, num5), this.listSpawnableObject[8]))
						{
							this.InstantBuild("CORRUGATED_FLOOR");
						}
						if (GUI.Button(new Rect(0f, num5 * 3f, num4, num5), this.listSpawnableObject[9]))
						{
							this.InstantBuild("BRICK_FLOOR");
						}
						if (GUI.Button(new Rect(num4, num5 * 3f, num4, num5), this.listSpawnableObject[10]))
						{
							this.InstantBuild("DRIFTWOOD_WEDGE_FOUNDATION");
						}
						if (GUI.Button(new Rect(num4 * 2f, num5 * 3f, num4, num5), this.listSpawnableObject[11]))
						{
							this.InstantBuild("WOOD_WEDGE_FOUNDATION");
						}
						if (GUI.Button(new Rect(0f, num5 * 4f, num4, num5), this.listSpawnableObject[12]))
						{
							this.InstantBuild("PLANK_WEDGE_FOUNDATION");
						}
						if (GUI.Button(new Rect(num4, num5 * 4f, num4, num5), this.listSpawnableObject[13]))
						{
							this.InstantBuild("CORRUGATED_WEDGE_FOUNDATION");
						}
						if (GUI.Button(new Rect(num4 * 2f, num5 * 4f, num4, num5), this.listSpawnableObject[14]))
						{
							this.InstantBuild("BRICK_WEDGE_FOUNDATION");
						}
						if (GUI.Button(new Rect(0f, num5 * 5f, num4, num5), this.listSpawnableObject[15]))
						{
							this.InstantBuild("DRIFTWOOD_WEDGE_FLOOR");
						}
						if (GUI.Button(new Rect(num4, num5 * 5f, num4, num5), this.listSpawnableObject[16]))
						{
							this.InstantBuild("WOOD_WEDGE_FLOOR");
						}
						if (GUI.Button(new Rect(num4 * 2f, num5 * 5f, num4, num5), this.listSpawnableObject[17]))
						{
							this.InstantBuild("PLANK_WEDGE_FLOOR");
						}
						if (GUI.Button(new Rect(0f, num5 * 6f, num4, num5), this.listSpawnableObject[18]))
						{
							this.InstantBuild("CORRUGATED_WEDGE_FLOOR");
						}
						if (GUI.Button(new Rect(num4, num5 * 6f, num4, num5), this.listSpawnableObject[19]))
						{
							this.InstantBuild("BRICK_WEDGE_FLOOR");
						}
						GUI.EndScrollView();
					}
					if (this.currentSeletectSpawnTab == 1)
					{
						this.spawnmenuTabScrollIndex = GUI.BeginScrollView(new Rect(10f, 50f, (float)num2 - 40f, (float)num3 - 100f), this.spawnmenuTabScrollIndex, new Rect(0f, 0f, (float)num2 - 20f, ((float)num3 - 80f) / 2f * 9f));
						this.InitIcons();
						float num6 = ((float)num2 - 20f) / 3f;
						float num7 = ((float)num3 - 80f) / 2f;
						if (GUI.Button(new Rect(0f, 0f, num6, num7), this.listSpawnableObject[20]))
						{
							this.InstantBuild("DRIFTWOOD_PANEL_STATIC");
						}
						if (GUI.Button(new Rect(num6, 0f, num6, num7), this.listSpawnableObject[21]))
						{
							this.InstantBuild("WOOD_PANEL_STATIC");
						}
						if (GUI.Button(new Rect(num6 * 2f, 0f, num6, num7), this.listSpawnableObject[22]))
						{
							this.InstantBuild("PLANK_PANEL_STATIC");
						}
						if (GUI.Button(new Rect(0f, num7, num6, num7), this.listSpawnableObject[23]))
						{
							this.InstantBuild("CORRUGATED_PANEL_STATIC");
						}
						if (GUI.Button(new Rect(num6, num7, num6, num7), this.listSpawnableObject[24]))
						{
							this.InstantBuild("BRICK_PANEL_STATIC");
						}
						if (GUI.Button(new Rect(num6 * 2f, num7, num6, num7), this.listSpawnableObject[25]))
						{
							this.InstantBuild("DRIFTWOOD_WALL_WINDOW");
						}
						if (GUI.Button(new Rect(0f, num7 * 2f, num6, num7), this.listSpawnableObject[26]))
						{
							this.InstantBuild("WOOD_WALL_WINDOW");
						}
						if (GUI.Button(new Rect(num6, num7 * 2f, num6, num7), this.listSpawnableObject[27]))
						{
							this.InstantBuild("PLANK_WALL_WINDOW");
						}
						if (GUI.Button(new Rect(num6 * 2f, num7 * 2f, num6, num7), this.listSpawnableObject[28]))
						{
							this.InstantBuild("CORRUGATED_WALL_WINDOW");
						}
						if (GUI.Button(new Rect(0f, num7 * 3f, num6, num7), this.listSpawnableObject[29]))
						{
							this.InstantBuild("BRICK_WALL_WINDOW");
						}
						if (GUI.Button(new Rect(num6, num7 * 3f, num6, num7), this.listSpawnableObject[30]))
						{
							this.InstantBuild("DRIFTWOOD_WALL_HALF");
						}
						if (GUI.Button(new Rect(num6 * 2f, num7 * 3f, num6, num7), this.listSpawnableObject[31]))
						{
							this.InstantBuild("WOOD_WALL_HALF");
						}
						if (GUI.Button(new Rect(0f, num7 * 4f, num6, num7), this.listSpawnableObject[32]))
						{
							this.InstantBuild("PLANK_WALL_HALF");
						}
						if (GUI.Button(new Rect(num6, num7 * 4f, num6, num7), this.listSpawnableObject[33]))
						{
							this.InstantBuild("CORRUGATED_WALL_HALF");
						}
						if (GUI.Button(new Rect(num6 * 2f, num7 * 4f, num6, num7), this.listSpawnableObject[34]))
						{
							this.InstantBuild("BRICK_WALL_HALF");
						}
						if (GUI.Button(new Rect(0f, num7 * 5f, num6, num7), this.listSpawnableObject[35]))
						{
							this.InstantBuild("DRIFTWOOD_STEPS");
						}
						if (GUI.Button(new Rect(num6, num7 * 5f, num6, num7), this.listSpawnableObject[36]))
						{
							this.InstantBuild("WOOD_STEPS");
						}
						if (GUI.Button(new Rect(num6 * 2f, num7 * 5f, num6, num7), this.listSpawnableObject[37]))
						{
							this.InstantBuild("PLANK_STEPS");
						}
						if (GUI.Button(new Rect(0f, num7 * 6f, num6, num7), this.listSpawnableObject[38]))
						{
							this.InstantBuild("CORRUGATED_STEPS");
						}
						if (GUI.Button(new Rect(num6, num7 * 6f, num6, num7), this.listSpawnableObject[39]))
						{
							this.InstantBuild("STEEL_STEPS");
						}
						if (GUI.Button(new Rect(num6 * 2f, num7 * 6f, num6, num7), this.listSpawnableObject[40]))
						{
							this.InstantBuild("DRIFTWOOD_ARCH");
						}
						if (GUI.Button(new Rect(0f, num7 * 7f, num6, num7), this.listSpawnableObject[41]))
						{
							this.InstantBuild("WOOD_ARCH");
						}
						if (GUI.Button(new Rect(num6, num7 * 7f, num6, num7), this.listSpawnableObject[42]))
						{
							this.InstantBuild("PLANK_ARCH");
						}
						if (GUI.Button(new Rect(num6 * 2f, num7 * 7f, num6, num7), this.listSpawnableObject[43]))
						{
							this.InstantBuild("CORRUGATED_ARCH");
						}
						if (GUI.Button(new Rect(0f, num7 * 8f, num6, num7), this.listSpawnableObject[44]))
						{
							this.InstantBuild("BRICK_ARCH");
						}
						GUI.EndScrollView();
					}
				}
				if (this.currentSelectedTabIndex == 3)
				{
					GUI.Label(new Rect(10f, 20f, 200f, 20f), "Current View:");
					GUI.DrawTexture(new Rect(10f, 40f, 200f, 200f), this.miniMapCamera);
					this.minimapZoomLevel = GUI.HorizontalSlider(new Rect(220f, 40f, (float)num2 - 10f - 240f, 60f), this.minimapZoomLevel, 5f, 256f);
					GUI.Label(new Rect(420f, 50f, 200f, 20f), "ZoomLevel : " + ((int)this.minimapZoomLevel).ToString());
					this.minimapAlphaLevel = GUI.HorizontalSlider(new Rect(220f, 110f, (float)num2 - 10f - 240f, 60f), this.minimapAlphaLevel, 0f, 255f);
					GUI.Label(new Rect(420f, 120f, 200f, 20f), "Transparency : " + ((int)this.minimapAlphaLevel).ToString());
					this.minimapSize = GUI.HorizontalSlider(new Rect(220f, 180f, (float)num2 - 10f - 240f, 60f), this.minimapSize, 1f, 256f);
					GUI.Label(new Rect(420f, 190f, 200f, 20f), "Minimap Size : " + ((int)this.minimapSize).ToString());
					if (GUI.Button(new Rect(10f, 260f, 200f, 50f), "Minimap Off"))
					{
						this.enableMinimap = false;
					}
					if (GUI.Button(new Rect(10f, 330f, 200f, 50f), "Minimap On"))
					{
						this.enableMinimap = true;
					}
				}
				GUI.EndGroup();
				GUI.EndGroup();
				return;
			}
			this.PauseCamera(false);
		}

		// Token: 0x06003CEA RID: 15594 RVA: 0x0012360C File Offset: 0x0012180C
		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.F7))
			{
				this.toggleCount++;
			}
			if (this.toggleCount > 1)
			{
				this.toggleCount = 0;
			}
			if (this.toggleCount == 1 && this.currentSelectedTabIndex == 0)
			{
				this.SetPlayerHealth(this.player_health);
				this.SetPlayerHunger(this.player_hunger);
				this.SetPlayerThirsty(this.player_thirsty);
				this.SetPlayerSleep(this.player_sleep);
				this.SetPlayerWalkSpeed(this.player_walkSpeed);
				this.SetPlayerRunSpeed(this.player_runSpeed);
			}
			if (this.enable_quicksave && Input.GetKeyDown(KeyCode.H))
			{
				this.GameSave();
			}
			if (this.enable_blockSunburn && !Singleton<Player>.Instance.Statistics.HasStatusEffect(StatusEffect.SUNBLOCK))
			{
				Singleton<Player>.Instance.Statistics.ApplyStatusEffect(StatusEffect.SUNBLOCK);
			}
			if (this.toggleCount == 1 || Singleton<MainMenuPresenter>.Instance._view.Visible || Singleton<CrafterMenuPresenter>.Instance._view.Visible)
			{
				this.ChangeCursorModeToMenuMode();
				return;
			}
			this.ResetCursorMode();
		}

		// Token: 0x06003CEB RID: 15595 RVA: 0x00123720 File Offset: 0x00121920
		public CMenu()
		{
			this.minimapZoomLevel = 15f;
			this.minimapSize = 128f;
			this.miniMapCamera = new RenderTexture(128, 128, 16);
			this.minimapCam = new GameObject();
			this.listSpawnableObject = new List<Texture2D>();
			this.IconButtonResultList = new bool[9];
			this.spawnmenuTabScrollIndex = Vector2.zero;
			this.hScrollThumbTex = CMenu.LoadPNG(Application.dataPath + "/Resources/CMenuHorizontalScroll.png");
			this.vScrollThumbTex = CMenu.LoadPNG(Application.dataPath + "/Resources/CMenuVerticalScroll.png");
			this.weatherIconSunneyTex = CMenu.LoadPNG(Application.dataPath + "/Resources/icon/SunIcon.png");
			this.weatherIconRaineyTex = CMenu.LoadPNG(Application.dataPath + "/Resources/icon/RainyIcon.png");
			this.weatherIconThunderTex = CMenu.LoadPNG(Application.dataPath + "/Resources/icon/StormIcon.png");
			this.player_walkSpeed = 3f;
			this.player_runSpeed = 5f;
			this.player_health = 700f;
			this.player_hunger = 700f;
			this.player_sleep = 700f;
			this.player_thirsty = 700f;
			this.mainTabScrollIndex = Vector2.zero;
			this.mainFrameSkin = CMenu.LoadPNG(Application.dataPath + "/Resources/CMenuFrame.png");
			this.hSliderThumbTex = CMenu.LoadPNG(Application.dataPath + "/Resources/CMenuSliderTracker.png");
			this.hNormalSliderTex = CMenu.LoadPNG(Application.dataPath + "/Resources/CMenuNormalSlider.png");
			this.groupboxTex = CMenu.LoadPNG(Application.dataPath + "/Resources/CMenuGroupBox.png");
			this.tabContainerTex = CMenu.LoadPNG(Application.dataPath + "/Resources/CMenuBox.png");
			this.tabTex = CMenu.LoadPNG(Application.dataPath + "/Resources/CMenuButtonNormal.png");
			this.tabActiveTex = CMenu.LoadPNG(Application.dataPath + "/Resources/CMenuButtonOnActive.png");
		}

		// Token: 0x06003CEC RID: 15596 RVA: 0x00123938 File Offset: 0x00121B38
		public static Texture2D LoadPNG(string filepath)
		{
			Texture2D texture2D = new Texture2D(2, 2);
			if (!File.Exists(filepath))
			{
				return null;
			}
			byte[] data = File.ReadAllBytes(filepath);
			texture2D.LoadImage(data);
			return texture2D;
		}

		// Token: 0x06003CED RID: 15597 RVA: 0x00123968 File Offset: 0x00121B68
		public void Start()
		{
			this.hNormalSliderSkin.normal.background = this.hNormalSliderTex;
			this.hNormalSloderThumbSkin.normal.background = this.hSliderThumbTex;
			this.hNormalSloderThumbSkin.fixedWidth = 40f;
			this.hNormalSloderThumbSkin.fixedHeight = 40f;
			this.backup_mouseVisiblity = Cursor.visible;
			this.backup_mouseLockMode = Cursor.lockState;
		}

		// Token: 0x06003CEE RID: 15598 RVA: 0x0001767A File Offset: 0x0001587A
		public void PauseCamera(bool isPause)
		{
			Singleton<PlayerCamera>.Instance.MouseLook.enabled = !isPause;
		}

		// Token: 0x06003CEF RID: 15599 RVA: 0x001239D8 File Offset: 0x00121BD8
		public void Awake()
		{
			this.arrowPlane = UnityEngine.Object.Instantiate<GameObject>(AssetBundle.LoadFromFile(Application.dataPath + "/Resources/cmenudb.ins").LoadAsset<GameObject>("ARROW"));
			if (this.arrowPlane == null)
			{
				Debug.Log("Cannot Load 'cmenudb.ins' !");
			}
			this.minimapCam.AddComponent<Camera>();
		}

		// Token: 0x06003CF0 RID: 15600 RVA: 0x0001768F File Offset: 0x0001588F
		public void ChangeCursorModeToMenuMode()
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
		}

		// Token: 0x06003CF1 RID: 15601 RVA: 0x0001769D File Offset: 0x0001589D
		public void ResetCursorMode()
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Confined;
		}

		// Token: 0x06003CF2 RID: 15602 RVA: 0x000176AB File Offset: 0x000158AB
		public void SetPrivateField(object obj, string fieldname, object value)
		{
			obj.GetType().GetField(fieldname, BindingFlags.Instance | BindingFlags.NonPublic).SetValue(obj, value);
		}

		// Token: 0x06003CF3 RID: 15603 RVA: 0x000176C2 File Offset: 0x000158C2
		public void SetPlayerHealth(float health)
		{
			this.SetPrivateField(Singleton<Player>.Instance.Statistics, "_health", health);
		}

		// Token: 0x06003CF4 RID: 15604 RVA: 0x000176DF File Offset: 0x000158DF
		public void SetPlayerHunger(float hunger)
		{
			this.SetPrivateField(Singleton<Player>.Instance.Statistics, "_calories", hunger);
		}

		// Token: 0x06003CF5 RID: 15605 RVA: 0x000176FC File Offset: 0x000158FC
		public void SetPlayerThirsty(float thirsty)
		{
			this.SetPrivateField(Singleton<Player>.Instance.Statistics, "_fluids", thirsty);
		}

		// Token: 0x06003CF6 RID: 15606 RVA: 0x00017719 File Offset: 0x00015919
		public void SetPlayerSleep(float sleep)
		{
			Singleton<Player>.Instance.Statistics._sleep = sleep;
		}

		// Token: 0x06003CF7 RID: 15607 RVA: 0x0001772B File Offset: 0x0001592B
		public void GameSave()
		{
			SaveManager.Save(delegate
			{
				Singleton<NotificationSystem>.Instance.KillCurrentNotification();
				Singleton<NotificationSystem>.Instance.NewNotification("Game saved.", 2f);
			});
		}

		// Token: 0x06003CF8 RID: 15608 RVA: 0x000023F4 File Offset: 0x000005F4
		public void FixedUpdate()
		{
		}

		// Token: 0x06003CF9 RID: 15609 RVA: 0x00017751 File Offset: 0x00015951
		public void SetPlayerWalkSpeed(float speed)
		{
			this.SetPrivateField(Singleton<Player>.Instance.Movement, "walkSpeed", speed);
		}

		// Token: 0x06003CFA RID: 15610 RVA: 0x0001776E File Offset: 0x0001596E
		public void SetPlayerRunSpeed(float speed)
		{
			this.SetPrivateField(Singleton<Player>.Instance.Movement, "runSpeed", speed);
		}

		// Token: 0x06003CFB RID: 15611 RVA: 0x00123A34 File Offset: 0x00121C34
		public void SetCurrentWorldWeather(int weather_type)
		{
			AtmosphereStorm instance = Singleton<AtmosphereStorm>.Instance;
			if (instance == null)
			{
				return;
			}
			if (weather_type == 0)
			{
				instance.ClearWeatherEvent();
				Shader.SetGlobalFloat("_AfsRainamount", 0f);
				Shader.SetGlobalFloat("_AfsSpecPower", 1f);
				return;
			}
			if (weather_type == 1)
			{
				instance.WeatherEvents[0].StartTime = Singleton<GameTime>.Instance.MilitaryTime;
				instance.WeatherEvents[0].StartEvent();
				return;
			}
			if (weather_type == 2)
			{
				instance.WeatherEvents[2].StartTime = Singleton<GameTime>.Instance.MilitaryTime;
				instance.WeatherEvents[2].StartEvent();
				return;
			}
		}

		// Token: 0x06003CFC RID: 15612 RVA: 0x0001778B File Offset: 0x0001598B
		public Texture2D SpriteToTexture2D(Sprite sprite)
		{
			return sprite.texture;
		}

		// Token: 0x06003CFD RID: 15613 RVA: 0x00123ADC File Offset: 0x00121CDC
		public void InitIcons()
		{
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Driftwood, InteractiveType.BUILDING_FOUNDATION).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Wood, InteractiveType.BUILDING_FOUNDATION).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Plank, InteractiveType.BUILDING_FOUNDATION).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Corrugated, InteractiveType.BUILDING_FOUNDATION).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Steel, InteractiveType.BUILDING_FOUNDATION).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Driftwood, InteractiveType.BUILDING_FLOOR).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Wood, InteractiveType.BUILDING_FLOOR).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Plank, InteractiveType.BUILDING_FLOOR).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Corrugated, InteractiveType.BUILDING_FLOOR).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Steel, InteractiveType.BUILDING_FLOOR).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Driftwood, InteractiveType.BUILDING_FOUNDATION_WEDGE).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Wood, InteractiveType.BUILDING_FOUNDATION_WEDGE).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Plank, InteractiveType.BUILDING_FOUNDATION_WEDGE).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Corrugated, InteractiveType.BUILDING_FOUNDATION_WEDGE).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Steel, InteractiveType.BUILDING_FOUNDATION_WEDGE).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Driftwood, InteractiveType.BUILDING_FLOOR_WEDGE).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Wood, InteractiveType.BUILDING_FLOOR_WEDGE).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Plank, InteractiveType.BUILDING_FLOOR_WEDGE).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Corrugated, InteractiveType.BUILDING_FLOOR_WEDGE).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Steel, InteractiveType.BUILDING_FLOOR_WEDGE).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Driftwood, InteractiveType.BUILDING_WALL).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Wood, InteractiveType.BUILDING_WALL).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Plank, InteractiveType.BUILDING_WALL).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Corrugated, InteractiveType.BUILDING_WALL).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Steel, InteractiveType.BUILDING_WALL).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Driftwood, InteractiveType.BUILDING_WALL_WINDOW).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Wood, InteractiveType.BUILDING_WALL_WINDOW).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Plank, InteractiveType.BUILDING_WALL_WINDOW).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Corrugated, InteractiveType.BUILDING_WALL_WINDOW).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Steel, InteractiveType.BUILDING_WALL_WINDOW).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Driftwood, InteractiveType.BUILDING_WALL_HALF).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Wood, InteractiveType.BUILDING_WALL_HALF).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Plank, InteractiveType.BUILDING_WALL_HALF).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Corrugated, InteractiveType.BUILDING_WALL_HALF).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Steel, InteractiveType.BUILDING_WALL_HALF).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Driftwood, InteractiveType.BUILDING_STEPS).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Wood, InteractiveType.BUILDING_STEPS).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Plank, InteractiveType.BUILDING_STEPS).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Corrugated, InteractiveType.BUILDING_STEPS).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Steel, InteractiveType.BUILDING_STEPS).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Driftwood, InteractiveType.BUILDING_ARCH).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Wood, InteractiveType.BUILDING_ARCH).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Plank, InteractiveType.BUILDING_ARCH).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Corrugated, InteractiveType.BUILDING_ARCH).texture);
			this.listSpawnableObject.Add(Icons.GetSmallIcon(AttributeType.Steel, InteractiveType.BUILDING_ARCH).texture);
		}

		// Token: 0x06003CFE RID: 15614 RVA: 0x00123F24 File Offset: 0x00122124
		public void InstantBuild(string prefab)
		{
			ICraftable craftable = UnityEngine.Object.Instantiate<BaseObject>(Resources.Load<BaseObject>("Prefabs/StrandedObjects/Building/" + prefab)) as ICraftable;
			if (this.complatedConstruct)
			{
				(craftable as BaseObject).HealthPoints = 6000f;
				(craftable as BaseObject).OriginalHealthPoints = 6000f;
				Singleton<Player>.Instance.Crafter.State = CrafterState.BUILDING;
				((craftable as BaseObject) as IConstructable).CheckHealth();
			}
			else
			{
				(craftable as BaseObject).HealthPoints = 1f;
				(craftable as BaseObject).OriginalHealthPoints = 1f;
				Singleton<Player>.Instance.Crafter.State = CrafterState.CRAFTING;
				((craftable as BaseObject) as IConstructable).CheckHealth();
			}
			base.StartCoroutine(Singleton<Player>.Instance.Crafter.PlaceCraftable_Sequence(craftable, null));
		}

		// Token: 0x06003CFF RID: 15615 RVA: 0x00123FF0 File Offset: 0x001221F0
		public void ShowMinimap(bool active)
		{
			Vector3 position = Singleton<Player>.Instance.transform.position;
			position.y = this.minimapZoomLevel;
			Singleton<PlayerCamera>.Instance.Camera.cullingMask = -1;
			if (active)
			{
				this.minimapCam.GetComponent<Camera>().targetTexture = this.miniMapCamera;
				this.minimapCam.GetComponent<Camera>().backgroundColor = Color.gray;
				this.minimapCam.GetComponent<Camera>().transform.position = position;
				this.minimapCam.GetComponent<Camera>().transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
				Color color = GUI.color;
				GUI.color = new Color(color.r, color.g, color.b, this.minimapAlphaLevel / 255f);
				GUI.DrawTexture(new Rect(10f, 10f, this.minimapSize, this.minimapSize), this.miniMapCamera);
				GUI.color = color;
			}
		}

		// Token: 0x06003D00 RID: 15616 RVA: 0x00017793 File Offset: 0x00015993
		public Sprite Texture2DTOSprite(Texture2D tex)
		{
			return Sprite.Create(tex, new Rect(0f, 0f, (float)tex.width, (float)tex.height), new Vector2(0.5f, 0.5f));
		}

		// Token: 0x04002B59 RID: 11097
		public Texture2D mainFrameSkin;

		// Token: 0x04002B5A RID: 11098
		public int toggleCount;

		// Token: 0x04002B5B RID: 11099
		public Texture2D hSliderThumbTex;

		// Token: 0x04002B5C RID: 11100
		public Texture2D hNormalSliderTex;

		// Token: 0x04002B5D RID: 11101
		public Texture2D groupboxTex;

		// Token: 0x04002B5E RID: 11102
		public GUIStyle hNormalSliderSkin;

		// Token: 0x04002B5F RID: 11103
		public GUIStyle hNormalSloderThumbSkin;

		// Token: 0x04002B60 RID: 11104
		public Texture2D tabContainerTex;

		// Token: 0x04002B61 RID: 11105
		public UnityEngine.Object[] obj;

		// Token: 0x04002B62 RID: 11106
		public Texture2D tabTex;

		// Token: 0x04002B63 RID: 11107
		public GUIContent tabSkin;

		// Token: 0x04002B64 RID: 11108
		public Texture2D tabActiveTex;

		// Token: 0x04002B65 RID: 11109
		public bool backup_mouseVisiblity;

		// Token: 0x04002B66 RID: 11110
		public CursorLockMode backup_mouseLockMode;

		// Token: 0x04002B67 RID: 11111
		public int currentSelectedTabIndex;

		// Token: 0x04002B68 RID: 11112
		public Vector2 mainTabScrollIndex;

		// Token: 0x04002B69 RID: 11113
		public float player_health;

		// Token: 0x04002B6A RID: 11114
		public float player_hunger;

		// Token: 0x04002B6B RID: 11115
		public float player_sleep;

		// Token: 0x04002B6C RID: 11116
		public float player_thirsty;

		// Token: 0x04002B6D RID: 11117
		public bool enable_quicksave;

		// Token: 0x04002B6E RID: 11118
		public bool enable_blockSunburn;

		// Token: 0x04002B6F RID: 11119
		public bool enable_noTakenPosion;

		// Token: 0x04002B70 RID: 11120
		public float currentGameTime;

		// Token: 0x04002B71 RID: 11121
		public float player_walkSpeed;

		// Token: 0x04002B72 RID: 11122
		public float player_runSpeed;

		// Token: 0x04002B73 RID: 11123
		public Texture2D hScrollThumbTex;

		// Token: 0x04002B74 RID: 11124
		public Texture2D vScrollThumbTex;

		// Token: 0x04002B75 RID: 11125
		public Texture2D weatherIconSunneyTex;

		// Token: 0x04002B76 RID: 11126
		public Texture2D weatherIconRaineyTex;

		// Token: 0x04002B77 RID: 11127
		public Texture2D weatherIconThunderTex;

		// Token: 0x04002B78 RID: 11128
		public const int WEATHER_TYPE_SUNNEY = 0;

		// Token: 0x04002B79 RID: 11129
		public const int WEATHER_TYPE_RAINEY = 1;

		// Token: 0x04002B7A RID: 11130
		public const int WEATHER_TYPE_THUNDER = 2;

		// Token: 0x04002B7B RID: 11131
		public Vector2 spawnmenuTabScrollIndex;

		// Token: 0x04002B7C RID: 11132
		public bool[] IconButtonResultList;

		// Token: 0x04002B7D RID: 11133
		public List<Texture2D> listSpawnableObject;

		// Token: 0x04002B7E RID: 11134
		public int currentSeletectSpawnTab;

		// Token: 0x04002B7F RID: 11135
		public bool complatedConstruct;

		// Token: 0x04002B80 RID: 11136
		public RenderTexture miniMapCamera;

		// Token: 0x04002B81 RID: 11137
		public GameObject minimapCam;

		// Token: 0x04002B82 RID: 11138
		public float minimapZoomLevel;

		// Token: 0x04002B83 RID: 11139
		public float minimapSize;

		// Token: 0x04002B84 RID: 11140
		public bool enableMinimap;

		// Token: 0x04002B85 RID: 11141
		public float minimapAlphaLevel = 255f;

		// Token: 0x04002B86 RID: 11142
		public Texture2D arrowTex = CMenu.LoadPNG(Application.dataPath + "/Resources/icon/arrow.png");

		// Token: 0x04002B87 RID: 11143
		public GameObject arrowPlane;
	}
}
