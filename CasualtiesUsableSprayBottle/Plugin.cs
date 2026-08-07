using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace CasualtiesUsableSprayBottle;

[BepInPlugin(ModGUID, ModName, ModVersion)]
public class Plugin : BaseUnityPlugin
{
	public const string ModGUID = "vee.usable.spray.bottle";
	public const string ModName = "CasualtiesUsableSprayBottle";
	public const string ModVersion = "1.0.0";

	internal static new ManualLogSource Logger;
	private readonly Harmony _harmony = new(ModGUID);
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

