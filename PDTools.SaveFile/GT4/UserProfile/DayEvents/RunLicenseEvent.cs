﻿using System;
using System.Collections.Generic;
using System.Text;
using Syroot.BinaryData.Memory;

using PDTools.Structures;
using PDTools.Enums.PS2;

namespace PDTools.SaveFile.GT4.UserProfile.DayEvents;

public class RunLicenseEvent : IDayEvent
{
    public DayEventType EventType => DayEventType.RUN_LICENSE;

    public Result Result { get; set; }
    public byte Unk14 { get; set; }
    public byte Unk { get; set; }
    public int BestTime { get; set; }
    public DbCode RaceCode { get; set; }

    public void CopyTo(IDayEvent dest)
    {
        ((RunLicenseEvent)dest).Result = Result;
        ((RunLicenseEvent)dest).Unk14 = Unk14;
        ((RunLicenseEvent)dest).Unk = Unk;
        ((RunLicenseEvent)dest).BestTime = BestTime;
        ((RunLicenseEvent)dest).RaceCode = new DbCode(RaceCode.Code, RaceCode.TableId);
    }

    public void Pack(GT4Save save, ref SpanWriter sw)
    {
        sw.WriteByte((byte)Result);
        sw.WriteByte(Unk14);
        sw.WriteByte(Unk);
        sw.WriteInt32(BestTime);
        sw.WriteInt32(RaceCode.Code);
        sw.WriteInt32(RaceCode.TableId);
    }

    public void Unpack(GT4Save save, ref SpanReader sr)
    {
        Result = (Result)sr.ReadByte();
        Unk14 = sr.ReadByte();
        sr.ReadByte();
        BestTime = sr.ReadInt32();
        RaceCode = new DbCode(sr.ReadInt32(), sr.ReadInt32());
    }
}
