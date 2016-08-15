using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionProxy
{
    public static class BEncode
    {
        /// <summary>
        /// Decodes the specified bencoded string.
        /// </summary>
        /// <param name="bencodedString">The bencoded string.</param>
        /// <returns></returns>
        public static List<object> Decode(string bencodedString)
        {
            int index = 0;

            if (bencodedString == null)
                return null;

            List<object> rootElements = new List<object>();
            while (bencodedString.Length > index)
                rootElements.Add(ReadElement(ref bencodedString, ref index));

            return rootElements;
        }

        /// <summary>
        /// Reads a element.
        /// </summary>
        /// <param name="bencodedString">The bencoded string.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException">bencodedString</exception>
        private static object ReadElement(ref string bencodedString, ref int index)
        {
            switch (bencodedString[index])
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9': return ReadString(ref bencodedString, ref index);
                case 'i': return ReadInteger(ref bencodedString, ref index);
                case 'l': return ReadList(ref bencodedString, ref index);
                case 'd': return ReadDictionary(ref bencodedString, ref index);
                default: throw new FormatException("bencodedString");
            }
        }

        /// <summary>
        /// Reads a dictionary.
        /// </summary>
        /// <param name="bencodedString">The bencoded string.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException">bencodedString</exception>
        private static Dictionary<string, object> ReadDictionary(ref string bencodedString, ref int index)
        {
            index++;
            Dictionary<string, object> dict = new Dictionary<string, object>();

            try
            {
                while (index < bencodedString.Length && bencodedString[index] != 'e')
                {
                    string key = ReadString(ref bencodedString, ref index);
                    object value = ReadElement(ref bencodedString, ref index);
                    dict.Add(key, value);
                }
            }
            catch (Exception e)
            {
                throw new FormatException("bencodedString", e);
            }

            index++;
            return dict;
        }

        /// <summary>
        /// Reads a list.
        /// </summary>
        /// <param name="bencodedString">The bencoded string.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException">bencodedString</exception>
        private static List<object> ReadList(ref string bencodedString, ref int index)
        {
            index++;
            List<object> list = new List<object>();

            try
            {
                while (bencodedString[index] != 'e')
                    list.Add(ReadElement(ref bencodedString, ref index));
            }
            catch (Exception e)
            {
                throw new FormatException("bencodedString", e);
            }

            index++;
            return list;
        }

        /// <summary>
        /// Reads an integer.
        /// </summary>
        /// <param name="bencodedString">The bencoded string.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException">
        /// bencodedString
        /// </exception>
        private static long ReadInteger(ref string bencodedString, ref int index)
        {
            index++;

            int end = bencodedString.IndexOf('e', index);
            if (end == -1)
                throw new FormatException("bencodedString");

            long integer;

            try
            {
                integer = Convert.ToInt64(bencodedString.Substring(index, end - index));
                index = end + 1;
            }
            catch (Exception e)
            {
                throw new FormatException("bencodedString", e);
            }

            return integer;
        }

        /// <summary>
        /// Reads a string.
        /// </summary>
        /// <param name="bencodedString">The bencoded string.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException">
        /// bencodedString
        /// </exception>
        private static string ReadString(ref string bencodedString, ref int index)
        {
            int length, colon;

            try
            {
                colon = bencodedString.IndexOf(':', index);
                if (colon == -1)
                    throw new FormatException("bencodedString");

                length = Convert.ToInt32(bencodedString.Substring(index, colon - index));
            }
            catch (Exception e)
            {
                throw new FormatException("bencodedString", e);
            }

            index = colon + 1;
            int tmpIndex = index;
            index += length;

            if (index > bencodedString.Length)
                length = bencodedString.Length - tmpIndex;

            try
            {
                return bencodedString.Substring(tmpIndex, length);
            }
            catch (Exception e)
            {
                throw new FormatException("bencodedString", e);
            }
        }
    }
}
