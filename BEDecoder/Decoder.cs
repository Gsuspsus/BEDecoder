using BEDecoder.Tokens;
using System;
using System.Collections.Generic;

namespace BEDecoder
{
    public class Decoder
    {
        public void Decode(string input)
        {
            Tokenizer tokenizer = new Tokenizer();
            foreach(BenToken tok in tokenizer.Tokenize(input))
            {
                Console.WriteLine($"{tok.Type.ToString()}, {tok.Literal}");
            }
        }
    }
}
