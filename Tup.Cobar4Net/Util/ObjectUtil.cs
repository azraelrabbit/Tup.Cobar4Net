/*
* Copyright 1999-2012 Alibaba Group.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
using System;
using System.Collections.Generic;

namespace Tup.Cobar4Net.Util
{
    public sealed class ObjectUtil
    {
        /// <summary>
        /// �ݹ�رȽ����������Ƿ���ͬ��֧�ֶ�ά���顣
        /// <p>
        /// ����ȽϵĶ��������飬��˷����Ľ��ͬ<code>ObjectUtil.equals</code>��
        /// </p>
        /// </summary>
        /// <param name="array1">����1</param>
        /// <param name="array2">����2</param>
        /// <returns>������, �򷵻�<code>true</code></returns>
        public static bool Equals<T>(IList<T> array1, IList<T> array2)
        {
            if (array1 == array2)
                return true;

            if (array1 == null || array2 == null)
                return false;

            if (array1.Count != array2.Count)
            {
                return false;
            }
            for (int i = 0; i < array1.Count; i++)
            {
                if (!array1[i].Equals(array2[i]))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// �ݹ�رȽ����������Ƿ���ͬ��֧�ֶ�ά���顣
        /// <p>
        /// ����ȽϵĶ��������飬��˷����Ľ��ͬ<code>ObjectUtil.equals</code>��
        /// </p>
        /// </summary>
        /// <param name="array1">����1</param>
        /// <param name="array2">����2</param>
        /// <returns>������, �򷵻�<code>true</code></returns>
        //public static bool Equals(object array1, object array2)
        //{
        //    //if (array1 == array2)
        //    //{
        //    //    return true;
        //    //}
        //    //if ((array1 == null) || (array2 == null))
        //    //{
        //    //    return false;
        //    //}
        //    //Type clazz = array1.GetType();
        //    //if (!clazz.Equals(array2.GetType()))
        //    //{
        //    //    return false;
        //    //}
        //    //if (!clazz.IsArray)
        //    //{
        //    //    return array1.Equals(array2);
        //    //}
        //    //// array1��array2Ϊͬ���͵�����
        //    //if (array1 is long[])
        //    //{
        //    //    long[] longArray1 = (long[])array1;
        //    //    long[] longArray2 = (long[])array2;
        //    //    if (longArray1.Length != longArray2.Length)
        //    //    {
        //    //        return false;
        //    //    }
        //    //    for (int i = 0; i < longArray1.Length; i++)
        //    //    {
        //    //        if (longArray1[i] != longArray2[i])
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //    return true;
        //    //}
        //    //else if (array1 is int[])
        //    //{
        //    //    int[] intArray1 = (int[])array1;
        //    //    int[] intArray2 = (int[])array2;
        //    //    if (intArray1.Length != intArray2.Length)
        //    //    {
        //    //        return false;
        //    //    }
        //    //    for (int i = 0; i < intArray1.Length; i++)
        //    //    {
        //    //        if (intArray1[i] != intArray2[i])
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //    return true;
        //    //}
        //    //else if (array1 is short[])
        //    //{
        //    //    short[] shortArray1 = (short[])array1;
        //    //    short[] shortArray2 = (short[])array2;
        //    //    if (shortArray1.Length != shortArray2.Length)
        //    //    {
        //    //        return false;
        //    //    }
        //    //    for (int i = 0; i < shortArray1.Length; i++)
        //    //    {
        //    //        if (shortArray1[i] != shortArray2[i])
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //    return true;
        //    //}
        //    //else if (array1 is byte[])
        //    //{
        //    //    byte[] byteArray1 = (byte[])array1;
        //    //    byte[] byteArray2 = (byte[])array2;
        //    //    if (byteArray1.Length != byteArray2.Length)
        //    //    {
        //    //        return false;
        //    //    }
        //    //    for (int i = 0; i < byteArray1.Length; i++)
        //    //    {
        //    //        if (byteArray1[i] != byteArray2[i])
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //    return true;
        //    //}
        //    //else if (array1 is double[])
        //    //{
        //    //    double[] doubleArray1 = (double[])array1;
        //    //    double[] doubleArray2 = (double[])array2;
        //    //    if (doubleArray1.Length != doubleArray2.Length)
        //    //    {
        //    //        return false;
        //    //    }
        //    //    for (int i = 0; i < doubleArray1.Length; i++)
        //    //    {
        //    //        if (double.DoubleToLongBits(doubleArray1[i]) != double.DoubleToLongBits(doubleArray2
        //    //            [i]))
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //    return true;
        //    //}
        //    //else if (array1 is float[])
        //    //{
        //    //    float[] floatArray1 = (float[])array1;
        //    //    float[] floatArray2 = (float[])array2;
        //    //    if (floatArray1.Length != floatArray2.Length)
        //    //    {
        //    //        return false;
        //    //    }
        //    //    for (int i = 0; i < floatArray1.Length; i++)
        //    //    {
        //    //        if (Sharpen.Runtime.FloatToIntBits(floatArray1[i]) != Sharpen.Runtime.FloatToIntBits
        //    //            (floatArray2[i]))
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //    return true;
        //    //}
        //    //else if (array1 is bool[])
        //    //{
        //    //    bool[] booleanArray1 = (bool[])array1;
        //    //    bool[] booleanArray2 = (bool[])array2;
        //    //    if (booleanArray1.Length != booleanArray2.Length)
        //    //    {
        //    //        return false;
        //    //    }
        //    //    for (int i = 0; i < booleanArray1.Length; i++)
        //    //    {
        //    //        if (booleanArray1[i] != booleanArray2[i])
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //    return true;
        //    //}
        //    //else if (array1 is char[])
        //    //{
        //    //    char[] charArray1 = (char[])array1;
        //    //    char[] charArray2 = (char[])array2;
        //    //    if (charArray1.Length != charArray2.Length)
        //    //    {
        //    //        return false;
        //    //    }
        //    //    for (int i = 0; i < charArray1.Length; i++)
        //    //    {
        //    //        if (charArray1[i] != charArray2[i])
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //    return true;
        //    //}
        //    //else
        //    //{
        //    //    object[] objectArray1 = (object[])array1;
        //    //    object[] objectArray2 = (object[])array2;
        //    //    if (objectArray1.Length != objectArray2.Length)
        //    //    {
        //    //        return false;
        //    //    }
        //    //    for (int i = 0; i < objectArray1.Length; i++)
        //    //    {
        //    //        if (!Equals(objectArray1[i], objectArray2[i]))
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //    return true;
        //    //}
        //}
    }
}
