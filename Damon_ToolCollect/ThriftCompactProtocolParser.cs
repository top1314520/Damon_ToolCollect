using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Transport;

namespace Damon_ToolCollect
{
    /// <summary>
    /// application/x-thrift数据包解析
    /// </summary>
    public class ThriftCompactProtocolParser
    {
        private readonly TProtocol protocol;
        public TMessage _message { get; set; }

        private static readonly Dictionary<TType, string> typeNameMap = new Dictionary<TType, string>
        {
            [TType.Stop] = "stop",
            [TType.Void] = "void",
            [TType.Bool] = "bool",
            [TType.Byte] = "byte",
            [TType.Double] = "double",
            [TType.I16] = "i16",
            [TType.I32] = "i32",
            [TType.I64] = "i64",
            [TType.String] = "string",
            [TType.Struct] = "struct",
            [TType.Map] = "map",
            [TType.Set] = "set",
            [TType.List] = "list",
            [TType.Uuid] = "Uuid"
        };

        public ThriftCompactProtocolParser(TProtocol protocol)
        {
            this.protocol = protocol;
        }

        public async Task<List<Dictionary<string, object>>> DecodeAsync(CancellationToken cancellationToken = default)
        {
            var result = new List<Dictionary<string, object>>();

            // 读取消息头
            TMessage message = await protocol.ReadMessageBeginAsync(cancellationToken);
            _message = message;
            // 读取结构体
            TStruct structInfo = await protocol.ReadStructBeginAsync(cancellationToken);
            result = await ReadFieldsAsync(cancellationToken);
            await protocol.ReadStructEndAsync(cancellationToken);

            // 读取消息尾
            await protocol.ReadMessageEndAsync(cancellationToken);

            return result;
        }

        private async Task<List<Dictionary<string, object>>> ReadFieldsAsync(CancellationToken cancellationToken)
        {
            var fields = new List<Dictionary<string, object>>();

            while (true)
            {
                TField field = await protocol.ReadFieldBeginAsync(cancellationToken);
                if (field.Type == TType.Stop)
                {
                    break;
                }

                var fieldData = new Dictionary<string, object>
                {
                    ["id"] = field.ID,
                    ["type"] = typeNameMap[field.Type],
                    ["value"] = await ReadFieldValueAsync(field.Type, cancellationToken)
                };

                fields.Add(fieldData);
                await protocol.ReadFieldEndAsync(cancellationToken);
            }

            return fields;
        }

        private async Task<object> ReadFieldValueAsync(TType type, CancellationToken cancellationToken)
        {
            switch (type)
            {
                case TType.Bool:
                    return await protocol.ReadBoolAsync(cancellationToken);
                case TType.Byte:
                    return await protocol.ReadByteAsync(cancellationToken);
                case TType.Double:
                    return await protocol.ReadDoubleAsync(cancellationToken);
                case TType.I16:
                    return await protocol.ReadI16Async(cancellationToken);
                case TType.I32:
                    return await protocol.ReadI32Async(cancellationToken);
                case TType.I64:
                    return await protocol.ReadI64Async(cancellationToken);
                case TType.String:
                    try
                    {
                        return await protocol.ReadStringAsync(cancellationToken);
                    }
                    catch
                    {
                        byte[] bytes = await protocol.ReadBinaryAsync(cancellationToken);
                        return $"UnicodeDecodeError. binary({BitConverter.ToString(bytes).Replace("-", "")})";
                    }
                case TType.Struct:
                    return await ReadStructAsync(cancellationToken);
                case TType.Map:
                    return await ReadMapAsync(cancellationToken);
                case TType.Set:
                    return await ReadSetAsync(cancellationToken);
                case TType.List:
                    return await ReadListAsync(cancellationToken);
                case TType.Uuid:
                    return await protocol.ReadUuidAsync(cancellationToken);
                default:
                    throw new Exception($"unknown type: {type}");
            }
        }

        private async Task<List<Dictionary<string, object>>> ReadStructAsync(CancellationToken cancellationToken)
        {
            await protocol.ReadStructBeginAsync(cancellationToken);
            var fields = await ReadFieldsAsync(cancellationToken);
            await protocol.ReadStructEndAsync(cancellationToken);
            return fields;
        }

        private async Task<Dictionary<string, object>> ReadMapAsync(CancellationToken cancellationToken)
        {
            var kvMap = new Dictionary<object, object>();
            TMap map = await protocol.ReadMapBeginAsync(cancellationToken);

            for (int i = 0; i < map.Count; i++)
            {
                object key = await ReadFieldValueAsync(map.KeyType, cancellationToken);
                object value = await ReadFieldValueAsync(map.ValueType, cancellationToken);
                kvMap[key] = value;
            }

            await protocol.ReadMapEndAsync(cancellationToken);

            return new Dictionary<string, object>
            {
                ["keyType"] = typeNameMap[map.KeyType],
                ["valueType"] = typeNameMap[map.ValueType],
                ["map"] = kvMap
            };
        }

        private async Task<Dictionary<string, object>> ReadSetAsync(CancellationToken cancellationToken)
        {
            var vSet = new HashSet<object>();
            TSet set = await protocol.ReadSetBeginAsync(cancellationToken);

            for (int i = 0; i < set.Count; i++)
            {
                if (set.ElementType == TType.Struct)
                {
                    vSet.Add((await ReadFieldValueAsync(set.ElementType, cancellationToken)).ToString());
                }
                else
                {
                    vSet.Add(await ReadFieldValueAsync(set.ElementType, cancellationToken));
                }
            }

            await protocol.ReadSetEndAsync(cancellationToken);

            return new Dictionary<string, object>
            {
                ["type"] = typeNameMap[set.ElementType],
                ["set"] = vSet
            };
        }

        private async Task<Dictionary<string, object>> ReadListAsync(CancellationToken cancellationToken)
        {
            var vList = new List<object>();
            TList list = await protocol.ReadListBeginAsync(cancellationToken);

            for (int i = 0; i < list.Count; i++)
            {
                vList.Add(await ReadFieldValueAsync(list.ElementType, cancellationToken));
            }

            await protocol.ReadListEndAsync(cancellationToken);

            return new Dictionary<string, object>
            {
                ["type"] = typeNameMap[list.ElementType],
                ["list"] = vList
            };
        }
    }
}
