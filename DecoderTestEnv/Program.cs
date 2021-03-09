using System;
using BEDecoder;

namespace DecoderTestEnv
{
    class Program
    {
        static void Main(string[] args)
        {
            Decoder d = new Decoder();
            while (true)
            {
                d.Decode(Console.ReadLine());
            }
        }
    }
}
