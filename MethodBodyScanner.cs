using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;

public class MethodBodyScanner
{
    private readonly MethodBody _methodBody;

    public MethodBodyScanner(MethodBody methodBody)
    {
        _methodBody = methodBody;
    }

    public MethodBodyScannerResult Scan(InstructionPattern pattern)
    {
        MethodBodyScannerResult result = new MethodBodyScannerResult();

        foreach (Instruction instruction in _methodBody.Instructions)
        {
            if (pattern.Matches(InstructionSequence(instruction)))
            {
                result.Match = instruction;
                result.MatchInstructions = InstructionSequence(instruction);
                result.Success = true;
                break;
            }
        }

        return result;
    }

    private IEnumerable<Instruction> InstructionSequence(Instruction start)
    {
        yield return start;

        Instruction current = start.Next;

        while (current != null)
        {
            yield return current;
            current = current.Next;
        }
    }
}
