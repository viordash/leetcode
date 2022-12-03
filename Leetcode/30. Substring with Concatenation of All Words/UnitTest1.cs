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

        public IList<int> FindSubstring(string s, string[] words) {
            var result = new List<int>();
            var len = words[0].Length;
            var totalLen = len * words.Length;
            var lastPos = s.Length - totalLen;

            var wordsAsMem = words
                .Select((x, i) => new { word = x.AsMemory(), index = i })
                .ToList();

            int i = 0;
            var mem = s.AsMemory();
            while(i <= s.Length - totalLen) {
                var substr = mem.Slice(i, len);

                var possibly = wordsAsMem.FirstOrDefault(x => substr.Span.SequenceEqual(x.word.Span));
                if(possibly != null) {
                    var restOfWords = wordsAsMem
                            .Where(x => x.index != possibly.index)
                            .ToList();

                    int k = i + len;
                    while(restOfWords.Count > 0 && k <= s.Length - len) {
                        substr = mem.Slice(k, len);
                        possibly = restOfWords.FirstOrDefault(x => substr.Span.SequenceEqual(x.word.Span));
                        if(possibly != null) {
                            restOfWords = restOfWords
                                .Where(x => x.index != possibly.index)
                                .ToList();
                            k += len;
                        } else {
                            break;
                        }

                    }
                    if(restOfWords.Count == 0) {
                        result.Add(i);
                        i += len - 1;
                    }
                }
                i++;
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