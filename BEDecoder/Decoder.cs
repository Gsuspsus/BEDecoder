using BEDecoder.Tokens;
using System;
using System.Collections.Generic;

namespace BEDecoder
{
    public class Decoder
    {
        public void Decode(string input)
        {
            foreach(BenToken tok in Tokenizer.Tokenize(input))
            {
                Console.WriteLine($"{tok.Type.ToString()}, {tok.Literal}");
            }
        }
    }
}
