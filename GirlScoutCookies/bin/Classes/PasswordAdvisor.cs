/*
    PasswordAdvisor.cs
    Developer:  Steven Murray   Date:  12-November-2017
    Purpose:    Determines strength of entered password
    Status:     Complete

    Revision History
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GirlScoutCookies.Classes
{
    public enum PasswordScore
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 5
    }

    public class PasswordAdvisor
    {
        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;
            int len = password.Length;

            if (len == 0)
                return PasswordScore.Blank;

            if (Regex.IsMatch(password, @"[\d]", RegexOptions.ECMAScript))
                score += 10;

            if (Regex.IsMatch(password, @"[a-z]", RegexOptions.ECMAScript))
                score += 26;
            if (Regex.IsMatch(password, @"[A-Z]", RegexOptions.ECMAScript))
                score += 26;

            if (Regex.IsMatch(password, @"[~`!@#$%\^\&\*\(\)\-_\+=\[\{\]\}\|\\;:'\""<\,>\.\?\/]", RegexOptions.ECMAScript) && len > 8)
                score += 33;

            int H = Convert.ToInt32(len * (Math.Round(Math.Log(score) / Math.Log(2))));

            if (H <= 32) return PasswordScore.VeryWeak;
            if (H <= 48) return PasswordScore.Weak;
            if (H <= 64) return PasswordScore.Medium;
            if (H <= 80) return PasswordScore.Strong;
            return PasswordScore.VeryStrong;
        }
    }
}
