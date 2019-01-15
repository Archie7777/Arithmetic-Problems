![](https://raw.githubusercontent.com/Archie7777/Arithmetic-Problems/master/images/featherwallpaper.png)

<div align="center">
<h1> Arithmetic-Problems </h1>
<p>😚🍩😂🎉🌞🚖<p>
<p><strong> BIT软件工程结队项目 </strong></p>
</div>

## 项目结构

```bash
│  .gitignore
│  LICENSE
│  mathproblem.sln
│  README.md
│
└─mathproblem
    │  App.config
    │  Component.cs
    │  mathproblem.csproj
    │  mathproblem.csproj.user
    │  Number.cs
    │  Operation.cs
    │  Problem.cs
    │  Program.cs
    │
    ├─bin
    │  ├─Debug
    │  │      mathproblem.exe
    │  │      mathproblem.exe.config
    │  │      mathproblem.pdb
    │  │
    │  └─Release
    ├─obj
    │  └─Debug
    │      │  DesignTimeResolveAssemblyReferencesInput.cache
    │      │  mathproblem.csproj.CoreCompileInputs.cache
    │      │  mathproblem.csproj.FileListAbsolute.txt
    │      │  mathproblem.csprojAssemblyReference.cache
    │      │  mathproblem.exe
    │      │  mathproblem.pdb
    │      │  TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs
    │      │  TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs
    │      │  TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs
    │      │
    │      └─TempPE
    └─Properties
            AssemblyInfo.cs
```
### 目前完成情况：
可以生成给定数量的表达式。
命令：
```
./mathproblem -g 1000 [-h] [-c/-d]
```
不输入-h则默认生成最简单表达式，即只有两个整数和一个运算符。
输入-h则生成最多7个运算符，8个数字的表达式，且包括真分数。
-c 和 -d 控制乘方运算的输出格式，-c为 ‘ ^ ’，-h为 ‘ ** ’，若二者都不输入，则表达式中无乘方运算。
后两个方括号内指令不分顺序。
#### 以下为对应的命令和输出：
##### 命令1：
```
./mathproblem -g 5
```
##### 输出1：(5个最简单的表达式)
```
1 + 7 = 8
9 / 7 = 9/7
18 + 20 = 38
6 - 10 = -4
16 - 11 = 5
```
##### 命令2：
```
./mathproblem -g 5 -c
```
##### 输出2：(带乘方运算且输出格式为 ^ )
```
16 ^ 0 = 1
9 ^ 2 = 81
7 ^ 0 = 1
7 / 7 = 1
16 + 5 = 21
```
##### 命令3：
```
./mathproblem -g 5 -d
```
##### 输出3：(带乘方运算且输出格式为 ** )
```
1 + 2 = 3
16 ** 0 = 1
8 - 1 = 7
2 - 6 = -4
13 ** 1 = 13
```
##### 命令4：
```
./mathproblem -g 5 -h
```
##### 输出4：（带真分数且复杂的表达式）
```
1/3 - (3 * (3/2 / 4 ) ) = -19/24
0 * (1/2 - (2 - 5/2 ) ) = 0
2/7 * 7/6 = 1/3
7/8 + (2/5 * (5/3 + 5 ) ) = 85/24
3/10 + (1/8 - 7 ) = -263/40
```
##### 命令5：
```
./mathproblem -g 5 -h -c
```
##### 输出5：
```
1/8 / (2/5 / 3/4 ) = 15/64
(1/2 ^ 2 ) - 10/9 = -31/36
(0 + 3/2 ) ^ 1 = 3/2
6 + ((2/7 + 5/2 ) / (3/5 - 1 ) ) = -27/28
5/6 * (6/7 / 1 ) = 5/7
```
##### 命令6：
```
./mathproblem -g 5 -h -d
```
##### 输出6：
```
2/5 / (8 + 1/3 ) = 6/125
((0 * 2 ) ** 2 ) / 9 = 0
((2 - 5/8 ) - (8 + 0 ) ) ** 3 = -148877/512
((2/3 - 0 ) / 1/2 ) ** 3 = 64/27
(3/2 * 1 ) * ((2/3 - 1/4 ) / 1 ) = 5/8
```
