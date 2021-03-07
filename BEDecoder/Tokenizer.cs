using BEDecoder.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEDecoder
{
    public class Tokenizer
    {
        public static Dictionary<char, TokenType> TypeLiterals = new Dictionary<char, TokenType>()
        {
            {'i', TokenType.INTEGER_BEGIN },
            { 'l', TokenType.LIST_BEGIN },
            {'d', TokenType.DICT_BEGIN },
            {':', TokenType.COLON }
        };
        public static List<BenToken> Tokenize(string input)
        {
            List<BenToken> tokens = new List<BenToken>();
            int i = 0;
            for (; i < input.Length; i++)
            {
                if (isDelimiter(input[i]))
                {
                    tokens.Add(new BenToken(TypeLiterals[input[i]], input[i].ToString()));
                }
                else if (Char.IsDigit(input[i]))
                {
                    try
                    {
                        string number = ReadNumber(input, ref i);
                        tokens.Add(new BenToken(TokenType.INTEGER, number));
                    }
                    catch
                    {
                        tokens.Add(new BenToken(TokenType.INVALID, null));
                    }
                }
                else
                {
                    if (Char.IsLetter(input[i]))
                    {
                        if (input[i] == 'e' && tokens[tokens.Count - 1].Type != TokenType.COLON)
                        {
                            tokens.Add(new BenToken(TokenType.END, "e"));
                        }
                        else if (char.IsLetter(input[i]) && tokens[tokens.Count - 1].Type == TokenType.COLON)
                        {
                            string length = tokens.Skip(1).First().Literal;
                            string letters = ReadByteString(input, int.Parse(length), ref i);
                            tokens.Add(new BenToken(TokenType.BYTESTRING, letters));
                        }
                    }
                }
            }
            return tokens;
        }

        private static bool isDelimiter(char c)
        {
            return TypeLiterals.Keys.Contains(c);
        }

        private static string ReadByteString(string input, int length, ref int i)
        {
            string letters = "";
            int target = length + i;
            while (i < target && char.IsLetter(input[i]))
            {
                letters += input[i++];
            }
            i--;

            return letters;
        }

        private static string ReadNumber(string input, ref int i)
        {
            string number = "";
            bool invalid = false;
            while (input[i] != 'e')
            {
                if (!char.IsDigit(input[i]))
                {
                    invalid = true;
                }
                number += input[i];
                i++;
            }
            i--;
            if (invalid)
            {
                throw new FormatException("Invalid Integer Format");
            }
            return number;
        }
    }
}
