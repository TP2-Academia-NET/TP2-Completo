﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Util
{
    public class Validaciones
    {
        static public bool IsEmpty(string param)
        {
            bool empty = false;
            if (param == string.Empty) { empty = true; return empty; }
            else { return empty; }
        }
        
        static public bool MinChar(string param, int min)
        {
            bool minChar = true;
            if (param.Length >= min) { minChar = false; return minChar; }
            else { return minChar; }
        }
        
        static public bool IsEmail(string param)
        {            
            bool isEmail = Regex.IsMatch(param, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }
        
        static public bool Coinciden(string pass1, string pass2)
        {
            bool coinciden = false;
            if (pass1.Equals(pass2)) { coinciden = true; return coinciden; }
            else { return false; }
        }

        static public bool ComparaString(string s1, string s2)
        {
            return string.Equals(s1,s2, StringComparison.OrdinalIgnoreCase);
        } 
    }
}
