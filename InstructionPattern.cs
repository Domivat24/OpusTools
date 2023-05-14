using System.Collections.Generic;
using Mono.Cecil.Cil;

public class InstructionPattern
{
    private readonly OpCode[] _opCodes;

    public InstructionPattern(params OpCode[] opCodes)
    {
        _opCodes = opCodes;
    }

    public bool Matches(IEnumerable<Instruction> instructions)
    {
        IEnumerator<Instruction> enumerator = instructions.GetEnumerator();

        foreach (OpCode opCode in _opCodes)
        {
            if (!enumerator.MoveNext())
            {
                return false;
            }

            if (enumerator.Current.OpCode != opCode)
            {
                return false;
            }
        }

        return !enumerator.MoveNext();
    }
}
