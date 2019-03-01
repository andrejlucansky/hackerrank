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