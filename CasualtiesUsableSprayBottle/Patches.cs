using HarmonyLib;

namespace CasualtiesUsableSprayBottle;

[HarmonyPatch(typeof(Item), nameof(Item.SetupItems))]
internal class MakeTheSprayBottleUsablePatch
{
	private static void Postfix()
	{
		var sprayBottle = Item.GlobalItems["spraybottle"];
		sprayBottle.usable = true;
		sprayBottle.useAction = (body, item) => item.GetComponent<WaterContainerItem>().Drink(body, 10f, "spray");
	}
}
