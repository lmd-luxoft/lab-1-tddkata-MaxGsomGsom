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

            // Set default dividers
            var dividers = new[] {',', '\n'};

            // Extract divider from input if possible
            if (v.Length >= 4 && v.Substring(0, 2) == "//")
            {
                if (v[3] != '\n')
                    return -1;

                dividers = new[] {v[2]};

                // Divider should not be digit
                if (dividers[0] >= '0' && dividers[0] <= '9')
                    return -1;

                v = v.Substring(4);
            }

            // Split input and sum every part if possible
            var parts = v.Split(dividers);

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