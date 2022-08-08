// Geri dönüşü olabilen
// salih - sdfkşalsdk - salih



// Geri dönüşü olamayan [Mutlaka her seferinde aynı sonucu üretmeli]
// salih - asdawıqu - 

// Veritabanındaki kullanıcı şifreleri (asdawıqu)


using CustomEncryptor;

string value = "sal ih";

PassEncryptor p = new();


//var e1 = p.NextLetterEnc(value, 6);
//var d1 = p.NextLetterDec(e1);

//Console.WriteLine($"E1: {e1}");
//Console.WriteLine($"D1: {d1}");


//for (int i = 0; i < 5; i++)
//{
//    var e2 = p.ByteBaseEnc(value);
//    var d2 = p.ByteBaseDec(e2);

//    Console.WriteLine($"E2: {e2}");
//    Console.WriteLine($"D2: {d2}");
//}

//for (int i = 0; i < 5; i++)
//{
//    var e3 = p.RandomByteBaseEnc(value, "this is my key");
//    Console.WriteLine($"E3: {e3}");
//}

//for (int i = 0; i < 5; i++)
//{
//    var e4 = p.MD5_Enc(value + (i + 1));
//    Console.WriteLine($"E4: {e4}");
//}

for (int i = 0; i < 5; i++)
{
    var e5 = p.SHA256_Encr(value);
    Console.WriteLine($"E5: {e5}");
}



Console.ReadLine();