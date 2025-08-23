using HarmonyLib;

[HarmonyPatch]
public class MissionModifierPatch
{
    [HarmonyPatch(typeof(Mission), "GetMissionData")]
    [HarmonyPostfix]
    static void Postfix()
    {
        // Hook once during mission generation
        Mission.ModifyModifierCount = (Mission mission, MissionContainer container, int seed, ref int count) =>
        {
            int forcedCount = Random.Range(3, 9);

            // Optionally mix with the game's roll:
            count = Mathf.Max(count, forcedCount);
        };
    }
}
