using System;
using System.Collections.Generic;

namespace Silverio.Žodynas.Models
{
    public class WordPair : IEquatable<WordPair>
    {
        public int Id { get; set; }
        public string LithuanianWord { get; set; }
        public string EnglishWord { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as WordPair);
        }

        public bool Equals(WordPair other)
        {
            return other != null &&
                   Id == other.Id &&
                   LithuanianWord == other.LithuanianWord &&
                   EnglishWord == other.EnglishWord;
        }

        public override int GetHashCode()
        {
            var hashCode = -1134854903;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LithuanianWord);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EnglishWord);
            return hashCode;
        }

        public static bool operator ==(WordPair pair1, WordPair pair2)
        {
            return EqualityComparer<WordPair>.Default.Equals(pair1, pair2);
        }

        public static bool operator !=(WordPair pair1, WordPair pair2)
        {
            return !(pair1 == pair2);
        }
    }
}
