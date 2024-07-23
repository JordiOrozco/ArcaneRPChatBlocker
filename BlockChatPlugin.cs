using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace BlockChatPlugin
{
    public class BlockChatPlugin : RocketPlugin
    {
        protected override void Load()
        {
            Rocket.Core.Logging.Logger.Log("ArcaneRPChatBlocker has been loaded!");
            ChatManager.onChatted += OnChatted;
        }

        protected override void Unload()
        {
            Rocket.Core.Logging.Logger.Log("ArcaneRPChatBlocker has been unloaded!");
            ChatManager.onChatted -= OnChatted;
        }

        private void OnChatted(SteamPlayer steamPlayer, EChatMode mode, ref Color color, ref bool isRich, string message, ref bool isVisible)
        {
            UnturnedPlayer player = UnturnedPlayer.FromSteamPlayer(steamPlayer);
            if (mode == EChatMode.GLOBAL && !message.StartsWith("/"))
            {
                UnturnedChat.Say(player, "El chat general está bloqueado. Solo se permiten comandos.", Color.red);
                isVisible = false; // Bloquea el mensaje de chat
            }
        }
    }
}
