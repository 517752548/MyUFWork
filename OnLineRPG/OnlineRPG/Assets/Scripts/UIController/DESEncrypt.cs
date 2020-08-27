using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public sealed class DESEncrypt
{
    private static string key = "Fotoable";
    private static string serverKey = "fzgw7*^w";

    public static string Key
    {
        get
        {
            return key;
        }
        set
        {
            key = value;
        }
    }

    /// <summary>
    /// DES加密
    /// </summary>
    /// <param name="encryptString"></param>
    /// <returns></returns>
    public static string DesEncrypt(string encryptString)
    {
        try
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            byte[] keyIv = keyBytes;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, provider.CreateEncryptor(keyBytes, keyIv), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();

            string ret = Convert.ToBase64String(mStream.ToArray());
            cStream.Close();
            mStream.Close();

            return ret;
        }
        catch (CryptographicException ex)
        {
            BetaFramework.LoggerHelper.Log(ex);
            return encryptString;
        }
    }

    /// <summary>
    /// DES解密
    /// </summary>
    /// <param name="decryptString"></param>
    /// <returns></returns>
    public static string DesDecrypt(string decryptString)
    {
        try
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            byte[] keyIv = keyBytes;
            byte[] inputByteArray = Convert.FromBase64String(decryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();

            CryptoStream cStream = new CryptoStream(mStream, provider.CreateDecryptor(keyBytes, keyIv), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();

            string ret = Encoding.UTF8.GetString(mStream.ToArray());
            cStream.Close();
            mStream.Close();

            return ret;
        }
        catch (Exception ex)
        {
            BetaFramework.LoggerHelper.Log(ex);
            return decryptString;
        }
    }

    #region ECB模式

    /// <summary>
    /// DES加密
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static byte[] DesEncrypt(byte[] bytes)
    {
        try
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(serverKey);
            byte[] keyIv = keyBytes;

            // Create a MemoryStream.
            MemoryStream mStream = new MemoryStream();
            DESCryptoServiceProvider tdsp = new DESCryptoServiceProvider
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.Zeros
            };

            CryptoStream cStream = new CryptoStream(mStream, tdsp.CreateEncryptor(keyBytes, keyIv), CryptoStreamMode.Write);

            cStream.Write(bytes, 0, bytes.Length);
            cStream.FlushFinalBlock();

            byte[] ret = mStream.ToArray();

            cStream.Close();
            mStream.Close();
            return ret;
        }
        catch (CryptographicException ex)
        {
            BetaFramework.LoggerHelper.Exception(ex);
            return bytes;
        }
    }

    /// <summary>
    /// DES解密
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static byte[] DesDecrypt(byte[] bytes)
    {
        try
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(serverKey);
            byte[] keyIv = keyBytes;

            MemoryStream msDecrypt = new MemoryStream(bytes);
            DESCryptoServiceProvider tdsp = new DESCryptoServiceProvider
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.Zeros
            };

            CryptoStream csDecrypt = new CryptoStream(msDecrypt, tdsp.CreateDecryptor(keyBytes, keyIv), CryptoStreamMode.Read);

            byte[] fromEncrypt = new byte[bytes.Length];
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

            msDecrypt.Close();
            csDecrypt.Close();

            return fromEncrypt;
        }
        catch (CryptographicException ex)
        {
            BetaFramework.LoggerHelper.Log(ex);
            return bytes;
        }
    }

    /// <summary>
    /// DES解密
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string DesDecryptECB(string decryptString)
    {
        try
        {
            byte[] encryptBytes = Convert.FromBase64String(decryptString);
            byte[] keyBytes = Encoding.UTF8.GetBytes(serverKey);
            byte[] keyIv = keyBytes;

            MemoryStream msDecrypt = new MemoryStream(encryptBytes);
            DESCryptoServiceProvider tdsp = new DESCryptoServiceProvider
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.Zeros
            };

            CryptoStream csDecrypt = new CryptoStream(msDecrypt, tdsp.CreateDecryptor(keyBytes, keyIv), CryptoStreamMode.Read);

            byte[] fromEncrypt = new byte[encryptBytes.Length];
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

            msDecrypt.Close();
            csDecrypt.Close();

            return Encoding.UTF8.GetString(fromEncrypt).TrimEnd('\0');
        }
        catch (CryptographicException ex)
        {
            BetaFramework.LoggerHelper.Log(ex);
            return decryptString;
        }
    }

    #endregion ECB模式

    #region ECB模式，通用加密解密

    /// <summary>
    /// DES加密
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static byte[] DesEncrypt(string key, byte[] bytes)
    {
        try
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] keyIv = keyBytes;

            // Create a MemoryStream.
            MemoryStream mStream = new MemoryStream();
            DESCryptoServiceProvider tdsp = new DESCryptoServiceProvider
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            CryptoStream cStream = new CryptoStream(mStream, tdsp.CreateEncryptor(keyBytes, keyIv), CryptoStreamMode.Write);

            cStream.Write(bytes, 0, bytes.Length);
            cStream.FlushFinalBlock();

            byte[] ret = mStream.ToArray();

            cStream.Close();
            mStream.Close();
            return ret;
        }
        catch (CryptographicException ex)
        {
            BetaFramework.LoggerHelper.Log(ex);
            return null;
        }
    }

    /// <summary>
    /// DES解密
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static byte[] DesDecrypt(string key, byte[] bytes)
    {
        try
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] keyIv = keyBytes;

            MemoryStream msDecrypt = new MemoryStream(bytes);
            DESCryptoServiceProvider tdsp = new DESCryptoServiceProvider
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            CryptoStream csDecrypt = new CryptoStream(msDecrypt, tdsp.CreateDecryptor(keyBytes, keyIv), CryptoStreamMode.Read);

            byte[] fromEncrypt = new byte[bytes.Length];
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

            msDecrypt.Close();
            csDecrypt.Close();

            return fromEncrypt;
        }
        catch (CryptographicException ex)
        {
            BetaFramework.LoggerHelper.Log(ex);
            return new byte[] { };
        }
    }

    /// <summary>
    /// DES加密
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string DesEncrypt(string key, string content)
    {
        byte[] decryptBytes = Encoding.UTF8.GetBytes(content);
        byte[] encryptBytes = DesEncrypt(key, decryptBytes);
        if (encryptBytes == null)
            return null;
        return Convert.ToBase64String(encryptBytes);
    }

    /// <summary>
    /// DES解密
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string DesDecrypt(string key, string content)
    {
        byte[] encryptBytes = Convert.FromBase64String(content);
        byte[] decryptBytes = DesDecrypt(key, encryptBytes);
        if (decryptBytes == null)
            return null;
        return Encoding.UTF8.GetString(decryptBytes).TrimEnd('\0');
    }

    #endregion ECB模式，通用加密解密
}