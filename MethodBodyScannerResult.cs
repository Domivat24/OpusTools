using System.Collections.Generic;
using Mono.Cecil.Cil;

public class MethodBodyScannerResult
{
    public bool Success { get; set; }
    public Instruction Match { get; set; }
    public IEnumerable<Instruction> MatchInstructions { get; set; }

    public MethodBodyScannerResult()
    {
        Success = false;
        Match = null;
        MatchInstructions = new List<Instruction>();
    }
}
