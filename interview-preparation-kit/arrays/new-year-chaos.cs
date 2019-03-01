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

    static void minimumBribes(int[] q) {
        forMinimumBribes(q);
        // whileMinimumBribes(q);
        // slowMinimumBribes(q);
    }

    // Complete the minimumBribes function below.
    static void forMinimumBribes(int[] q) {
        var bribes = 0;

        // reduce values by 1 to align with indices
        for (var i = 0; i < q.Length; i++){
            q[i] -=1; 
        }

        // start from the last element and move to the beginning
        for(var i = q.Length - 1; i >= 0; i--){
            if(q[i] - i > 2){
                Console.WriteLine("Too chaotic");
                return;
            }

            // For loop implementation of fast version. Find the biggest element which 
            // could have skipped q[i] - should be on original position of q[i] or on position 
            // one index lower. If the calculated position would be lesser than 0, use 0. That 
            // could happen if q[i] is 0.     
            for(var j = Math.Max(q[i] - 1, 0); j < i; j++){
                if(q[j] > q[i]){
                    bribes++;
                }
            }
        }

        Console.WriteLine(bribes);
    }

    // While implementation of the fast version
    static void whileMinimumBribes(int[] q) {
        var bribes = 0;

        for (var i = 0; i < q.Length; i++){
            q[i] -=1; 
        }

        for(var i = q.Length - 1; i >= 0; i--){
            if(q[i] - i > 2){
                Console.WriteLine("Too chaotic");
                return;
            }
            
            var movingIndex = Math.Max(q[i] - 1, 0);

            while(movingIndex < i){
                if( q[movingIndex] > q[i]){
                    bribes++;
                }
                movingIndex++;
            }
        }

        Console.WriteLine(bribes);
    }

    // Compare one by one - slow but works
    static void slowMinimumBribes(int[] q) {
        var bribes = 0;

        for(var i = 0; i < q.Length; i++){
            if(q[i] - i  > 3){
                Console.WriteLine("Too chaotic");
                return;
            }

            for(var j = i + 1; j < q.Length; j++){
                if(q[i]>q[j]){
                    bribes++;
                }
            }
        }

        Console.WriteLine(bribes);
    }

    static void Main(string[] args) {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
            ;
            minimumBribes(q);
        }
    }
}
