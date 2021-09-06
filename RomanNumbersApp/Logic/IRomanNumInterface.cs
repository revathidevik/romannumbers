using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumbersApp.Logic
{
    public interface IRomanNumInterface
    {
        int RomanToInt(string roman);
        string RomanNumeralFrom(int number);
    }
}
