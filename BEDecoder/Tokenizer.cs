using BEDecoder.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEDecoder
{
    public class Tokenizer
    {
        private static Dictionary<char, TokenType> TypeLiterals = new Dictionary<char, TokenType>()
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
                if (isDelimiter(input[i])){
                    tokens.Add(new BenToken(TypeLiterals[input[i]], input[i].ToString()));
                }
                else if (Char.IsDigit(input[i]))
                {

                    (string number, int j) = ReadNumber(input, i);
                    tokens.Add(new BenToken(TokenType.INTEGER, number));
                    i = j;
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
                            (string letters, int k) = ReadByteString(input, int.Parse(length), i);
                            i = k;
                            tokens.Add(new BenToken(TokenType.BYTESTRING, letters));
                        }
                    }
                }
            }
            return tokens;
        }

        private static bool isDelimiter(char c)
        {
            return "d:li".Contains(c);
        }

        private static (string, int) ReadByteString(string input, int length, int i)
        {
            string letters = "";
            int target = length + i;
            while (i < target && char.IsLetter(input[i]))
            {
                letters += input[i++];
            }
            i--;

            return (letters, i);
        }

        private static (string, int) ReadNumber(string input, int i)
        {
            string number = "";
            while (Char.IsDigit(input[i]))
            {
                number += input[i];
                i++;
            }
            i--;
            return (number, i);
        }
    }
}
