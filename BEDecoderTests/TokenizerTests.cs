using BEDecoder;
using BEDecoder.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void Tokenize_KnownDelimiter_ShouldMapToRelevantToken()
        {
            string input = "ild:";
            List<TokenType> expectedTypes= Tokenizer.TypeLiterals.Values.ToList();
            List<TokenType> actualTypes = input.Select((c) => Tokenizer.TypeLiterals[c]).ToList();
            CollectionAssert.AreEquivalent(expectedTypes, actualTypes);
        }

        [TestMethod]
        public void Tokenize_ValidInteger_ShouldParse()
        {
            string input = "i42e";
            List<TokenType> expected = new List<TokenType>() { TokenType.INTEGER_BEGIN, TokenType.INTEGER, TokenType.END };
            List<TokenType> actual = Tokenizer.Tokenize(input).Select((t) => t.Type).ToList();
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Tokenize_InvalidInteger_ShouldReturnInvalidToken()
        {
            string input = "i4ae";
            List<TokenType> expected = new List<TokenType>() { TokenType.INTEGER_BEGIN, TokenType.INVALID, TokenType.END };
            List<TokenType> actual = Tokenizer.Tokenize(input).Select((t) => t.Type).ToList();
            CollectionAssert.AreEquivalent(expected, actual);
        }


    }


}
