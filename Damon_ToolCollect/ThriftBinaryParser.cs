using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol.Entities;

namespace Damon_ToolCollect
{
    internal class ThriftBinaryParser
    {
        private readonly byte[] _data;
        private int _position;

        public ThriftBinaryParser(byte[] data)
        {
            _data = data;
            _position = 0;
        }
        public Dictionary<short, object> Parse()
        {
            var result = new Dictionary<short, object>();

            // 读取消息头（如果是RPC调用）
            if (PeekByte() == 0x82) // 协议标识符
            {
                _position += 1; // 跳过协议标识
                var messageType = (MessageType)ReadByte();
                var methodName = ReadString();
                var seqId = ReadI32();
            }

            // 解析结构体
            while (_position < _data.Length)
            {
                var fieldType = (TType)ReadByte();
                if (fieldType == TType.Stop)
                    break;

                var fieldId = ReadI16();
                var value = ParseValue(fieldType);
                result.Add(fieldId, value);
            }

            return result;
        }

        private object ParseValue(TType type)
        {
            switch (type)
            {
                case TType.Bool:
                    return ReadBool();
                case TType.Byte:
                    return ReadByte();
                case TType.I16:
                    return ReadI16();
                case TType.I32:
                    return ReadI32();
                case TType.I64:
                    return ReadI64();
                case TType.Double:
                    return ReadDouble();
                case TType.String:
                    return ReadString();
                case TType.Struct:
                    return ParseStruct();
                case TType.Map:
                    return ParseMap();
                case TType.Set:
                    return ParseSet();
                case TType.List:
                    return ParseList();
                default:
                    throw new NotSupportedException($"Unsupported type: {type}");
            }
        }
        private Dictionary<short, object> ParseStruct()
        {
            var result = new Dictionary<short, object>();

            while (true)
            {
                var fieldType = (TType)ReadByte();
                if (fieldType == TType.Stop)
                    break;

                var fieldId = ReadI16();
                var value = ParseValue(fieldType);
                result.Add(fieldId, value);
            }

            return result;
        }

        private Dictionary<object, object> ParseMap()
        {
            var keyType = (TType)ReadByte();
            var valueType = (TType)ReadByte();
            var size = ReadI32();
            var map = new Dictionary<object, object>();

            for (int i = 0; i < size; i++)
            {
                var key = ParseValue(keyType);
                var value = ParseValue(valueType);
                map.Add(key, value);
            }

            return map;
        }

        private HashSet<object> ParseSet()
        {
            var elementType = (TType)ReadByte();
            var size = ReadI32();
            var set = new HashSet<object>();

            for (int i = 0; i < size; i++)
            {
                var value = ParseValue(elementType);
                set.Add(value);
            }

            return set;
        }

        private List<object> ParseList()
        {
            var elementType = (TType)ReadByte();
            var size = ReadI32();
            var list = new List<object>();

            for (int i = 0; i < size; i++)
            {
                var value = ParseValue(elementType);
                list.Add(value);
            }

            return list;
        }
        private byte ReadByte()
        {
            return _data[_position++];
        }

        private byte PeekByte()
        {
            return _data[_position];
        }

        private bool ReadBool()
        {
            return ReadByte() != 0;
        }

        private short ReadI16()
        {
            short value = (short)((_data[_position] << 8) | _data[_position + 1]);
            _position += 2;
            return value;
        }

        private int ReadI32()
        {
            int value = (_data[_position] << 24) | (_data[_position + 1] << 16)
                      | (_data[_position + 2] << 8) | _data[_position + 3];
            _position += 4;
            return value;
        }

        private long ReadI64()
        {
            long value = ((long)_data[_position] << 56) | ((long)_data[_position + 1] << 48)
                       | ((long)_data[_position + 2] << 40) | ((long)_data[_position + 3] << 32)
                       | ((long)_data[_position + 4] << 24) | ((long)_data[_position + 5] << 16)
                       | ((long)_data[_position + 6] << 8) | _data[_position + 7];
            _position += 8;
            return value;
        }

        private double ReadDouble()
        {
            var bytes = new byte[8];
            Array.Copy(_data, _position, bytes, 0, 8);
            _position += 8;
            return BitConverter.ToDouble(bytes, 0);
        }

        private string ReadString()
        {
            var length = ReadI32();
            var value = Encoding.UTF8.GetString(_data, _position, length);
            _position += length;
            return value;
        }
    }
    public enum MessageType : byte
    {
        Call = 1,
        Reply = 2,
        Exception = 3,
        Oneway = 4
    }
}
