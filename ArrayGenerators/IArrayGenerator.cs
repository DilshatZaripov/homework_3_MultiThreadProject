using System;
using System.Collections.Generic;
using System.Text;

namespace homework_3_MultiThreadProject.ArrayGenerators
{
    internal interface IArrayGenerator
    {
        int[] Generate(int arraySize);
    }
}
