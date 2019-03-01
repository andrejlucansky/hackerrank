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

    // Complete the arrayManipulation function below.
    static long arrayManipulation(int n, int[][] queries) {
        fastArrayManipulation(n, queries);
        // slowArrayManipulation(n, queries);
    }

    static long fastArrayManipulation(int n, int[][] queries) {
            var diff = new long[n+1];

            foreach(var query in queries){
                diff[query[0] -1] += query[2];  
                diff[query[1]] -= query[2];
            }

            var maximum = diff[0];

            for(var i = 1; i <= n; i++){
                diff[i] = diff[i] + diff[i-1];
                if(maximum < diff[i]){
                    maximum = diff[i];
                }
            }

            return maximum;
    }

    static long slowArrayManipulation(int n, int[][] queries){
        var array = new long[n];

        foreach(var query in queries){
            for(var i = query[0] - 1; i < query[1]; i++){
                array[i] += query[2]; 
            }
        }

        return array.Max();
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] queries = new int[m][];

        for (int i = 0; i < m; i++) {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        long result = arrayManipulation(n, queries);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
