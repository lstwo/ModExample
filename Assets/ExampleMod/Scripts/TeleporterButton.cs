using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterButton : MonoBehaviour
{
    public ModPlayerCharacterSpawnPoint teleportPosition;
    private ModTouchButton button;

    void Awake()
    {
        button = GetComponent<ModTouchButton>();
        button.isAllowedToPress += Teleport;
    }

    bool Teleport(ModTouchButton touchButton, ModPlayerCharacter character, ModRagdollHandJoint handJoint)
    {
        if (touchButton != null && button != null && touchButton == button)
        {
            ModdedGameMode.Instance.SetPlayerSpawnpoint(character.GetPlayerController(), teleportPosition);
            character.Kill();
        }

        return true;
    }
}
