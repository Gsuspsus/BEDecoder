using BEDecoder.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEDecoder
{
    class Tokenizer
    {
        public List<BenToken> Tokenize(string input)
        {
            Stack<BenToken> tokens = new Stack<BenToken>();
            int i = 0;
            for (; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'i':
                        tokens.Push(new BenToken(TokenType.INTEGER_BEGIN, "i"));
                        break;
                    case 'l':
                        tokens.Push(new BenToken(TokenType.LIST_BEGIN, "l"));
                        break;
                    case 'd':
                        tokens.Push(new BenToken(TokenType.DICT_BEGIN, "d"));
                        break;
                    case ':':
                        tokens.Push(new BenToken(TokenType.COLON, ":"));
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        string number = "";
                        while (Char.IsDigit(input[i]))
                        {
                            number += input[i];
                            i++;
                        }
                        i--;
                        tokens.Push(new BenToken(TokenType.INTEGER, number));
                        break;

                    default:
                        if (Char.IsLetter(input[i]))
                        {
                            if(input[i] == 'e' && tokens.Peek().Type != TokenType.COLON)
                            {
                                tokens.Push(new BenToken(TokenType.END, "e"));
                                break;
                            }else if(char.IsLetter(input[i]) && tokens.Peek().Type == TokenType.COLON)
                            {
                                string letters = "";
                                int length = int.Parse(tokens.Skip(1).First().Literal);
                                int target = length + i;
                                while (i < target && char.IsLetter(input[i]))
                                {
                                    letters += input[i++];
                                }
                                i--;
                                tokens.Push(new BenToken(TokenType.BYTESTRING, letters));
                                break;
                            }
                        }

                        break;
                }
            }

            List<BenToken> tokensList = new List<BenToken>(tokens);
            tokensList.Reverse();
            return new List<BenToken>(tokensList);
        }
    }
}
