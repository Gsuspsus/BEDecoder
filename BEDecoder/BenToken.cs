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
    }
}