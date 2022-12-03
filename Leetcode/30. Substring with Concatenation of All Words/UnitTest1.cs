using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace _30._Substring_with_Concatenation_of_All_Words {
    public class Tests {
        [SetUp]
        public void Setup() {
        }


        IEnumerable<int> AllSubstrings(string s, string substr) {
            int i = 0;
            while((i = s.IndexOf(substr, i)) >= 0) {
                yield return i;
                i++;
            }
        }

        public IList<int> FindSubstring(string s, string[] words) {
            var result = new List<int>();
            var len = words[0].Length;
            var totalLen = len * words.Length;
            var lastPos = s.Length - totalLen;


            var occurrences = new Dictionary<int, int>();

            for(int i = 0; i < words.Length; i++) {
                foreach(var k in AllSubstrings(s, words[i])) {
                    occurrences.TryAdd(k, i);
                }
            }

            var ordered = occurrences
                .OrderBy(x => x.Key)
                .ToList();

            var wordsIndexes = new List<int>();
            var index = 0;
            while(index < ordered.Count - 1) {
                var prev = ordered[index++];
                var item = ordered[index];

                int delta = item.Key - prev.Key;
                if(delta == len) {
                    wordsIndexes.Add(prev.Value);
                    if(wordsIndexes.Count == words.Length - 1) {
                        wordsIndexes.Add(item.Value);
                        index -= (wordsIndexes.Count - 2);
                        if(wordsIndexes.Distinct().Count() == words.Length) {
                            result.Add(ordered[index - 1].Key);
                        }
                        wordsIndexes.Clear();
                    }
                } else {
                    wordsIndexes.Clear();
                }
            }
            return result;
        }

        [Test]
        public void Test1() {
            var res = FindSubstring("barfoothefoobarman", new[] { "foo", "bar" });
            Assert.That(res, Is.EquivalentTo(new int[] { 0, 9 }));
        }

        [Test]
        public void Test2() {
            var res = FindSubstring("wordgoodgoodgoodbestword", new[] { "word", "good", "best", "word" });
            Assert.That(res, Is.EquivalentTo(new int[] { }));
        }

        [Test]
        public void Test3() {
            var res = FindSubstring("barfoofoobarthefoobarman", new[] { "bar", "foo", "the" });
            Assert.That(res, Is.EquivalentTo(new int[] { 6, 9, 12 }));
        }

        [Test]
        public void Test_137() {
            var res = FindSubstring("wordgoodgoodgoodbestword", new[] { "word", "good", "best", "good" });
            Assert.That(res, Is.EquivalentTo(new int[] { 8 }));
        }
    }
}