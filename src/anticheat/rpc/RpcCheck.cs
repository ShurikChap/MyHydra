using Hazel;
using System;

namespace HydraMenu.anticheat.rpc
{
	internal class RpcCheck
	{
		public virtual bool Enabled { get; set; } = true;

		public virtual void Validate(PlayerControl player, MessageReader reader, ref bool blockRpc) { }

		public virtual RpcCalls GetRpcCall() {
			throw new InvalidOperationException("Unimplemented");
		}

		public virtual bool IsHostOnly()
		{
			return false;
		}
	}
}