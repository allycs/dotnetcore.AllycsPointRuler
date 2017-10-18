# dotnetcore.AllycsPointRuler
配置xml的通用积分规则计算系统.netcore

-----------------------------------------------------码农不需要，割了-----------------------------------------------------

# 源码结构
> 方法主体（类库支持.netcore）：
>> AllycsPointRuler

> 项目样例：
>> DemoNancyDotnetCore（nancy的简单样例）

# xml配置参考（源码根目录BaseRuler.xml）

```
<?xml version="1.0" encoding="UTF-8"?>
<ROOT>
  <BASE_IN>
    <BASE>
      <ISONLY>FALSE</ISONLY>
      <WEIGHT>0</WEIGHT>
      <AMOUNT>20</AMOUNT>
      <POINT>1</POINT>
      <MULTIPLE>1</MULTIPLE>
      <PLUSORMINUS>TRUE</PLUSORMINUS>
    </BASE>
    <WEEK_2>
      <ISONLY>FALSE</ISONLY>
      <WEIGHT>0</WEIGHT>
      <AMOUNT>0</AMOUNT>
      <POINT>0</POINT>
      <MULTIPLE>2</MULTIPLE>
      <PLUSORMINUS>TRUE</PLUSORMINUS>
    </WEEK_2>
    <WEEK_5>
      <ISONLY>FALSE</ISONLY>
      <WEIGHT>0</WEIGHT>
      <AMOUNT>0</AMOUNT>
      <POINT>0</POINT>
      <MULTIPLE>3</MULTIPLE>
      <PLUSORMINUS>TRUE</PLUSORMINUS>
    </WEEK_5>
  </BASE_IN>
  <BASE_OUT>
    <BASE>
      <ISONLY>FALSE</ISONLY>
      <WEIGHT>0</WEIGHT>
      <AMOUNT>10</AMOUNT>
      <POINT>100</POINT>
      <MULTIPLE>1</MULTIPLE>
      <PLUSORMINUS>FALSE</PLUSORMINUS>
      <DEDUCTION>FALSE</DEDUCTION>
    </BASE>
  </BASE_OUT>
  <REG_IN>
    <BASE>
      <ISONLY>FALSE</ISONLY>
      <WEIGHT>0</WEIGHT>
      <AMOUNT>0</AMOUNT>
      <POINT>50</POINT>
      <MULTIPLE>1</MULTIPLE>
      <PLUSORMINUS>TRUE</PLUSORMINUS>
    </BASE>
  </REG_IN>
</ROOT>
```

# 可提供的功能
. 支持基础的
