using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace CasualtiesUsableSprayBottle;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
	public const string ModGuid = MyPluginInfo.PLUGIN_GUID;
	public const string ModName = MyPluginInfo.PLUGIN_NAME;
	public const string ModVersion = MyPluginInfo.PLUGIN_VERSION;

	internal static new ManualLogSource Logger;
	private readonly Harmony _harmony = new(ModGuid);
	public static Plugin Instance { get; private set; } = null!;

	public void Awake()
	{
		Logger = base.Logger;
		Instance = this;

		_harmony.PatchAll();
		Logger.LogInfo($"Plugin {ModName} is loaded!");
	}

	public void OnDestroy()
	{
		_harmony?.UnpatchSelf();
		Instance = null;
	}
}
