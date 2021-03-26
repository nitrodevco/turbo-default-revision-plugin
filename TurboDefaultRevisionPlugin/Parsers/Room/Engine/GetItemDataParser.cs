﻿using Turbo.Core.Packets.Messages;
using Turbo.Packets.Incoming.Room.Engine;
using Turbo.Packets.Parsers;

namespace TurboDefaultRevisionPlugin.Parsers.Room.Engine
{
    public class GetItemDataParser : AbstractParser<GetItemDataMessage>
    {
        public override IMessageEvent Parse(IClientPacket packet) => new GetItemDataMessage 
        { 
            ObjectId = packet.PopInt() 
        };
    }
}