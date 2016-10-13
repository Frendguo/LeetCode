
#不使用 ＋－×÷ 运算符来实现 加减乘除 四项运算

最近，在看《剑指Offer——名企面试官精讲典型编程题》一书，当看到“面试题47：不用加减乘除做加法”时，经过一分钟左右思考后，得出了思路，跟书上一对照，基本一致，呵呵O(∩_∩)O~。于是，随即又开始思考：加法是实现了，那么减法、乘法还有除法又该怎么实现呢？一番思考与分析后，得出算法，写出代码，测试通过，Happy！！\(^o^)/~

 接下来，就将我的算法与代码展示如下，还请有更好算法的牛人不吝赐教！！

 

#【1. 加法】

 因本人的算法与《剑指Offer——名企面试官精讲典型编程题》中一致，就不做赘述，而只贴出代码。

代码1.1 加法：计算a+b

int Add(int a, int b)
{
    int sum = a ^ b;
    int carry = a & b;
    while (carry != 0) {
        a = sum;
        b = carry << 1;
        sum = a ^ b;
        carry = a & b;
    }

    return sum;
}
#【2. 减法】

方案一：通过Add函数的实现

按常规思路，根据加减运算的互反性（即，减去一个数等于加上这个数的相反数），然后利用前面已实现的Add函数来进行实现。

按这个思路，我们首先要做到对一个整数取相反数，不能使用运算符“-”，那么就只能根据C++上两个互为相反数的int型数据的二进制结构关系——整数的相反数等于该数按位取反再加1，来设计如下的函数了。

代码2.1 取整数n的相反数

int OppositeNumber(int n)
{
    return Add(~n, 1);
}
然后就可以通过Add函数来实现减法了。

代码2.2 减法一：计算a-b

int Subtract(int a, int b)
{
    return Add(a, OppositeNumber(b));
}
毕竟是作为对思维开放的一个锻炼，所以对于直接的减法算法的思考还是值得的。于是就有了下面的方案二。

方案二：直接通过位操作实现减法

算法是得通过二进制位计算来实现的，所以在分析减法时从二进制减法计算的角度去考虑将更合适。那么，两个二进制形式整数的减法操作又是怎样进行的呢？

首先，如果减数为0，则被减数即为减法的结果，运算结束。
但如果减数不为0，我们可以先把被减数和减数上同为1的位从两个数上去除。至于如何分离出值同为1的位，则可以通过求位与操作来做到；而把这些1分别中被减数和减数中去除，则可以通过按位异或来的操作来实现。
经步骤1处理后，被减数和减数在对应的位上，将或者通为0，或者分别为0和1，却不会同为1。此时：
如果对应位被减数=1，而减数=0，则所得结果对应位也为1；
如果对应位被减数=0，而减数=1，则所得结果对应位还是1，但此时须向前一位借1；
即，通过被减数与减数作位异或的操作得到临时结果，和通过对减数左移一位得到需从临时结果中减去的借数。
于是，经过步骤2后，原来的减法变成了要求：临时结果 - 借数
很明显，只要以临时结果为被减数，借数为减数，重复步骤1~3即可。
上述步骤中，如果被减数或减数为负数，由负数的二进制位结构，可以保证上述步骤的处理仍适用，证明过程就请恕我在这里略去了。具体的实现代码如下。

代码2.3 减法二：计算a-b

int Subtract(int a, int b)
{
    while (b != 0) 
    {
        int sameBits = a & b;
        a ^= sameBits;
        b ^= sameBits;
        a |= b;
        b <<= 1;
    }

    return a;
}
※注：上述加法和减法中，按代码安全性，其实还应考虑计算后数据溢出的情况，这里我偷了下懒，省去了。不过下面的乘除法，我会提供包含了异常处理的代码。异常处理的方式，我采用了throw抛出的方式。

 #【3. 乘法】

为了方便对数据溢出的统一处理，在进行计算前，我先保存了被乘数与乘数的符号信息，并当被乘数或乘数为负时，利用上面的OppositeNumber函数，统一的转换为正整数（或0），然后再来进行乘法的运算。为了能同时适应32位和64位的整形数，在取符号信息与设置溢出判断位时，使用了以下的辅助宏和函数。

代码3.1 辅助宏与辅助函数

