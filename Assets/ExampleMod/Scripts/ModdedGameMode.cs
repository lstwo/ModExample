using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModdedGameMode : ModFreemodeGamemode
{
    private List<ModPlayerController> playerControllers = new List<ModPlayerController>();
    private List<ModPlayerCharacterSpawnPoint> spawnPoints = new List<ModPlayerCharacterSpawnPoint>();

    private static ModdedGameMode _instance;

    public static ModdedGameMode Instance
    {
        get { return _instance; }
    }

    protected override void ModAwake()
    {
        _instance = this;
        base.ModAwake();
    }

    protected override void OnSpawnedPlayerController(ModPlayerController playerController)
    {
        base.OnSpawnedPlayerController(playerController);
    }

    public override ModPlayerCharacterSpawnPoint GetPlayerSpawnPoint(ModPlayerController playerController)
    {
        if (playerControllers.Contains(playerController))
            return spawnPoints[playerControllers.IndexOf(playerController)];
        else
            return base.GetPlayerSpawnPoint(playerController);
    }

    public void SetPlayerSpawnpoint(ModPlayerController controller, ModPlayerCharacterSpawnPoint spawnPoint)
    {
        if (playerControllers.Contains(controller))
            spawnPoints[playerControllers.IndexOf(controller)] = spawnPoint;
        else
        {
            playerControllers.Add(controller);
            spawnPoints.Add(spawnPoint);
        }
    }
}
