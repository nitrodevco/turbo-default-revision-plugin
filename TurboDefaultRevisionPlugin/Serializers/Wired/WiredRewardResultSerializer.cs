using System.Collections.Generic;
using Turbo.Packets.Serializers;
using Turbo.Core.Packets.Messages;
using Turbo.Packets.Outgoing.Wired;
using Turbo.Core.Game.Rooms.Object.Logic.Wired.Data;

namespace TurboDefaultRevisionPlugin.Serializers.Wired
{
    public class WiredRewardResultSerializer : AbstractSerializer<WiredRewardResultMessage>
    {
        public WiredRewardResultSerializer(int header) : base(header) { }

        protected override void Serialize(IServerPacket packet, WiredRewardResultMessage message)
        {
            packet.WriteInteger(message.Reason);
        }
    }
}