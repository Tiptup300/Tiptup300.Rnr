﻿using System.Collections.Immutable;

namespace Tiptup300.Rnr;

public record struct RunScriptCommand
{
   public string ScriptTag { get; init; }
   public ScriptArgs ScriptArgs { get; init; }
   public ImmutableArray<Arg> RnrArgs { get; init; }
}
