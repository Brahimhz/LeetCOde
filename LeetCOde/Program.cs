// See https://aka.ms/new-console-template for more information

using LeetCOde;

var easy = new Easy();
var medium = new Medium();
Console.WriteLine("Hello, World!");

/*
  foreach (var item in easy.TwoSum(new int[] { 3, 2, 4 }, 6))
    Console.WriteLine(item);
*/

//Console.WriteLine(easy.RomanToInt("LVIII"));


//Console.WriteLine(easy.LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));


//Console.WriteLine(easy.IsPalindrome(10));


//var ary = new int[] { 1, 1, 2 };
//Console.WriteLine(easy.RemoveDuplicates(ary));

//var ary = new int[] { 1, 2 };
//Console.WriteLine(easy.RemoveElement(ary, 2));

//medium.Rotate(ary, 3);

//Console.WriteLine(easy.RemoveOuterParentheses("()()"));

//Console.WriteLine(easy.BackspaceCompare("ab#c", "ad#c"));

//Console.WriteLine(easy.ContainsDuplicate(new int[] { 1, 1, 2 }));


//Console.WriteLine(easy.IsAnagram("anagsram", "nagaram"));
//Console.WriteLine(medium.FrequencySort("tree"));



LRUCache l = new LRUCache(2);
l.Put(2, 1);
l.Put(2, 2);
Console.WriteLine(l.Get(2));
l.Put(1, 1);
l.Put(4, 1);
Console.WriteLine(l.Get(2));


Console.ReadLine();


