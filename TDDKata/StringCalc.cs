// Copyright 2021 Russian Post
// This source code is Russian Post Confidential Proprietary.
// This software is protected by copyright. All rights and titles are reserved.
// You shall not use, copy, distribute, modify, decompile, disassemble or reverse engineer the software.
// Otherwise this violation would be treated by law and would be subject to legal prosecution.
// Legal use of the software provides receipt of a license from the right holder only.

// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

namespace TDDKata
{
    internal class StringCalc
    {
        internal int Sum(string v)
        {
            if (v == null)
                return -1;

            var parts = v.Split(',');
            if (parts.Length > 2)
                return -1;

            int sum = 0;
            foreach (var part in parts)
            {
                if (string.IsNullOrWhiteSpace(part))
                    continue;
                if (int.TryParse(part, out int parsed) && parsed >= 0)
                    sum += parsed;
                else return -1;
            }

            return sum;
        }
    }
}