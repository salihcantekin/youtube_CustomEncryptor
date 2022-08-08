using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomEncryptor;
public class PassEncryptor
{
    private char[] fullArr = new[] { '0','1','2','3','4','5','6','7','8','9',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O',
            'P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d',
            'e','f','g','h','i','j','k','l','m','n','o','p','q',
            'r','s','t','u','v','w','x','y','z',
            '+', '-', '&', '|', '!', '(', ')', '{', '}', '[', ']', '^', '~', '*', '?', ':'};


    public string NextLetterEnc(string password, int nextCount = 1)
    {
        // ali
        // bmj

        StringBuilder sb = new();

        for (int i = 0; i < password.Length; i++)
        {
            var ch = password[i];
            var b = (byte)ch;
            var newB = b + (nextCount + 5);
            ch = (char)newB;
            sb.Append(ch);
        }

        sb.Append($".{nextCount}");

        return sb.ToString();
    }

    public string NextLetterDec(string encrpted)
    {
        // alih
        // bmj.1
        var nextCount = encrpted.Contains(".")
            ? int.Parse(encrpted.Substring(encrpted.LastIndexOf(".") + 1))
            : 1;

        StringBuilder sb = new();

        for (int i = 0; i < encrpted.Length; i++)
        {
            var ch = encrpted[i];

            if (ch == '.')
                break;

            var b = (byte)ch;
            var newB = b - nextCount - 5;
            ch = (char)newB;
            sb.Append(ch);
        }

        return sb.ToString();
    }

    public string ByteBaseEnc(string password)
    {
        var randomNumbers = new List<string>();
        StringBuilder sb = new();

        for (int i = 0; i < password.Length; i++)
        {
            var r = new Random().Next(fullArr.Length);
            randomNumbers.Add(r.ToString().PadLeft(3, 'x'));

            var ch = password[i];
            var b = (byte)ch + r;
            var value = b.ToString().PadLeft(3, '0');

            var randomChar = fullArr[r];

            sb.Append(value);
            sb.Append(randomChar);
        }

        sb.Append($".{string.Join("", randomNumbers)}");


        return sb.ToString();
    }


    public string ByteBaseDec(string password)
    {
        // 062T133I1025161r147g177^.x29x18xx5x53x42x73

        var arr = password.Split('.', StringSplitOptions.RemoveEmptyEntries);

        var randomNumberArr = arr[^1];
        var randomNumbers = randomNumberArr.Chunk(3)
                                        .Select(i => new string(i).Replace("x", ""))
                                        .Select(i => int.Parse(i))
                                        .ToList();

        var sb = new StringBuilder();


        var passPart = arr.First();
        var byteArr = passPart.Chunk(4)
                              .Select(i => new string(i))
                              .Select(i => i.Substring(0, i.Length - 1))
                              .Select(i => int.Parse(i))
                              .ToList();

        for (int i = 0; i < byteArr.Count; i++)
        {
            var randomNumber = randomNumbers[i];
            var ch = byteArr[i] - randomNumber;

            sb.Append((char)ch);
        }

        return sb.ToString();
    }



    public string RandomByteBaseEnc(string password, string key)
    {
        var sb = new StringBuilder();
        var seed = key.ToCharArray().Select(i => (byte)i).Sum(i => i);
        var r = new Random(seed);

        foreach (var ch in password)
        {
            var randomNumber = r.Next(fullArr.Length);
            var charVal = fullArr[randomNumber];

            sb.Append(charVal);
        }

        return sb.ToString();
    }

    public string MD5_Enc(string text)
    {
        using MD5 md5 = MD5.Create();
        var passBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(text));

        return BitConverter.ToString(passBytes).Replace("-", "");
    }

    public string SHA256_Encr(string text)
    {
        using SHA256 mySHA = SHA256.Create();
        var passBytes = mySHA.ComputeHash(Encoding.UTF8.GetBytes(text));

        return BitConverter.ToString(passBytes).Replace("-", "");
    }
}
