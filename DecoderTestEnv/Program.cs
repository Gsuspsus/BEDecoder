using System;
using BEDecoder;

namespace DecoderTestEnv
{
    class Program
    {
        static void Main(string[] args)
        {
            Decoder d = new Decoder();
            d.Decode(Console.ReadLine());
        }
    }
}
