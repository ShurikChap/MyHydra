using Hazel;

namespace HydraMenu.anticheat.rpc
{
	internal class ExitVent : RpcCheck
	{
		// Sending ExitVent RPCs can be used to make the player teleport to areas without having to send SnapTo RPCs
		public override void Validate(PlayerControl player, MessageReader reader, ref bool blockRpc)
		{
			if(ShipStatus.Instance == null)
			{
				Anticheat.Flag(player, $"{player.Data.PlayerName} tried to exit a vent when there is no instance of ShipStatus.");
				blockRpc = true;
			}

			if(!player.Data.IsDead && !player.Data.Role.CanVent)
			{
				Anticheat.Flag(player, $"{player.Data.PlayerName} tried to exit a vent when their role ({player.Data.RoleType}) does not support venting.");
				blockRpc = true;
			}
		}

		public override RpcCalls GetRpcCall()
		{
			return RpcCalls.ExitVent;
		}
	}
}