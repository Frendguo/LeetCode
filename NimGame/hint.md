#题目分析：

#原题：

You are playing the following Nim Game with your friend: 
There is a heap of stones on the table, each time one of you take turns to remove 1 to 3 stones. 
The one who removes the last stone will be the winner. You will take the first turn to remove the stones.

Both of you are very clever and have optimal strategies for the game. 
Write a function to determine whether you can win the game given the number of stones in the heap.

For example, if there are 4 stones in the heap, then you will never win the game:
 no matter 1, 2, or 3 stones you remove, the last stone will always be removed by your friend.

#大概题意：

一个玩石子的游戏，你先拿，一次只能拿[1,3]个石子，谁最后一次拿，谁就赢。
问：你能根据石子总数n，判断你是否能赢吗？

#解题思路：

首先，如果总数n等于4，那么一定会输。
类似的，如果总数为8，那么你也一定会输！因为不管你拿多少个石子，对方都能使剩余石子数为4.

类推下去，此题的拿石子问题就转变成了判断是否为4的倍数的问题。
