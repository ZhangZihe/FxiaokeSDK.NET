# FxiaokeSDK.NET

## 纷享销客SDK - C#版本
- 该文档旨在帮助您快速接入纷享销客系统

## 第一步 配置您的开发者参数
- 方法一
    
    ```
    <appSettings>
      <add key="fxiaoke_appid" value="FSAID_1317cde" />
      <add key="fxiaoke_appsecret" value="1909c5c548244d36bdc93c6d293e4f8b" />
      <add key="fxiaoke_apppermanentcode" value="6FE4EAB36C49B0D8EFD57B18261932D4" />
    </appSettings>
    ```
 
- 方法二

    ```
    FxiaokeConfig.AppId = "FSAID_1317cde";
    FxiaokeConfig.AppSecret = "1909c5c548244d36bdc93c6d293e4f8b";
    FxiaokeConfig.PermanentCode ="6FE4EAB36C49B0D8EFD57B18261932D4";
    ```

## 第二步 开始您的开发之旅
- 方法一

    ```
    var client = new FxiaokeClient();
    var result = client.Execute(new CorpAccessTokenGetRequest());
    ```
- 方法二

    ```
    //适用于动态拼接参数
    var jsonParam = new JObject
    {
        ["corpAccessToken"] = "BED6379A56AF1C1026A8E422B810D31C",
        ["corpId"] = "FSCID_2C7B425CA79FC5B442013B1B43F4BFAC",
    };
    jsonParam["fetchChild"] = false;
    jsonParam["departmentId"] = 999999;

    var client = new FxiaokeClient();
    var result = client.Execute("/cgi/user/simpleList", jsonParam.ToString());
    ```
## 注意事项
- 命名规则: 接口模型字段命名均采用了C#常规的大驼峰法命名, 为了适配纷享接口的小驼峰命名, json序列化时采用了`CamelCasePropertyNamesContractResolver`进行规则转换, 由此带来了另一个问题, 接口中某些字段本身是首字母大写, 因为被转换了小驼峰而导致接口请求失败或结果异常, 这种问题可以采用以下解决方案处理:

    ```
    //正确的写法:
    Conditions = new JObject
    {
        ["UDSText1__C"] = "987654321"
    }
    
    //错误的写法:
    Conditions = new 
    {
        UDSText1__C = "987654321" //序列化时会被解析器转换为udsText1__C
    }
    ```
