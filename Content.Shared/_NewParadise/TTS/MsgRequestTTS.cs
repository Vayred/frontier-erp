﻿using Lidgren.Network;
using Robust.Shared.Network;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Shared._NewParadise.TTS;

// ReSharper disable once InconsistentNaming
public sealed class MsgRequestTTS : NetMessage
{
    public override MsgGroups MsgGroup => MsgGroups.Command;

    public NetEntity Uid { get; set; } = NetEntity.Invalid;
    public string Text { get; set; } = string.Empty;
    public ProtoId<TTSVoicePrototype> VoiceId { get; set; } = string.Empty;
    public bool IsWhisper = false;

    public override void ReadFromBuffer(NetIncomingMessage buffer, IRobustSerializer serializer)
    {
        IsWhisper = buffer.ReadBoolean();
        Uid = new NetEntity(buffer.ReadInt32());
        Text = buffer.ReadString();
        VoiceId = buffer.ReadString();
    }

    public override void WriteToBuffer(NetOutgoingMessage buffer, IRobustSerializer serializer)
    {
        buffer.Write(IsWhisper);
        buffer.Write((int)Uid);
        buffer.Write(Text);
        buffer.Write(VoiceId);
    }
}
