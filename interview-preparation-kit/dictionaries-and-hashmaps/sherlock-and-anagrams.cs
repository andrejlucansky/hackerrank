using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the sherlockAndAnagrams function below.
    static int sherlockAndAnagrams(string s) {
        var substrings = new Dictionary<string, int>();
        var anagrams = 0;

        for(var start = 0; start < s.Length; start++){
            for(var length = 1; length <= s.Length - start; length++){
                var characters = s.Substring(start,length).ToArray();
                Array.Sort(characters);
                var substring = new String(characters);
                if(!substrings.ContainsKey(substring)){
                    substrings.Add(substring, 1);
                }else{
                    anagrams += substrings[substring];
                    substrings[substring]++;
                }
            }
        }

        return anagrams;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string s = Console.ReadLine();

            int result = sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
