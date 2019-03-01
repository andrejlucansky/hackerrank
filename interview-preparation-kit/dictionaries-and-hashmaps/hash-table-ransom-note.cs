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

    // Complete the checkMagazine function below.
    static void checkMagazine(string[] magazine, string[] note) {
        var magazineDictionary = new Dictionary<string, int>();
        
        foreach(var word in magazine){
            if(!magazineDictionary.ContainsKey(word)){
                magazineDictionary.Add(word, 1);
            }else{
                magazineDictionary[word] +=1; 
            }
        }

        foreach(var word in note){
            if(magazineDictionary.ContainsKey(word) && magazineDictionary[word] > 0){
                magazineDictionary[word] -=1;
            } else{
                Console.WriteLine("No");
                return;
            }
        }

        Console.WriteLine("Yes");
    }

    static void Main(string[] args) {
        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] magazine = Console.ReadLine().Split(' ');

        string[] note = Console.ReadLine().Split(' ');

        checkMagazine(magazine, note);
    }
}
