using BEDecoder;
using BEDecoder.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BEDecoderTests
{
    [TestClass]
    public class TokenizerTests
    {
        [TestMethod]
        public void Tokenize_I_ShouldTokenizeToIntegerBegin()
        {
            string input = "i";
            List<BenToken> tokenList = Tokenizer.Tokenize(input);
            List<BenToken> expectedTokenList = new List<BenToken>() { new BenToken(TokenType.INTEGER_BEGIN, "i") };
            CollectionAssert.AreEquivalent(expectedTokenList, tokenList);
        }

        [TestMethod]
        public void Tokenize_L_ShouldTokenizeToListBegin()
        {
            string input = "l";
            List<BenToken> tokenList = Tokenizer.Tokenize(input);
            List<BenToken> expectedTokenList = new List<BenToken>() { new BenToken(TokenType.LIST_BEGIN, "l") };
            CollectionAssert.AreEquivalent(expectedTokenList, tokenList);
        }
        
        [TestMethod]
        public void Tokenize_D_ShouldTokenizeToDictBegin()
        {
            string input = "d";
            List<BenToken> tokenList = Tokenizer.Tokenize(input);
            List<BenToken> expectedTokenList = new List<BenToken>() { new BenToken(TokenType.DICT_BEGIN, "d") };
            CollectionAssert.AreEquivalent(expectedTokenList, tokenList);
        }

        [TestMethod]
        public void Tokenize_Colon_ShouldTokenizeColon()
        {
            string input = ":";
            List<BenToken> tokenList = Tokenizer.Tokenize(input);
            List<BenToken> expectedTokenList = new List<BenToken>() { new BenToken(TokenType.COLON, ":") };
            CollectionAssert.AreEquivalent(expectedTokenList, tokenList);
        }

    }
}