#define BITS_OF_ONE_BYTE     8
#define SIGN_BIT_FLAG_FOR_BYTE   0x80     // for signed byte/char

int SignBitFlagOfInt()
{
    static int signBitFlag = 0;

    static bool bIs1stCalled = true;
    if (bIs1stCalled)
    {
        int temp = SIGN_BIT_FLAG_FOR_BYTE;
        while (temp != 0) 
        {
            signBitFlag = temp;
            temp <<= BITS_OF_ONE_BYTE;
        }
        bIs1stCalled = false;
    }

    return signBitFlag;
}
乘法的算法。考虑到：

整数n乘以2k == n << k
C++中的任何一个非负int型数据都可以表示为如下的形式：
k0×20+k1×21+...+km×2m
的形式。（其中：ki∈{0, 1}, i∈{0, 1, ... , m}, 32位int型m = 30, 64位int型m = 62）
于是，就可以利用乘法分配率，通过循环累加，进行乘法的运算了。参考代码3.2。

代码3.2 乘法：计算a×b

int Multiply(int a, int b)
{
    int signStatA = a & SignBitFlagOfInt();
    if (signStatA != 0)
    {
        a = OppositeNumber(a);
    }

    int signStatB = b & SignBitFlagOfInt();
    if (signStatB != 0)
    {
        b = OppositeNumber(b);
    }

    int overFlowFlag = SignBitFlagOfInt(); // used for checking if the signed int data overflowed.
    int product = 0; // the result of |a| * |b|
    for (int curBitPos = 1; curBitPos != 0; curBitPos <<= 1)
    {
        if ((b & curBitPos) != 0)
        {
            product = Add(product, a);
            if (((a & overFlowFlag) != 0) 
                || ((product & overFlowFlag) != 0))
            {
                throw std::exception("The result data war overflowed.");
            }
        }
        a <<= 1;
    }

    return ((signStatA ^ signStatB) == 0) ? product : OppositeNumber(product);
}
#【4. 除法】

整数的除法，不同于乘法，除法所得的商的绝对值必然不大于被除数的绝对值，而所得余数的绝对值则必然小于除数的绝对值。所以，在设计除法函数的时候，无需考虑数据溢出的问题。但对于除法，却也有它自己的禁忌——除数不能为“0”。

为了处理的方便，准备工作同乘法一样，记录下被除数与除数的符号状态（比便在计算出结果后进行符号的调整），并当被除数或除数为负时，通过函数OppositeNumber将其转换为相反数。于是，接下来，我就只需考虑“非负整数（>=0）÷正整数（>0）”的情况了。对这种情况，计算过程如下：

预备工作：置商为0；
判断“被除数>=除数 ”是否成立：
成立，继续步骤3；
不成立，被除数的值赋给余数，计算结束。
备份除数，并设置商分子（一个临时变量，最终需加到商上面，故暂且如此命名）为1；
对商分子和除数同步向左移位，直到继续移位将大于被除数时为止；
从被除数上减去除数，并将商加上商分子。
通过备份的除数值还原除数，跳转到步骤2继续执行。
对应的代码参加代码4.1。

代码4.1 除法：计算a÷b 

int Divide(int a, int b, int * pRem /*= NULL*/)
{
    if (b == 0)
    {
        throw std::exception("Invalid divisor!! (The divisor can't be 0!)");
    }

    int signStatA = a & SignBitFlagOfInt();
    if (signStatA != 0)
    {
        a = OppositeNumber(a);
    }

    int signStatB = b & SignBitFlagOfInt();
    if (signStatB != 0)
    {
        b = OppositeNumber(b);
    }

    int quotient = 0;
    int backupB = b;
    while (a >= b) 
    {
        int tempB = b << 1;
        int tempQ = 1;
        while ((tempB <= a) && ((tempB & SignBitFlagOfInt()) == 0))
        {
            b = tempB;
            tempQ <<= 1;
            tempB <<= 1;
        }

        a = Subtract(a, b);
        quotient |= tempQ;
        b = backupB;
    }

    if (pRem != NULL)
    {
        *pRem = a;
    }

    if ((signStatA != 0) && (a != 0))
    {
        quotient = Add(quotient, 1);
        if (pRem != NULL)
        {
            *pRem = Subtract(b, *pRem);
        }
    }

    return ((signStatA ^ signStatB) == 0) ? quotient : OppositeNumber(quotient);
}