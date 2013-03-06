using System;
using System.Text;
using System.Collections.Generic;

public static class ExtensionSubstring
{
    public static StringBuilder SubStringBuilder(this StringBuilder sb, int start, int length)
    {
        StringBuilder resultSB = new StringBuilder(length);
        for (int index = start; index < start + length; index++)
        {
            resultSB.Append(sb[index]);
        }
        return resultSB;        
    }
}