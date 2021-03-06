using System;

namespace BEDecoder.Tokens
{
    public enum TokenType
    {
        INTEGER_BEGIN,
        INTEGER,
        BYTESTRING_BEGIN,
        COLON,
        BYTESTRING,
        LIST_BEGIN,
        DICT_BEGIN,
        END
    };


    public class BenToken
    {
        public TokenType Type { get; }
        public string Literal { get; }

        public BenToken(TokenType type, string literal)
        {
            Type = type;
            Literal = literal;
        }

        public override bool Equals(object obj)
        {
            return obj is BenToken token &&
                   Type == token.Type &&
                   Literal == token.Literal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Literal);
        }
    }
}