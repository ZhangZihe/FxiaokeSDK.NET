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
- 调用

    ```
    var client = new FxiaokeClient();
    var result = client.Execute(new CorpAccessTokenGetRequest());
    ```
