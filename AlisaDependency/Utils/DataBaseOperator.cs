using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlisaDependency.DataTypes.Configs;
using AlisaDependency.DataTypes.Infos;
using SlpzLibrary;

namespace AlisaDependency.Utils
{
    public static class DataBaseOperator
    {
        public async static Task<GroupInfo> FindGroup(long num)
        {
            try
            {
                var values = new object[12];
                var temp = new GroupInfo(num);
                using (var connection = new MySqlConnection(GlobalConfigs.DataBaseConfig.OutConfig()))
                {
                    await connection.OpenAsync();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = $"select * from groupinfos WHERE num={num}";
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            await reader.ReadAsync();
                            if (reader.HasRows)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    values[i] = reader.GetValue(i);
                                }
                                return new GroupInfo(values);
                            }
                        }
                    }
                }
                await AddGroup(temp);
                Logger.Log($"收录新群聊信息\n{DataOperator.ToJsonString(temp)}", 0);
                return temp;
                //throw new Exception("指定的群组不存在");                
            }
            catch
            {
                throw;
            }
        }
        public async static Task AddGroup(GroupInfo info)
        {
            using (var connection = new MySqlConnection(GlobalConfigs.DataBaseConfig.OutConfig()))
            {
                await connection.OpenAsync();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = info.OutDbAddText();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public static async Task UpdateGroup(GroupInfo info)
        {
            try
            {
                using(var connection = new MySqlConnection(GlobalConfigs.DataBaseConfig.OutConfig()))
                {
                    await connection.OpenAsync();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = $"DELETE FROM groupinfos WHERE num = {info.num}";
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                await AddGroup(info);
                Logger.Log("更新群聊信息成功", 0);
            }
            catch
            {
                throw;
            }
        }
        public static async Task<MemberInfo> FindMember(long num)
        {
            try
            {
                var values = new object[11];
                var temp = new MemberInfo(num);
                using (var connection = new MySqlConnection(GlobalConfigs.DataBaseConfig.OutConfig()))
                {
                    await connection.OpenAsync();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = $"select * from memberinfos WHERE num={num}";
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            await reader.ReadAsync();
                            if (reader.HasRows)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    values[i] = reader.GetValue(i);
                                }
                                return new MemberInfo(values);
                            }
                        }
                    }
                }
                await AddMember(temp);
                Logger.Log($"收录新人员信息\n{DataOperator.ToJsonString(temp)}", 0);
                return temp;
            }
            catch
            {
                throw;
            }
        }
        public async static Task AddMember(MemberInfo info)
        {
            using (var connection = new MySqlConnection(GlobalConfigs.DataBaseConfig.OutConfig()))
            {
                await connection.OpenAsync();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = info.OutDbAddText();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public static async Task UpdateMember(MemberInfo info)
        {
            try
            {
                using (var connection = new MySqlConnection(GlobalConfigs.DataBaseConfig.OutConfig()))
                {
                    await connection.OpenAsync();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = $"DELETE FROM memberinfos WHERE num = {info.num}";
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                await AddMember(info);
                Logger.Log("更新群员信息成功", 0);
            }
            catch
            {
                throw;
            }
        }
    }
}
