﻿using AutoFixture;
using DotNetty.Buffers;
using System.Text;
using Turbo.Core.Packets.Messages;
using Turbo.Packets.Incoming;
using Turbo.Packets.Incoming.Handshake;
using TurboDefaultRevisionPlugin.Parsers.Handshake;
using Xunit;

namespace Turbo.Packets.Tests.Parsers.Handshake
{
    public class ClientHelloParserTests
    {
        private readonly IFixture _fixture;
        private readonly IParser _sut;

        public ClientHelloParserTests()
        {
            _fixture = new Fixture();
            _sut = new ClientHelloParser();
        }

        [Fact]
        private void Parse_WithClientPacket_ReturnsClientHelloMessage()
        {
            // Arrange
            var packetHeader = _fixture.Create<int>();
            var production = _fixture.Create<string>();
            var platform = _fixture.Create<string>();
            var clientPlatform = _fixture.Create<int>();
            var deviceCategory = _fixture.Create<int>();

            IByteBuffer buffer = Unpooled.Buffer();
            var encoding = Encoding.UTF8;

            buffer.WriteShort(encoding.GetByteCount(production));
            buffer.WriteString(production, encoding);
            buffer.WriteShort(encoding.GetByteCount(platform));
            buffer.WriteString(platform, encoding);
            buffer.WriteInt(clientPlatform);
            buffer.WriteInt(deviceCategory);

            var packet = new ClientPacket(packetHeader, buffer);

            // Act
            var result = (ClientHelloMessage) _sut.Parse(packet);

            // Assert
            Assert.Equal(production, result.Production);
            Assert.Equal(platform, result.Platform);
            Assert.Equal(clientPlatform, result.ClientPlatform);
            Assert.Equal(deviceCategory, result.DeviceCategory);
        }
    }
}